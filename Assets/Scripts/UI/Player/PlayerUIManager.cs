using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerCoinsText;

    [SerializeField] private Button[] weaponsButton;
    [SerializeField] private GameObject[] weapons;

    private int _lastPlayerCoins;

    private void Start()
    {
        _lastPlayerCoins = PlayerController.Instance.money;
    }

    private void Update()
    {
        if (PlayerController.Instance.money == _lastPlayerCoins) return;
        // se o player ganhar/perder moedas:
        ButtonsHandler();
        _lastPlayerCoins = PlayerController.Instance.money;
    }

    private void ButtonsHandler()
    {
        playerCoinsText.text = PlayerController.Instance.money.ToString();
        for (int i = 0; i < weaponsButton.Length; i++)
        {
            bool canBuy = PlayerController.Instance.money >= weapons[i].GetComponent<BaseWeapon>().price;

            foreach (var button in weaponsButton)
            {
                if (button.name == weapons[i].name)
                {
                    button.interactable = canBuy;
                }
            }
        }
    }
}
