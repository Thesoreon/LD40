using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Animator[] anim;

    public void EndGame()
    {
        anim[0].SetBool("Swap", true);
        anim[1].SetBool("Show", true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
	
    public void GoToTheMenu()
    {

    }
}
