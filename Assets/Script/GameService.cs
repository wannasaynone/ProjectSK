using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectSK
{
    public class GameService
    {
        private static Dictionary<Type, object> m_typeToInstance = new Dictionary<Type, object>();

        public static void Register<T>(T obj) where T : class
        {
            if (m_typeToInstance.ContainsKey(typeof(T)))
            {
                Debug.Log("[GameService] already contains key:" + typeof(T).Name);
                return;
            }

            m_typeToInstance.Add(typeof(T), obj);
        }

        public static T Get<T>() where T : class
        {
            if (!m_typeToInstance.ContainsKey(typeof(T)))
            {
                return null;
            }

            return m_typeToInstance[typeof(T)] as T;
        }
    }
}