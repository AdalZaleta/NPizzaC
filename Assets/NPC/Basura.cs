using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Basura : MonoBehaviour
{
    bool hit = false;
    private void Start()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("coolided w/" + collision.collider.gameObject.name);
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = hit ? Random.ColorHSV() : Color.blue;
            hit = true;
        }
    }
}
