using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionToThird : MonoBehaviour
{
    public string nextSceneName = "thirdscene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
