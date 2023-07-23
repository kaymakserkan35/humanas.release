namespace web.api.DTOS
{


    public class Response<TData>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Success";
        public TData Data { get; set; }

        public Response()
        {

        }

        public Response(bool isSuccess, string message, TData data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public Response(TData data)
        {
            Data = data;
        }
    }
}
