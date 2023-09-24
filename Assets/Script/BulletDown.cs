using UnityEngine;

class BulletDown : MonoBehaviour
{
    public float speed = 1000f;
    public float BottomLimit = 1.25f;

    private void Update()
    {
        if (transform.position.y <= BottomLimit)
            Destroy(gameObject);
    }
}
