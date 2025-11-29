using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class EntitySpawner : IHookedComponent
{
	[SerializeField]
	protected GameEntity SpawnablePrefab = default;
	[SerializeField]
	protected Vector3 SpawnOffset = default;
	[SerializeField]
	protected Vector3 SpawnOrientation = default;

	protected GameEntity parent = default;
	protected List<GameEntity> spawnedEntities = new List<GameEntity>();

	public virtual void Setup(GameEntity parent)
	{
		this.parent = parent;
	}

	public virtual void Teardown()
	{

	}

	public virtual void Update()
	{
		PruneSpawnList();
	}

	public virtual void SpawnEntity()
	{
		if (SpawnablePrefab != null)
		{
			GameEntity e = Object.Instantiate(SpawnablePrefab);
			e.transform.position = parent.transform.position + SpawnOffset;
			e.transform.eulerAngles = e.transform.eulerAngles + SpawnOrientation;
			spawnedEntities.Add(e);
		}
	}

	protected void PruneSpawnList()
	{
		spawnedEntities.RemoveAll(x => x == null);
	}

	protected virtual bool IsValid()
	{
		return SpawnablePrefab != null;
	}
}
