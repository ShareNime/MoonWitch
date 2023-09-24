using UnityEngine;
using System.Collections;
using UnityEngine.UI;
class Mover : MonoBehaviour
{
    public float Speed;
    public float LeftLimit;
    public int MaxHealth;
    public int CurrHealth;
    public Animator anim;
    private int Score;
    // Update is called once per frame
    private void Start()
    {
        CurrHealth = MaxHealth;
        Score = MaxHealth * 10;
    }
    private void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
        if (transform.position.x <= LeftLimit)
            Destroy(gameObject);
    }
    public void Damaged(int damage)
    {
        CurrHealth -= damage;
        anim.SetTrigger("Hit");
        
        if (CurrHealth <= 0)
        {
            Dead();
            FindObjectOfType<ScoreSystem>().Score += Score;
            FindObjectOfType<ScoreSystem>().ScoreUpdate(FindObjectOfType<ScoreSystem>().Score);
        }
    }
    private void Dead()
    {
        StartCoroutine(Mati());
        
    }
    private IEnumerator Mati()
    {
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
