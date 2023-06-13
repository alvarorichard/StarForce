using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBasica : MonoBehaviour
{

    public Laser laserPrefab;
    public float tempoEsperaTiro;
    private float intervaloTiro;
    public Transform[] posicoesArmas;
    private Transform armaAtual;


    // Start is called before the first frame update
    void Start()
    {
        
         this.intervaloTiro = 0;
        this.armaAtual = this.posicoesArmas[0];

    }

    // Update is called once per frame
    void Update()
    {
            this.intervaloTiro += Time.deltaTime;
        if (this.intervaloTiro >= this.tempoEsperaTiro)
        {
            this.intervaloTiro = 0;
            Atirar();
        }
        
    }

     private void Atirar()
    {
        Instantiate(this.laserPrefab, this.armaAtual.position, Quaternion.identity);
        if (this.armaAtual == this.posicoesArmas[0])
        {
            this.armaAtual = this.posicoesArmas[1];
        }
        else
        {
            this.armaAtual = this.posicoesArmas[0];
        }
    }
    
}
