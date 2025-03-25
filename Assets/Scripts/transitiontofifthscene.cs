using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonSceneTransition : MonoBehaviour
{
    public string nextSceneName = "fifthscene";
    public float transitionDelay = 1.0f;
    public AudioSource buttonSound; // Optional

    private XRSimpleInteractable interactable;

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnButtonPressed);
        }
        else
        {
            Debug.LogError("No XR Simple Interactable found on this object");
        }
    }

    public void OnButtonPressed(SelectEnterEventArgs args)
    {
        // Play sound if available
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
        
        // Visual feedback (could make button glow or change color)
        Debug.Log("Button pressed! Transitioning to " + nextSceneName + " in " + transitionDelay + " seconds");
        
        // Load next scene after delay
        Invoke("LoadNextScene", transitionDelay);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}