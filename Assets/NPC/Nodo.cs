using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    public enum Actions
    {
        Repetir,
        Matar,
        Pizza,
        Nada
    }
    [System.Serializable]
    public struct Nodo
    {
        public string Dialogo;
        public List<Nodo> Hijos;
        public Actions Action;

        public Nodo(string dialogo, Actions act = Actions.Nada)
        {
            Hijos = new List<Nodo>();
            Dialogo = dialogo;
            Action = act;
        }
    }
}

