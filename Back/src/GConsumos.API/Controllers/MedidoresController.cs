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
    public class MedidoresController : Controller
    {
        private readonly IMedidoresService _medidoresService;
        
        public MedidoresController(IMedidoresService medidoresService)
        {
            _medidoresService = medidoresService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var medidores = await _medidoresService.GetAllMedidoresAsync();
                if(medidores == null) return NoContent();

                return Ok(medidores);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar recuperar medidores. Erro: {ex.Message} ");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var medidor = await _medidoresService.GetMedidorByIdAsync(id);
                if(medidor == null) return NoContent();

                return Ok(medidor);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar recuperar medidor. Erro: {ex.Message} ");
            }
        }

         [HttpGet("{medidor}/medidor")]
        public async Task<IActionResult> GetByMedidor(string medidor)
        {
            try
            {
                var medidores = await _medidoresService.GetAllMedidoresByMedidorAsync(medidor);
                if(medidores == null) return NoContent();

                return Ok(medidores);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar recuperar medidor. Erro: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedidorDto model)
        {
            try
            {
                var medidor = await _medidoresService.AddMedidor(model);
                if(medidor == null) return NoContent();

                return Ok(medidor);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar adicionar medidor. Erro: {ex.Message} ");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MedidorDto model)
        {
            try
            {
                var medidor = await _medidoresService.UpdateMedidor(id, model);
                if(medidor == null) return NoContent();

                return Ok(medidor);
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar atualizar medidor. Erro: {ex.Message} ");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(int id)
        {
            try
            {
                var medidor = await _medidoresService.GetMedidorByIdAsync(id);
                if(medidor == null) return NoContent();

                return await _medidoresService.DeleteMedidor(id)?
                    Ok("Deletado") :
                    throw new Exception("Ocorreu um problema não específico ao tentar deletar medidor");
                 
            }
            catch (Exception ex)
            {  
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar deletar medidor. Erro: {ex.Message} ");
            }
        }

    }
}