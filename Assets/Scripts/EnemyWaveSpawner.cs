using System.Collections;
using UnityEngine;

[System.Serializable]
public class EnemyWaveSpawner : EntitySpawner
{
    [SerializeField]
    protected int NumRows = 2;
	[SerializeField]
	protected int NumCols = 3;
	[SerializeField]
	protected float RowOffset = -1f;
	[SerializeField]
	protected float ColOffset = 2f;
    [SerializeField]
    protected float WaveRespawnDelay = 1.5f;

    protected bool readyToSpawn = true;

    public override void Setup(GameEntity parent)
    {
        base.Setup(parent);
        SpawnWave();
    }

    public override void Update()
    {
        base.Update();
        if (readyToSpawn && CheckWaveClear())
        {
            readyToSpawn = false;
            parent.StartCoroutine(SpawnWave());
        }
    }

    bool CheckWaveClear()
    {
        return spawnedEntities.Count == 0;
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(WaveRespawnDelay);
        Vector3 origin = SpawnOffset;
        for (int i = 0; i < NumRows; ++i)
        {
            for (int j = 0; j < NumCols; ++j)
            {
                SpawnEntity();
                SpawnOffset.x += ColOffset;
            }
            SpawnOffset.x = 0f;
            SpawnOffset.y += RowOffset;
        }
        SpawnOffset = origin;
        readyToSpawn = true;
    }

	public override object Clone()
	{
        EnemyWaveSpawner obj = new EnemyWaveSpawner();
		obj.SpawnablePrefab = SpawnablePrefab;
		obj.SpawnOffset = SpawnOffset;
		obj.SpawnOrientation = SpawnOrientation;
		obj.NumCols = NumCols;
		obj.NumRows = NumRows;
		obj.ColOffset = ColOffset;
		obj.RowOffset = RowOffset;
		obj.WaveRespawnDelay = WaveRespawnDelay;
        return obj;
	}
}
