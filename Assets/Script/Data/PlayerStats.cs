using System.Collections.Generic;

namespace ProjectSK.Data
{
    public class PlayerStats 
    {
        public List<int> Knoledge { get; private set; } = new List<int>();
        public List<int> Stuits { get; private set; } = new List<int>();
        public int Stamina { get; private set; }
        public int StaminaLevel { get; private set; }
        public int StaminaExp { get; private set; }
        public int Gold { get; private set; }
    }
}