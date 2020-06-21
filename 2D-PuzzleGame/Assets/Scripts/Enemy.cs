using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool shouldMove = false;
    private bool moveRight = true;
    public float enemySpeed = 2f;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove == true)
        {
            transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
            RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 0.01f, PlayerControlls.Instance.groundLayer);
            if (groundInfo.collider == false || wallInfo.collider == true)
            {
                if(moveRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    moveRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    moveRight = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Manager.Instance.GameOver();
        }

        if (collision.gameObject.tag == "Box")
        {
            Destroy(gameObject);
        }
    }
}
