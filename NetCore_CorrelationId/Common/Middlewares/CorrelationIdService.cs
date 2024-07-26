namespace NetCore_CorrelationId.Common.Middlewares;

public class CorrelationIdService : ICorrelationIdService
{
    private string _value = Guid.NewGuid().ToString();
    public string GetCorrelationId() => _value;
    public void SetCorrelationId(string value)
      => _value = value;

}
