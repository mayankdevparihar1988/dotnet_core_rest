using System;
using dotnetAPI.Models;

namespace dotnetAPI.Dtos.Character
{
	public class GetCharacterResponseDto
	{
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.KNIGHT;

        public static implicit operator GetCharacterResponseDto(Models.Character v)
        {
            throw new NotImplementedException();
        }
    }
}

