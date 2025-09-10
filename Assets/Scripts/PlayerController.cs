using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float MoveSpeed ;
    private GameObject focalPoint;
    public bool HasPowerUp = false;

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
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.CompareTag("Enemy") && HasPowerUp)
         {
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + HasPowerUp);
        }
    }
}
