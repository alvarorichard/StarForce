using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoAlternado :EfeitoPowerUp
{

 public override void Aplicar(jogador jogador){
     jogador.EquiparArmaDisparoAlternado(); 
 }

    public override void Remover(jogador jogador){
    
    }
}
