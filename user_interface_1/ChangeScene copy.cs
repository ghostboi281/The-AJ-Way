using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShifter : MonoBehaviour
{
    // Change scenes by an offset (+1 to go to next, -1 to go back, etc.)
    public void ShiftScene(int offset)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int newSceneIndex = currentSceneIndex + offset;

        // Clamp to valid range
        if (newSceneIndex >= 0 && newSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(newSceneIndex);
        }
        else
        {
            Debug.LogWarning("Scene index out of bounds: " + newSceneIndex);
        }
    }

    // Example: go to next scene
    public void NextScene()
    {
        ShiftScene(1);
    }

    // Example: go to previous scene
    public void PreviousScene()
    {
        ShiftScene(-1);
    }
}
