using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
