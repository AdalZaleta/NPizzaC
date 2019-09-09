using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField]
        float speed = 1;
        bool isTalking = false;
        // Start is called before the first frame update
        void Start()
        {
            if (Manager.Player == null)
                Manager.Player = this;
        }

        // Update is called once per frame
        void Update()
        {
            //movimiento (bloqueado si esta conversando)
            if (!isTalking)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                transform.Translate(new Vector3(horizontal, 0, vertical) * speed);

                //Distancia con el npc
                float distance = Vector3.Distance(transform.position, Manager.ArbolNPC.gameObject.transform.position);
                if (distance < 2)
                {
                    isTalking = true;
                    //mandar llamar el método de dialogo
                    Manager.ArbolNPC.IniciaDialogo();
                }
            }
            
        }
    }

}
