using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string firstLevel;
    public GameObject optScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void OpenOption()
    {
        optScreen.SetActive(true);
    }

    public void CloseOption()
    {
        optScreen.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit(0);
        Debug.Log("I quit");
    }
}
