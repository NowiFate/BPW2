using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    private bool isPulled = false;
    public SpriteRenderer switchingObject;
    public SpriteRenderer switchedObject;
    public Sprite switchOn, switchOff;
    public BoxCollider2D switchingCollider;
    public BoxCollider2D switchedCollider;

    private void Start()
    {
        switchingObject.sprite = switchOn;
        switchingCollider.enabled = true;
        switchedObject.sprite = switchOff;
        switchedCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Switch();
        }
    }

    private void Switch()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);

        if (isPulled == false)
        {
            isPulled = true;

            switchingObject.sprite = switchOff;
            switchingCollider.enabled = false;
            switchedObject.sprite = switchOn;
            switchedCollider.enabled = true;
        }
        else
        {
            isPulled = false;

            switchingObject.sprite = switchOn;
            switchingCollider.enabled = true;
            switchedObject.sprite = switchOff;
            switchedCollider.enabled = false;
        }
    }
}
