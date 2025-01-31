using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Inspection;
using App.Infra.Data.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Drawing;

namespace App.EndPoints.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController : ControllerBase
	{
		private readonly AppDbContext _appDbContext;
		private readonly IAppointmentAppService _appointmentAppService;
		
		public AppointmentController(AppDbContext appDbContext,
									 IAppointmentAppService appointmentAppService)
		{
			_appDbContext = appDbContext;
			_appointmentAppService = appointmentAppService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Appointment>> Get(int id)
		{
			// var appoinntment = await _appDbContext.Appointments.FindAsync(id);
			var appoinntment = await _appointmentAppService.GetAppointmentById(id);
			if (appoinntment == null) return NotFound("نوبت معاینه فنی یافت نشد");
			return appoinntment;
		}

		[HttpGet]
		public async Task<ActionResult<List<Appointment>>> GetAll()
		{
			//return await _appDbContext.Appointments.ToListAsync();
			return await _appointmentAppService.GetAllAppointments();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id,Appointment appointment)
		{  
			if (id != appointment.Id) return BadRequest();
			#region dbContextAccess
			//var appointmentToEdit = await _appDbContext.Appointments.FindAsync(id);
			//if (appointmentToEdit == null) return NotFound("نوبت معاینه فنی یافت نشد");
			//appointmentToEdit.CarId = appointment.CarId;
			//appointmentToEdit.CenterId = appointment.CenterId;
			//appointmentToEdit.Status = appointment.Status;
			//appointmentToEdit.Date = appointment.Date;
			//await _appDbContext.SaveChangesAsync();
			#endregion
			await _appointmentAppService.ChangeAppointmentInfo(appointment);
			return Ok("تغییرات با موفقیت اعمال شد");
		}

		[HttpPost]
		public async Task<IActionResult> Create(Appointment appointment)
		{
			//if (!ModelState.IsValid) return BadRequest(ModelState);
			#region DbContextAccess
			//_appDbContext.Appointments.Add(appointment);
			//await _appDbContext.SaveChangesAsync();
			#endregion
			var result = await _appointmentAppService.ScheduleAppointment(appointment);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			#region DbContextAccess
			var appointmentToDelete = await _appDbContext.Appointments.FindAsync(id);
			if (appointmentToDelete == null)  return NotFound("نوبت معاینه فنی یافت نشد");
			_appDbContext.Appointments.Remove(appointmentToDelete);
			await _appDbContext.SaveChangesAsync();
			#endregion
			var result = await _appointmentAppService.DeleteAppointment(id);
			return Ok(result);
		}
	}
}
