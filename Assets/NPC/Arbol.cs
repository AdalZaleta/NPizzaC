using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace IA
{
    public class Arbol : MonoBehaviour
    {
        [HideInInspector]
        public Nodo Root = new Nodo("Hola", false);
        public GameObject Dialogo;
        public GameObject Respuestas;
        public GameObject PrefbRespuestas;
        bool NextDiag;
        public float letterPause = 0.2f;
        Nodo Temp;

        private void Start()
        {
            InitializeTree();
            StartConversation();
            //StartCoroutine("StartDialog");
        }

        void InitializeTree()
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

            Temp = Root;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                if (!NextDiag)
                    NextDiag = true;
            }
        }

        public void StartConversation()
        {
            TextMeshProUGUI DialogoNPC = Dialogo.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            GameObject go;
                
            //Debug.Log("NPC SAYS: " + Temp.Dialogo);
            DialogoNPC.text = Temp.Dialogo;
            //Debug.Log("Posibles respuestas:");
            //Debug.Log("Mis hijos: " + Temp.Hijos.Count);
            if (Respuestas.transform.childCount > 0)
            {
                Debug.Log("Cleaning childs...");
                while (Respuestas.transform.childCount > 0)
                {
                    Transform child = Respuestas.transform.GetChild(0);
                    child.parent = null;
                    Destroy(child.gameObject);
                }
            }

            for (int i = 0; i < Temp.Hijos.Count; i++)
            {
                int tempnum = i;
                go = Instantiate(PrefbRespuestas, Vector3.zero, Quaternion.identity);
                //Debug.Log("Intancia del Objeto relizada");
                go.GetComponentInChildren<Button>().onClick.AddListener(() => NextDialog(tempnum));
                go.GetComponentInChildren<TextMeshProUGUI>().text = Temp.Hijos[i].Dialogo;
                go.gameObject.transform.SetParent(Respuestas.transform);
                go.transform.localPosition = Vector3.zero;
                //Debug.Log("Posición Local seteada a cero");
                go.transform.localScale = Vector3.one;
                //Debug.Log("Escala local seteada a cero");
                //Debug.Log("__" + Temp.Hijos[i].Dialogo);
            }

            print("FINALIZADO. ACTION: " + Temp.Action);
        }

        public void NextDialog(int _hijo)
        {
            Debug.Log("Valor que recibi de hijo: " + _hijo);
            Temp = Temp.Hijos[_hijo];
            Debug.Log("Mis nietos: " + Temp.Hijos.Count);
            if(Temp.Action == Actions.Nada)
            {
                StartConversation();
            }

        }

        public IEnumerator StartDialog()
        {
            Nodo Temp = Root;
            bool prnt = true;
            while (Temp.Action == Actions.Nada)
            {
                if (prnt)
                {
                    Debug.ClearDeveloperConsole();
                    if (!Temp.IsUserResponse)
                    {
                        Debug.Log("NPC SAYS: " + Temp.Dialogo);
                        Debug.Log("Posibles respuestas:");
                        for (int i = 0; i < Temp.Hijos.Count; i++)
                        {
                            Debug.Log("__" + Temp.Hijos[i].Dialogo);
                        }
                    }
                    else
                    {
                        Debug.Log("USER SAYS: " + Temp.Dialogo);
                        NextDiag = true;
                    }
                    prnt = false;
                }

                if (NextDiag)
                {
                    yield return new WaitForEndOfFrame();
                    NextDiag = false;
                    Temp = Temp.Hijos.SelectOneRandom();
                    prnt = true;
                }
                else
                    yield return new WaitForEndOfFrame();
            }
            print("FINALIZADO. ACTION: " + Temp.Action);
        }
    }
}

