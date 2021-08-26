using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetPoulinaDomain.Command;
using ProjetPoulinaDomain.Models;
using ProjetPoulinaDomain.Querie;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Speculation_centreController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public Speculation_centreController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllSpeculation_centre")]
        public IEnumerable<Speculation_centreDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Speculation_centre>()).Result.Select(speculation_centre => _mapper.Map<Speculation_centreDTO>(speculation_centre));
        }

        [HttpGet("getSpeculation_centreById")]
        public async Task<Speculation_centreDTO> GetSpeculation_centre(Guid? id)
        {
            var speculation_centre = _mediator.Send(new GetByIDGeneric<Speculation_centre>(condition: c => c.speculation_centre_Id == id)).Result;
            return _mapper.Map<Speculation_centreDTO>(speculation_centre);
        }

        [HttpPost("PostSpeculation_centre")]
        public async Task<string> AddSpeculation_centre(Speculation_centre speculation_centre)
        {

            return await _mediator.Send(new PostGeneric<Speculation_centre>(speculation_centre));
        }

        [HttpPut("PutSpeculation_centre")]
        public async Task<string> PutSpeculation_centre(Speculation_centre speculation_centre)
        {

            return await _mediator.Send(new PutGeneric<Speculation_centre>(speculation_centre));
        }

        [HttpDelete("DeleteSpeculation_centre")]
        public async Task<string> DeleteSpeculation_centre(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Speculation_centre>(id));
        }
    }
}
