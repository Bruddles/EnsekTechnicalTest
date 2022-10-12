import { Table } from 'antd';
import React from 'react';
import { Account } from '../Services/EnsekTechnicalTestService';

export interface IAccountsListProps {
    accounts: Account[]
    onRowClick: (record: Account) => void
}

function AccountList(
    {
        accounts,
        onRowClick,
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

    const mapAccounts = (accounts: Account[]) => accounts.map(a => ({ key: a.accountId, ...a }))

    var tableData = mapAccounts(accounts)

    return (
        <Table
            dataSource={tableData}
            columns={columns}
            rowSelection={{
                type: 'radio',
                onChange: (selectedRowKeys: React.Key[], selectedRows: Account[]) => {
                    onRowClick(selectedRows[0])
                }
            } }
        />
    );
}

export default AccountList;