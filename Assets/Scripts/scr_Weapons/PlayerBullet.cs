using System.Collections;
using scr_Interfaces;
using UnityEngine;

namespace scr_Weapons
{
    public class PlayerBullet : MonoBehaviour
    {
        [HideInInspector] public float bulletSpeed;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public float bulletDamage;
        private Rigidbody2D _rb;

        private string _target;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rb.AddRelativeForce(Vector3.right * bulletSpeed,ForceMode2D.Impulse);
            StartCoroutine(BulletDestroy());
        }
        public void CreateBullet(string targetTag, float damage, float speed)
        {
            _target = targetTag;
            bulletDamage = damage;
            bulletSpeed = speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_target))
            {
                other.gameObject.GetComponent<IDamageable>().TakeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
        private IEnumerator BulletDestroy()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}

