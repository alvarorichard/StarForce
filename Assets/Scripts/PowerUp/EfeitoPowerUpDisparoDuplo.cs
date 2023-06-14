using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoDuplo : EfeitoPowerUp
{

    public EfeitoPowerUpDisparoDuplo(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
        
    }

    public override void Aplicar(jogador jogador)
    {
         //acessar o script jogador 
            //acessar o script controlador de arma e alterar a arma atual para a arma de disparo duplo
        
        jogador.EquiparArmaDisparoDuplo();

    }

    public override void Remover(jogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }

}
