using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimationsControl : MonoBehaviour
{
    // Vari�vel que armazena o Box Collider do persongem:
    [SerializeField]
    private PlayerAttacks playerAttacks;

    // Vari�vel que armazena o Animator do personagem:
    [SerializeField]
    private Animator anim;

    // Vari�vel que aramazena o tempo em que o personagem poder� permanecer em Barrel Roll:
    [SerializeField]
    private float barrelTime;

    public bool isRolling = false;

    [SerializeField]
    private float parryTime;

    public bool isParrying = false;

    void Update()
    {
        // Garante que o personagem possa desviar de ataques, fazendo giros em torno do seu pr�prio eixo.
        if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Parrying());
            StartCoroutine(BarrelRoll());
        }
    }

    public void doBarrelRoll()
    {
        StartCoroutine(Parrying());
        StartCoroutine(BarrelRoll());
    }

    // O IEnumerator permite que a��es acontecem apenas depois de um determinado per�odo de tempo.
    // Neste caso, quando doBarrelRoll em anim for verdadeiro, o personagem far� a anima��o Barrel Roll
    // e ficar� imune a danos inimigos at� que WaitForSeconds acabe e doBarrelRoll se torne falso.

    // A imunidade ocorre por conta do script PlayerCollision_Control atrelado ao corpo do player.
    IEnumerator BarrelRoll()
    {
        anim.SetBool("doBarrelRoll", true);
        isRolling = true;

        yield return new WaitForSeconds(barrelTime);

        anim.SetBool("doBarrelRoll", false);

        playerAttacks.firstSuperFlag = false;
        isRolling = false;
    }

    IEnumerator Parrying()
    {
        isParrying = true;

        yield return new WaitForSeconds(parryTime);

        isParrying = false;
    }
}









