using UnityEngine;
using UnityEngine.UI;

public class PlayerControlls : MonoBehaviour
{
    public static PlayerControlls Instance;
    public float moveSpeed =1f;
    public float jumpHeight = 1f;
    public int blocksNumber;
    public bool canMove = true;

    public Text blockText;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //textupdate
        blockText.text = "Blocks :" + blocksNumber.ToString();

        //reset
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Manager.Instance.GameOver();
        }

        if (canMove == true)
        {
            //Movement
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

            transform.position += movement * Time.deltaTime * moveSpeed;

            //Flip character
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }

            //jump
            if (Input.GetButtonDown("Jump"))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            }

            //Place Blocks
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (blocksNumber > 0)
                {
                    BlockScript.Instance.SpawnBlock();
                }
            }
        }
    }
}
