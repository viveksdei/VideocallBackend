using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public static class ResponseMessage
    {
        public const string Successfull = "Operation Successfull";
        public const string Success = "Added Successfully";
        public const string Error = "Some internal error occured";
        public const string LoginSuccess = "Login successfully";
        public const string UserNotExist = "User not exist";
        public const string PasswordNotMatch = "Password not match";
        public const string DataFetchSuccess = "Data fetch successfully";
        public const string NotFound = "Record not found";
        public const string AppointmentNotFound = "Appointment not found";
        public const string PatientNotFound = "Patient not found";
        public const string DataSaved = "Record Saved Successfully";
        public const string DataUpdated = "Record Updated Successfully";
        public const string DataDeleted = "Record Deleted Successfully";
        public const string UserExist = "UserName Already Exists";
        public const string SubExist = "Subscription Already Exists";
        public const string depExist = "DepartmentName Already Exists";
        public const string INCExist = "IncidentType Already Exists";
        public const string Locxist = "IncidentLocation Already Exists";
        public const string hosExist = "HospitalName Already Exists";
        public const string UserEmailExist = "Email Is Already In Use";
        public const string TryAgain = "Please Try Again";
        public const string InvalidRequest = "Request parameter is not Correct";
        public const string PasswordChanged = "Password Changed Successfully";
        public const string OtpSent = "OTP Sent Successfully";
        public const int Otp = 0;
        // SoapNotes
        public const string SoapNotesExist = "Soap note already exist";
        public const string SoapNotesSave = "Soap note has been saved successfully.";
        public const string SoapNotesUpdated = "Soap note has been updated successfully.";
        public const string SoapNotesDeleted = "Soap note has been deleted successfully.";
        public const string DapNotesExist = "Soap note already exist";
        public const string DapNotesSave = "Soap note has been saved successfully.";
        public const string DapNotesUpdated = "Soap note has been updated successfully.";
        public const string DapNotesDeleted = "Soap note has been deleted successfully.";
        public const string RecordSuccess = "Record fetched successfully";


    }
}
