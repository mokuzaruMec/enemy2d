using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class player2 : MonoBehaviour
{
    public float velocidad = 8f;
    public float fuerzaSalto = 30f;

    private Rigidbody2D rb;
    private Vector2 inputMovimiento;
        
    private InputAction playerActions;
    private InputAction saltar;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerActions = InputSystem.actions.FindAction("Move");
        //saltar = InputSystem.actions.FindAction("Jump");
    }


    void FixedUpdate()
    {
        inputMovimiento = playerActions.ReadValue<Vector2>();
        //transform.Translate(new Vector3(inputMovimiento.x, 0, inputMovimiento.y) * Time.deltaTime);
        rb.linearVelocity = new Vector2(inputMovimiento.x * velocidad, 0);

        if(Keyboard.current.spaceKey.isPressed){
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Force);
        }
    }
}