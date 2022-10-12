import { Table } from 'antd';
import React from 'react';
import { Account } from '../Services/EnsekTechnicalTestService';

export interface IAccountsListProps {
    accounts: Account[]
}

function AccountList(
    {
        accounts,
    }: IAccountsListProps
) {
    var columns = [
        {
            title: 'Account ID',
            dataIndex: 'accountId',
            key: 'accountId'
        },
        {
            title: 'First Name',
            dataIndex: 'firstName',
            key: 'firstName'
        },
        {
            title: 'Last Name',
            dataIndex: 'lastName',
            key: 'lastName'
        },
    ]

    return (
        <Table
            dataSource={accounts}
            columns={columns}
        />
    );
}

export default AccountList;