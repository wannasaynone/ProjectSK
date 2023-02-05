using System;

namespace ProjectSK.Data.Mission
{
    public class Mission 
    {
        public static event Action<Mission> OnCompleted;

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