using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{   
    private Button newGameButton;

    // Start is called before the first frame update
    private void Start()
    {
        newGameButton = GetComponent<Button>();

    //button to start new game, should transition to Intro Scrawl
    newGameButton.onClick.AddListener(StartNewGame);
    }

    // Update is called once per frame
    private void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
}
