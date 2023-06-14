using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDisparoDuplo : PowerUpColetavel
{

    public  override EfeitoPowerUp EfeitoPowerUp{
        get{
            return new EfeitoPowerUpDisparoDuplo(DuracaoEmSegundos);
        }
    }
}