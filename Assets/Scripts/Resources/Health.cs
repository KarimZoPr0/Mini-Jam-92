using UnityEngine;
using UnityEngine.Events;


namespace GSS.Resources
{
	public class Health : MonoBehaviour
	{
		public int healthPoints;

		[SerializeField] private UnityEvent    onDie;
		[SerializeField] private UnityEvent    onDamage;

		private bool _isDead;

		public bool IsDead() => _isDead;
		
		public void TakeDamage(int damage)
		{
			onDamage?.Invoke(); 
			healthPoints = Mathf.Max(healthPoints - damage, 0);

			if (healthPoints <= 0)
				Die();
		}

		private void Die()
		{
			if (_isDead) return;
			onDie.Invoke();
			_isDead            = true;
		}

	}
}