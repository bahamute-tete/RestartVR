using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRRoomScenesManager : MonoBehaviour
{
    private static VRRoomScenesManager _instance;
    public static VRRoomScenesManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        { 
         _instance= this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadVRroomScenes(1);
        }
    }

    public void LoadVRroomScenes(int index)
    { 
        SceneManager.LoadSceneAsync(index,LoadSceneMode.Single);
    }
}


