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

    Laser laser = CriarLaser (posicaoDisparo);
    //laser.Direcao =

   }
   
}
