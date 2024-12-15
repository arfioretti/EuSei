﻿using EuSei.Shared;
using System.ComponentModel.DataAnnotations;

namespace EuSei.Api.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Nmae { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [Length(10,15)]
        public string Phone { get; set; }
        [MaxLength(250)]
        public string PasswordHash { get; set; }
        [MaxLength(15)]
        public string Role { get; set; }=nameof(UserRole.Student);
        public bool IsAproved{ get; set; }
    }
}
