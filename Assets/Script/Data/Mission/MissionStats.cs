using System;
using System.Collections.Generic;

namespace ProjectSK.Data.Mission
{
    public class MissionStats
    {
        public static event Action<MissionStats> OnMissionStatsUpdated;

        private readonly List<Mission> holdingMission = new List<Mission>();

        public MissionStats()
        {
            Mission.OnCompleted += OnMissionCompleted;
        }

        public bool IsHavingMission()
        {
            return holdingMission.Count > 0;
        }

        public bool IsHavingMission(string character, string map)
        {
            return GetMission(character, map) != null;
        }

        public Mission GetMission(string character, string map)
        {
            return holdingMission.Find(mission => mission.targetCharacterName == character && mission.targetMapName == map);
        }

        public Mission GetMission(string map)
        {
            return holdingMission.Find(mission => mission.targetMapName == map);
        }

        public void AddMission(Mission mission)
        {
            if (GetMission(mission.targetCharacterName, mission.targetMapName) != null)
            {
                return;
            }

            holdingMission.Add(mission);
            OnMissionStatsUpdated?.Invoke(this);
        }

        private void OnMissionCompleted(Mission mission)
        {
            holdingMission.Remove(mission);
        }
    }
}