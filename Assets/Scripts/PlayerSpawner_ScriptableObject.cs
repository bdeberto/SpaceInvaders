using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpawner", menuName = "Game Data/Player Spawner")]
public class PlayerSpawner_ScriptableObject : EntitySpawner_ScriptableObject
{
	[SerializeField]
	protected PlayerSpawner Target = default;

	public override EntitySpawner GetSpawnerCopy()
	{
		return (PlayerSpawner)Target.Clone();
	}
}
