using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetPoulinaDomain.Command;
using ProjetPoulinaDomain.Models;
using ProjetPoulinaDomain.Querie;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrixController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public PrixController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllPrix")]
        public IEnumerable<PrixDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Prix>()).Result.Select(prix => _mapper.Map<PrixDTO>(oeuf));
        }

        [HttpGet("getPrixById")]
        public async Task<PrixDTO> GetPrix(Guid? id)
        {
            var prix = _mediator.Send(new GetByIDGeneric<Prix>(condition: c => c.PrixId == id)).Result;
            return _mapper.Map<PrixDTO>(prix);
        }

        [HttpPost("PostPrix")]
        public async Task<string> AddPrix(Prix prix)
        {

            return await _mediator.Send(new PostGeneric<Prix>(prix));
        }

        [HttpPut("PutPrix")]
        public async Task<string> PutPrix(Prix prix)
        {

            return await _mediator.Send(new PutGeneric<Prix>(prix));
        }

        [HttpDelete("DeletePrix")]
        public async Task<string> DeletePrix(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Prix>(id));
        }
    }
}
