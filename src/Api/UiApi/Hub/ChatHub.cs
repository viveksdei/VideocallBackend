using Core.App.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Drawing.Printing;

namespace UiApi.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IApplicationDbContext _dbContext;

        public ChatHub(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
       
        }
        static IList<UserConnection> Users = new List<UserConnection>(); 

        public class UserConnection
        {
            public string UserId { get; set; }
            public string ConnectionId { get; set; }
            public string FullName { get; set; }
            public string Username { get; set; }
        }


        public async Task CallInitiate(int patientid, int fromcall)
        {
            try
            {
                var UserDetails = "Marvin Nguyen"; /*_dbContext.Patients.Where(x => x.UserId == fromcall).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();*/
                await Clients.All.SendAsync("CallInitiated", patientid, UserDetails);

            }
            catch (Exception)
            {
            }
        }

        public async Task CallEnd(int UserId)
        {
            try
            {
                //var result = _therapist.GetTokenById(new GetTokenDto { UserId = UserId.ToString() });
                //var g = (PatientSessionSlotBooking)result.Result.ResponseData;
                //var UserResult = _dbContext.Therapist.Where(x => x.TherapistId == g.TherapistId).Select(x => x.UserId).FirstOrDefault();
                //await Clients.All.SendAsync("CallEnded", UserResult);

            }
            catch (Exception)
            {
            }
        }
    }
}
