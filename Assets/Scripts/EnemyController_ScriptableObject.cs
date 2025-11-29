using UnityEngine;

[CreateAssetMenu(fileName = "EnemyShipController", menuName = "Game Data/Enemy Ship Controller")]
public class EnemyController_ScriptableObject : ShipController_ScriptableObject
{
	public EnemyController Target = default;

	public override EntityController GetControllerCopy()
	{
		return (EntityController)Target.Clone();
	}
}
