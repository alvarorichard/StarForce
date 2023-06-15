using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoEspalhado : ArmaBasica
{
    [SerializeField,Range(0f,30f)]
    private float anguloEntreDisparos;

    [SerializeField,Range(1,30)]
    private int  quantidadeDisparos;




   protected override void Atirar(){

    Vector2 posicaoDisparo = this.posicoesDisparo[0].position;

    for(int i = 0; i< this.quantidadeDisparos; i++){
 Laser laser = CriarLaser (posicaoDisparo);
    laser.Direcao = CalcularDirecaoDisparo(i);
    }

   

   }

   private Vector2 CalcularDirecaoDisparo(int indiceDisparo){

    int indiceDisparoArco;

    if((this.quantidadeDisparos %2) == 0 ){
        indiceDisparoArco = indiceDisparo + 1;

    }else {
        indiceDisparoArco = indiceDisparo;

    }

    indiceDisparoArco = Mathf.CeilToInt(indiceDisparoArco /2f);

      float angulo = (this.anguloEntreDisparos * indiceDisparoArco);


    if(indiceDisparo %2 !=0){
        angulo *= -1;

    }




  Quaternion rotacao = Quaternion.AngleAxis(angulo,Vector3.forward);

  Vector2 direcao = rotacao * Vector3.up;

  return direcao;

   }
   
}
