using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionToSecond : MonoBehaviour
{
    public string nextSceneName = "secondscene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
