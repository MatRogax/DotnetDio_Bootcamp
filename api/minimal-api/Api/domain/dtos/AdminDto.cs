using minimal_api.domain.Enuns;

namespace minimal_api.domain.dtos
{
    public class AdminDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Profile Profile { get; set; } = default!;

    }
}
