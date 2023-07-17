using System;
using System.Text.Json.Serialization;

namespace dotnetAPI.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum RpgClass
	{
		KNIGHT = 1,
		MAGE = 2,
		CLERIC = 3

	}
}

