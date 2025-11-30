using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWeapon", menuName = "Game Data/Player Weapon")]
public class PlayerWeapon_ScriptableObject : ShipGun_ScriptableObject
{
	[SerializeField]
	protected PlayerGun Target = default;

	public override EntitySpawner GetSpawnerCopy()
	{
		return (EntitySpawner)Target.Clone();
	}
}
