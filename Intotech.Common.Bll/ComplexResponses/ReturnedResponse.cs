namespace Intotech.Common.Bll.ComplexResponses;

public class ReturnedResponse<TResult>
{
    public ReturnedResponse(TResult result, string errorMessage, bool isSuccess, int errorCode)
    {
        MethodResult = result;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }

    public TResult MethodResult { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
    public int ErrorCode { get; set; }
}