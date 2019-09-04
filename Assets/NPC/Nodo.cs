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
        public bool IsUserResponse;

        public Nodo(string dialogo, bool isUser, Actions act = Actions.Nada)
        {
            IsUserResponse = isUser;
            Hijos = new List<Nodo>();
            Dialogo = dialogo;
            Action = act;
        }
    }
}

