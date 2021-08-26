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
        [SerializeField] private ParticleSystem toonSplatParticle;
        private PlayerController playerController;
        private NavMeshAgent agent;
        private bool isDead = false;

        #endregion

        #region Properties

        public bool IsDead
        {
            get => isDead;
            set => isDead = value;
        }

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
                isDead = true;
                StartCoroutine(nameof(PlayParticleCoroutine));
            }
        }

        #endregion

        #region Private Methods

        IEnumerator PlayParticleCoroutine()
        {
            toonSplatParticle.Play();
            yield return new WaitForSeconds(1f);
            this.gameObject.SetActive(false);
        }

        #endregion
    }
}