using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerGun : ShipGun
{
	protected InputAction attackAction = default;

	public override object Clone()
	{
		PlayerGun obj = new PlayerGun();
		obj.parent = parent;
		obj.ShotDelay = ShotDelay;
		obj.SpawnablePrefab = SpawnablePrefab;
		obj.SpawnOffset = SpawnOffset;
		obj.SpawnOrientation = SpawnOrientation;
		return obj;
	}

	public override void Setup(GameEntity parent)
	{
		base.Setup(parent);
		attackAction = InputSystem.actions.FindAction("Attack");
	}

	protected override bool IsValid()
	{
		return base.IsValid() && attackAction != null;
	}

	protected override void FireWeapon()
	{
		if (attackAction.IsPressed())
		{
			base.FireWeapon();
		}
	}
}
