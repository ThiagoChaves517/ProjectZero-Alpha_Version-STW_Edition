using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleShot_Control : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeOfDeath;

    // Update is called once per frame
    void Update()
    {
        ShotDirection();
        ShotLife();
    }

    // Movimenta��o que faz o game object se movimentar para esquerda:
    private void ShotDirection()
    {
        Vector2 position = this.transform.position;
        Vector2 direction = this.transform.right; // Obter a dire��o do objeto

        position += direction * -speed * Time.deltaTime; // Adicionar � posi��o na dire��o do objeto
        this.transform.position = position;
    }

    // Destr�i o game object no qual este script est� atrelado depois de um certo tempo:
    private void ShotLife()
    {
        Destroy(this.gameObject, timeOfDeath);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se a bala encontrar um game object com a tag Player, este game object se destruir�:
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.01f);
        }
    }
}