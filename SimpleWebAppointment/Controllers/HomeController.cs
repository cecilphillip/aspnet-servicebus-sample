using Microsoft.AspNetCore.Mvc;
using SimpleWebAppointment.Models;
using SimpleWebAppointment.Services;
using System.Threading.Tasks;

namespace SimpleWebAppointment.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppointmentService _appointmentService;

        public HomeController(AppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppointmentRequest appointmentRequest)
        {
            //todo validate
            await _appointmentService.SubmitForProcessing(appointmentRequest);
            return RedirectToAction(nameof(Confirmation));
        }
        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }


    }
}
