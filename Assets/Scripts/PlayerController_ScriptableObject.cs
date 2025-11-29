using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipController", menuName = "Game Data/Player Ship Controller")]
public class PlayerController_ScriptableObject : ShipController_ScriptableObject
{
    public PlayerController Target = default;

	public override EntityController GetController()
	{
		return Target;
	}
}
