import { Table } from 'antd';
import React from 'react';
import { MeterReading } from '../Services/EnsekTechnicalTestService';

export interface IMeterReadingListProps {
    meterReadings: MeterReading[]
}

function MeterReadingList(
    {
        meterReadings,
    }: IMeterReadingListProps
) {
    var columns = [
        {
            title: 'Account ID',
            dataIndex: 'accountId',
            key: 'accountId'
        },
        {
            title: 'Reading Date',
            dataIndex: 'meterReadingDateTime',
            key: 'meterReadingDateTime'
        },
        {
            title: 'Reading Value',
            dataIndex: 'meterReadValue',
            key: 'meterReadValue'
        },
    ]

    return (
        <Table
            dataSource={meterReadings}
            columns={columns}
        />
    );
}

export default MeterReadingList;