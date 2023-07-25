namespace web.api.DTOS
{


    public class Response<TData>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Success!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
        public TData Data { get; set; }
        public Response()
        {

        }
        public Response(TData data)
        {
            this.Data = data;   
        }

        public Response(bool isSuccess, string message, TData data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

       
    }
}
