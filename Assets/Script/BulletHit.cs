using UnityEngine;

class BulletHit : MonoBehaviour
{
    public bool Hit = false;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            gameObject.GetComponent<Bullet>().testing();
            collision.GetComponent<Mover>().Damaged(1);
        }
    }
}
