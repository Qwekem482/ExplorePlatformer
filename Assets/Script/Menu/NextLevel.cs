using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void ToNextLevel()
    {
        /* Example
        ------------------
        List Scene:
        ------------------
        Scene   |   Index
        Start   |   0
        CompLv  |   1
        EndGame |   2
        L1      |   3
        L2      |   4
        L3      |   5
        L4      |   6
        L5      |   7
        L6      |   8
        ------------------
        Total: 9 scenes (sceneCountInBuildSettings)
        ------------------
        NextLevelSceneIndex = CurrentLevelNumber(L1 = 1; L2 = 2;...) + 3
        ------------------
        At last Level (Eg. L6), no scene index 9 (6 + 3 = 9 = sceneCountInBuildSettings) & must back to scene 2
        ------------------
        From StartScene, Data.GetLevel() = 0. 0 + 3 = 3 = L1 SceneIndex
        */
        if (Data.GetLevel() + 3 == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(Data.GetLevel() + 3);
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
