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
    public class StockController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public StockController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("getAllStock")]
        public IEnumerable<StockDTO> Gets()
        {
            return _mediator.Send(new GetAllGeneric<Stock>(condition: null, includes: i => i.Include(m => m.speculation_centre))).Result.Select(stock => _mapper.Map<StockDTO>(stock));
        }

        [HttpGet("getStockById")]
        public async Task<StockDTO> GetStock(Guid? id)
        {
            var stock = _mediator.Send(new GetByIDGeneric<Stock>(condition: c => c.StockId == id)).Result;
            return _mapper.Map<StockDTO>(stock);
        }

        [HttpPost("PostStock")]
        public async Task<string> AddStock(Stock stock)
        {

            return await _mediator.Send(new PostGeneric<Stock>(stock));
        }

        [HttpPut("PutStock")]
        public async Task<string> PutStock(Stock stock)
        {

            return await _mediator.Send(new PutGeneric<Stock>(stock));
        }

        [HttpDelete("DeleteStock")]
        public async Task<string> DeleteStock(Guid id)
        {
            return await _mediator.Send(new DeleteGeneric<Stock>(id));
        }
    }
}
