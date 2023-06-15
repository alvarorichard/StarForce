using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{

[SerializeField]
 private ArmaDisparoAlternado armaDisparoAlternado;

 [SerializeField]

 private ArmaDisparoDuplo armaDisparoDuplo;

 private ArmaBasica armaAtual;

[SerializeField]
 private ArmaDisparoEspalhado armaDisparoEspalhado;


 private void Awake() {
    this.armaDisparoAlternado.Desativar();
    this.armaDisparoDuplo.Desativar();
    this.armaDisparoEspalhado.Desativar();
    

 }

 public void EquiparArmaDisparoEspalhado(){
     this.ArmaAtual = this.armaDisparoEspalhado;
 }


 public void EquiparArmaDisparoAlternado(){
     this.ArmaAtual = this.armaDisparoAlternado;
 }

 public void EquiparArmaDisparoDuplo(){
     this.ArmaAtual = this.armaDisparoDuplo;
 }

 private ArmaBasica ArmaAtual{
    set{
        if(this.armaAtual != null){
            this.armaAtual.Desativar();
        }
        this.armaAtual = value;
        this.armaAtual.Ativar();
    }
 }

    
}
