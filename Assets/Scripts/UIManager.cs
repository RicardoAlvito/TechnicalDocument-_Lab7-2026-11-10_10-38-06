using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Instance para
    public static UIManager Instance { get; private set; }
    [SerializeField]private TMP_Text scoreText;
    [SerializeField]private TMP_Text livesText;
    private int startLives = 3;
    public int score = 0;
    private int lives = 0;

    private void Awake()
    {
        //Caso a Instancia do objeto da UI for diferente de null "vazio" se destroi
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Inicializa valores da UI no início
        Instance = this;
        lives = startLives;
        score = 0;
        UpdateScoreUI();
        UpdateLivesUI();
    }
    // Atualiza o texto da pontuação
    void UpdateScoreUI()
    {
        scoreText.text = "Pontos: " + score;
    }

    // Atualiza o texto das vidas
    void UpdateLivesUI() 
    {
        livesText.text = "Vida: " + lives;
    }

    // Define o valor para as vidas
    public void SetLives(int newLives)
    {
        lives = newLives;
        UpdateLivesUI();
    }

    // Define o valor para os pontos
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    // Adiciona o valor para as vidas
    public void AddLives(int amount)
    {
        lives += amount;
        UpdateLivesUI();
    }

    // Diminui o valor para os vidas
    public void munusLives(int amount)
    {
        lives -= amount;
        UpdateLivesUI();
    }

}
