[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar([FromBody] CreateUserViewModel model)
    {
        var command = new CreateUserCommand(model.Nome, model.Email, model.Senha);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id = result }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var user = await _mediator.Send(query);
        return Ok(user);
    }
}