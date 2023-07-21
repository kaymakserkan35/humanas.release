namespace web.api.Utilities.Results
{

    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorValue { get; set; }
    }


    public class Response<TEntity>
    {
        public Response()
        {
            Errors = new List<Error>();
            Data = new List<TEntity>();
        }
        public bool IsSucceded { get; set; }
        public List<Error> Errors { get; set; }
        public List<TEntity> Data { get; set; }
        public string Message { get; set; }
    }
}
