using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public GameObject winScreen;
    public bool isFinalStage = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isFinalStage == false)
            {
                StartCoroutine(NextLevel());
            }
            else
            {
                StartCoroutine(LastLevel());
            }
        }
    }

    IEnumerator NextLevel()
    {
        PlayerControlls.Instance.canMove = false;
        winScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LastLevel()
    {
        PlayerControlls.Instance.canMove = false;
        Destroy(BGPlayer.instance.gameObject);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
