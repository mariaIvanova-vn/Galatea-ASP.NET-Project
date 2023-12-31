﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Galatea.Data.Models
{
    public class Rating
    {
        public Rating()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public double TotalRating { get; set; }

        public Guid? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser? User { get; set; }

        public Guid? PublicationId { get; set; }

        [ForeignKey(nameof(PublicationId))]
        public virtual Publication? Publication { get; set; } 
    }
}