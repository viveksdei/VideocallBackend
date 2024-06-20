using Api.DTO;
using Api.DTO.PatientSlot;
using Core.App.Apps.SOAP.SoapCommand;
using Core.Domain.Common;
using Core.Domain.Entities.DAP;
using Core.Domain.Entities.Patients;
using Core.Domain.Entities.SoapNotes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using OpenTokSDK;
using System.Data;
using System.Dynamic;
using System.Net;

namespace Core.App.Common.Services
{
    public class PatientService : IPatients
    {
        private readonly IApplicationDbContext _dbContext;
        public ApiResponse response = new ApiResponse();
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        public PatientService(IApplicationDbContext dbContext, IConfiguration configuration, IHostingEnvironment env)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _env = env;
        }

        public async Task<ApiResponse> AddUpdatePatientSlot(List<PatientSlotDto> model)
        {
            try
            {
                foreach (var item in model)
                {

                        int apiKey = 47863071;
                        string apiSecret = "eca802f1132218d4cd931038cac24ec1bf80c5b3";

                       // OpenTokService openService = new OpenTokService();

                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        DateTime d = DateTime.Now.AddDays(30);
                        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        var duration = (d.ToUniversalTime() - epoch).TotalSeconds;

                        dynamic locals = new ExpandoObject();

                        OpenTokSDK.OpenTok openTok = new OpenTokSDK.OpenTok(apiKey, apiSecret);
                        var session = openTok.CreateSession(string.Empty, OpenTokSDK.MediaMode.ROUTED);
                        var opentok = new OpenTokSDK.OpenTok(apiKey, apiSecret);

                        string token = opentok.GenerateToken(session.Id, Role.PUBLISHER, duration);
                        string tokenClient = opentok.GenerateToken(session.Id, Role.PUBLISHER, duration);

                            response.Status = 200;
                            response.Message = "Patient slot Booking Successfully";
                }
            }
            catch (Exception ex)
            {
                response.Status = 500;
            }


            return response;

        }

        public async Task<ApiResponse> AddUpdatePatientSlotOld(List<PatientSlotDto> model)
        {
            try
            {
                foreach (var item in model)
                {
                    int patient = await _dbContext.Patients.Where(x => x.UserId == Convert.ToInt32(item.CreatedBy)).Select(x => x.PatientId).FirstOrDefaultAsync();
                    var slotRes = await _dbContext.PatientSessionSlotBooking
                                        .FirstOrDefaultAsync(r =>
                                            r.SlotTimeId == item.SlotTimeId &&
                                            r.SlotDate == item.SlotDate &&
                                            r.TherapistId == item.TherapistId &&
                                            r.PatientId == patient);
                    if (slotRes != null)
                    {
                        response.Status = ResponseCode.AlreadyExist;
                        response.Message = "Same time slot already booked for you!";
                        if (model.Count == 1)
                        {
                            break;
                        }
                        continue;
                    }
                    if (slotRes == null)
                    {

                        int apiKey = 47863071;
                    string apiSecret = "eca802f1132218d4cd931038cac24ec1bf80c5b3";

                    // OpenTokService openService = new OpenTokService();

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    DateTime d = DateTime.Now.AddDays(30);
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    var duration = (d.ToUniversalTime() - epoch).TotalSeconds;

                    dynamic locals = new ExpandoObject();

                    OpenTokSDK.OpenTok openTok = new OpenTokSDK.OpenTok(apiKey, apiSecret);
                    var session = openTok.CreateSession(string.Empty, OpenTokSDK.MediaMode.ROUTED);
                    var opentok = new OpenTokSDK.OpenTok(apiKey, apiSecret);

                    string token = opentok.GenerateToken(session.Id, Role.PUBLISHER, duration);
                    string tokenClient = opentok.GenerateToken(session.Id, Role.PUBLISHER, duration);

                    var objSlotBooking = new PatientSessionSlotBooking();
                    {
                        int status = 4;
                        objSlotBooking.PatientId = _dbContext.Patients.Where(x => x.UserId == Convert.ToInt32(item.CreatedBy)).Select(x => x.PatientId).FirstOrDefault();
                        objSlotBooking.TherapistId = item.TherapistId;
                        objSlotBooking.SlotDate = item.SlotDate;
                        objSlotBooking.SlotTimeId = item.SlotTimeId;
                        objSlotBooking.CreatedBy = item.CreatedBy;
                        objSlotBooking.StatusId = status;
                        objSlotBooking.SessionId = session.Id;
                        objSlotBooking.Token = token;
                        objSlotBooking.TokenClient = tokenClient;
                    }
                    await _dbContext.PatientSessionSlotBooking.AddAsync(objSlotBooking);
                    var result = await _dbContext.SaveChangesAsync();
                    response.Status = 200;
                    response.Message = "Patient slot Booking Successfully";
                    response.ResponseData = result;
                }
            }
            }
            catch (Exception ex)
            {
                response.Status = 500;
            }


            return response;

        }

