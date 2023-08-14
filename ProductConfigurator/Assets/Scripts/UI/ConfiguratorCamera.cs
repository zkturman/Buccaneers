using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;

public class ConfiguratorCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraParent;
    private CinemachineVirtualCamera[] sceneCameras;
    [SerializeField]
    private CinemachineVirtualCamera zoomedOutCamera;
    private int zoomedOutPriority;
    [SerializeField]
    private GameObject pirateObject;
    [SerializeField]
    private GameObject beastieObject;
    [SerializeField]
    private ModelSwitcher modelSwitcher;
    [SerializeField]
    private GameObject objectToOrbit;
    [SerializeField]
    private int degreesPerClick = 45;
    [SerializeField]
    private float rotationDuration = 0.5f;
    private Button rotateLeftButton;
    private Button rotateRightButton;
    private Button zoomButton;
    [SerializeField]
    private Sprite zoomInIcon;
    [SerializeField]
    private Sprite zoomOutIcon;

    private void OnEnable()
    {
        zoomedOutPriority = zoomedOutCamera.Priority;
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        rotateLeftButton = rootElement.Q<Button>(CameraRotatorNameManager.Names.LeftButtonName);
        rotateLeftButton.clicked += () => { rotateButtonClick(1); };
        rotateRightButton = rootElement.Q <Button>(CameraRotatorNameManager.Names.RightButtonName);
        rotateRightButton.clicked += () => { rotateButtonClick(-1); };
        zoomButton = rootElement.Q <Button>(CameraRotatorNameManager.Names.ZoomButtonName);
        zoomButton.clicked += () => { zoomButtonClick(); };
    }

    private void rotateButtonClick(int direction)
    {
        if (direction < 0)
        {
            revolveCamera(direction);
        }
        else
        {
            revolveCamera(direction);
        }
    }

    private void revolveCamera(int direction)
    {
        objectToOrbit.transform.Rotate(new Vector3(0, degreesPerClick * direction, 0));
    }

    private IEnumerator revolveRoutine(int direction)
    {
        int numberOfSteps =250;
        float stepTime = rotationDuration / numberOfSteps;
        float totalRotation = 0f;
        int i = 0;
        while (i <= numberOfSteps)
        {
            float rotationStepAmount = (float)i / numberOfSteps;
            float stepEndRotationTarget = Mathf.SmoothStep(0f, degreesPerClick, rotationStepAmount);
            float stepRotation = stepEndRotationTarget - totalRotation;
            totalRotation += stepRotation;
            objectToOrbit.transform.Rotate(new Vector3(0f, direction * stepRotation, 0f));
            i++;
            yield return new WaitForSeconds(stepTime);
        }
    }

    private void zoomButtonClick()
    {
        modelSwitcher.SwitchModels();
        if (isZoomedOut())
        {
            zoomedOutCamera.Priority = 0;
            zoomButton.style.backgroundImage = new StyleBackground(zoomOutIcon);
        }
        else
        {
           zoomedOutCamera.Priority = zoomedOutPriority;
            zoomButton.style.backgroundImage = new StyleBackground(zoomInIcon);
        }
    }

    private bool isZoomedOut()
    {
        return zoomedOutCamera.Priority == zoomedOutPriority;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
