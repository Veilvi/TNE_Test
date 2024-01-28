using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNE_Test.DTO.MeasurementPoints;
using TNE_Test.Exceptions;
using TNE_Test.Services;

/*
 * В боевых проектах не все делается как здесь. Но требуемые задачи выполняются в данном коде.
 * 
 * Для мапинга моделей и DTO на больших таблицах лучше использовать automapper, но не так много полей, поэтому сделал через explicit operator.
 * 
 * По хорошему, связные данные не выдаются в виде дополнительных подобъектов.
 * Опционально по параметрам выдаются id связных объектов. Связные объекты запрашиваются по id отдельным запросом.
 */
namespace HttpsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TneController : ControllerBase
    {
        private readonly ILogger<TneController> _logger;
        private readonly ITneServices _service;
        private readonly DbContext Context;

        public TneController(ILogger<TneController> logger, ITneServices service, DbContext context)
        {
            _logger = logger;
            _service = service;
            Context = context;
        }
        [HttpPost("generateData")]
        public async Task<IActionResult> GenerateData() // Пока здесь инициализирую данные
        {
            try
            {
                 await _service.GenerateData();
                return Ok("Данные сгенерированы");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("measurement_points/{objOfConsumptionId}")]
        public async Task<IActionResult> CreateNewMeasurementPoint(long objOfConsumptionId, MeasurementPointCreateDto dto)
        {
            try
            {
                await _service.CreateNewMeasurementPoint(objOfConsumptionId, dto);
                return StatusCode(200, "Точка измерения успешно добавлена");
            }
            catch (ItemNotFoundException)
            {
                return StatusCode(404, "Объект потребления не найден");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("calculation_meters")]
        public async Task<IActionResult> GetAllCalculationMeters(int year)
        {
            try
            {
               var result=await _service.GetAllCalculationMeters(year);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("energy_meters")]
        public async Task<IActionResult> GetExpiredEnergyMetersByObjectId(long objId)
        {
            try
            {
                var result=await _service.GetExpiredEnergyMetersByObjectId(objId);
                return StatusCode(200, result);
            }
            catch (ItemNotFoundException)
            {
                return StatusCode(404, "Объект потребления не найден");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("current_transformers")]
        public async Task<IActionResult> GetExpiredCurrentTransformersByObjectId(long objId)
        {
            try
            {
                var result=await _service.GetExpiredCurrentTransformersByObjectId(objId);
                return StatusCode(200, result);
            }
            catch (ItemNotFoundException)
            {
                return StatusCode(404, "Объект потребления не найден");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("voltage_transformers")]
        public async Task<IActionResult> GetExpiredVoltageTransformersByObjectId(long objId)
        {
            try
            {
                var result=await _service.GetExpiredVoltageTransformersByObjectId(objId);
                return StatusCode(200, result);
            }
            catch (ItemNotFoundException)
            {
                return StatusCode(404, "Объект потребления не найден");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
      
    }
}
