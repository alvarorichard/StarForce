using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoEspalhado : ArmaBasica
{
   protected override void Atirar(){

    Vector2 posicaoDisparo = this.posicoesDisparo[0].position;

    CriarLaser(posicaoDisparo);

   }
   
}
