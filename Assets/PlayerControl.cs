using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CircleCollider2D playerCollider;

    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D upLeftWall;
    public BoxCollider2D upRightWall;
    public BoxCollider2D downLeftWall;
    public BoxCollider2D downRightWall;

    void Start()
    {
        playerCollider = GetComponent<CircleCollider2D>();

        Transform wallsParent = GameObject.Find("Walls").transform;

        leftWall = wallsParent.Find("LeftWall").GetComponent<BoxCollider2D>();
        rightWall = wallsParent.Find("RightWall").GetComponent<BoxCollider2D>();
        upLeftWall = wallsParent.Find("UpLeftWall").GetComponent<BoxCollider2D>();
        upRightWall = wallsParent.Find("UpRightWall").GetComponent<BoxCollider2D>();
        downLeftWall = wallsParent.Find("DownLeftWall").GetComponent<BoxCollider2D>();
        downRightWall = wallsParent.Find("DownRightWall").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 pos = mousePos;

        float radius = playerCollider.bounds.extents.x;

        if (pos.x - radius < leftWall.bounds.max.x)
            pos.x = leftWall.bounds.max.x + radius;

        if (pos.x + radius > rightWall.bounds.min.x)
            pos.x = rightWall.bounds.min.x - radius;

        if (pos.y - radius < downLeftWall.bounds.max.y)
            pos.y = downLeftWall.bounds.max.y + radius;

        if (pos.y + radius > upLeftWall.bounds.min.y)
            pos.y = upLeftWall.bounds.min.y - radius;
        
        float maxY = 0f - radius;
        pos.y = Mathf.Clamp(pos.y, downLeftWall.bounds.max.y + radius, maxY);

        transform.position = pos;
    }
}
