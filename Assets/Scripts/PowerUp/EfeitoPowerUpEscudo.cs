using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpEscudo : EfeitoPowerUp
{
    public EfeitoPowerUpEscudo(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
    }
    public override void Aplicar(jogador jogador)
    {
        jogador.AtivarEscudo();
    }

    public override void Remover(jogador jogador)
    {
        jogador.DesativarEscudo();
    }
}
