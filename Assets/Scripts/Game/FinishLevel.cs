using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using Game;
using UnityEngine;
using UnityEngine.AI;

public class FinishLevel : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private PlayerController playerController;
    private LinkedList<GameObject> activeCharacters;
    [SerializeField] private List<GameObject> listOfActiveCharacters;
    [SerializeField] private CinemachineVirtualCamera vcam1;
    [SerializeField] private CinemachineVirtualCamera vcam2;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        listOfActiveCharacters = new List<GameObject>(playerController.AutomatedCharacterCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchCamera();
            other.GetComponent<PlayerMovementController>().IsMovable = false;
            Debug.Log(other.GetComponent<PlayerController>().ActiveAutomatedCharacters.Count);
            activeCharacters = other.GetComponent<PlayerController>().ActiveAutomatedCharacters;
            foreach (var character in activeCharacters)
            {
                character.GetComponent<NavMeshAgent>().enabled = false;
                listOfActiveCharacters.Add(character);
            }
            playerController.SetActiveAutomatedCharactersForDancing();
            
            CreateHumanPyramid();
            playerController.IsWin = true;
        }
    }

    #endregion

    #region Private Methods

    private void SwitchCamera()
    {
        vcam1.Priority = 0;
        vcam2.Priority = 1;
    }

    private void CreateHumanPyramid()
    {
        DOTween.Init();

        int tierCount = CalculateTierCount();
        int dualDoubleTierCount = tierCount / 2;
        int monoDoubleTierCount = tierCount % 2;
        float yParam = 0f;

        #region Mono Section

        int firstFloorCharacterCount = tierCount / 2 + 1;
        for (int i = 0; i < firstFloorCharacterCount; i++)
        {
            listOfActiveCharacters[i].transform.DOMove(new Vector3(-5 + i, yParam, 225), 2f);
        }

        #endregion

        yParam += 3f;

        #region Dual Section

        int xOffset = 1;
        int counter = 0;
        for (int i = dualDoubleTierCount; i > 0; i--)
        {
            int floorCharacterCount = i;
            for (int j = 0; j < floorCharacterCount; j++)
            {
                if (firstFloorCharacterCount + counter + 5 < playerController.AutomatedCharacterCount)
                {
                    listOfActiveCharacters[firstFloorCharacterCount + counter].transform
                        .DOMove(new Vector3(-5 + j + xOffset, yParam, 225), 1);
                    counter++;
                    listOfActiveCharacters[firstFloorCharacterCount + counter].transform
                        .DOMove(new Vector3(-5 + j + xOffset, yParam + 3, 225), 1);
                    counter++;
                }
            }

            yParam += 6;
            xOffset += 1;
        }

        #endregion
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