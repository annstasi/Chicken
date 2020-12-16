using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int numberOfCoins;
    public TextMeshProUGUI numberOfCoinsText;

    public static int currentHealth = 100;
    public Slider healthbar;

    public GameObject gameOverPanel;
    public GameObject youWinPanel;

    public static bool gameOver;
    void Start()
    {
        gameOverPanel.SetActive(false);
        youWinPanel.SetActive(false);
        numberOfCoins = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCoinsText.text = " coins: " + numberOfCoins;
        healthbar.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            currentHealth = 100;
        }

        if (numberOfCoins == 18)
        {
            gameOver = true;
            youWinPanel.SetActive(true);
            numberOfCoins = 0;
        }
    }
}