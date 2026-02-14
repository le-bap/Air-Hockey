using UnityEngine;

public class AIPlayerControl : MonoBehaviour
{
    public Transform ball; 
    public float speed = 5f;
    public bool isTopPlayer = true;

    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D upWall;
    public BoxCollider2D downWall;

    private CircleCollider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (ball == null)
            return;

        Vector3 pos = transform.position;
        float radius = playerCollider.bounds.extents.y;

        if (pos.x - radius < leftWall.bounds.max.x)
            pos.x = leftWall.bounds.max.x + radius;
        if (pos.x + radius > rightWall.bounds.min.x)
            pos.x = rightWall.bounds.min.x - radius;

        float minY = downWall.bounds.max.y + radius;
        float maxY = upWall.bounds.min.y - radius;

        bool ballOnMySide = isTopPlayer ? (ball.position.y > 0) : (ball.position.y < 0);

        if (ballOnMySide)
        {
            float directionX = ball.position.x - pos.x;
            pos.x += Mathf.Sign(directionX) * speed * Time.deltaTime;

            float directionY = ball.position.y - pos.y;
            pos.y += Mathf.Sign(directionY) * speed * Time.deltaTime;

            pos.y = Mathf.Clamp(pos.y, minY, maxY);
        }

        transform.position = pos;
    }

}
