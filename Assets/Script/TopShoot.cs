using UnityEngine;
using System.Collections;
class TopShoot : MonoBehaviour
{
    public Transform ShootTopPoint;
    public GameObject BulletDown;
    private bool CanFire = true;
    private void FixedUpdate()
    {
        Vector2 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = transform.position;
        gunpos.y = 4;
        float NewX = gunpos.x;
        NewX = Mathf.Clamp(NewX, 1.5f, 14.5f);
        gunpos.x = NewX;
        transform.position = Vector2.Lerp(currPos, gunpos, 3f);
        if (Input.GetButtonDown("Fire1") && CanFire == true)
        {
            ShootTop();
            StartCoroutine(FireDelay());
        }
    }
    void ShootTop()
    {
        Quaternion spawnrotation = Quaternion.Euler(0, 0, 0);
        Instantiate(BulletDown, ShootTopPoint.position, spawnrotation);
    }
    IEnumerator FireDelay()
    {
        CanFire = false;
        yield return new WaitForSeconds(1f);
        CanFire = true;
    }
}
