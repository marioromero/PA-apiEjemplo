namespace PA_EjemploApi.Responses
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
