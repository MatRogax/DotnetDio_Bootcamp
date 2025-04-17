using minimal_api.domain.Enuns;

namespace minimal_api.domain.ModelViews
{
    public record adminLogged
    {
        public string Email { get; set; } = default!;
        public string profile { get; set; } = default!;
        public string Token { get; set; } = default!;

    }
   
}
