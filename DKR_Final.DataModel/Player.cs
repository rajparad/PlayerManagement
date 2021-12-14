using System;
using System.Collections.Generic;
using System.Text;

namespace DKR_Final.DataModel
{
   public class Player
    {
        public int playerID { get; set; }
        public string playerName { get; set; }
        public int playerAge { get; set; }
        public int teamId { get; set; }
        public Team team { get; set; }
    }
}
