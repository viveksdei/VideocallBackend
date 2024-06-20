using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class PageRequestVM
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string ClinicID { get; set; }
        public string SearchText { get; set; }
        public string SearchColumn { get; set; }
    }
}
