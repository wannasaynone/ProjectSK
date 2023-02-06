namespace ProjectSK.Data
{
    public class CharacterStats 
    {
        public string Name { get; private set; }
        public int Horny { get; private set; }
        public int Love { get; private set; }
        public int Suspect { get; private set; }
        public int Lonely { get; private set; }

        public CharacterStats() { }
        public CharacterStats(string name, int horny, int love, int suspect, int loney)
        {
            Name = name;
            Horny = horny;
            Love = love;
            Suspect = suspect;
            Lonely = loney;
        }
    }
}