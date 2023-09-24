using UnityEngine;

class EnemyDamage : MonoBehaviour
{
    private int damage;
    GameObject a;
    int angkarandom;
    private void Awake()
    {
        a = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerGate"))
        {
            angkarandom = Random.Range(1,5);
            if (collision.CompareTag("Player"))
            {
                if(angkarandom <= 2)
                {
                    FindObjectOfType<AudioManager>().Play("Hit1");
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Hit2");
                }
                
            }else if (collision.CompareTag("PlayerGate"))
            {
                FindObjectOfType<AudioManager>().Play("PortalHit");
            }
            damage = this.gameObject.GetComponent<Mover>().MaxHealth;
            a.GetComponent<HealthSystem>().DamagePlayer(damage);
            Debug.Log("damage Player");
            Destroy(gameObject);
        }
        
    }
}
