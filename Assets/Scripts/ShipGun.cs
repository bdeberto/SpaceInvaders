using UnityEngine;

[System.Serializable]
public class ShipGun : EntitySpawner
{
	[SerializeField]
	protected float ProjectileSpeed = 25000f;

	public override void Setup(GameEntity parent)
	{
		base.Setup(parent);

	}

	public override void Teardown()
	{
		
	}

	public override void Update()
	{
		
	}


}
