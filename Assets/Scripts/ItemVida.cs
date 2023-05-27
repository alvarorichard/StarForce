using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    [SerializeField]
    private int quantidadeVidas;

    public int QuantidadeVidas{
        get{
            return this.quantidadeVidas;
        }
    }

    public void Coletar(){
        Debug.Log("Coletou item de vida");
        Destroy(this.gameObject);
    }

}
