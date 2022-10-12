import axios from 'axios'
import config from './../Config/config.json'

export class EnsekTechnicalTestService {

    public async getAccounts(): Promise<ApiResponse<Array<Account>>> {
        const response = await axios.get(`${config.EnsekTechnicalTestServiceUrl}/api/Account`)
        return await response.data
    }

    public async getAccount(accountId: number): Promise<ApiResponse<Account>> {
        const response = await axios.get(`${config.EnsekTechnicalTestServiceUrl}/api/Account/${accountId}`)
        return await response.data
    }

    public async getMeterReadings(): Promise<ApiResponse<Array<MeterReading>>> {
        const response = await axios.get(`${config.EnsekTechnicalTestServiceUrl}/api/MeterReading`)
        return await response.data
    }

    public async getAccountsMeterReadings(accountId: number): Promise<ApiResponse<Array<MeterReading>>> {
        const response = await axios.get(`${config.EnsekTechnicalTestServiceUrl}/api/MeterReading/account/${accountId}`)
        return await response.data
    }


    public async uploadMeterReadings(file: File): Promise<ApiResponse<ProcessResponse>> {
        let formData = new FormData();
        formData.append('formFile', file);

        const response = await axios.put(`${config.EnsekTechnicalTestServiceUrl}/api/MeterReading/upload-meter-readings`, formData)
        return await response.data
    }

}

export type ApiResponse<T> = {
    success: boolean,
    error: string,
    value: T
}

export type Account = {
    accountId: number,
    firstName: string,
    lastName: string
}

export type MeterReading = {
    id: number,
    accountId: number,
    meterReadingDateTime: Date,
    meterReadValue: string
}

export type ProcessResponse = {
    totalLines: number,
    linesSaved: number,
    linesFailed: number
}