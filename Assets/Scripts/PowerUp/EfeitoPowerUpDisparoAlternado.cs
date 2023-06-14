using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoAlternado :EfeitoPowerUp
{
    public EfeitoPowerUpDisparoAlternado(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
        
    }

 public override void Aplicar(jogador jogador){
     jogador.EquiparArmaDisparoAlternado(); 
 }

    public override void Remover(jogador jogador){
        jogador.EquiparArmaDisparoAlternado();
    
    }
}
