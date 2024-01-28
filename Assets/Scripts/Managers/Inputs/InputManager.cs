using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
        private static InputManager _instance;

        public static InputManager Instance
        {
            get
            {
                return _instance;
            }
        }


        private InputActions inputActions;

        private void Awake()
        {
            _instance = this;

            inputActions = new InputActions();

        }

        public void OnEnable()
        {
            inputActions.Enable();

        }

        public void OnDisable()
        {
            inputActions.Disable();
        }

        public void OnDestroy()
        {
            inputActions.Dispose();

        }

        /// <summary>
        /// helper function to call the player movement controls
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPlayerMovement()
        {
            Vector2 inputMovement = inputActions.Player.Move.ReadValue<Vector2>();
            inputMovement = inputMovement.normalized;

            return inputMovement;
        }

        /// <summary>
        /// Returns true if the jump control was triggered
        /// </summary>
        /// <returns></returns>
        public bool PlayerJumped()
        {
            return inputActions.Player.Jump.triggered;
        }


        /// <summary>
        /// /Returns true if the fire control was triggered
        /// </summary>
        /// <returns></returns>
        public bool PlayerFired()
        {
            return inputActions.Player.Fire.triggered;
        }

        /// <summary>
        /// /Returns true if the fire control was triggered
        /// </summary>
        /// <returns></returns>
        public bool PlayerRun()
        {
            return inputActions.Player.Run.triggered;
        }



    public Vector2 GetMouseDelta() {

            return inputActions.Player.Look.ReadValue<Vector2>();
            
        }

        /// <summary>
        /// Returns true if the option menu control was triggered
        /// </summary>
        /// <returns></returns>
        public bool OptionsMenu()
        {
            return inputActions.Player.OptionsMenu.triggered;
        }
}
