using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables 

    private Rigidbody playerRigidboddy;
    [SerializeField] private float playerSpeed;
    private float forwardInput;
    [SerializeField] private GameObject focalPoint;
    private bool hasPowerUp = false;
    [SerializeField] float PowerUpForce = 10f;

    // funciones

    private IEnumerator PowerupCountdown()
    {
        //espera 6 segundos

        yield return new WaitForSeconds(6);
        hasPowerUp = false;
    }

    //-----------------------------------------------

    private void Awake()
    {
        playerRigidboddy = GetComponent<Rigidbody>();

    }

    

    private void Update()
    {
        //movment
        
        forwardInput = Input.GetAxis("Vertical");
        playerRigidboddy.AddForce(focalPoint.transform.forward * playerSpeed * forwardInput);

        //frenar en seco --- no tiene sentido en este projecto-----mejor configurar drag del rigidbody.
        //valor absoluto
      
        /* if (Mathf.Abs(forwardInput) < 0.01f)
        {
            playerRigidboddy.velocity = Vector3.zero;
        } */
    }


    //power up

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerUp"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerupCountdown());
            Debug.Log(hasPowerUp);
            Destroy(other.gameObject);
           
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("enemy") && hasPowerUp == true)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = other.transform.position - transform.position;
            other.rigidbody.AddForce(direction * PowerUpForce, ForceMode.Impulse);
        }
    }


}
