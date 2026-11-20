using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

public class player : MonoBehaviour
{
    public float velocidad = 8f;
    public float fuerzaSalto = 30f;

    private Rigidbody2D rb;
    private Vector2 inputMovimiento;
        
    private InputAction playerActions;
    private InputAction saltar;

    public float vida = 100;

    public TextMeshProUGUI textoVida;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerActions = InputSystem.actions.FindAction("Move");


        textoVida.text = "vida: " + vida;
    }

    public void morir(){
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        inputMovimiento = playerActions.ReadValue<Vector2>();
        //transform.Translate(new Vector3(inputMovimiento.x, 0, inputMovimiento.y) * Time.deltaTime);
        rb.linearVelocity = new Vector2(inputMovimiento.x * velocidad, 0);

        bool hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, LayerMask.GetMask("piso"));
        Debug.DrawRay(transform.position, Vector2.down * 5f, Color.red);
        Debug.Log(hit);

        if(Keyboard.current.spaceKey.isPressed && hit){
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

       
    }
}
