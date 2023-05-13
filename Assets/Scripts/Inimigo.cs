using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public float velocidadeMinima;
    public float velocidadeMaxima;
    private float velocidadeY;
    public int vidas;


    public ParticleSystem particulaExplosaoPrefab;



    // Start is called before the first frame update
    void Start()
    {
        this.velocidadeY = Random.Range(this.velocidadeMinima, this.velocidadeMaxima);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody.velocity = new Vector2(0, -this.velocidadeY);

        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if(posicaoNaCamera.y < 0)
        {
            //jogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
            jogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<jogador>();

             jogador.Vida--;
            Destruir(false);
        }
  
    
    }

    public void ReceberDano()
    {
        this.vidas--;
        if(vidas <= 0)
        {
            Destruir(true);
        }
    }

    private void Destruir(bool derrotado)
    {
        if (derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }
        // Instatiate(this.particulaExplosaoPrefab, this.transform.position, Quarternion.identity);
       ParticleSystem ParticulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
        Destroy(ParticulaExplosao.gameObject,1f);



        Destroy(this.gameObject);
    }

}


