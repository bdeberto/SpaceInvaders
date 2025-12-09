using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveSpawner", menuName = "Game Data/Enemy Wave Spawner")]
public class EnemyWaveSpawner_ScriptableObject : EntitySpawner_ScriptableObject
{
	[SerializeField]
	protected EnemyWaveSpawner Target = default;

	public override EntitySpawner GetSpawnerCopy()
	{
		return (EnemyWaveSpawner)Target.Clone();
	}
}
