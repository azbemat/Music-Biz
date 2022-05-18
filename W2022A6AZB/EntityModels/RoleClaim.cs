﻿using System.ComponentModel.DataAnnotations;

namespace W2022A6AZB.EntityModels
{
    public class RoleClaim
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}