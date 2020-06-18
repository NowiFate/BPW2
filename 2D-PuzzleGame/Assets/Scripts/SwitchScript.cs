using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    private bool isPulled = false;

    public GameObject switchingObject, switchedObject;

    private void Start()
    {
        switchedObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPulled == false)
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);
                isPulled = true;

                //switching
                switchingObject.SetActive(false);
                switchedObject.SetActive(true);
            }
        }
    }
}
