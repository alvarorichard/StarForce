using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EfeitoPowerUp 
{

    private float duracaoEmSegundos;

    public EfeitoPowerUp(float duracaoEmSegundos)
    {
        this.duracaoEmSegundos = duracaoEmSegundos;
    }

    public abstract void Aplicar(jogador jogador);

    public abstract void Remover(jogador jogador);

    public void Autalizar(){

        if(Ativo){
        this.duracaoEmSegundos -= Time.deltaTime;

        }
    }

    public bool Ativo{
        get{
            return this.duracaoEmSegundos > 0;
        }
    }

}
