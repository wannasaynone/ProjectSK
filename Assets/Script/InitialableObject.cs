using UnityEngine;
using ProjectSK.Data;

namespace ProjectSK
{
    public class InitialableObject : MonoBehaviour
    {
        protected SaveData Save { get; private set; }

        public virtual void Initial(SaveData saveData)
        {
            if (Save != null)
            {
                Debug.Log("gameObject " + name + " was initialed, but trying to do it again.");
                return;
            }

            Save = saveData;
        }
    }
}
