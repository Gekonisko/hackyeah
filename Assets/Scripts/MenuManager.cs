using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        SceneManager.LoadSceneAsync("Kinga", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    public void StartGame(){
        SceneManager.LoadScene("MainScene");
    }
}
