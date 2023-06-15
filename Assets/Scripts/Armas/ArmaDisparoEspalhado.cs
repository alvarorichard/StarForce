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

  float angulo = (this.anguloEntreDisparos * indiceDisparo);

  Quaternion rotacao = Quaternion.AngleAxis(angulo,Vector3.forward);

  Vector2 direcao = rotacao * Vector3.up;

  return direcao;

   }
   
}
