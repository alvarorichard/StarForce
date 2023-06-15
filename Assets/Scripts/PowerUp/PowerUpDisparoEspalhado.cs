using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDisparoEspalhado : PowerUpColetavel
{
    public override EfeitoPowerUp EfeitoPowerUp{
        get{
            return new EfeitoPowerUpDisparoEspalhado(duracaoEmSegundos);
        }
    }
}
