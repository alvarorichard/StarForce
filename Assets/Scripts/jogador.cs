using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    public Laser laserPrefab;
    public float tempoEsperaTiro;
        private float intervaloTiro;

    public Transform[] posicoesArmas;
    private Transform armaAtual;

    private int vidas;
    private FimJogo TelaFimJogo;

    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        this.vidas = 5;
        this.intervaloTiro = 0;
        this.armaAtual = this.posicoesArmas[0];
        ControladorPontuacao.Pontuacao = 0;
        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.TelaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this .TelaFimJogo.Esconder();

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


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //mobile input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.x > 0)
            {
                horizontal = 1;
            }
            else
            {
                horizontal = -1;
            }
            if (touchPosition.y > 0)
            {
                vertical = 1;
            }
            else
            {
                vertical = -1;
            }
        }

        float velocidadeX = (horizontal * this.velocidadeMovimento);
        float velocidadeY = (vertical * this.velocidadeMovimento);

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY);
         VerificarLimiteTela();

    }

    private void VerificarLimiteTela(){

Vector2 posicaoAtual = this.transform.position;

float metadeLargura = this.Largura / 2f;
float metadeAltura = this.Altura / 2f;

Camera camera = Camera.main;

Vector2 limiteInferiorEquerdo = camera.ViewportToWorldPoint(new Vector2(0,0));

Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(new Vector2(1,1));

float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;



if(posicaoAtual.x < limiteInferiorEquerdo.x){

this.transform.position = new Vector2( limiteInferiorEquerdo.x , posicaoAtual.y);


}else if(posicaoAtual.x > limiteSuperiorDireito.x){
    this.transform.position = new Vector2( limiteSuperiorDireito.x, posicaoAtual.y);
}

   posicaoAtual = this.transform.position;

    float pontoReferenciaInferior = posicaoAtual.y - metadeAltura;
    float pontoReferenciaSuperior = posicaoAtual.y + metadeAltura;


    if(pontoReferenciaSuperior > limiteSuperiorDireito.y){
        this.transform.position = new Vector2(posicaoAtual.x, limiteSuperiorDireito.y - metadeAltura);

    }else if(pontoReferenciaInferior < limiteInferiorEquerdo.y){
        this.transform.position = new Vector2(posicaoAtual.x, limiteInferiorEquerdo.y + metadeAltura);
    }

}

private float Largura{
    get{
        Bounds bounds = this.spriteRenderer.bounds;
        Vector3 tamanho = bounds.size;
        return tamanho.x;
    }

}


private float Altura{
    get{
        Bounds bounds = this.spriteRenderer.bounds;
        Vector3 tamanho = bounds.size;
        return tamanho.y;
    }

}



 private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Inimigo")) {
            Vida--;
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            inimigo.ReceberDano();
        }
    }



 public int Vida {
        get {
            return this.vidas;
        }
        set {
            this.vidas = value;
            if (this.vidas <= 0) {
                this.vidas = 0;
                this.gameObject.SetActive(false);
                // Exibir tela de fim de jogo               
                TelaFimJogo.Exibir();
            }
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