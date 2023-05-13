using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{

    public Text textoPontuacao;

    public BarraVida barraVida;

    private jogador jogador;


    void Start() {
        this.jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<jogador>();
    }

    // Update is called once per frame
   void Update() {
    this.barraVida.ExibirVida(this.jogador.Vida);
  

    if (textoPontuacao != null) {
        textoPontuacao.text = ControladorPontuacao.Pontuacao.ToString();
    }
}
}

