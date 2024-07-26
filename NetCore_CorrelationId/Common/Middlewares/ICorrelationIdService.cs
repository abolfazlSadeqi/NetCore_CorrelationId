namespace NetCore_CorrelationId.Common.Middlewares;

public interface ICorrelationIdService
{
    string GetCorrelationId();
    void SetCorrelationId(string value);
}
