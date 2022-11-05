namespace Intotech.Common.Bll.ComplexResponses;

public class ReturnedResponse<TResult>
{
    public TResult MethodResult { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
}