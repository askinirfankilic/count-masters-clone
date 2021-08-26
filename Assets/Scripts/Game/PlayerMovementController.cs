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
    
        #endregion
    
        #region Properties
    
        public float Horizontal
        {
            get => horizontal;
            set => horizontal = value;
        }
    
        #endregion
    
        #region Unity Methods
        
        void Update()
        {
            this.Move();
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
                this.transform.Translate(-this.transform.position.x / movableLineBoundary * horizontalMultiplier, 0, speed * Time.deltaTime);
            }
    
            ResetHorizontal();
    
        }
    
        private void ResetHorizontal()
        {
            Horizontal = 0f;
        }
    
        #endregion
    }
}
