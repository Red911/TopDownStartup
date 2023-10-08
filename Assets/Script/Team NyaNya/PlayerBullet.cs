using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _rb;
        [SerializeField] float _bulletSpeed;
        [SerializeField] int _bulletDamage = 1;
        Vector2 bulletDir;

        public Vector2 BulletDir { get => bulletDir; set => bulletDir = value; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if (collision.gameObject.layer == 8) Destroy(gameObject);
            if (collision.gameObject.layer == 8) gameObject.SetActive(false);

            if (collision.gameObject.layer == 7)
            {
                collision.GetComponent<Mob>().Damage(_bulletDamage);
                gameObject.SetActive(false);
            }

        }

        private void FixedUpdate()
        {
            _rb.velocity = bulletDir.normalized * _bulletSpeed * Time.fixedDeltaTime;
        }


    }
}
