using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.AI;

public class FinishLevel : MonoBehaviour
{
    #region Private Fields

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
        }
    }

    #endregion
}
