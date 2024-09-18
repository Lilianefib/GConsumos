using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GConsumos.Application.Contratos;
using GConsumos.Application.Dtos;
using GConsumos.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GConsumos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoradoresController : Controller
    {
        private readonly IMoradoresService _moradoresService;
        
        public MoradoresController(IMoradoresService moradoresService)
        {
            _moradoresService = moradoresService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var moradores = await _moradoresService.GetAllMoradoresAsync();
                if(moradores == null) return NoContent();

                return Ok(moradores);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar recuperar moradores. Erro: {ex.Message} ");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var morador = await _moradoresService.GetMoradorByIdAsync(id);
                if(morador == null) return NoContent();

                return Ok(morador);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar recuperar morador. Erro: {ex.Message} ");
            }
        }

         [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var moradores = await _moradoresService.GetAllMoradorByNomeAsync(nome);
                if(moradores == null) return NoContent();

                return Ok(moradores);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar recuperar morador. Erro: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MoradorDto model)
        {
            try
            {
                var morador = await _moradoresService.AddMorador(model);
                if(morador == null) return NoContent();

                return Ok(morador);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar adicionar morador. Erro: {ex.Message} ");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MoradorDto model)
        {
            try
            {
                var morador = await _moradoresService.UpdateMorador(id, model);
                if(morador == null) return NoContent();

                return Ok(morador);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar atualizar morador. Erro: {ex.Message} ");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(int id)
        {
            try
            {
                var morador = await _moradoresService.GetMoradorByIdAsync(id);
                if(morador == null) return NoContent();

                return await _moradoresService.DeleteMorador(id)?
                    Ok("Deletado") :
                    throw new Exception("Ocorreu um problema não específico ao tentar deletar Morador");
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar deletar morador. Erro: {ex.Message} ");
            }
        }

    }
}