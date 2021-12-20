using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BowlingGame.API.Requests;
using BowlingGame.API.Response;
using BowlingGame.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BowlingGame.API.Controllers
{
    [ApiController]
    [Route("api/bowling")]
    public class BowlingGameController : ControllerBase
    {
        private readonly IGameService gameService;
        private readonly IScoreService scoreService;
        private readonly IRollService rollService;
        private readonly IMemoryCache cache;

        public BowlingGameController(IGameService gameService,
                                     IScoreService scoreService,
                                     IRollService rollService,
                                     IMemoryCache cache)
        {
            this.gameService = gameService;
            this.scoreService = scoreService;
            this.rollService = rollService;
            this.cache = cache;
        }

        [HttpPost("create-game")]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameRequest request)
        {
            if (request.HasErrors()) return BadRequest(request.Errors);

            var gameModel = await gameService.CreateGame(request.PlayerName);
            return Ok(new CreateGameResponse(gameModel));
        }

        [HttpPatch("roll")]
        public async Task<IActionResult> Roll([FromBody] RollRequest request)
        {
            if (request.HasErrors()) return BadRequest(request.Errors);
            await rollService.Roll(request.GameId, request.Score);
            return NoContent();
        }

        [HttpGet("score/{gameId:guid}")]
        public async Task<IActionResult> GetScore(string gameId)
        {
            if (!cache.TryGetValue(gameId, out GetScoreResponse response))
            {
                var memoryCacheOptions = new MemoryCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromSeconds(5)
                };

                var gameModel = await scoreService.GetScore(gameId);
                response = new GetScoreResponse(gameModel);
                cache.Set(gameId, response, memoryCacheOptions);
            }

            return Ok(response);
        }
    }
}
