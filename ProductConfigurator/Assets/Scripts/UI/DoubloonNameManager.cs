using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubloonNameManager : MonoBehaviour, IMenuLoadStep
{
    [SerializeField]
    private int loadPriority;
    public int Priority { get => loadPriority; }
    [SerializeField]
    private string currentDoubloonAmountName = "DoubloonAmount";
    public string CurrentDoubloonAmountName { get => currentDoubloonAmountName; }
    [SerializeField]
    private string costTotalName = "CostSubtraction";
    public string CostTotalName { get => costTotalName; }
    [SerializeField]
    private string subtractionLineName = "SubtractionLine";
    public string SubtractionLineName { get => subtractionLineName; }
    [SerializeField]
    private string remainingDoubloonsName = "PredictedTotal";
    public string RemaininDoubloonsName { get => remainingDoubloonsName; }
    public static DoubloonNameManager Names;

    public IEnumerator LoadStep()
    {
        Names = this;
        yield break;
    }
}
