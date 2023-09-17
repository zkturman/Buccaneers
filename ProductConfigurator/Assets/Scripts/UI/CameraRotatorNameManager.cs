using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotatorNameManager : MonoBehaviour, IMenuLoadStep
{
    [SerializeField]
    private int loadPriority;
    public int Priority { get => loadPriority; }
    [SerializeField]
    private string leftButtonName;
    public string LeftButtonName { get => leftButtonName; }
    [SerializeField]
    private string rightButtonName;
    public string RightButtonName { get => rightButtonName; }
    [SerializeField]
    private string zoomButtonName;
    public string ZoomButtonName { get => zoomButtonName; }

    public static CameraRotatorNameManager Names;

    public IEnumerator LoadStep()
    {
        Names = this;
        yield break;
    }
}
