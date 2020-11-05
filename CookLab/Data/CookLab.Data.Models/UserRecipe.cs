﻿namespace CookLab.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using CookLab.Data.Common.Models;

    public class UserRecipe : BaseDeletableModel<string>
    {
        public UserRecipe()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Recipe))]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
