using System;

[Serializable]
public class PropertyContainer : IHookedComponent, ICloneable
{
	public int HitPoints = 10;
	public int HitValue = 10;
	public bool DeadFlag = false;

	protected PropertyContainer target = null;
	protected GameEntity parent = default;

	public virtual void Setup(GameEntity parent)
	{
		this.parent = parent;
		target = null;
	}

	public virtual void Update()
	{
		//physics resolves before Update
		//cross-pollinate in physics, resolve in Update
		ResolveInfluence();
	}

	public virtual void Teardown()
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

	public object Clone()
	{
		PropertyContainer obj = new PropertyContainer();
		obj.HitPoints = HitPoints;
		obj.HitValue = HitValue;
		obj.DeadFlag = DeadFlag;
		return obj;
	}
}
