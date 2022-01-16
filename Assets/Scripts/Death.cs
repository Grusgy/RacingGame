using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnDeath();
    }

    public void OnDeath()
    {
        animator.SetTrigger("death");
        Time.timeScale = 0.0000000001f;

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
