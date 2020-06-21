using UnityEngine;
using UnityEngine.Events;

public class SwitchScript : MonoBehaviour
{
    private bool isPulled = false;

    public UnityEvent switchingOn;
    public UnityEvent switchingOff;
    public GameObject energyBolt;
    public AudioSource switchSound;
    public AudioSource Bolt;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject == energyBolt)
        {
            if (collision.gameObject == energyBolt)
            {
                Bolt.Play();
                Destroy(energyBolt.gameObject);
            }
            else
            {
                switchSound.Play();
            }
            Switch();
        }
    }

    private void Switch()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);

        if (isPulled == false)
        {
            isPulled = true;
            switchingOn?.Invoke();
        }
        else
        {
            isPulled = false;
            switchingOff?.Invoke();
        }
    }
}
