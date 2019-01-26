using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionsAmount;
    [SerializeField] private GameObject lifesPanel;
    [SerializeField] private Player player;


    private void Start()
    {
        player.notifyHpChange += updateLifesHud;
        player.notifyDeath += endGame;
        player.notifyInventoryChange += updateInventoryHud;
    }

    private void updateLifesHud(float amount)
    {
        for (int i = lifesPanel.transform.childCount-1; i >= 0; i--)
        {
            if (i >= amount)
            {
                Image icon = lifesPanel.transform.GetChild(i).GetComponent<Image>();
                var color = icon.color;
                color.a = 0f;
                icon.color = color;
            }
            else
            {
                Image icon = lifesPanel.transform.GetChild(i).GetComponent<Image>();
                var color = icon.color;
                color.a = 1f;
                icon.color = color;
            }
        }
    }

    private void updateInventoryHud(float amount)
    {
        potionsAmount.SetText("x " + amount.ToString());
    }

    private void endGame()
    {
        updateLifesHud(0);
    }
}
