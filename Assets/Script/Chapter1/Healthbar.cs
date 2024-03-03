using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject playerObject;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth/6 ;
        
        if(currenthealthBar.fillAmount <= 0)
        {
            
            GameOverUI.SetActive(true);
            Debug.Log("-1 {die}");
            playerObject.SetActive(false);
            
        }

        if(player.position.y <= -20.0f)
        {
           
            GameOverUI.SetActive(true);
            playerObject.SetActive(false);
           Debug.Log("-1 {die}");
            
        }
    }
}