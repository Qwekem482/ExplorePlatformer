using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAC : MonoBehaviour
{
    private void ToIdle()
    {
        gameObject.GetComponent<Animator>().SetInteger(StringStore.activeStage, 2);
    }
}
