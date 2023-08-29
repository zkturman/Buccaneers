using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject switchEffect;
    [SerializeField]
    private GameObject[] modelChoices;
    private int currentChoice = 0;

    private void Start()
    {
        updateSelection();            
    }

    public void SwitchModels()
    {
        Instantiate(switchEffect, transform);
        currentChoice = (currentChoice + 1) % modelChoices.Length;
        updateSelection();
    }

    private void updateSelection()
    {
        for (int i = 0; i < modelChoices.Length; i++)
        {
            if (i == currentChoice)
            {
                modelChoices[i].SetActive(true);
            }
            else
            {
                modelChoices[i].SetActive(false);
            }
        }
    }
}
