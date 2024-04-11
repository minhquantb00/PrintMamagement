namespace PrintManagement.Application.Payloads.RequestModels.ResourceRequests
{
    public class Request_CreateResourceProperty
    {
        public string ResourcePropertyName { get; set; }
        public List<Request_CreateResourcePropertyDetail>? requests { get; set; }
    }
}
