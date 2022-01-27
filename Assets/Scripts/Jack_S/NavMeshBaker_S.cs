using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavMeshBaker_S : MonoBehaviour
{
    [SerializeField]
    NavMeshSurface[] navMeshSurfaces;
    bool meshReset = false;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMeshSurfaces = GameObject.FindObjectsOfType<NavMeshSurface>();
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            if (i < 100)
            {
                navMeshSurfaces[i].BuildNavMesh();
            }
        }
            //meshReset = true;
        
        if (SceneManager.GetActiveScene().name == "Keyboard_U")
        {
            meshReset = false;
        }
    }
}
