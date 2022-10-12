import React, { useEffect, useMemo, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import 'antd/dist/antd.css';
import { Account, EnsekTechnicalTestService, MeterReading, ProcessResponse } from './Services/EnsekTechnicalTestService';
import { Button, Col, Row } from 'antd';
import AccountList from './Components/AccountList';
import MeterReadingList from './Components/MeterReadingList';
import { RcFile } from 'antd/lib/upload';
import UploadMeterReadings from './Components/UploadMeterReadings';
import UploadMeterReadingsResults from './Components/UploadMeterReadingsResults';

function App() {
    var service = useMemo(() => new EnsekTechnicalTestService(), [])
    var [accountsState, setsAccountState] = useState<Array<Account>>([])
    var [meterReadingsForAccountState, setMeterReadingsForAccountState] = useState<Array<MeterReading>>([])
    var [uploadResultState, setUploadResultState] = useState<ProcessResponse | null>(null)
    var [selectedAccountState, setSelectedAccountState] = useState<Account | null>(null)

    useEffect(() => {
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

    var handleAccountRowClick = (account: Account) => {
        setSelectedAccountState(account)
    }

    var handleUpload = (file: RcFile): boolean => {
        const sendFile = async (file: File) => {
            var response = await service.uploadMeterReadings(file)

            setUploadResultState(response.value)
        }

        sendFile(file)
        return true
    }

    return (
        <>
            <Row>
                <Col span={18}>
                    <h1>ENSEK TECHNICAL TEST</h1>
                </Col>
            </Row>
            <Row>
                <Col span={6}>
                    <UploadMeterReadings beforeUpload={handleUpload} />
                </Col>
                <Col span={6}>
                    <UploadMeterReadingsResults result={uploadResultState} />
                </Col>
            </Row>
            <Row>
                <Col span={24}>
                    <AccountList accounts={accountsState} onRowClick={handleAccountRowClick}/>
                </Col>
            </Row>
            <Row>
                <Col span={24}>
                    <MeterReadingList meterReadings={meterReadingsForAccountState} />
                </Col>
            </Row>
        </>
    );
}

export default App;
