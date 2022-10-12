import React, { useEffect, useMemo, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import 'antd/dist/antd.css';
import { Account, EnsekTechnicalTestService, MeterReading } from './Services/EnsekTechnicalTestService';
import { Col, Row } from 'antd';
import AccountList from './Components/AccountList';
import MeterReadingList from './Components/MeterReadingList';

function App() {
    var service = useMemo(() => new EnsekTechnicalTestService(), [])
    var [accountsState, setsAccountState] = useState<Array<Account>>([])
    var [meterReadingsForAccountState, setMeterReadingsForAccountState] = useState<Array<MeterReading>>([])
    var [selectedAccountState, setSelectedAccountState] = useState<Account | null>(null)


    var accounts = useMemo(() => {
        var fetchData = async () => {
            var result = await service.getAccounts()
            setsAccountState(result.value)
        }
        fetchData()
    }, [service])

    useEffect(() => {
        var fetchData = async (accountId: number) => {
            var result = await service.getAccountsMeterReadings(accountId)
            setMeterReadingsForAccountState(result.value)
        }
        if (selectedAccountState != null) {
            fetchData(selectedAccountState.accountId)
        }
    }, [selectedAccountState, service])


    return (
        <>
            <Row>
                <Col>
                    <AccountList accounts={accountsState} />
                </Col>
            </Row>
            <Row>
                <Col>
                    <MeterReadingList meterReadings={meterReadingsForAccountState} />
                </Col>
            </Row>
        </>
    );
}

export default App;
