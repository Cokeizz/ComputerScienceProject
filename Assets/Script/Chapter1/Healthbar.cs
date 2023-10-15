using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    [SerializeField] private Transform player;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth/6 ;
        
        if(currenthealthBar.fillAmount <= 0)
        {
            Debug.Log("Player Die");
            SceneManager.LoadScene(5);
        }

        if(player.position.y <= -20.0f)
        {
            SceneManager.LoadScene(5);
        }
    }
}