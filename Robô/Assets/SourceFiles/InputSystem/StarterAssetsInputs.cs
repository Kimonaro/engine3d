using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if(cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
#endif

        private void Awake()
        {
            SetCursorState(cursorLocked);
            Cursor.visible = false;
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        } 

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !newState;  
        }
        
        private void OnTriggerEnter(Collider outro)
        {
            // Verifica se o objeto com o qual colidimos tem a tag "moeda"
            if (outro.CompareTag("moeda"))
            {
                // 1. Avisa no console que a física funcionou (sem caracteres que bugam a Unity)
                Debug.Log("<color=cyan>SAI: Moeda encostada! Avisando o gerenciador...</color>");

                // 2. Comunicação DIRETA e SEGURA com o cérebro do jogo
                if (PlayerObserverManager.Instancia != null)
                {
                    PlayerObserverManager.Instancia.AdicionarMoeda();
                }
                else
                {
                    Debug.LogWarning("SAI: O PlayerObserverManager não foi encontrado na cena!");
                }

                // 3. Destrói o objeto da moeda para ela desaparecer do jogo
                Destroy(outro.gameObject);
            }
        }
    }
