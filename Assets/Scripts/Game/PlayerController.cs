using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private float automatedCharacterCount = 1;
    [SerializeField] private GameObject automatedCharacterPrefab;

    #endregion

    #region Properties

    public float AutomatedCharacterCount
    {
        get => automatedCharacterCount;
        set => automatedCharacterCount = value;
    }

    public GameObject AutomatedCharacterPrefab => automatedCharacterPrefab;

    #endregion


    #region Unity Methods

    private void Start()
    {
        if (automatedCharacterCount > 1)
        {
            //starting object spawn routine
        }
    }

    private void Update()
    {
    }

    #endregion

    #region Private Methods

    private void SpawnAutomatedCharacter(int spawnAmount)
    {
        
        //spawn block

        AutomatedCharacterCount += spawnAmount;
    }

    private void DismissAutomatedCharacter(int dismissAmount)
    {
        //dismiss block

        AutomatedCharacterCount -= dismissAmount;
    }

    #endregion
}