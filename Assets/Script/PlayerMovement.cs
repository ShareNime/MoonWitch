using UnityEngine;

class PlayerMovement : MonoBehaviour
{
    public float YOffset;
    private Vector2 TargetPos;
    public float YLimit;
    public float Speed;
    private void Update()
    {
        
        Vector2 CurrentPos = transform.position;
        if (Input.GetKeyDown("w"))
        {
            setTargetPos(CurrentPos, YOffset);
        }
        else if (Input.GetKeyDown("s"))
        {
            setTargetPos(CurrentPos, -YOffset);
        }
        transform.position = Vector2.MoveTowards(CurrentPos, TargetPos, Speed * Time.deltaTime);
    }
    private void setTargetPos(Vector2 currentPos, float YOffset)
    {
        float NewY = currentPos.y + YOffset;
        NewY = Mathf.Clamp(NewY, -YLimit, 0);
        TargetPos = new Vector2(currentPos.x, NewY);
    }
}
