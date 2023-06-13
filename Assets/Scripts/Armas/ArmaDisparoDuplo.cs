using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoDuplo : ArmaBasica
{


protected override void Atirar(){
    CriarLaser(this.posicoesDisparo[0].position);
    CriarLaser(this.posicoesDisparo[1].position);


}

  
}
