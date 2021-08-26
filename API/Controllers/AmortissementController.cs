using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetPoulinaDomain.Command;
using ProjetPoulinaDomain.Models;
using ProjetPoulinaDomain.Querie;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmortissementController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public AmortissementController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllAmortissement")]
        public IEnumerable<AmortissementDTO> Gets() 
        {
            return _mediator.Send(new GetAllGeneric<Amortissement>()).Result.Select(amortissement => _mapper.Map<AmortissementDTO>(amortissement));
        }

        [HttpGet("getAmortissementById")]
        public async Task<AmortissementDTO> GetAmortissement(Guid? id)
        {
            var amortissement = _mediator.Send(new GetByIDGeneric<Amortissement>(condition: c => c.AmortissementId == id)).Result;
            return _mapper.Map<AmortissementDTO>(amortissement);
        }

        [HttpPost("PostAmortissement")]
        public async Task<string> AddAmortissement(Amortissement amortissement)
        {

            return await _mediator.Send(new PostGeneric<Amortissement>(amortissement));
        }

        [HttpPut("PutAmortissement")]
        public async Task<string> PutAmortissement(Amortissement amortissement)
        {

            return await _mediator.Send(new PutGeneric<Amortissement>(amortissement));
        }

        [HttpDelete("DeleteAmortissement")]
        public async Task<string> DeleteAmortissement(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Amortissement>(id));
        }

    }
}
