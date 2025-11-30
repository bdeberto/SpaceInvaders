using UnityEngine;

[System.Serializable]
public class EnemyGun : ShipGun
{
	[SerializeField]
	protected float ShotDelayMinimum = .2f;

	public override object Clone()
	{
		EnemyGun obj = new EnemyGun();
		obj.parent = parent;
		obj.ShotDelay = ShotDelay;
		obj.SpawnablePrefab = SpawnablePrefab;
		obj.SpawnOffset = SpawnOffset;
		obj.SpawnOrientation = SpawnOrientation;
		obj.ShotDelayMinimum = ShotDelayMinimum;
		return obj;
	}

	public override void Setup(GameEntity parent)
	{
		base.Setup(parent);
		PickDelay();
	}

	protected virtual void PickDelay()
	{
		shotTimer = Random.Range(ShotDelayMinimum, ShotDelay);
	}

	protected override void FireWeapon()
	{
		SpawnEntity();
		PickDelay();
	}
}
