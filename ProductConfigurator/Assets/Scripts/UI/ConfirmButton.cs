using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;

public abstract class ConfirmButton : MonoBehaviour
{
    [SerializeField]
    private string confirmButtonName;
    private Button confirmButton;
    [SerializeField]
    private CinemachineVirtualCamera waitingCamera;
    [SerializeField]
    private GameObject configMenu;
    [SerializeField]
    private UIUpdateController uiController;
    protected BaseGameStateHandler gameStateHandler;

    protected void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        confirmButton = rootElement.Q<Button>(confirmButtonName);
        gameStateHandler = FindObjectOfType<BaseGameStateHandler>();
        confirmButton.clicked += buttonClickAction;
    }

    protected abstract void buttonClickAction();

    protected void updateUIAfterConfirm()
    {
        waitingCamera.Priority = 100;
        configMenu.SetActive(false);
    }

    protected string getSerialisedBeastieConfig()
    {
        BeastieData configData = uiController.GetCurrentBeastieConfig();
        BeastieConfigSerialiser dataSerialiser = new BeastieConfigSerialiser();
        string serialisedData = dataSerialiser.SerialiseBeastieData(configData);
        return serialisedData;
    }
}
