using UnityEngine;

[System.Serializable]
public abstract class ShipGun : EntitySpawner
{
	[SerializeField]
	protected float ShotDelay = .33f;
	
	protected float shotTimer = 0f;

	public override void Update()
	{
		if (IsValid() && shotTimer <= 0f)
		{
			FireWeapon();
		}
		if (shotTimer > 0f)
		{
			shotTimer -= Time.deltaTime;
		}
		base.Update();
	}

	protected virtual void FireWeapon()
	{
		SpawnEntity();
		shotTimer = ShotDelay;
	}
}
