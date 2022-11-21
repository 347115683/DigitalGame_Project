using UnityEngine;
using System.Collections;
using UnityEditor;
// Quits the player when the user press escape key

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //close playing screen
            EditorApplication.isPlaying = false;
        }
    }
        public void Quit()
    {
        // //close a running application
        // Application.Quit();
        //close playing screen
        EditorApplication.isPlaying = false;
    }
}