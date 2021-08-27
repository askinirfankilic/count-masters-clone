using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game;
using UnityEngine;
using UnityEngine.AI;

public class FinishLevel : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private PlayerController playerController;
    private LinkedList<GameObject> activeCharacters;
    #endregion
    #region Unity Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovementController>().IsMovable = false;
            Debug.Log(other.GetComponent<PlayerController>().ActiveAutomatedCharacters.Count);
            activeCharacters = other.GetComponent<PlayerController>().ActiveAutomatedCharacters;
            foreach (var character in activeCharacters)
            {
                character.GetComponent<NavMeshAgent>().enabled = false;
            }

            CreateHumanPyramid();
        }
    }

    #endregion

    #region Private Methods

    private void CreateHumanPyramid()
    {
        int tierCount = CalculateTierCount();
        

    }

    private int CalculateTierCount()
    {
        int tierCount = 0;
        int tierCoefficient = 1;
        int characterCount = playerController.AutomatedCharacterCount;
        bool isFirst = true;
        while (characterCount > 0)
        {
            if (isFirst)
            {
                characterCount -= tierCoefficient;
                isFirst = false;
                tierCount++;
            }
            else
            {
                characterCount -= tierCoefficient;
                isFirst = true;
                tierCount++;
                tierCoefficient++;
            }
            
        }

        tierCount--;
        
        return tierCount;
    }

    #endregion
}
