import { Button, Upload } from 'antd';
import { RcFile } from 'antd/lib/upload'
import React from 'react';

export interface IUploadMeterReadingsProps {
    beforeUpload: (file: RcFile) => boolean
}

function UploadMeterReadings({
    beforeUpload
}: IUploadMeterReadingsProps) {
    return (
        <Upload
            beforeUpload={beforeUpload}
            accept='.csv'
        >
            <Button>Upload Meter Readings</Button>
        </Upload>
  );
}

export default UploadMeterReadings;