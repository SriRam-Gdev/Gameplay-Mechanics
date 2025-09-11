using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float MoveSpeed ;
    private GameObject focalPoint;
    public bool HasPowerUp = false;
    private float powerUpStrength = 15.0f;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * MoveSpeed * forwardInput);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerups"))
        {
            HasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        HasPowerUp = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.CompareTag("Enemy") && HasPowerUp)
         {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            
        }
    }
}
