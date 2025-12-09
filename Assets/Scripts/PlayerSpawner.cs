using System.Collections;
using UnityEngine;

[System.Serializable]
public class PlayerSpawner : EntitySpawner
{
	[SerializeField]
	protected int NumLives = 4;
	[SerializeField]
	protected float SpawnDelay = 1f;

	protected int livesRemaining = 0;
	protected bool readyToSpawn = true;

	public override void Setup(GameEntity parent)
	{
		base.Setup(parent);
		livesRemaining = NumLives;
	}

	public override void Update()
	{
		base.Update();
		if (readyToSpawn && spawnedEntities.Count == 0)
		{
			parent.StartCoroutine(SpawnPlayer());
		}
	}

	IEnumerator SpawnPlayer()
	{
		yield return new WaitForSeconds(SpawnDelay);
		if (livesRemaining > 0)
		{
			SpawnEntity();
			--livesRemaining;
		}
	}

	public override object Clone()
	{
		PlayerSpawner obj = new PlayerSpawner();
		obj.SpawnablePrefab = SpawnablePrefab;
		obj.SpawnOffset = SpawnOffset;
		obj.SpawnOrientation = SpawnOrientation;
		obj.NumLives = NumLives;
		obj.SpawnDelay = SpawnDelay;
		return obj;
	}
}
