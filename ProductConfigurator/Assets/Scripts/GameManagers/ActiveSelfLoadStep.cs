using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSelfLoadStep : MonoBehaviour, IMenuLoadStep
{
    [SerializeField]
    private int loadPriority;
    public int Priority { get => loadPriority; }

    public IEnumerator LoadStep()
    {
        this.gameObject.SetActive(true);
        yield break;
    }
}
