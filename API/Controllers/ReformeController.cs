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
    public class ReformeController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public ReformeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllReforme")]
        public IEnumerable<ReformeDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Reforme>()).Result.Select(reforme => _mapper.Map<ReformeDTO>(reforme));
        }

        [HttpGet("getReformeById")]
        public async Task<PrixDTO> GetReforme(Guid? id)
        {
            var reforme = _mediator.Send(new GetByIDGeneric<Reforme>(condition: c => c.PrixId == id)).Result;
            return _mapper.Map<ReformeDTO>(reforme);
        }

        [HttpPost("PostReforme")]
        public async Task<string> AddReforme(Reforme reforme)
        {

            return await _mediator.Send(new PostGeneric<Reforme>(reforme));
        }

        [HttpPut("PutReforme")]
        public async Task<string> PutReforme(Reforme reforme)
        {

            return await _mediator.Send(new PutGeneric<Reforme>(reforme));
        }

        [HttpDelete("DeleteReforme")]
        public async Task<string> DeleteReforme(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Reforme>(id));
        }
    }
}
