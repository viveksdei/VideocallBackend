
using Api.DTO;
using Api.DTO.PatientSlot;
using Core.App.Apps.SOAP.SoapCommand;

namespace Core.App.Common.Interfaces
{
    public interface IPatients
    {

        Task<ApiResponse> AddUpdatePatientSlot(List<PatientSlotDto> model);
        Task<ApiResponse> AddUpdateSoapNotes(AddUpdateSoapNotesCommand model);
        Task<ApiResponse> AddUpdateDapNotes(AddUpdateDapNotesCommand model);
        Task<ApiResponse> GetCallEnd(int SlotId);
   
    }
}
