using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Operation
{
    Multiply,
    Add
};

public class GateScore : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private Operation operation;
    [SerializeField] private int value;
    [SerializeField] private PlayerController playerController;
    private SpriteRenderer background;

    #endregion

    private void Start()
    {
        background = this.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        background.enabled = false;
        if (operation == Operation.Add)
        {
            playerController.SpawnAutomatedCharacter(value);
        }
        else if (operation == Operation.Multiply)
        {
            int spawnCount = (value - 1) * playerController.AutomatedCharacterCount;
            playerController.SpawnAutomatedCharacter(spawnCount);
        }
    }
}