using UnityEngine;
using System;
using ProjectSK.Data;

namespace ProjectSK.Map
{
    public abstract class MapEventBase : ScriptableObject
    {
        public static event Action<MapEventBase> OnMapEventStartToStart;
        public static event Action<MapEventBase> OnMapEventEnded;

        [SerializeField] private MapSetting mapSetting;
        public MapSetting MapSetting { get { return mapSetting; } }

        protected SaveData Save { get; private set; }

        public void Start(SaveData saveData)
        {
            Save = saveData;
            OnMapEventStartToStart?.Invoke(this);
            DoMapEvent();
        }

        protected void EndMapEvent()
        {
            Save = null;
            OnMapEventEnded?.Invoke(this);
        }

        protected abstract void DoMapEvent();
    }
}