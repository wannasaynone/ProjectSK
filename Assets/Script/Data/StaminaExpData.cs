namespace ProjectSK.Data
{
    public class StaminaExpData : KahaGameCore.GameData.IGameData
    {
        public int ID { get; private set; }
        public int Stamina { get; private set; }
        public int RequireExp { get; private set; }
    }
}