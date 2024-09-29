using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
		btn = GetComponent<Button>();
        btn.onClick.AddListener(GoToGame);
    }

    void GoToGame () {
        SceneManager.LoadScene("GameScene");
    }

}
