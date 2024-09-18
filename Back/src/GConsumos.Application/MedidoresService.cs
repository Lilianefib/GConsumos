using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GConsumos.Application.Contratos;
using GConsumos.Application.Dtos;
using GConsumos.Domain;
using GConsumos.Persistence.Contratos;

namespace GConsumos.Application
{
    public class MedidoresService : IMedidoresService
    {
        private readonly IMedidorPersist _medidorPersist;
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        public MedidoresService(IMedidorPersist medidorPersist, 
                                IGeralPersist geralPersist,
                                IMapper mapper)
        {
            _medidorPersist = medidorPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
            
        }
        public async Task<MedidorDto> AddMedidor(MedidorDto model)
        {
            try
            {
                var medidor = _mapper.Map<Medidor>(model);

                 _geralPersist.Add<Medidor>(medidor);
                 if(await _geralPersist.SaveChangeAsync())
                 {
                    var medidorRetorno = await _medidorPersist.GetMedidorByIdAsync(medidor.Id);

                    return _mapper.Map<MedidorDto>(medidorRetorno);
                 }
                 return null; 
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<MedidorDto> UpdateMedidor(int medidorId, MedidorDto model)
        {
            try
            {
                 var medidor = await _medidorPersist.GetMedidorByIdAsync(medidorId);
                 if(medidor == null) return null;

                 model.Id = medidor.Id;

                 _mapper.Map(model, medidor);

                 _geralPersist.Update(medidor);

                 if(await _geralPersist.SaveChangeAsync())
                 {
                    var medidorRetorno = await _medidorPersist.GetMedidorByIdAsync(medidorId);
                    return _mapper.Map<MedidorDto>(medidorRetorno);
                 }
                 return null;

            }
            catch (Exception ex)
            {               
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteMedidor(int medidorId)
        {
            var medidor = await _medidorPersist.GetMedidorByIdAsync(medidorId);
            if(medidor == null) throw new Exception("Medidor para delete não encontrado.");

            _geralPersist.Delete(medidor);

            return await _geralPersist.SaveChangeAsync();
        }

        public async Task<MedidorDto[]> GetAllMedidoresAsync()
        {
            try
            {
                var medidores = await _medidorPersist.GetAllMedidoresAsync();
                if(medidores == null) return null;

                var resultado = _mapper.Map<MedidorDto[]>(medidores);

                return resultado;
                 
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<MedidorDto> GetMedidorByIdAsync(int MedidorId)
        {
            try
            {
                 var medidor = await _medidorPersist.GetMedidorByIdAsync(MedidorId);
                 if(medidor == null) return null;

                 var resultado = _mapper.Map<MedidorDto>(medidor);

                 return resultado;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<MedidorDto[]> GetAllMedidoresByMedidorAsync(string medidor)
        {
            try
            {
                 var medidores = await _medidorPersist.GetAllMedidoresByMedidorAsync(medidor);
                 if(medidores == null) return null; 

                 var resultado = _mapper.Map<MedidorDto[]>(medidores);

                 return resultado;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


       
    }
}