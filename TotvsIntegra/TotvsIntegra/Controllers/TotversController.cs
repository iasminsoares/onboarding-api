﻿using AutoMapper;
using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Services;
using IntegraApi.Application.Domain.Services.Comunication;
using IntegraApi.Application.Dtos;
using IntegraApi.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegraApi.Application.Controllers
{
    public class TotversController(ITotverService TotverService, IMapper mapper) : BaseApiController
    {
        /// <summary>
        /// Lists all Totver.
        /// </summary>
        /// <returns>List of Totvers.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TotverDto>), 200)]
        public async Task<IEnumerable<TotverDto>> ListAsync()
        {
            var result = await TotverService.ListAsync();
            return mapper.Map<IEnumerable<TotverDto>>(result);
        }

        /// <summary>
        /// Lists all totvers.
        /// </summary>
        /// <returns>List of atividades.</returns>
        [HttpGet]
        [Route("GetOptions")]
        public async Task<IActionResult> GetOptions()
        {
            var options = await TotverService.GetOptions();
            return Ok(options);
        }

        /// <summary>
        /// Saves a new Totver.
        /// </summary>
        /// <param name="resource">Totver data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TotverDto), 201)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> PostAsync([FromBody] TotverDto resource)
        {

            resource.CriadoPor = "Iasmin";
            resource.AlteradoPor = "Iasmin";
            resource.DataCriacao = DateTime.Now;
            resource.UltimaAlteracao = DateTime.Now;
            resource.UsuarioRede = "Iasmin";


            var entity = mapper.Map<Totver>(resource);
            var result = await TotverService.SaveAsync(entity);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<TotverDto>(result.Data!);
            return Ok(data);
        }

        /// <summary>
        /// Updates an existing Totver according to an identifier.
        /// </summary>
        /// <param name="id">Totver identifier.</param>
        /// <param name="resource">Updated Totver data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TotverDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] TotverDto resource)
        {
            var totver = mapper.Map<Totver>(resource);
            var result = await TotverService.UpdateAsync(id, totver);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<TotverDto>(result.Data!);
            return Ok(data);
        }

        /// <summary>
        /// Deletes a given Totver according to an identifier.
        /// </summary>
        /// <param name="id">Totver identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TotverDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await TotverService.DeleteAsync(id);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<TotverDto>(result.Data!);
            return Ok(data);
        }
    }
}
