using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoEspalhado : EfeitoPowerUp
{

    public EfeitoPowerUpDisparoEspalhado(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
    }
   
   public override void Aplicar (jogador jogador){
         jogador.EquiparArmaDisparoEspalhado();
    }

    public override void Remover(jogador jogador){
       jogador.EquiparArmaDisparoAlternado();
    }
   
}
