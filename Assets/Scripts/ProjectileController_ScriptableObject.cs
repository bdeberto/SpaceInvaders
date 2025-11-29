using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileController", menuName = "Game Data/Projectile Controller")]
public class ProjectileController_ScriptableObject : ShipController_ScriptableObject
{
	public ProjectileController Target = default;

	public override EntityController GetControllerCopy()
	{
		return (EntityController)Target.Clone();
	}
}
