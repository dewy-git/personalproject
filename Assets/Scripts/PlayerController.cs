using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 1;
    public bool gameOver;

    public bool hasPowerup1 = false;
    public GameObject powerup1Indicator;
    
    public bool hasPowerup2 = false;
    public GameObject powerup2Indicator;

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

    //powerup 1 (super shield)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup1"))
        {
            hasPowerup1 = true;
            powerup1Indicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(Powerup1CountdownRoutine());
        }
        if (other.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            powerup2Indicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(Powerup2CountdownRoutine());
        }
    }

    IEnumerator Powerup1CountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup1 = false;
        powerup1Indicator.gameObject.SetActive(false);
    }

    IEnumerator Powerup2CountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup2 = false;
        powerup2Indicator.gameObject.SetActive(false);
    }
    
    //collision with catasteroid or powerup
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Powerup1"))
       {
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
       }
    }
}
