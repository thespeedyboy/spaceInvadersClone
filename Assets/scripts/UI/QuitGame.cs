using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public KeyCode quitKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(quitKey))
        {
            Quit();
        }
    }

    void Quit()
    {
        Debug.Log("Quitting Game...");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
