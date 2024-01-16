using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody enemyRigidbody;
    private GameObject playerReference;
    private float lowerLimit = -3f;
    private SpwnManager Spawnmanager;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        playerReference = GameObject.Find("Player");
        Spawnmanager = FindObjectOfType<SpwnManager>();
    }
    private void Update()
    {
        //calcura vector enemy--player  vector dado por dos puntos--- V AB = B - A --- punto de player menos punto de enemigo

        Vector3 direccion = (playerReference.transform.position - transform.position);

        direccion = direccion.normalized;

        //direccion = destino - origen
        // destino = posicion player
        //origen = posicion enemigo 

        enemyRigidbody.AddForce (direccion * speed );

        //destroy enemy when dies

        if(transform.position.y < lowerLimit)
        {
            Spawnmanager.EnemmyDestry();
            Destroy(gameObject);
            
        }

    }
}
