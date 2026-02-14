using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu: MonoBehaviour
{
    void Start()
    {
        
    }
    public void RetryButton()
    {
        SceneManager.LoadScene("Bayat_game_1");
    }
}
