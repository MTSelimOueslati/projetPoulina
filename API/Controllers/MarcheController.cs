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
    public class MarcheController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public MarcheController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllMarche")]
        public IEnumerable<MarcheDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Marche>()).Result.Select(marche => _mapper.Map<MarcheDTO>(marche));
        }

        [HttpGet("getMarcheById")]
        public async Task<MarcheDTO> GetMarche(Guid? id)
        {
            var marche = _mediator.Send(new GetByIDGeneric<Marche>(condition: c => c.PrixId == id)).Result;
            return _mapper.Map<MarcheDTO>(marche);
        }

        [HttpPost("PostMarche")]
        public async Task<string> AddMarche(Marche marche)
        {

            return await _mediator.Send(new PostGeneric<Marche>(marche));
        }

        [HttpPut("PutMarche")]
        public async Task<string> PutMarche(Marche marche)
        {

            return await _mediator.Send(new PutGeneric<Marche>(marche));
        }

        [HttpDelete("DeleteMarche")]
        public async Task<string> DeleteMarche(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Marche>(id));
        }
    }
}
