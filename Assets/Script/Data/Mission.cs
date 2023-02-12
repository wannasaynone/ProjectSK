using System;

namespace ProjectSK.Data.Mission
{
    public class Mission 
    {
        public static event Action<Mission> OnCompleted;

        public struct MissionTypeCollection
        {
            public readonly string NormalDate;
            public readonly string ImportantDate;
            public readonly string HentaiDate;
            public readonly string Court;

            public MissionTypeCollection(string normalDate = "NormalDate", string importantData = "ImportantDate", string hentaiDate = "HentaiDate", string court = "Court")
            {
                NormalDate = normalDate;
                ImportantDate = importantData;
                HentaiDate = hentaiDate;
                Court = court;
            }
        }

        public static readonly MissionTypeCollection missionTypeCollection = new MissionTypeCollection();
  
        public string targetCharacterName;
        public string targetMapName;
        public string missionType;

        public bool IsCompleted { get; private set; } = false;

        public void Complete()
        {
            IsCompleted = true;
            OnCompleted?.Invoke(this);
        }
    }
}