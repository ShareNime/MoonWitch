using UnityEngine;
using System.Collections;
class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    private bool CanFire = true;
    int angkarandom;
    private void Update()
    {
        if (Input.GetKeyDown("space") && CanFire == true)
        {
            angkarandom = Random.Range(1, 5);
            if(angkarandom < 3)
            {
                FindObjectOfType<AudioManager>().Play("Attack2");
            }else if(angkarandom > 3)
            {
                FindObjectOfType<AudioManager>().Play("Attack3");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Attack1");
            }
            FireBullet();
            StartCoroutine(FireDelay());
        }
    }
    void FireBullet()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    IEnumerator FireDelay()
    {
        CanFire = false;
        yield return new WaitForSeconds(0.3f);
        CanFire = true;
    }
}
