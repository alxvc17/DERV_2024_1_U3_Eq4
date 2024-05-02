using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovInicialProyectil : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    float fuerza;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerza, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
