

using UnityEngine;

[System.Serializable]
public class PropertyContainer : IHookedComponent
{
	public int HitPoints = 10;
	public int HitValue = 10;
	public bool DeadFlag = false;
	public EntityAlignment Alignment = EntityAlignment.UNDEFINED;

	protected PropertyContainer target = null;
	protected GameEntity parent = default;

	public virtual void Setup(GameEntity parent)
	{
		this.parent = parent;
		target = null;
		switch (Alignment)
		{
			case EntityAlignment.PROTAGONIST:
				parent.gameObject.layer = LayerMask.NameToLayer("Protagonist");
				break;
			case EntityAlignment.ANTAGONIST:
				parent.gameObject.layer = LayerMask.NameToLayer("Antagonist");
				break;
			default:
				//leave as default
				break;
		}
	}

	public void Update()
	{
		//physics resolves before Update
		//cross-pollinate in physics, resolve in Update
		ResolveInfluence();
	}

	public void Teardown()
	{

	}

	protected void ResolveInfluence()
	{
		if (target != null && target.Alignment != Alignment)
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
