using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float intervaloTempoAntesAutoDestruir;

    private float contagemTempoAntesAutoDestruir;
    private bool autodestruindo;

    [SerializeField]
    private float intervaloTempoEntrePiscadas;

    [SerializeField]
    private int quantidadeTotalPiscadas;

    [SerializeField]
    private float reducaoTempoEntrePiscadas;

    private float tempoDesaparecer;

    [SerializeField]
     protected float duracaoEmSegundos;

    public void Start()
    {
        this.autodestruindo = false;
        this.contagemTempoAntesAutoDestruir = 0;
        this.tempoDesaparecer = intervaloTempoAntesAutoDestruir;
    }

    public void Update()
    {
        if (!this.autodestruindo)
        {
            this.contagemTempoAntesAutoDestruir += Time.deltaTime;
            if (this.contagemTempoAntesAutoDestruir >= this.intervaloTempoAntesAutoDestruir)
            {
                IniciarAutoDestruicao();
            }
        }
        else
        {
            tempoDesaparecer -= Time.deltaTime;
            if (tempoDesaparecer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public abstract EfeitoPowerUp EfeitoPowerUp { get; }

    public float DuracaoEmSegundos
    {
        get
        {
            return this.duracaoEmSegundos;
        }
    }

    public void Coletar()
    {
        Destroy(this.gameObject);
    }

    private void IniciarAutoDestruicao()
    {
        this.autodestruindo = true;
        StartCoroutine(Autodestruir());
    }

    private IEnumerator Autodestruir()
    {
        int contadorPiscadas = 0;
        do
        {
            this.spriteRenderer.enabled = !this.spriteRenderer.enabled;
            yield return new WaitForSeconds(this.intervaloTempoEntrePiscadas);
            contadorPiscadas++;
            this.intervaloTempoEntrePiscadas -= contadorPiscadas * this.reducaoTempoEntrePiscadas;
        } while (contadorPiscadas < this.quantidadeTotalPiscadas);

        Destroy(this.gameObject);
    }
}
