namespace minimal_api.domain.ModelViews;

public struct ErrorValidations
{

    public List<string> Message { get; set; }

    public ErrorValidations(List<string> Message)
    {
        this.Message = Message;

    }
}
