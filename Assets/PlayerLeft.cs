using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerLeft : MonoBehaviour
{
    //create private internal references
    private InputActions inputActions;
    private InputAction movement;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody, responsible for enabling collision with other colliders
        inputActions = new InputActions(); //create new InputActions
        movement = inputActions.PlayerLeft.Movement; //get reference to movement action
    }
    //called when script enabled
    private void OnEnable()
    {
        movement.Enable();
        //create a DoJump callback function
        //DoJump automatically called when Jump binding performed
        // inputActions.LeftPlayer.Jump.performed += DoJump;
        // inputActions.LeftPlayer.Jump.Enable();
    }

    //called when script disabled
    private void OnDisable()
    {
        movement.Disable();
        // inputActions.LeftPlayer.Jump.performed -= DoJump;
        // inputActions.LeftPlayer.Jump.Disable();
    }
    // private void DoJump(InputAction.CallbackContext obj)
    // {
    // Debug.Log("Jump"); //called when jump performed
    // }
    //called every physics update
    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>(); //extract 2d input data
        Vector3 v3 = new Vector3(0, v2.y, 0); //convert to 3d space
                                                 // transform.Translate(v3); //moves transform, ignoring physics
        rb.AddForce(v3, ForceMode.VelocityChange); //apply instant physics force, ignoring mass
    }
}