using UnityEngine;
using System.Collections;
class Bullet : MonoBehaviour
{
    public float speed = 1000f;
    public Rigidbody2D rb;
    public float rightlimit = 25f;
    public Animator anim;
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
    }

    private void Update()
    {
        if (transform.position.x >= rightlimit)
            Destroy(gameObject);
    }
    public void testing()
    {
        StartCoroutine(HitEnemy());
    }
    public IEnumerator HitEnemy()
    {
        speed = 0;
        GetComponent<Bullet>().anim.SetTrigger("Hit");
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
