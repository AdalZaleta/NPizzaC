using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    public class Arbol : MonoBehaviour
    {
        public Nodo Root = new Nodo("Hola", false);
        private void Start()
        {
            //nivel final
            Nodo Vamos = new Nodo("Yo conozco una mejor, vamos", false, Actions.Pizza);
            Nodo TeMuestro = new Nodo("Yo te muestro una", false, Actions.Pizza);
            Nodo Enjado = new Nodo("ÒnÓ", false, Actions.Matar);
            Nodo Repetir = new Nodo("Hay que intentarlo de nuevo", false, Actions.Repetir);

            //tercer nivel
            Nodo UnoBueno = new Nodo("Sí, conozco una muy buena", true);
            UnoBueno.Hijos.Add(Vamos);

            Nodo NoSoy = new Nodo("No, no soy de aquí", true);
            NoSoy.Hijos.Add(TeMuestro);

            Nodo NoConozco = new Nodo("No te conozco, aléjate", true);
            NoConozco.Hijos.Add(Enjado);

            Nodo Silecio2 = new Nodo("...", true);
            Silecio2.Hijos.Add(Repetir);

            //Segundo nivel
            Nodo Conoces = new Nodo("¿Conoces alguna pizzería?", false);
            Conoces.Hijos.Add(UnoBueno);
            Conoces.Hijos.Add(NoSoy);
            Conoces.Hijos.Add(NoConozco);

            Nodo TeHablo = new Nodo("Oye, te estoy hablando", false);
            TeHablo.Hijos.Add(NoConozco);
            TeHablo.Hijos.Add(Silecio2);

            //Primer nivel
            Nodo Hola = new Nodo("¡Hola!", true);
            Hola.Hijos.Add(Conoces);

            Nodo MeHablas = new Nodo("¿Me hablas a mi?", true);
            MeHablas.Hijos.Add(Conoces);
            MeHablas.Hijos.Add(TeHablo);

            Nodo Silencio1 = new Nodo("...", true);
            Silencio1.Hijos.Add(TeHablo);

            //Añadir a la raiz
            Root.Hijos.Add(Hola);
            Root.Hijos.Add(MeHablas);
            Root.Hijos.Add(Silencio1);
        }

        public void StartDialog()
        {

        }
    }
}

