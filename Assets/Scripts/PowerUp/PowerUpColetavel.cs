using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{
  [SerializedField]
   private float intervaloTempoAntesAutoDestruir;

   private float contagemTempoAntesAutoDestruir;


   public  void Start() {
    this.contagemTempoAntesAutoDestruir = 0;
    
   }

   public void Update() {
     this.contagemTempoAntesAutoDestruir += Time.deltaTime;
     if(this.contagemTempoAntesAutoDestruir >= this.intervaloTempoAntesAutoDestruir){
       Destroy(this.gameObject);
     }
   }

   public abstract EfeitoPowerUp EfeitoPowerUp {get;}

   public void Coletar(){
    Destroy(this.gameObject);
   }

   private void IniciarAutoDestruicao(){
     this.contagemTempoAntesAutoDestruir = 0;
   }

 }



