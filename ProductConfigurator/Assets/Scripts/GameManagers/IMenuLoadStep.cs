using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenuLoadStep
{
    public int Priority { get; }
    public IEnumerator LoadStep();
}
