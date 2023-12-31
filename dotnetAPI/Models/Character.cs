﻿using System;
namespace dotnetAPI.Models;

public class Character
{

    public int Id { get; set; } = 0;
    public string Name { get; set; } = "Frodo";
    public int HitPoints { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Defence { get; set; } = 10;
    public int Intelligence { get; set; } = 10;
    public RpgClass Class { get; set; } = RpgClass.KNIGHT;
    public User? User { get; set; }
}

