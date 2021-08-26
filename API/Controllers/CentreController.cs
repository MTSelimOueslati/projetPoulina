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
    public class CentreController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public CentreController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllCentre")]
        public IEnumerable<CentreDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Centre>(condition: null, includes: i => i.Include(m => m.amortissment))).Result.Select(centre => _mapper.Map<CentreDTO>(centre));
        }

        [HttpGet("getCentreById")]
        public async Task<CentreDTO> GetCentre(Guid? id)
        {
            var centre = _mediator.Send(new GetByIDGeneric<Centre>(condition: c => c.CentreId == id)).Result;
            return _mapper.Map<CentreDTO>(centre);
        }

        [HttpPost("PostCentre")]
        public async Task<string> AddCentre(Centre centre)
        {

            return await _mediator.Send(new PostGeneric<Centre>(centre));
        }

        [HttpPut("PutCentre")]
        public async Task<string> PutCentre(Centre centre)
        {

            return await _mediator.Send(new PutGeneric<Centre>(centre));
        }

        [HttpDelete("DeleteCentre")]
        public async Task<string> DeleteCentre(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Centre>(id));
        }
    }
}
