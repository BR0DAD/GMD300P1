using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;
    private float verticalMovement = 0;

    public InputActionAsset CharacterActionAsset;

    public Camera FirstPersonCamera;

    private InputAction moveAction;
    private InputAction rotateAction;

    private CharacterController characterController;

    //Vector Variables for frame inputs
    private Vector2 inputMovement = Vector2.zero;
    private Vector2 previousFrameInputMovement = Vector2.zero;
    private Vector2 inputRotation = Vector2.zero;
    private Vector2 previousFrameInputRotation = Vector2.zero;

    private Vector2 moveValue = Vector2.zero;
    private Vector2 rotateValue = Vector2.zero;
    private Vector3 currentRotationAngle = Vector3.zero;

    private void OnEnable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Enable();
    }
    private void OnDisable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotate");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        rotateValue = rotateAction.ReadValue<Vector2>() * Time.deltaTime * RotationSpeed;

        currentRotationAngle = new Vector3(currentRotationAngle.x - rotateValue.y, currentRotationAngle.y + rotateValue.x, 0);

        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);

        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);

        //GRAVITY
        verticalMovement = 0;
        verticalMovement += Physics.gravity.y * Time.deltaTime;

        LookMovement();

    }

   private void LookMovement() 
    {
        moveValue = moveAction.ReadValue<Vector2>() * MoveSpeed * Time.deltaTime;
        Vector3 MoveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;
        MoveDirection.y = 0;
        MoveDirection.y += verticalMovement;
        characterController.Move(MoveDirection);

    }

    void OnDrawGizmos ()
    {
        Gizmos.color = new Vector4(0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

}
