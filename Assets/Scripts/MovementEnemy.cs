using UnityEngine;

namespace Lab2
{
    public class MovementEnemy : MonoBehaviour
    {
        [SerializeField]
        private float _speedMovement;

        [SerializeField]
        private float _zBound;

        private Rigidbody _enemyRb;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Movement();
            CheckBoard();
        }

        private void Movement()
        {
            _enemyRb.AddForce(Vector3.forward * -_speedMovement);
        }

        private void CheckBoard()
        {
            if (transform.position.z < _zBound)
            { 
                Destroy(this.gameObject);
            }
        }
    }
}
