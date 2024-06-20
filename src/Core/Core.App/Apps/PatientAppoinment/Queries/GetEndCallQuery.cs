using Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Apps.PatientAppoinment.Queries
{
    public class GetEndCallQuery : IRequest<ApiResponse>
    {
        public int SlotId { get; set; }

    }
    public class GetEndCallQueryHandler : IRequestHandler<GetEndCallQuery, ApiResponse>
    {
        private readonly IPatients _patient;

        public GetEndCallQueryHandler(IPatients patient)
        {

            _patient = patient;
        }

        public async Task<ApiResponse> Handle(GetEndCallQuery request, CancellationToken cancellationToken)
        {
            return await _patient.GetCallEnd(request.SlotId);
        }
    }
}
