using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWeapon", menuName = "Game Data/Enemy Weapon")]
public class EnemyWeapon_ScriptableObject : ShipGun_ScriptableObject
{
	[SerializeField]
	protected EnemyGun Target = default;

	public override EntitySpawner GetSpawnerCopy()
	{
		return (EntitySpawner)Target.Clone();
	}
}
