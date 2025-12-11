using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILDMS.Model.CBPSModule
{
    public class BPS_BoxLocation
    {
        public string BoxLocationID { get; set; }
        public string UDLocationName { get; set; }
        public string LocationName { get; set; }
        public string Location { get; set; }
        public string Building { get; set; }
        public string BuildingName { get; set; }
        public string Floor { get; set; }
        public string FloorName { get; set; }
        public string Room { get; set; }
        public string RoomName { get; set; }
        public string OthersAddress { get; set; }
        public string Remarks { get; set; }
        public string SetBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string TotalPages { get; set; }
    }
}
