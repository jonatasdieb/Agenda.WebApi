using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Services;
using Agenda.WebApi.Helpers;
using Agenda.WebApi.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Agenda.WebApiControllers
{
    [RoutePrefix("Pessoa")]
    public class PessoaController : ApiController
    {
        private readonly IPessoaService _pessoaService;
        private readonly IPessoaMarcadorService _pessoaMarcadorService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService service, IPessoaMarcadorService pessoaMarcadorService, IMapper mapper)
        {
            _mapper = mapper;
            _pessoaService = service;
            _pessoaMarcadorService = pessoaMarcadorService;
        }
        
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {            
            try
            {
                var pessoas = _pessoaService.Get();
                var pessoaVM = _mapper.Map<IEnumerable<PessoaViewModel>>(pessoas);  
               
                return Json(pessoaVM);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var pessoa = _pessoaService.GetById(id);
                PessoaViewModel pessoaVM = _mapper.Map<PessoaViewModel>(pessoa);
              
                return Json(pessoaVM);
            }
            catch (Exception e)
            {                
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

        [HttpGet]
        [Route("GetMarcadores")]
        public IHttpActionResult GetMarcadores()
        {
            try
            {
                var marcadores = _pessoaMarcadorService.Get();
                var marcadoresVM = _mapper.Map<IEnumerable<PessoaMarcadorViewModel>>(marcadores);

                return Json(marcadoresVM);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(PessoaViewModel pessoaVM)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaVM);

            try
            {
                _pessoaService.Create(pessoa);
                return Content(HttpStatusCode.OK, "Registro criado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao cadastrar: " + e.Message);
            }
        }


        [HttpPut] 
        [Route("")]
        public IHttpActionResult Update(PessoaViewModel pessoaVM)
        {           

            if (!ModelState.IsValid)
            {                
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaVM);

            try
            {
                _pessoaService.Update(pessoa);                
                return Content(HttpStatusCode.OK, "Registro atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao atualizar: " + e.Message);
            }
        }    
       
        [HttpDelete]      
        public IHttpActionResult Delete(PessoaViewModel pessoaVM)
        {
            var pessoa = _pessoaService.GetById(pessoaVM.Id);

            try
            {                
                _pessoaService.Remove(pessoa);                
                return Content(HttpStatusCode.OK, "Registro deletado com sucesso.");
            }
            catch (Exception e)
            {                
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

    }
}
