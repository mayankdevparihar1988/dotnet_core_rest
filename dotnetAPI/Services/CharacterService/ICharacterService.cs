﻿using System;

namespace dotnetAPI.Services.CharacterService;

public interface ICharacterService
{

	Task<ServiceResponse<List<GetCharacterResponseDto>>> GetCharacters();
    Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById( int id);
    Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter);
    Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updateCharacter);
    Task<ServiceResponse<GetCharacterResponseDto>> DeleteCharacter(int Id);

}

