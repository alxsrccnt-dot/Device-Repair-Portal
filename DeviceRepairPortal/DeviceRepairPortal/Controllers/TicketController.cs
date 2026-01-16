using Infrastructure.ApisClients.Management;
using Microsoft.AspNetCore.Mvc;

namespace DeviceRepairPortal.Controllers;

public class TicketController(IManagementServicesClient TicketServicesClient) : Controller
{

}