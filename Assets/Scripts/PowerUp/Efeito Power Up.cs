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

    public void Atualizar(){

        if(Ativo){
        this.duracaoEmSegundos -= Time.deltaTime;
        Debug.Log("Tempo restante: " + this.duracaoEmSegundos);

        }
    }

    public bool Ativo{
        get{
            return this.duracaoEmSegundos > 0;
        }
    }

}
