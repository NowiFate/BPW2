using UnityEngine;
using UnityEngine.UI;

public class PlayerControlls : MonoBehaviour
{
    public static PlayerControlls Instance;
    public float moveSpeed =3f;
    public float jumpHeight = 5f;
    public int blocksNumber;
    public bool canMove = true;
    public Transform groundCheckBehind;
    public Transform groundCheckFront;
    public LayerMask groundLayer;
    public Text blockText;
    public Sprite holding, notHolding;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //textupdate
        blockText.text = "Blocks: " + blocksNumber.ToString();

        //Sprite update
        if (holding != null && notHolding != null)
        {
            if(blocksNumber > 0 )GetComponent<SpriteRenderer>().sprite = holding;
            else
            {
                GetComponent<SpriteRenderer>().sprite = notHolding;
            }
        }

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
            if (Physics2D.Raycast(groundCheckBehind.transform.position, -Vector2.up, 0.1f, groundLayer) || 
                Physics2D.Raycast(groundCheckFront.transform.position, -Vector2.up, 0.1f, groundLayer))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
                }

            }

            //Place Blocks
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (blocksNumber > 0) BlockScript.Instance.SpawnBlock();
            }
        }
    }
}
