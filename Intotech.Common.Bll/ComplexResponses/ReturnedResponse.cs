namespace Intotech.Common.Bll.ComplexResponses;

public class ReturnedResponse<TResult>
{
    public ReturnedResponse(TResult result, string errorMessage, bool isSuccess)
    {
        MethodResult= result;
        IsSuccess= isSuccess;
        ErrorMessage= errorMessage;
    }

    public TResult MethodResult { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
}