using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConfiguratorCamera : MonoBehaviour
{
    [SerializeField]
    private Camera cameraView;
    [SerializeField]
    private GameObject objectToOrbit;
    [SerializeField]
    private int degreesPerClick = 45;
    [SerializeField]
    private float rotationDuration = 0.5f;
    private Button rotateLeftButton;
    private Button rotateRightButton;

    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        rotateLeftButton = rootElement.Q<Button>(CameraRotatorNameManager.Names.LeftButtonName);
        rotateLeftButton.clicked += () => { buttonClick(1); };
        rotateRightButton = rootElement.Q <Button>(CameraRotatorNameManager.Names.RightButtonName);
        rotateRightButton.clicked += () => { buttonClick(-1); };
    }

    private void buttonClick(int direction)
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
        StartCoroutine(revolveRoutine(direction));
    }

    private IEnumerator revolveRoutine(int direction)
    {
        int numberOfSteps = 10;
        float stepTime = rotationDuration / numberOfSteps;
        float totalRotation = 0f;
        int i = 0;
        while (i <= numberOfSteps)
        {
            float rotationStepAmount = (float)i / numberOfSteps;
            float stepEndRotationTarget = Mathf.SmoothStep(0f, degreesPerClick, rotationStepAmount);
            float stepRotation = stepEndRotationTarget - totalRotation;
            totalRotation += stepRotation;
            cameraView.transform.RotateAround(objectToOrbit.transform.position, objectToOrbit.transform.up, direction * stepRotation);
            i++;
            yield return new WaitForSeconds(stepTime);
        }
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
