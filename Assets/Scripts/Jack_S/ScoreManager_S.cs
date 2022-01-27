using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager_S : MonoBehaviour
{
    public int scoreTotal = 0;
    public bool Col = true;

    public Text Scoreboard;
    public Text timer;
    public Button resetButton;
    public Button playAgainButton;

    private GameObject finishZone;

    public GameObject prefab;
    GameObject starP;
    public float waitAmount;
    float remainingTime;
    public Animator ScreenAnim;

    bool reseted;

    // Start is called before the first frame update
    void Start()
    {
        finishZone = GameObject.FindWithTag("Zone");
        resetButton.onClick.AddListener(ResetGame);
        playAgainButton.onClick.AddListener(ResetGame);
        remainingTime = waitAmount;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if star is spawned
        if (starP = GameObject.FindGameObjectWithTag("Pickup"))
        {
            //Starts countdown timer 
            if(remainingTime >= 0)
            {
                remainingTime -= 1 * Time.deltaTime;
                timer.text = remainingTime.ToString();
            }
            else
            {
                timer.gameObject.SetActive(false);
                Destroy(starP);
                ScreenAnim.SetBool("Dead", true);
            }
        }
        // Update Score with stars
        Scoreboard.text = scoreTotal.ToString();
        // Scene check for animation variables
        if (SceneManager.GetActiveScene().name == "Keyboard_U" && reseted == false)
        {
            ScreenAnim.SetBool("Dead", false);
            ScreenAnim.SetBool("Win", false);
            timer.gameObject.SetActive(false);
            reseted = true;
        }
        else if (SceneManager.GetActiveScene().name == "Prototyping_U")
        {
            reseted = false;
        }
        //Win State
        if (finishZone.GetComponent<FinishZone_S>().enteredTrigger && scoreTotal == 1000)
        {
            timer.gameObject.SetActive(false);
            ScreenAnim.SetBool("Win", true);
        }
    }
    private void ResetGame()
    {
        SceneManager.LoadScene("Keyboard_U");
    }
}
