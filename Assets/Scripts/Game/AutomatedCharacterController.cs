using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class AutomatedCharacterController : MonoBehaviour
    {
        #region Private Fields

        [SerializeField] private Transform destination;
        private PlayerController playerController;
        private NavMeshAgent agent;

        #endregion

        #region Unity Methods

        private void Start()
        {
            playerController = GetComponentInParent<PlayerController>();
            destination = transform.parent;
            agent = this.GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            agent.SetDestination(destination.localPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pylon"))
            {
                playerController.DismissAutomatedCharacter(this.gameObject);
                
                this.gameObject.SetActive(false);
            }
        }

        #endregion
    }
}