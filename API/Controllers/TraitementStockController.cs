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
    public class TraitementStockController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public TraitementStockController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllTraitementStock")]
        public IEnumerable<TraitementStockDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<TraitementStock>(condition: null, includes: i => i.Include(m => m.stock))).Result.Select(traitementstock => _mapper.Map<TraitementStockDTO>(traitementstock));
        }

        [HttpGet("getTraitementStockById")]
        public async Task<TraitementStockDTO> GetTraitementStock(Guid? id)
        {
            var traitementstock = _mediator.Send(new GetByIDGeneric<TraitementStock>(condition: c => c.TraitementStockId == id)).Result;
            return _mapper.Map<TraitementStockDTO>(traitementstock);
        }

        [HttpPost("PostTraitementStock")]
        public async Task<string> AddStock(TraitementStock traitementstock)
        {

            return await _mediator.Send(new PostGeneric<TraitementStock>(traitementstock));
        }

        [HttpPut("PutTraitementStock")]
        public async Task<string> PutTraitementStock(TraitementStock traitementstock)
        {

            return await _mediator.Send(new PutGeneric<TraitementStock>(traitementstock));
        }

        [HttpDelete("DeleteTraitementStock")]
        public async Task<string> DeleteTraitementStock(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<TraitementStock>(id));
        }
    }
}
