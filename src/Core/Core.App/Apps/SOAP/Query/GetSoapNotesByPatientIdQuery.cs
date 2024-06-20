using Api.DTO;
using Api.DTO.SoapNotesDTO;
using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Apps.SOAP.Query
{
    public class GetSoapNotesByPatientIdQuery : IRequest<ApiResponse>
    {
        public int PatientId { get; set; }
    }
    public class GetSoapNotesByPatientIdQueryHandler : IRequestHandler<GetSoapNotesByPatientIdQuery, ApiResponse>
    {
        private readonly IApplicationDbContext _applicationDBContext;
        private readonly IMapper _mapper;

        public GetSoapNotesByPatientIdQueryHandler(IApplicationDbContext applicationDBContext, IMapper mapper)
        {
            _applicationDBContext = applicationDBContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetSoapNotesByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                PatientSOAPDAP patientSOAPDAP = new PatientSOAPDAP();

                var soapresult = await _applicationDBContext.SoapNotes.Where(a => a.PatientId == request.PatientId && a.IsActive == true && a.IsDeleted == false).Select(a => new SoapNotesDto
                {
                    SoapNoteId = a.SoapNoteId,
                    PatientId = a.PatientId,
                    TherapistId=a.TherapistId,
                    OrganizationId= a.OrganizationId,
                    Subjective=a.Subjective,
                    Objective=a.Objective,
                    Assessment=a.Assessment,
                    Plans=a.Plans,
                    CreatedDate=a.CreatedOn.ToString("yyyy-MM-dd")
                })
                 .ToListAsync();
                var dapresult = await _applicationDBContext.DapNotes.Where(a => a.PatientId == request.PatientId && a.IsActive == true && a.IsDeleted == false).Select(a => new DAPNotesDto
                {
                    DapNoteId = a.DapNoteId,
                    PatientId = a.PatientId,
                    TherapistId = a.TherapistId,
                    OrganizationId = a.OrganizationId,
                    Data = a.Data,
                    Assessment = a.Assessment,
                    Plans = a.Plans,
                    CreatedDate = a.CreatedOn.ToString("yyyy-MM-dd")
                })
                 .ToListAsync();
                var SQLResponse = new ApiResponse();
                if (soapresult != null || dapresult !=null)
                {
                    patientSOAPDAP.soapNotesDtos = soapresult;
                    patientSOAPDAP.dAPNotesDtos = dapresult;
                    SQLResponse.ResponseData = patientSOAPDAP;
                    SQLResponse.Message = ResponseMessage.RecordSuccess;
                    SQLResponse.StatusCode = (int)ResponseCode.Ok;
                }
                else
                {
                    SQLResponse.Message = ResponseMessage.NotFound;
                    SQLResponse.StatusCode = (int)ResponseCode.NotFound;
                }
                return SQLResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