        public async Task<ApiResponse> AddUpdateSoapNotes(AddUpdateSoapNotesCommand model)
        {
            try
            {
                var SQLResponseDto = new ApiResponse();
                var isExist = _dbContext.SoapNotes.Where(x => x.SoapNoteId == model.SoapNoteId).DefaultIfEmpty().First();

                if (isExist == null)
                {
                    SoapNotes soapNotes = new SoapNotes();
                    soapNotes.PatientId = (int)model.PatientId;
                    soapNotes.TherapistId = (int)model.TherapistId;
                    soapNotes.OrganizationId = (int)model.OrganizationId;
                    soapNotes.Subjective = model.Subjective;
                    soapNotes.Objective = model.Objective;
                    soapNotes.Assessment = model.Assessment;
                    soapNotes.Plans = model.Plans;
                    soapNotes.IsActive = true;
                    soapNotes.IsDeleted = false;
                    soapNotes.CreatedBy = model.TherapistId.ToString();
                    soapNotes.CreatedOn = DateTime.UtcNow;
                      _dbContext.SoapNotes.Add(soapNotes);
                    await _dbContext.SaveChangesAsync();
                    SQLResponseDto.Message = ResponseMessage.SoapNotesSave;
                    SQLResponseDto.StatusCode = (int)ResponseCode.Ok;
                    return SQLResponseDto;
                }
                else
                {
                    var soapNotes = _dbContext.SoapNotes.FirstOrDefault(x => x.SoapNoteId == model.SoapNoteId);
                    if (soapNotes != null)
                    {
                        soapNotes.Subjective = model.Subjective;
                        soapNotes.Objective = model.Objective;
                        soapNotes.Assessment = model.Assessment;
                        soapNotes.Plans = model.Plans;
                        soapNotes.LastModifiedBy = model.TherapistId.ToString();
                        soapNotes.LastModifiedOn = DateTime.UtcNow;
                        _dbContext.SoapNotes.Update(soapNotes);
                       await _dbContext.SaveChangesAsync();
                        SQLResponseDto.Message = ResponseMessage.SoapNotesUpdated;
                        SQLResponseDto.StatusCode = (int)ResponseCode.Ok;
                    }
                    return SQLResponseDto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ApiResponse> AddUpdateDapNotes(AddUpdateDapNotesCommand model)
        {
            try
            {
                var SQLResponseDto = new ApiResponse();
                var isExist = _dbContext.DapNotes.Where(x => x.DapNoteId == model.DapNoteId).DefaultIfEmpty().First();

                if (isExist == null)
                {
                    DapNotes dapNotes = new DapNotes();
                    dapNotes.PatientId = (int)model.PatientId;
                    dapNotes.TherapistId = (int)model.TherapistId;
                    dapNotes.OrganizationId = (int)model.OrganizationId;
                    dapNotes.Data = model.Data;
                    dapNotes.Assessment = model.Assessment;
                    dapNotes.Plans = model.Plans;
                    dapNotes.IsActive = true;
                    dapNotes.IsDeleted = false;
                    dapNotes.CreatedBy = model.TherapistId.ToString();
                    dapNotes.CreatedOn = DateTime.UtcNow;
                    _dbContext.DapNotes.Add(dapNotes);
                   await _dbContext.SaveChangesAsync();
                    SQLResponseDto.Message = ResponseMessage.DapNotesSave;
                    SQLResponseDto.StatusCode = (int)ResponseCode.Ok;
                    return SQLResponseDto;
                }
                else
                {
                    var dapNotes = _dbContext.DapNotes.FirstOrDefault(x => x.DapNoteId == model.DapNoteId);
                    if (dapNotes != null)
                    {

                        dapNotes.Data = model.Data;
                        dapNotes.Assessment = model.Assessment;
                        dapNotes.Plans = model.Plans;
                        dapNotes.LastModifiedBy = model.TherapistId.ToString();
                        dapNotes.LastModifiedOn = DateTime.UtcNow;
                        _dbContext.DapNotes.Update(dapNotes);
                        await _dbContext.SaveChangesAsync();
                        SQLResponseDto.Message = ResponseMessage.DapNotesUpdated;
                        SQLResponseDto.StatusCode = (int)ResponseCode.Ok;
                    }
                    return SQLResponseDto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      

      

        public async Task<ApiResponse> GetCallEnd(int SlotId)
        {
            try
            {
                var call = _dbContext.PatientSessionSlotBooking.Where(x => x.SlotId == SlotId).FirstOrDefault();
                if (call != null)
                {
                    call.IsActive = false;
                    call.IsDeleted = true;
                    _dbContext.PatientSessionSlotBooking.Update(call);
                    _dbContext.SaveChangesAsync();
                }
                response.StatusCode = ResponseCode.Ok;
                response.ResponseData = 1;
                response.Message = ResponseMessage.InvalidRequest;
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ResponseCode.ServerError;
                response.ResponseData = null;
                response.Message = ResponseMessage.Error;
                return response;
            }
        }

        
    
     
       
    }
}