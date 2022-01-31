using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    // Start is called before the first frame update
    public Vector3 lastCheckpointPos;
     void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else 
        
        {
            Destroy(gameObject);
        
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
