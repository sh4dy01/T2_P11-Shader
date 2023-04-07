using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	[SerializeField] private PlayerAttacks _playerAttacks;
	[SerializeField] private PlayerHungerThirst _playerHungerThirst;

	[SerializeField] private Image _hungerBar;
	[SerializeField] private Image _thirstBar;
	[SerializeField] private Image _healthBar;
	
	private void Awake()
	{
		_playerHungerThirst.OnUpdate += UpdateValues;
		_playerAttacks.OnHit += UpdateHealth;
	}

	private void OnDestroy()
	{
		_playerHungerThirst.OnUpdate -= UpdateValues;
		_playerAttacks.OnHit -= UpdateHealth;
	}

	private void UpdateValues()
	{
		_hungerBar.fillAmount = _playerHungerThirst.Hunger / 100.0F;
		_thirstBar.fillAmount = _playerHungerThirst.Thirst / 100.0F;
	}

	private void UpdateHealth()
	{
		_healthBar.fillAmount = (float)_playerAttacks.Health / (float)_playerAttacks.MaxHealth;
	}
}
