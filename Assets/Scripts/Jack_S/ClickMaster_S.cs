using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickMaster_S : MonoBehaviour
{
    //Scene
    public static ClickMaster_S instance;
    public bool newScene;
    //Keys
    public int maxClicks = 10;
    public int numberOfClicks;

    public GameObject clicks;

    public List<Vector3> keys = new List<Vector3>();
    public List<GameObject> rooms = new List<GameObject>();
    //Reset Loop
    public bool reseted = false;
    public bool Spawner = true;

    private void Awake()
    {
        //creates an instance of this gameobject so not destroyed on load of other scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        //main check for if scene has reset by finishing game
        if (SceneManager.GetActiveScene().name == "Keyboard_U" && reseted == false)
        {
            clicks = GameObject.Find("Clicks");
            newScene = false;
            numberOfClicks = maxClicks;
            keys.Clear(); 
            reseted = true;
            Spawner = true;
        }
        else if(SceneManager.GetActiveScene().name == "Prototyping_U")
        {           
            reseted = false;
        }
        //spawns rooms in position of keys
        if(SceneManager.GetActiveScene().name == "Prototyping_U" && Spawner == true)
        {
            transformSpawn();
        }
        //move onto game scene after keys
        if (numberOfClicks == 0 && newScene == false)
        {
            SceneManager.LoadScene("Prototyping_U");
            newScene = true;
        }
        if (reseted == true)
        {
            clicks.GetComponent<Text>().text = numberOfClicks.ToString();
        }
    }
    /// <summary>
    /// instantiates a series of randomly generated rooms from a list at the positions and order that the keys were pressed
    /// </summary>
    public void transformSpawn()
    {
        for (var i = 0; i < keys.Count; i++)
        {
            Instantiate(rooms[Random.Range(0, rooms.Count)], keys[i], Quaternion.identity);
            Spawner = false; 
        }

        GameObject play = GameObject.Find("Player");
        play.transform.position = keys[0];
        play.transform.Translate(0, -10, 0);
        GameObject finishZone = GameObject.Find("Finish Area");
        finishZone.transform.position = keys[4];
        finishZone.transform.Translate(0, -10, 0);

    }
}
