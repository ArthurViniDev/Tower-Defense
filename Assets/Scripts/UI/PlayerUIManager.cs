using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerCoinsText;
    
    [SerializeField] private Button[] weaponsButton;
    [SerializeField] private GameObject[] weapons;
    
    private int _lastPlayerCoins = 0;

    private void Start()
    {
        _lastPlayerCoins = PlayerController.playerControllerSingleton.money;
    }

    private void Update()
    {
        if (PlayerController.playerControllerSingleton.money != _lastPlayerCoins)
        {
            ButtonsHandler();
            _lastPlayerCoins = PlayerController.playerControllerSingleton.money;
        }
    }

    private void ButtonsHandler()
    {
        playerCoinsText.text = PlayerController.playerControllerSingleton.money.ToString();
        for (int i = 0; i < weaponsButton.Length; i++)
        {
            if (PlayerController.playerControllerSingleton.money < weapons[i].GetComponent<BaseWeapon>().price)
            {
                foreach (var button in weaponsButton)
                {
                    if (button.name == weapons[i].name) button.interactable = false;
                    
                }
            }
            else
            {
                foreach (var button in weaponsButton)
                {
                    if (button.name == weapons[i].name) button.interactable = true;
                    
                }
            }
        }
    }
}
