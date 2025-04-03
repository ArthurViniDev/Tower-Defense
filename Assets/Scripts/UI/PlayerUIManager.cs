using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerCoinsText;
    
    [SerializeField] private Button[] weaponsButton;
    [SerializeField] private GameObject[] weapons;

    private void Update()
    {
        playerCoinsText.text = PlayerController.playerControllerSingleton.money.ToString();
        for (int i = 0; i < weaponsButton.Length; i++)
        {
            foreach (var buttons in weaponsButton)
            {
                if (PlayerController.playerControllerSingleton.money < weapons[i].GetComponent<BaseWeapon>().price)
                {
                    buttons.interactable = false;
                }
            }
        }
    }
}
