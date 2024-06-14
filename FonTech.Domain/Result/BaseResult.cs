namespace FonTech.Domain.Result;

public class BaseResult
{
    public bool IsSuccess => ErrorMessage == null;
    public string ErrorMessage { get; set; }
    
    public int? ErrorCode { get; set; }
}

public class BaseResult<T> : BaseResult
{
    public BaseResult(string errorMessage, int errorCode, T data)
    {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
        Data = data;
    }

    public BaseResult() { }
    
    public T Data { get; set; }
}