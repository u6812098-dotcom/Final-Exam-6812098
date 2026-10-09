using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
namespace Sumo
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
        public float speed;
        private GameObject focalPoint;
        public bool hasPowerup;
        private float powerupStrength = 15.0f;
        public GameObject powerupIndicator;
        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        // Update is called once per frame
        void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                Destroy(other.gameObject);
                powerupIndicator.SetActive(true);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {
                Rigidbody enenmyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
                Debug.Log("Player Collided with " + collision.gameObject + " and has powerup");
                enenmyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
        }

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7); hasPowerup = false;
            powerupIndicator.SetActive(false);

        }
    }
}
