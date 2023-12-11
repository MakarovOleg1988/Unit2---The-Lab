using UnityEngine;

namespace Lab2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Range(10f, 250f)]
        private float speedMovePlayer;

        [SerializeField]
        private float sizeBound = 8f;

        private Rigidbody rbPlayer;

        private void Start()
        {
            rbPlayer = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            MovementPlayer();
            CheckWall();
        }

        private void MovementPlayer()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            rbPlayer.AddForce(Vector3.forward * speedMovePlayer * verticalInput);
            rbPlayer.AddForce(Vector3.right * speedMovePlayer * horizontalInput);
        }

        private void CheckWall()
        {
            if (transform.position.z < -sizeBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -sizeBound);
            }
            if (transform.position.z > sizeBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, sizeBound);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Player has collided with some enemy");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
