using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    public float money = 0;
    public Text moneyTextBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyTextBox.text = money.ToString();

    }
    public void addMoney()
    {
        money = money + 15;
    }
}
