using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDoorsB_S : MonoBehaviour
{
    //All doors had to have seperate script so that room detection could work
    private void OnTriggerEnter(Collider other)
    {
        other.transform.Translate(0, -226.5f, 46);
    }
}
