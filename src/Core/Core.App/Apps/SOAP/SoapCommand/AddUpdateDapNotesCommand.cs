using Api.DTO.SoapNotesDTO;
using Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Apps.SOAP.SoapCommand
{
    public class AddUpdateDapNotesCommand : DAPNotesDto, IRequest<ApiResponse>
    {

    }
    public class AddUpdateDapNotesCommandHandler : IRequestHandler<AddUpdateDapNotesCommand, ApiResponse>
    {
        private readonly IPatients _Patients;

        public AddUpdateDapNotesCommandHandler(IPatients Patients)
        {
            _Patients = Patients;
        }
        public async Task<ApiResponse> Handle(AddUpdateDapNotesCommand request, CancellationToken cancellationToken)
        {
            return await _Patients.AddUpdateDapNotes(request);
        }


    }
}
