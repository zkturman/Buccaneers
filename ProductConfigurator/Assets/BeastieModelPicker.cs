using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieModelPicker : MonoBehaviour
{
    [SerializeField]
    private BeastieType type = BeastieType.None;
    [SerializeField]
    private BeastieModelKeyValue[] beastieModels;
    private GameObject currentModel;
    
    public void SelectModel(BeastieType typeToSelect)
    {
        type = typeToSelect;
        bool isFound = false;
        int i = 0;
        while (!isFound && i < beastieModels.Length)
        {
            if (beastieModels[i].Key == typeToSelect)
            {
                isFound = true;
                createNewModel(beastieModels[i].Model);
            }
            i++;
        }
    }

    private void createNewModel(GameObject prefabToCreate)
    {
        if (currentModel != null)
        {
            GameObject.Destroy(currentModel);
        }
        currentModel = Instantiate(prefabToCreate, this.transform);
    }
}
