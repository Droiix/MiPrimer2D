using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;

    private int spriteIndex = 0;
    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        // Una comprobación de seguridad para evitar el error si el array está vacío
        if (mySprites.Length > 0)
        {
            StartCoroutine(WalkCoRoutine());
        }
        else
        {
            Debug.LogError("El array de sprites está vacío en el PlayerController. Por favor, asigna los sprites en el Inspector.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumpForce);
        }
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
    }

    IEnumerator WalkCoRoutine()
    {
        // Un bucle infinito que se ejecuta dentro de la corutina es más eficiente
        while (true)
        {
            // Asigna el sprite actual
            mySpriteRenderer.sprite = mySprites[spriteIndex];

            // Incrementa el índice para el siguiente frame
            spriteIndex++;

            // Si el índice alcanza el tamaño del array, reinícialo a 0
            // Esto funciona sin importar cuántos sprites tengas (1, 5, 10, etc.)
            if (spriteIndex >= mySprites.Length)
            {
                spriteIndex = 0;
            }

            // Espera un momento antes de cambiar al siguiente sprite
            yield return new WaitForSeconds(0.05f);
        }
    }
}
