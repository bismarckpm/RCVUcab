﻿using System;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class ProviderDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string  Address { get; set; }

        public string CreatedAt { get; set; }
    }
}
