﻿using System;
using EntityController.Entity.Interfaces;

namespace EntityController.Entity
{
    public class OwnPlayer : IOwnPlayer
    {
        public Guid Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        
        public string Nickname { get; set; }
    }
}