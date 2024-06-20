using Api.DTO;
using Api.DTO.SoapNotesDTO;

namespace Core.App.Apps.SOAP.SoapCommand
{
    public class AddUpdateSoapNotesCommand : SoapNotesDto, IRequest<ApiResponse>
    {

    }
    public class AddUpdateSoapNotesCommandHandler : IRequestHandler<AddUpdateSoapNotesCommand, ApiResponse>
    {
        private readonly IPatients _Patients;

        public AddUpdateSoapNotesCommandHandler(IPatients Patients)
        {
            _Patients = Patients;
        }
        public async Task<ApiResponse> Handle(AddUpdateSoapNotesCommand request, CancellationToken cancellationToken)
        {
            return await _Patients.AddUpdateSoapNotes(request);
        }


    }

}
