using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
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
        private GameObject background;

        #endregion

        private void Start()
        {
            background = this.GetComponentInChildren<Transform>().gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                background.SetActive(false);
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
    }
}