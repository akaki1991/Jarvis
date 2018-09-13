using System.Collections.Generic;

namespace Service
{
    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
    public class Error
    {
        public ErrorCode Code { get; set; }
        public string ErrorMessage { get; set; }
    }


    public enum ErrorCode
    {
        None = 0,
        Internal=500
    }

    public class BaseResponse
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
        public IEnumerable<Error> OtherErrors { get; set; }
        //public ModelStateDictionary ModelState { get; set; }

        public static BaseResponse Ok() => new BaseResponse { Success = true };
        public static BaseResponse Fail() => new BaseResponse { Success = false };
        public static BaseResponse<T> Fail<T>() => new BaseResponse<T> { Success = false };
        public static BaseResponse Fail(string message) => new BaseResponse { Success = false, Error = new Error { ErrorMessage = message } };
        public static BaseResponse Fail<T>(string message) => new BaseResponse<T> { Success = false, Error = new Error { ErrorMessage = message } };
        public static BaseResponse<T> Ok<T>(T response = default(T)) => new BaseResponse<T> { Success = true, Data = response };
        public static BaseResponse Fail(Error error, IEnumerable<Error> errors = null) => new BaseResponse { Success = false, Error = error, OtherErrors = errors };
        public static BaseResponse<T> Fail<T>(Error error, IEnumerable<Error> errors = null) => new BaseResponse<T> { Success = false, Error = error, OtherErrors = errors };

        //public static BaseResponse Fail(ModelStateDictionary modelState) => new BaseResponse { Success = false,  ModelState = modelState };
    }
}
