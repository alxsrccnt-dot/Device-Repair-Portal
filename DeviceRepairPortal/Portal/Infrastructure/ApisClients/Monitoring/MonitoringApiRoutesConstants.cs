namespace Infrastructure.ApisClients.Monitoring;

public class MonitoringApiRoutesConstants
{
    public const string GetUserTicketEndpointRoute = "api/tickets?pageNumber={0}&pageSize={1}";
    public const string GetTicketEndpointRoute = "api/tehnician/tickets?pageNumber={0}&pageSize={1}";
    public const string GetTehnicianJobsEndpointRoute = "api/jobs?pageNumber={0}&pageSize={1}";
    public const string GetIssuesEndpointRoute = "api/issues";
}