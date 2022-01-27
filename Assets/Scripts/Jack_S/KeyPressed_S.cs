using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressed_S : MonoBehaviour
{
    public Button me;

    bool isSelected = false;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager Keys");
        Button btn = me.GetComponent<Button>();
        btn.onClick.AddListener(Selected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Selected()
    {
        if (!isSelected)
        {
            gameManager.GetComponent<ClickMaster_S>().keys.Add(gameObject.transform.position);
            me.GetComponent<Image>().color = Color.green;
            gameManager.GetComponent<ClickMaster_S>().numberOfClicks--;
            isSelected = true;
        }
        else
        {
            gameManager.GetComponent<ClickMaster_S>().keys.Remove(gameObject.transform.position);
            me.GetComponent<Image>().color = Color.white;
            isSelected = false;
        }

    }

}
