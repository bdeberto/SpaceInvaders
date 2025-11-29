using UnityEngine;

[System.Serializable]
public class PropertyContainer
{
	public int HitPoints = 10;
	public int HitValue = 10;
	public bool DeadFlag = false;

	protected PropertyContainer target = null;
   
	public void Setup(GameObject parent)
	{
		target = null;
	}

	public void Update()
	{
		ResolveInfluence();
	}

	public void Teardown()
	{

	}

	protected void ResolveInfluence()
	{
		if (target != null)
		{
			HitPoints -= target.HitValue;
			if (HitPoints <= 0)
			{
				DeadFlag = true;
			}
			target = null;
		}
	}

	public void ApplyInfluence(PropertyContainer other)
	{
		if (target == null)
		{
			target = other;
		}
	}
}
