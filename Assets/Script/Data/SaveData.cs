using ProjectSK.Data.Mission;

namespace ProjectSK.Data
{
    public class SaveData 
    {
        public PlayerStats Player { get; private set; }
        public MissionStats MissionStats { get; private set; }
        public CharacterStats Rocker { get; private set; }
        public CharacterStats Senpai { get; private set; }
        public CharacterStats Gal { get; private set; }
    }
}