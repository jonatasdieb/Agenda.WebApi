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
    [RoutePrefix("Endereco")]
    public class EnderecoController : ApiController
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IEnderecoTipoService _enderecoTipoService;
        private readonly IMapper _mapper;        

        public EnderecoController(IEnderecoService service, IEnderecoTipoService enderecoTipoService, IMapper mapper)
        {
            _mapper = mapper;
            _enderecoService = service;
            _enderecoTipoService = enderecoTipoService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var enderecos = _enderecoService.Get();
                var enderecoVM = _mapper.Map<IEnumerable<EnderecoViewModel>>(enderecos);

                return Json(enderecoVM);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

        [HttpGet]
        [Route("GetTipos")]
        public IHttpActionResult GetTipos()
        {
            try
            {
                var tipos = _enderecoTipoService.Get();
                var enderecoTipoVM = _mapper.Map<IEnumerable<EnderecoTipoViewModel>>(tipos);

                return Json(enderecoTipoVM);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(EnderecoViewModel enderecoVM)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            var endereco = _mapper.Map<Endereco>(enderecoVM);

            try
            {
                _enderecoService.Create(endereco);
                return Content(HttpStatusCode.OK, "Registro criado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao cadastrar: " + e.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(EnderecoViewModel enderecoVM)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return Content(HttpStatusCode.BadRequest, ListErrors.toList(errors));
            }

            var endereco = _mapper.Map<Endereco>(enderecoVM);

            try
            {
                _enderecoService.Update(endereco);
                return Content(HttpStatusCode.OK, "Registro atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao atualizar: " + e.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(EnderecoViewModel enderecoVM)
        {
            var endereco = _enderecoService.GetById(enderecoVM.Id);

            try
            {
                _enderecoService.Remove(endereco);
                return Content(HttpStatusCode.OK, "Registro deletado com sucesso.");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, "Erro na requisição: " + e.Message);
            }
        }

    }
}
