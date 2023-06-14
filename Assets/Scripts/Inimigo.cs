using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody;
    public float velocidadeMinima;
    public float velocidadeMaxima;
    private float velocidadeY;
    public int vidas;
    public ParticleSystem particulaExplosaoPrefab;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarItemVida;

    [SerializeField]
    private ItemVida itemVidaPrefab;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarPowerUp;

    [SerializeField]
    private PowerUpColetavel[] powerUpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 posicaoAtual = transform.position;
        float metadeLargura = Largura / 2f;

        float pontoReferenciaEsquerda = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireita = posicaoAtual.x + metadeLargura;

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero);
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one);

        if (pontoReferenciaEsquerda < limiteInferiorEsquerdo.x)
        {
            float posicaoX = limiteInferiorEsquerdo.x + metadeLargura;
            transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }
        else if (pontoReferenciaDireita > limiteSuperiorDireito.x)
        {
            float posicaoX = limiteSuperiorDireito.x - metadeLargura;
            transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }

        velocidadeY = Random.Range(velocidadeMinima, velocidadeMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(0, -velocidadeY);

        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(transform.position);
        if (posicaoNaCamera.y < 0)
        {
            jogador jogador = GameObject.FindGameObjectWithTag("Player")?.GetComponent<jogador>();
            if (jogador != null)
            {
                jogador.Vida--;
                Destruir(false);
            }
            //jogador.Vida--;
            Destruir(false);
        }
    }

    public void ReceberDano()
    {
        vidas--;
        if (vidas <= 0)
        {
            Destruir(true);
        }
    }

   private float Largura
{
    get
    {
        if (spriteRenderer != null)
        {
            Bounds bounds = spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
        else
        {
            Debug.LogError("A variável spriteRenderer não foi atribuída no Inspector.");
            return 0f;
        }
    }
}


    private void Destruir(bool derrotado)
    {
        if (derrotado)
        {
            ControladorPontuacao.Pontuacao++;

            SoltarItemVida();


        }
        ParticleSystem particulaExplosao = Instantiate(particulaExplosaoPrefab, transform.position, Quaternion.identity);
        Destroy(particulaExplosao.gameObject, 1f);
        Destroy(gameObject);
    }


    private void SoltarItemVida(){
        float chanceAleatoria = Random.Range(0f, 100f);
        if(chanceAleatoria <= this.chanceSoltarItemVida){
            
            Instantiate(this.itemVidaPrefab, transform.position, Quaternion.identity);
        }
    }

    private void SoltarPowerUp(){
        float chanceAleatoria = Random.Range(0f, 100f);
        if(chanceAleatoria <= this.chanceSoltarPowerUp){
            int indiceAleatorio = Random.Range(0, this.powerUpPrefabs.Length);
            PowerUpColetavel powerUpPrefab = this.powerUpPrefabs[indiceAleatorio];
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
           
        }
    }
}
