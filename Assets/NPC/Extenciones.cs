using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    public static class Extenciones
    {
        public static T SelectOneRandom<T>(this List<T> list)
        {
            int index = Random.Range(0, list.Count);
            return list[index];
        }
    }
}

