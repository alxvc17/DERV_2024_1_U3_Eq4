using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzadorProyectiles : MonoBehaviour
{
    [SerializeField]
    GameObject bala;

    [SerializeField]
    GameObject spawnBala;

    public List<GameObject> balas;
    void Start()
    {
        balas = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject b = Instantiate(bala,
                spawnBala.transform.position,
                spawnBala.transform.rotation
            );
            b.SetActive(false);
            balas.Add(b);
        }
        contBalaDisparada = 0;
    }

    int contBalaDisparada;

    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Disparo");
            if (contBalaDisparada < balas.Count)
            {
                balas[contBalaDisparada].SetActive(true);
                contBalaDisparada++;
            }
            else
            {
                Reiniciar();
            }
        }
    }

    void Reiniciar()
    {
        foreach (GameObject b in balas)
        {
            if (b != null)
            {
                b.SetActive(false);
                b.transform.position = spawnBala.transform.position;
                b.transform.rotation = spawnBala.transform.rotation;
            }
        }
        contBalaDisparada = 0;
    }
}
