using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        PlayerControlls.Instance.canMove = false;
        winScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
