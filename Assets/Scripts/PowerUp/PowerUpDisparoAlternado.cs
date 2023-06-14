using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDisparoAlternado : PowerUpColetavel
{
    public override EfeitoPowerUp EfeitoPowerUp
    {
        get
        {
            return new EfeitoPowerUpDisparoAlternado(DuracaoEmSegundos);
        }
    }
}
