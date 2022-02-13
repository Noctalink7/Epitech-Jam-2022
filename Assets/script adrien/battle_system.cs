using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class battle_system : MonoBehaviour
{
public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	enemy playerUnit;
	enemy enemyUnit;
//	public Animator animator_player;
//	public Animator animator_enemy;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<enemy>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<enemy>();

		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
//		animator_player = playerUnit.GetComponentInChildren<Animator>;
//		animator_enemy = enemyUnit.GetComponentInChildren<Animator>;

		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
//		animator_player.SetTrigger("attack");
//		animator_enemy.SetTrigger("hurt");

		enemyHUD.SetHP(enemyUnit.currentHP, enemyUnit);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
//			animator_player.SetBool("win", true);
//			animator_enemy.SetBool("dead", true);
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
//		animator_player = playerUnit.GetComponentInChildren<Animator>;
//		animator_enemy = enemyUnit.GetComponentInChildren<Animator>;

		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
//		animator_player.SetTrigger("hurt");
//		animator_enemy.SetTrigger("attack");

		playerHUD.SetHP(playerUnit.currentHP, playerUnit);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
//			animator_player.SetBool("win", false);
//			animator_enemy.SetBool("dead", true);
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	{
//		animator_player = playerUnit.GetComponentInChildren<Animator>;
//		animator_enemy = enemyUnit.GetComponentInChildren<Animator>;

		playerUnit.Heal(5);

//		animator_player.SetTrigger("heal");
		playerHUD.SetHP(playerUnit.currentHP, playerUnit);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}
}
