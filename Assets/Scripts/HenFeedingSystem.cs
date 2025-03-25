using UnityEngine;
using UnityEngine.SceneManagement;

public class HenFeedingSystem : MonoBehaviour
{
    public int requiredFeedCount = 3; // Number of feed items needed
    public string nextSceneName = "fourthscene"; // The scene to load after feeding
    public GameObject instructionText; // Text telling the user to feed hens
    public GameObject completionText; // Text congratulating completion
    public AudioSource successSound; // Sound to play when task is complete
    
    private int currentFeedCount = 0;
    
    // This method is called when something enters the feed zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is a feed item
        if (other.CompareTag("FeedItem"))
        {
            // Increase feed count
            currentFeedCount++;
            
            Debug.Log("Feed count: " + currentFeedCount + "/" + requiredFeedCount);
            
            // Optional: Deactivate the feed item (make it disappear)
            other.gameObject.SetActive(false);
            
            // Check if we've reached the required amount
            if (currentFeedCount >= requiredFeedCount)
            {
                // Show completion message
                if (instructionText) instructionText.SetActive(false);
                if (completionText) completionText.SetActive(true);
                
                // Play success sound if available
                if (successSound) successSound.Play();
                
                // Trigger scene transition after delay
                Invoke("LoadNextScene", 3.0f);
            }
        }
    }
    
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}