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
    public class MoradoresService : IMoradoresService
    {
        private readonly IMoradorPersist _moradorPersist;
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        public MoradoresService(IMoradorPersist moradorPersist, 
                                IGeralPersist geralPersist,
                                IMapper mapper)
        {
            _moradorPersist = moradorPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
            
        }
        public async Task<MoradorDto> AddMorador(MoradorDto model)
        {
            try
            {
                var morador = _mapper.Map<Morador>(model);

                 _geralPersist.Add<Morador>(morador);
                 if(await _geralPersist.SaveChangeAsync())
                 {
                    var moradorRetorno = await _moradorPersist.GetMoradorByIdAsync(morador.Id);

                    return _mapper.Map<MoradorDto>(moradorRetorno);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<MoradorDto> UpdateMorador(int moradorId, MoradorDto model)
        {
            try
            {
                 var morador = await _moradorPersist.GetMoradorByIdAsync(moradorId);
                 if(morador == null) return null;

                 model.Id = morador.Id;

                 _mapper.Map(model, morador);

                 _geralPersist.Update(morador);

                 if(await _geralPersist.SaveChangeAsync())
                 {
                    var moradorRetorno = await _moradorPersist.GetMoradorByIdAsync(moradorId);
                    return _mapper.Map<MoradorDto>(moradorRetorno);
                 }
                 return null;

            }
            catch (Exception ex)
            {               
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteMorador(int moradorId)
        {
            var morador = await _moradorPersist.GetMoradorByIdAsync(moradorId);
            if(morador == null) throw new Exception("Morador para delete não encontrado.");

            _geralPersist.Delete(morador);

            return await _geralPersist.SaveChangeAsync();
        }

        public async Task<MoradorDto[]> GetAllMoradoresAsync()
        {
            try
            {
                var moradores = await _moradorPersist.GetAllMoradoresAsync();
                if(moradores == null) return null;

                var resultado = _mapper.Map<MoradorDto[]>(moradores);

                return resultado;
                 
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<MoradorDto> GetMoradorByIdAsync(int MoradorId)
        {
            try
            {
                 var morador = await _moradorPersist.GetMoradorByIdAsync(MoradorId);
                 if(morador == null) return null;

                 var resultado = _mapper.Map<MoradorDto>(morador);

                 return resultado;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<MoradorDto[]> GetAllMoradorByNomeAsync(string nome)
        {
            try
            {
                 var moradores = await _moradorPersist.GetAllMoradorByNomeAsync(nome);
                 if(moradores == null) return null;

                 var resultado = _mapper.Map<MoradorDto[]>(moradores);

                 return resultado;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


       
    }
}