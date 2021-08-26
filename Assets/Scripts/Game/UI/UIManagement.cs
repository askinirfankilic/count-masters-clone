using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class UIManagement : MonoBehaviour
    {
        #region Private Fields

        [Header("References"), SerializeField] private GameObject homeUI;
        [SerializeField] private GameObject gameplayUI;
        [SerializeField] private GameObject winUI;
        [SerializeField] private GameObject loseUI;

        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private PlayerMovementController playerMovementController;

        #endregion

        #region Public Methods

        public void StartButton()
        {
            homeUI.SetActive(false);
            gameplayUI.SetActive(true);
            playerMovementController.IsMovable = true;
        }

        #endregion
    }
}