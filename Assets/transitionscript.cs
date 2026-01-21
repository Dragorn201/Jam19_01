using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionscript : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        Debug.Log("Animation has ended!");
        SceneManager.LoadScene("MainGame");
    }
}
