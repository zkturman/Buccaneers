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
    private Material fadingMaterial;
    [SerializeField]
    private GameObject objectToOrbit;
    [SerializeField]
    private int degreesPerClick = 45;
    [SerializeField]
    private float rotationDuration = 0.5f;
    private Button rotateLeftButton;
    private Button rotateRightButton;
    private Button zoomButton;

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
        //sceneCameras = cameraParent.GetComponentsInChildren<CinemachineVirtualCamera>();
        ////foreach(CinemachineVirtualCamera camera in sceneCameras)
        ////{
        ////    camera.transform.RotateAround(objectToOrbit.transform.position, objectToOrbit.transform.up, degreesPerClick);
        ////}
        //StartCoroutine(revolveRoutine(direction));
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
        if (zoomedOutCamera.Priority == zoomedOutPriority)
        {
            zoomedOutCamera.Priority = 0;
        }
        else
        {
           zoomedOutCamera.Priority = zoomedOutPriority;
        }
        //StartCoroutine(zoomRoutine());
    }

    //private IEnumerator zoomRoutine()
    //{
    //    float outWeight = cameraView.GetWeight(0);
    //    float inWeight = cameraView.GetWeight(1);
    //    int numberOfSteps = 10;
    //    float stepTime = zoomDuration / numberOfSteps;
    //    for (int i = 1; i <= numberOfSteps; i++)
    //    {
    //        cameraView.SetWeight(0, Mathf.Lerp(outWeight, inWeight, (float)i / numberOfSteps));
    //        cameraView.SetWeight(1, Mathf.Lerp(inWeight, outWeight, (float)i / numberOfSteps));
    //        yield return new WaitForSeconds(stepTime);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
