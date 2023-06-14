using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    
    [SerializeField]
    [Tooltip("Quantidade de dano que poder ser recebido antes de ser destruído")]
     private int protecaoTotal;
///<summary>
/// Quantidade de dano que poder ser recebido antes de ser destruído
///</summary>
     private int protecaoAtual;

     public void Ativar(){
        this.protecaoAtual = this.protecaoTotal;
        this.gameObject.SetActive(true);
     }

     public void Desativar(){
        this.gameObject.SetActive(false);
     }

     public bool Ativo{
         get{
             return this.gameObject.activeSelf;
         }
     }

     public void ReceberDano(){
        this.protecaoAtual--;
        if(this.protecaoAtual <= 0){
            Desativar();
        }
     }

}
