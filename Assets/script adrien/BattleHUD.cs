using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

	public Text nameText;
	public Text levelText;
	public Slider hpSlider;
    public Text nb_life;

	public void SetHUD(enemy unit)
	{
		nameText.text = unit.unitName;
		levelText.text = "Lvl " + unit.unitLevel;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
        nb_life.text = unit.currentHP + "/" + unit.maxHP;
	}

	public void SetHP(int hp, enemy unit)
	{
		hpSlider.value = hp;
        nb_life.text = hp + "/" + unit.maxHP;

	}

}