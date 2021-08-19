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
    public class OeufController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public OeufController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllOeuf")]
        public IEnumerable<OeufDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Oeuf>()).Result.Select(oeuf => _mapper.Map<OeufDTO>(oeuf));
        }

        [HttpGet("getOeufById")]
        public async Task<OeufDTO> GetOeuf(Guid? id)
        {
            var oeuf = _mediator.Send(new GetByIDGeneric<Oeuf>(condition: c => c.PrixId == id)).Result;
            return _mapper.Map<OeufDTO>(oeuf);
        }

        [HttpPost("PostOeuf")]
        public async Task<string> AddOeuf(Oeuf oeuf)
        {

            return await _mediator.Send(new PostGeneric<Oeuf>(oeuf));
        }

        [HttpPut("PutOeuf")]
        public async Task<string> PutOeuf(Oeuf oeuf)
        {

            return await _mediator.Send(new PutGeneric<Oeuf>(oeuf));
        }

        [HttpDelete("DeleteOeuf")]
        public async Task<string> DeleteOeuf(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Oeuf>(id));
        }
    }
}
