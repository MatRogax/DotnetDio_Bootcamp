﻿using minimal_api.domain.Enuns;

namespace minimal_api.domain.ModelViews
{
    public record AdminModelView
    {
        public int Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Profile { get; set; } = default!;

    }
   
}
