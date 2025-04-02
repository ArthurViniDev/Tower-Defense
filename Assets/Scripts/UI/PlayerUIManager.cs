using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerCoinsText;

    private void Update()
    {
        playerCoinsText.text = PlayerController.playerControllerSingleton.money.ToString();
    }
}
