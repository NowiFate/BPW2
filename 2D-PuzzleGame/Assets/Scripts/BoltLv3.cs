using UnityEngine.Events;
using UnityEngine;

public class BoltLv3 : MonoBehaviour
{
    public UnityEvent startOnCollision;
    public AudioSource boltSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boltSound.Play();
            startOnCollision?.Invoke();
        }
    }
}
