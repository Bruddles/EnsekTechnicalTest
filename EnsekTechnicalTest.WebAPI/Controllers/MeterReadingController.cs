using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Models.Database;
using EnsekTechnicalTest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnsekTechnicalTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        private readonly IMeterReadingService _service;

        public MeterReadingController(IMeterReadingService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ApiResponse<List<MeterReading>>> GetAll()
        {
            var readings = await _service.GetAll();

            if (readings == null)
            {
                return new ApiResponse<List<MeterReading>>
                {
                    Success = false,
                    Error = "Failed to get Meter Readings"
                };
            }

            return new ApiResponse<List<MeterReading>>
            {
                Success = true,
                Value = readings,
            };
        }

        [HttpGet("account/{accountId}")]
        public async Task<ApiResponse<List<MeterReading>>> GetByAccountId(int accountId)
        {
            var readings = await _service.GetByAccountId(accountId);

            if (readings == null)
            {
                return new ApiResponse<List<MeterReading>>
                {
                    Success = false,
                    Error = "Failed to get Meter Readings"
                };
            }

            return new ApiResponse<List<MeterReading>>
            {
                Success = true,
                Value = readings,
            };
        }

        [HttpPost("/meter-reading-uploads")]
        public async Task<ApiResponse<ProcessResponse>> Upload([FromForm]IFormFile formFile)
        {
            var uploadFileStream = formFile.OpenReadStream();

            var result = await _service.Process(uploadFileStream);

            return new ApiResponse<ProcessResponse>
            {
                Success = true,
                Value = result
            };
        }
    }
}
