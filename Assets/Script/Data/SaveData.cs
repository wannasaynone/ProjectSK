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

        public void SetUpWithDefaultSetting()
        {
            Player = new PlayerStats();
            MissionStats = new MissionStats();
            Rocker = new CharacterStats("Rocker", 0, 0, 0, 0);
            Senpai = new CharacterStats("Senpai", 0, 0, 0, 0);
            Gal = new CharacterStats("Gal", 0, 0, 0, 0);
        }
    }
}