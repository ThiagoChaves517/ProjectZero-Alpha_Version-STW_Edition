using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

 [SerializeField] private string NomeDoLevelDoJogo;
 [SerializeField] private GameObject painelMenuInicial;

   public void Jogar(){
    SceneManager.LoadScene(NomeDoLevelDoJogo);
   }

   public void Sair(){
    Debug.Log("Sair do Jogo");
    Application.Quit();
   }

}