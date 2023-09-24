using UnityEngine;

class BulletDownHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);
            collision.GetComponent<Mover>().Damaged(5);
        }
    }
}
