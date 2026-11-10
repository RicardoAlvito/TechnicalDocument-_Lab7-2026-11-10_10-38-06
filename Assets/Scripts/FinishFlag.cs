using UnityEngine;

public class FinishFlag : MonoBehaviour
{

    public int requiredScore = 5;//Quatidade necessária para completar o nível
   
    private void Awake()
    {
        //Obriga a colisão do objeto fique Trigger
        GetComponent<Collider>().isTrigger = true;
    }

    // Verefica se a colisão do obejto tem a tag "Player" se não ignorar 
    private void OnTriggerEnter(Collider other) {


        if (UIManager.Instance!=null) {
            // Verifica se o jogador têm a quatidade necessária de pontos
            if (UIManager.Instance.score >= requiredScore)
            {


                Debug.Log("Nivel Complento");
            }
            else {

                Debug.Log("Colenta todos os tokens antes complentar o nivel");
            }
        
        }

      
        
    }
}
