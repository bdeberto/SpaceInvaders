using UnityEngine;

public abstract class EntitySpawner_ScriptableObject : ScriptableObject
{
    public abstract EntitySpawner GetSpawnerCopy();
}
