using System;
using dotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using dotnetAPI.Services.CharacterService;

namespace dotnetAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class Charactercontroller : ControllerBase
	{
		private readonly ICharacterService _characterService;

		public Charactercontroller(ICharacterService characterService)
		{
			this._characterService = characterService;

		}


		[HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> Get()
		{
			return Ok(await _characterService.GetCharacters());
		}

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetSingle(int id)
        {
			return Ok(await _characterService.GetCharacterById(id));
        }

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> AddCharacter(AddCharacterRequestDto newCharacter)
		{
			return Ok(await _characterService.AddCharacter(newCharacter));
		}

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> UpdateCharacter(UpdateCharacterRequestDto updateCharacter)
        {
			var response = await _characterService.UpdateCharacter(updateCharacter);
			if(response.Data is null)
			{
				return NotFound(response);
			}

            return Ok(response);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}

