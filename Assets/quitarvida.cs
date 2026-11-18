using UnityEngine;

public class quitarvida : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D objeto){
        player salud =  objeto.GetComponent<player>();

        if( salud.vida <= 1){
            salud.morir();

        }else{
            salud.vida--;
            salud.textoVida.text = "vida: " + salud.vida;
        }
        

    }
}
