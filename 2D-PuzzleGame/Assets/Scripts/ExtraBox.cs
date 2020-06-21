using UnityEngine;

public class ExtraBox : MonoBehaviour
{
    public AudioSource powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            powerUp.Play();
            PlayerControlls.Instance.blocksNumber += 1;
            Destroy(gameObject);
        }
    }


}
