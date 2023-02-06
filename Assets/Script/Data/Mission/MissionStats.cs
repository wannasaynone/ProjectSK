using System;
using System.Collections.Generic;

namespace ProjectSK.Data.Mission
{
    public class MissionStats
    {
        public static event Action<MissionStats> OnMissionStatsUpdated;

        public struct CharacterNameContainer { public string Name { get; private set; } public CharacterNameContainer(string name) { Name = name; } }
        public struct MapNameContainer { public string Name { get; private set; } public MapNameContainer(string name) { Name = name; } }

        private readonly List<Mission> holdingMission = new List<Mission>();

        public MissionStats()
        {
            Mission.OnCompleted += OnMissionCompleted;
        }

        public bool IsHavingMission()
        {
            return holdingMission.Count > 0;
        }

        public bool IsHavingMission(MapNameContainer map)
        {
            return GetMission(map) != null;
        }

        public bool IsHavingMission(CharacterNameContainer character, MapNameContainer map)
        {
            return GetMission(character, map) != null;
        }

        public Mission GetMission(CharacterNameContainer character, MapNameContainer map)
        {
            return holdingMission.Find(mission => mission.targetCharacterName == character.Name && mission.targetMapName == map.Name);
        }

        public Mission GetMission(MapNameContainer map)
        {
            return holdingMission.Find(mission => mission.targetMapName == map.Name);
        }

        public void AddMission(Mission mission)
        {
            if (GetMission(new CharacterNameContainer(mission.targetCharacterName), new MapNameContainer(mission.targetMapName)) != null)
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