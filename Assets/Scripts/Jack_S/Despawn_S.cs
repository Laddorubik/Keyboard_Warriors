using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Despawn_S : MonoBehaviour
{
    public List<GameObject> gmList = new List<GameObject>();
    bool despawn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.tag == "Room") gmList.Add(other.gameObject);
        if (SceneManager.GetActiveScene().name == "Keyboard_U") Destroy(other);
    }
}
