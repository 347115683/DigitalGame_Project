using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource FinishSound;
    private bool LevelCompleted = false;
    void Start()
    {
        // play sound
        FinishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !LevelCompleted)
        {
            FinishSound.Play();
            //CompleteLevel();
            //Invokes the method methodName in time seconds.
            Invoke("CompleteLevel",2f);
            LevelCompleted = true;
        }
    }
    private void CompleteLevel()
    {
        // pass to next level (switch scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
