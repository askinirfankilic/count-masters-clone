using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Public Fields

        public float speed = 1f;
        public float horizontalMultiplier = 1f;
        [SerializeField] private float movableLineBoundary = 10f;
        [SerializeField] private Joystick joystick;

        #endregion

        #region Private Fields

        private float horizontal = 0f;
        private PlayerController playerController;

        #endregion

        #region Properties

        public float Horizontal
        {
            get => horizontal;
            set => horizontal = value;
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            playerController = this.GetComponent<PlayerController>();
        }

        void Update()
        {
            this.Move();
            AdjustMovableLineBoundary();
        }

        #endregion

        #region Private Methods

        private void Move()
        {
            this.Horizontal = this.joystick.Horizontal;

#if UNITY_EDITOR
            var standaloneHorizontal = Input.GetAxisRaw("Horizontal");
            if (standaloneHorizontal != 0)
            {
                this.horizontal = standaloneHorizontal;
            }
#endif

            if (movableLineBoundary > Math.Abs(this.transform.position.x))
            {
                this.transform.Translate(this.Horizontal * horizontalMultiplier, 0, speed * Time.deltaTime);
            }
            else
            {
                this.transform.Translate(-this.transform.position.x / movableLineBoundary * horizontalMultiplier, 0,
                    speed * Time.deltaTime);
            }

            ResetHorizontal();
        }

        private void ResetHorizontal()
        {
            Horizontal = 0f;
        }

        private void AdjustMovableLineBoundary()
        {
            if (playerController.AutomatedCharacterCount <= 20)
            {
                return;
            }
            else if (20 < playerController.AutomatedCharacterCount && playerController.AutomatedCharacterCount <= 40)
            {
                this.movableLineBoundary = 8f;
                return;
            }
            else if (40 < playerController.AutomatedCharacterCount && playerController.AutomatedCharacterCount <= 80)
            {
                this.movableLineBoundary = 6f;
                return;
            }
            else if (80 < playerController.AutomatedCharacterCount && playerController.AutomatedCharacterCount <= 120)
            {
                this.movableLineBoundary = 4f;
                return;
            }
            else if (120 < playerController.AutomatedCharacterCount)
            {
                this.movableLineBoundary = 2f;
                return;
            }
        }

        #endregion
    }
}