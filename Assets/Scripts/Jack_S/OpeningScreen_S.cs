using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScreen_S : MonoBehaviour
{
    public
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        SceneManager.LoadScene("Keyboard_U");
    }
}
