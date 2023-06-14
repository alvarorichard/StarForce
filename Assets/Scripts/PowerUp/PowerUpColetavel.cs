using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{
   [SerializeField]
   private SpriteRender spriteRender;

  [SerializedField]
   private float intervaloTempoAntesAutoDestruir;

   private float contagemTempoAntesAutoDestruir;
   private bool autodestruindo;

   [SerializedField]
   private float intervaloTempoEntrePiscadas;

   [SerializedField]
   private int quantidadeTotalPiscadas;
   


   public  void Start() {
    this.autodestruindo = false;
    this.contagemTempoAntesAutoDestruir = 0;
    
   }

   public void Update() {
    if(!this.autodestruindo){
      
     this.contagemTempoAntesAutoDestruir += Time.deltaTime;
     if(this.contagemTempoAntesAutoDestruir >= this.intervaloTempoAntesAutoDestruir){
     IniciarAutoDestruicao();
     }
   }
    }

   public abstract EfeitoPowerUp EfeitoPowerUp {get;}

   public void Coletar(){
    Destroy(this.gameObject);
   }

   private void IniciarAutoDestruicao(){
   this.autodestruindo = true;

   

   }

   private IEnumerator Autodestruir(){
    int contadorPiscadas = 0;
   do{
      

     this.spriteRender.enabled = !this.spriteRender.enabled;
// esperar um intervalo de tempo 

  yield return new WaitForSeconds(3f);

    contadorPiscadas++;

   }while(contadorPiscadas < this.quantidadeTotalPiscadas);

 }

}



