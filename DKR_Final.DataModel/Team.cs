using System;
using System.Collections.Generic;
using System.Text;

namespace DKR_Final.DataModel
{
   public class Team
    {
        public int teamID { get; set; }
        public string teamName { get; set; }
        public string managerName { get; set; }
        public List<Player> Players { get; set; }
    }
}
