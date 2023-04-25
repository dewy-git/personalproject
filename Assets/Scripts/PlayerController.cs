using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 1;
    public bool gameOver;

    private float powerupStrength = 15.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Keep the player in bounds
        if (transform.position.x < -4)
        {
            transform.position = new Vector3(-4, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 4)
        {
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            Destroy(gameObject);
        }
    }
}
