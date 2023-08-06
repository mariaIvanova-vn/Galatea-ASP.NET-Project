using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galatea.WebAPI.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IPublicationService publicationService;

        public StatisticsApiController(IPublicationService publicationService)
        {
            this.publicationService = publicationService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                StatisticsServiceModel serviceModel =
                    await publicationService.GetStatisticsAsync();

                return Ok(serviceModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
