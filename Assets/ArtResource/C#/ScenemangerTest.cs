using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class LevelOrder
{

    [Header("每组关卡名称")]
    public string[] LevelNames;
}
public class ScenemangerTest : MonoBehaviour
{

    [Header("所有关卡列表")]
    public LevelOrder[] levelOrder;
    private static int index;
    private int totalLevels = 0;
    private int levelOrderLength;

    // Start is called before the first frame update
    void Start()
    {
        //Scene scene  = SceneManager.GetActiveScene();
        //Debug.Log($"Scene ======================={scene.name}");


        for (int i = 0; i < levelOrder.Length; i++)
        {
            totalLevels += levelOrder[i].LevelNames.Length;
        }

        if (totalLevels != SceneManager.sceneCountInBuildSettings)
        {

        }
        levelOrderLength = levelOrder.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool isOk = LoadNextLevels();
            if (isOk)
            {
                InvokeRepeating("UnloadLastLevel", 2.0f, 5);
            }
        }
    }

    bool LoadNextLevels()
    {
        bool bResult = true;
        //index = index % levelOrderLength;
        if (index < 0 || index >= levelOrderLength)
        {
            bResult = false;
            return bResult;
        }

        int LoadTimes = levelOrder[index].LevelNames.Length;
        for (int i = 0; i < LoadTimes; i++)
        {
            SceneManager.LoadSceneAsync(levelOrder[index].LevelNames[i], LoadSceneMode.Single);
        }
        return bResult;
    }

    void UnloadLastLevel()
    {
        if (index == 0)
        {
            index++;
            CancelInvoke("UnloadLastLevel");
            return;
        }
        // 上一組的關卡
        int TmpLast = (index - 1) >= 0 ? (index - 1) : levelOrderLength - 1;
        int LoadTimes = levelOrder[index].LevelNames.Length;
        for (int i = 0; i < LoadTimes; i++)
        {
            Scene Tmp = SceneManager.GetSceneByName(levelOrder[index].LevelNames[i]);
            if (!Tmp.isLoaded)
            {
                return;
            }
        }

        // 下一關卡全部加載完畢後，卸載之前關卡
        for (int i = 0; i < levelOrder[TmpLast].LevelNames.Length; i++)
        {
            SceneManager.UnloadSceneAsync(levelOrder[TmpLast].LevelNames[i]);
        }
        index++;
        CancelInvoke("UnloadLastLevel");
    }
}
