using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{

    public GameObject[] barrasVermelhas;

    
    public void ExibirVida(int vidas) {
        for (int i = 0; i < this.barrasVermelhas.Length; i++) {
            if (i < vidas) {
                // Ativar barra vermelha
                this.barrasVermelhas[i].SetActive(true);
            } else {
                // Desativar barra vermelha
                this.barrasVermelhas[i].SetActive(false);
            }
        }
    }

}
