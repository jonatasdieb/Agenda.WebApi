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
    [RoutePrefix("Contato")]
    public class ContatoController : ApiController
    {
        private readonly IContatoService _contatoService;
        private readonly IContatoTipoService _contatoTipoService;
        private readonly IMapper _mapper;

        public ContatoController(IContatoService service, IContatoTipoService contatoTipoService, IMapper mapper)
        {
            _mapper = mapper;
            _contatoService = service;
            _contatoTipoService = contatoTipoService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var contatos = _contatoService.Get();
                var contatoVM = _mapper.Map<IEnumerable<ContatoViewModel>>(contatos);

                return Json(contatoVM);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTipos()
        {
            try
            {
                var tipos = _contatoTipoService.Get();
                var tiposVM = _mapper.Map<ContatoTipoViewModel>(tipos);

                return Json(tiposVM);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(ContatoViewModel contatoVM)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            var contato = _mapper.Map<Contato>(contatoVM);

            try
            {
                _contatoService.Create(contato);
                return Content(HttpStatusCode.OK, "Registro criado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao cadastrar: " + e.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(ContatoViewModel contatoVM)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            var contato = _mapper.Map<Contato>(contatoVM);

            try
            {
                _contatoService.Update(contato);
                return Content(HttpStatusCode.OK, "Registro atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao atualizar: " + e.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(ContatoViewModel contatoVM)
        {
            var contato = _contatoService.GetById(contatoVM.Id);

            try
            {
                _contatoService.Remove(contato);
                return Content(HttpStatusCode.OK, "Registro deletado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

    }
}
