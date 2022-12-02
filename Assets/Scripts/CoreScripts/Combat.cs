using UnityEngine;

public class Combat<T> where T: IDamageable
{
	private float _health;
	public Combat(T damageable)
	{
		_health = damageable.Health;
	}

	public void TakeDamage()
	{
		_health -= 10;
	}


}
