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
    public class SpeculationController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public SpeculationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllSpeculation")]
        public IEnumerable<SpeculationDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Speculation>()).Result.Select(speculation => _mapper.Map<SpeculationDTO>(speculation));
        }

        [HttpGet("getSpeculationById")]
        public async Task<SpeculationDTO> GetSpeculation(Guid? id)
        {
            var speculation = _mediator.Send(new GetByIDGeneric<Speculation>(condition: c => c.SpeculationId == id)).Result;
            return _mapper.Map<SpeculationDTO>(speculation);
        }

        [HttpPost("PostSpeculation")]
        public async Task<string> AddSpeculation(Speculation speculation)
        {

            return await _mediator.Send(new PostGeneric<Speculation>(speculation));
        }

        [HttpPut("PutSpeculation")]
        public async Task<string> PutSpeculation(Speculation speculation)
        {

            return await _mediator.Send(new PutGeneric<Speculation>(speculation));
        }

        [HttpDelete("DeleteSpeculation")]
        public async Task<string> DeleteSpeculation(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Speculation>(id));
        }
    }
}
