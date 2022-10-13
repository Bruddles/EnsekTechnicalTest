import { Button, Upload } from 'antd';
import { RcFile } from 'antd/lib/upload'
import React from 'react';
import { ProcessResult } from '../Services/EnsekTechnicalTestService';

export interface IUploadMeterReadingsResultsProps {
    result: ProcessResult | null
}

function UploadMeterReadingsResults({
    result
}: IUploadMeterReadingsResultsProps) {
    return (
        result == null
            ? <p>No Upload File has been processed</p>
            : <p>Upload Results: Saved lines {result.linesSaved}, Failed Lines: {result.linesFailed}</p>
  );
}

export default UploadMeterReadingsResults;