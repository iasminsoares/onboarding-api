using AutoMapper;
using Castle.Core.Resource;
using IntegraApi.Application.Controllers;
using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Services;
using IntegraApi.Application.Domain.Services.Comunication;
using IntegraApi.Application.Dtos;
using IntegraApi.Application.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TotvsIntegra.Application.Controllers
{
   
    public class AtividadesController(IAtividadeService AtividadeService, IMapper mapper) : BaseApiController
    {
        //private readonly IMapper _mapper;
        //private readonly IAtividadeService _atividadeService;

        //public AtividadesController(IAtividadeService AtividadeService, IMapper mapper)
        //{
        //   _mapper = mapper;
        //    _atividadeService = AtividadeService;
        //}



        /// <summary>
        /// Lists all atividades.
        /// </summary>
        /// <returns>List of atividades.</returns>
        [HttpGet]
        [Route("GetOptions")]
        public async Task<IActionResult> GetOptions()
        {
            var options = await AtividadeService.GetOptions();
            return Ok(options);
        }

        /// <summary>
        /// Lists all Atividade.
        /// </summary>
        /// <returns>List of Atividades.</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AtividadeDto>), 200)]
        public async Task<IEnumerable<AtividadeDto>> ListAsync()
        {
            var result = await AtividadeService.ListAsync();
            return mapper.Map<IEnumerable<AtividadeDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AtividadeDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> RetornaAtividadePorId(Guid id)
        {
            var result = await AtividadeService.GetByIdAsync(id);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<AtividadeDto>(result.Data!);
            return Ok(data);
        }


        /// <summary>
        /// Adiciona uma atividade ao banco de dados
        /// </summary>
        /// <param name="atividadeDto">Obj com os campos necessários para a criação da atividade.</param>
        /// <returns>IActionResult</returns>
        /// <response code="201"> Caso a inserção seja feita com sucesso.</response>
        [HttpPost]
        [ProducesResponseType(typeof(AtividadeDto), 201)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> PostAsync([FromBody] AtividadeDto resource)
        {
            resource.CriadoPor = "Iasmin";
            resource.AlteradoPor = "Iasmin";
            resource.DataCriacao = DateTime.Now;
            resource.UltimaAlteracao = DateTime.Now;
            var entity = mapper.Map<Atividade>(resource);
            var result = await AtividadeService.SaveAsync(entity);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<AtividadeDto>(result.Data!);
            return Ok(data);
        }

        /// <summary>
		/// Updates an existing Atividade according to an identifier.
		/// </summary>
		/// <param name="id">Atividade identifier.</param>
		/// <param name="resource">Updated Atividade data.</param>
		/// <returns>Response for the request.</returns>
		[HttpPut("{id}")]
        [ProducesResponseType(typeof(AtividadeDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] AtividadeDto resource)
        {
            var Atividade = mapper.Map<Atividade>(resource);
            var result = await AtividadeService.UpdateAsync(id, Atividade);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<AtividadeDto>(result.Data!);
            return Ok(data);
        }

        
        /// <summary>
		/// Deletes a given Atividade according to an identifier.
		/// </summary>
		/// <param name="id">Atividade identifier.</param>
		/// <returns>Response for the request.</returns>
		[HttpDelete("{id}")]
        [ProducesResponseType(typeof(AtividadeDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await AtividadeService.DeleteAsync(id);

            if (result._message != null)
            {
                result._message.code = HttpStatusCode.BadRequest.ToString();
                return BadRequest(result._message);
            }

            var data = mapper.Map<AtividadeDto>(result.Data!);
            return Ok(data);
        }

        //[HttpGet]
        //public IEnumerable<ReadAtividadeDto> RetornaAtividades([FromQuery]int skip = 0, [FromQuery] int take = 10) //paginacao
        //{
        //    return _mapper.Map<List<ReadAtividadeDto>>(_context.Atividades.Skip(skip).Take(take));
        //}


       
        //[HttpPut("{id}")] // Atualizada o objeto todo
        //public IActionResult AtualizaAtividadePorId(int id, [FromBody] UpdateAtividadeDto atividadeDto)
        //{
        //    var atividade = _context.Atividades.FirstOrDefault(atividade => atividade.CodAtividade == id);

        //    if (atividade == null) return NotFound();

        //    _mapper.Map(atividadeDto, atividade);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        //[HttpPatch("{id}")] // Atualizada apenas um campo do objeto
        //public IActionResult AtualizaParcialAtividadePorId(int id, JsonPatchDocument< UpdateAtividadeDto> patch)
        //{
        //    var atividade = _context.Atividades.FirstOrDefault(atividade => atividade.CodAtividade == id);

        //    if (atividade == null) return NotFound();

        //    var atividadeParaAtualizar = _mapper.Map<UpdateAtividadeDto>(atividade);

        //    patch.ApplyTo(atividadeParaAtualizar, ModelState);

        //    if (!TryValidateModel(atividadeParaAtualizar)) return ValidationProblem(ModelState);

        //    _mapper.Map(atividadeParaAtualizar, atividade);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}
