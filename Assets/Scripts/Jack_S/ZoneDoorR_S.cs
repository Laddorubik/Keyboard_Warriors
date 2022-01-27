using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDoorR_S : MonoBehaviour
{
    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.Translate(173f, 0, 0);
    }
}
