using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public abstract class Entity
    {
        public bool Active { get; set; }

        public bool Removed { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    }
}
