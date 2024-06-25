// Script for the player controls

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Input input;

    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] ParticleSystem booster;
    bool boosterOn = false;
    float inputRotation = 0;
    

    private void Awake() {
        input = new Input();
    }

    private void OnEnable() {
        input.Enable();

        input.Player.Forward.performed += OnPropelInput;
        input.Player.Forward.canceled += OnPropelReleased;
        input.Player.Rotate.performed += OnRotateInput;
        input.Player.Rotate.canceled += OnRotateInput;
        input.Player.Interact.performed += OnInteractInput;
    }

    private void OnDisable() {
        input.Disable();

        input.Player.Forward.performed -= OnPropelInput;
        input.Player.Forward.canceled -= OnPropelReleased;
        input.Player.Rotate.performed -= OnRotateInput;
        input.Player.Rotate.canceled -= OnRotateInput;
        input.Player.Interact.performed -= OnInteractInput;
    }

    private void FixedUpdate() {
        if (boosterOn) {
            PlayerData.rb.AddRelativeForce(Vector2.up);
        }

        if (inputRotation != 0) {
            PlayerData.rb.SetRotation(PlayerData.rb.rotation + inputRotation);
        }
    }

    private void OnPropelInput(InputAction.CallbackContext context) {
        boosterOn = true;
        booster.Play();
    }

    private void OnPropelReleased(InputAction.CallbackContext context) {
        boosterOn = false;
        booster.Stop();
    }

    private void OnRotateInput(InputAction.CallbackContext context) {
        inputRotation = context.ReadValue<float>() * rotationSpeed;
    }

    private void OnInteractInput(InputAction.CallbackContext context) {
        Collider2D[] results = new Collider2D[10];
        int numberOfResults = Physics2D.OverlapCircleNonAlloc(transform.position, 2f, results);

        if (numberOfResults > 0) {
            for (int i = 0; i < numberOfResults; i++) {
                IInteractable interactable = results[i].GetComponent<IInteractable>();

                if (interactable != null) {
                    Debug.Log("Interactable object found!");
                    interactable.Interact(gameObject);
                    break;
                }
            }
        }
    }
}
