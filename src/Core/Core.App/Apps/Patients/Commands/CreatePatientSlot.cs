using Api.DTO;
using Api.DTO.PatientSlot;

namespace Core.App.Apps.Patient.Commands
{
    public class CreatePatientSlotCommand : List<PatientSlotDto>, IRequest<ApiResponse>
    {
        
    }
    public class CreatePatientSlotCommandHandler : IRequestHandler<CreatePatientSlotCommand, ApiResponse>
    {
        private readonly IPatients _Patients;
        public CreatePatientSlotCommandHandler(IPatients patients)
        {
            _Patients = patients;
        }

        public async Task<ApiResponse> Handle(CreatePatientSlotCommand request, CancellationToken cancellationToken)
        {
            return await _Patients.AddUpdatePatientSlot(request);
        }
    }
}
