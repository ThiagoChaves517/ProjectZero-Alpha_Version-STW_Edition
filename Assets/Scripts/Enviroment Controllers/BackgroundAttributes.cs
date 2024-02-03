using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAttributes : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D boxCollider;

    [SerializeField]
    private float width;
    [SerializeField]
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        width = boxCollider.size.x; 
    }

    // Update is called once per frame
    void Update()
    {
        AllowMovingToLeft();

        if (transform.position.x< -width)
        {
            Reposition();
        }
    }

    // Permite movimenta��o constante para a esquerda:
    private void AllowMovingToLeft()
    {
        Vector2 position = this.transform.position;
        position.x -= speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }

    // Permite movimenta��o constante para a direita:
    private void AllowMovingToRight()
    {
        Vector2 position = this.transform.position;
        position.x += speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2 (width * 2f, 0);
        transform.position = (Vector2) transform.position + vector;
    }
}