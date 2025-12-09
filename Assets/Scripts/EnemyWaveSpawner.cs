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

    public override void Setup(GameEntity parent)
    {
        base.Setup(parent);
        SpawnWave();
    }

    public override void Update()
    {
        base.Update();
        if (CheckWaveClear())
        {
            SpawnWave();
        }
    }

    bool CheckWaveClear()
    {
        return spawnedEntities.Count == 0;
    }

    void SpawnWave()
    {
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
    }

	public override object Clone()
	{
        EnemyWaveSpawner waveSpawner = new EnemyWaveSpawner();
        waveSpawner.SpawnablePrefab = SpawnablePrefab;
        waveSpawner.SpawnOffset = SpawnOffset;
        waveSpawner.SpawnOrientation = SpawnOrientation;
        waveSpawner.NumCols = NumCols;
        waveSpawner.NumRows = NumRows;
        waveSpawner.ColOffset = ColOffset;
        waveSpawner.RowOffset = RowOffset;
        return waveSpawner;
	}
}
