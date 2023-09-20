using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuLoader : MonoBehaviour
{
    private IMenuLoadStep[] stepsToLoad = new IMenuLoadStep[0];
    // Start is called before the first frame update
    void Start()
    {
        stepsToLoad = GetComponentsInChildren<IMenuLoadStep>(true);
        stepsToLoad = stepsToLoad.OrderBy(x => x.Priority).ToArray();
        StartCoroutine(loadRoutine());
    }

    private IEnumerator loadRoutine()
    {
        for (int i = 0; i < stepsToLoad.Length; i++)
        {
            yield return stepsToLoad[i].LoadStep();
        }
    }
}
