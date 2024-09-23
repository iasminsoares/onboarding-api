using AutoMapper;
using IntegraApi.Application.Controllers;
using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Services;
using IntegraApi.Application.Domain.Services.Comunication;
using IntegraApi.Application.Dtos;
using IntegraApi.Application.Persistence.Context;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TotvsIntegra.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnboardingController(IOnboardingService OnboardingService, IMapper mapper) : BaseApiController
    {

        

        /// <summary>
        /// Lists all Onboarding.
        /// </summary>
        /// <returns>List of Onboardings.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OnboardingDto>), 200)]
        public async Task<IEnumerable<OnboardingDto>> ListAsync()
        {
            var result = await OnboardingService.ListAsync();
            return mapper.Map<IEnumerable<OnboardingDto>>(result);
        }

        /// <summary>
        /// Saves a new Onboarding.
        /// </summary>
        /// <param name="resource">Onboarding data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(OnboardingDto), 201)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> PostAsync([FromBody] OnboardingDto resource)
        {
            var entity = mapper.Map<Onboarding>(resource);
            var result = await OnboardingService.SaveAsync(entity);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<OnboardingDto>(result.Data!);
            return Ok(data);
        }

        /// <summary>
        /// Updates an existing Onboarding according to an identifier.
        /// </summary>
        /// <param name="id">Onboarding identifier.</param>
        /// <param name="resource">Updated Onboarding data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OnboardingDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] OnboardingDto resource)
        {
            var Onboarding = mapper.Map<Onboarding>(resource);
            var result = await OnboardingService.UpdateAsync(id, Onboarding);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<OnboardingDto>(result.Data!);
            return Ok(data);
        }

        /// <summary>
        /// Deletes a given Onboarding according to an identifier.
        /// </summary>
        /// <param name="id">Onboarding identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OnboardingDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await OnboardingService.DeleteAsync(id);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<OnboardingDto>(result.Data!);
            return Ok(data);
        }
    }
}
