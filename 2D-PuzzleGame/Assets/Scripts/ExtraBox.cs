using UnityEngine;

public class ExtraBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControlls.Instance.blocksNumber += 1;
            Destroy(gameObject);
        }
    }
}
