using Api.DTO.SoapNotesDTO;
using Core.App.Apps.Patient.Commands;
using Core.App.Apps.PatientAppoinment.Queries;
using Core.App.Apps.SOAP.Query;
using Core.App.Apps.SOAP.SoapCommand;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using UiApi.Hub;

namespace UiApi.Controllers.Patient
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ApiBaseController
    {
        private readonly IMediator _mediator;
        IHubContext<ChatHub> _chatHubContext;

        public PatientController(IMediator mediator, IHubContext<ChatHub> chatHubContext)
        {
            _mediator = mediator;
            _chatHubContext = chatHubContext;
        }


        [HttpPost]
        [Route("PatientSessionSlotBooking")]
        public async Task<IActionResult> PatientSlotBooking([FromBody] CreatePatientSlotCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);

        }

 
        [HttpPost]
        [Route("AddUpdateSoapNotes")]
        public async Task<IActionResult> AddUpdateSoapNotes([FromBody] AddUpdateSoapNotesCommand soapNotesDto)
        {
            var result = await _mediator.Send(soapNotesDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSoapNotesByPatientID")]
        public async Task<IActionResult> GetSoapNotesByPatientID(string patientId)
        {
            var result = await _mediator.Send(new GetSoapNotesByPatientIdQuery
            {
                PatientId = Convert.ToInt32(patientId)
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("AddUpdateDapNotes")]
        public async Task<IActionResult> AddUpdateDapNotes([FromBody] AddUpdateDapNotesCommand dapNotesDto)
        {
            var result = await _mediator.Send(dapNotesDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetEndCall")]
        public async Task<IActionResult> GetEndCall(int slotId)
        {
            var result = await Mediator.Send(new GetEndCallQuery { SlotId = slotId });
            return Ok(result);
        }


        [HttpPost]
        [Route("CallEnd")]
        public async Task<IActionResult> CallEnd([FromBody] checkAppointmentDto app)
        {
            await _chatHubContext.Clients.All.SendAsync("CallEnd", app.appointmentId, app.userId);
            return Ok();
        }

    }
}
