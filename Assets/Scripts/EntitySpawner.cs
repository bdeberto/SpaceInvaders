using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class EntitySpawner : IHookedComponent, ICloneable
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
			GameEntity e = UnityEngine.Object.Instantiate(SpawnablePrefab);
			e.transform.position = parent.transform.position + SpawnOffset;
			e.transform.eulerAngles = parent.transform.eulerAngles + SpawnOrientation;
			e.Alignment = parent.Alignment;
			spawnedEntities.Add(e);
		}
	}

	protected virtual void PruneSpawnList()
	{
		spawnedEntities.RemoveAll(x => x == null);
	}

	protected virtual bool IsValid()
	{
		return SpawnablePrefab != null;
	}

	public abstract object Clone();
}
