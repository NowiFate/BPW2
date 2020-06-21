using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        StartCoroutine(Death());
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    IEnumerator Death()
    {
        PlayerControlls.Instance.canMove = false;
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
