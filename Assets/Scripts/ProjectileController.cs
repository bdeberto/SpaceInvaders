using UnityEngine;

[System.Serializable]
public class ProjectileController : EntityController
{
	[SerializeField]
	protected float Speed = 100f;

	protected Rigidbody2D rb = default;

	public override object Clone()
	{
		ProjectileController obj = new ProjectileController();
		obj.Speed = Speed;
		return obj;
	}

	public override void Setup(GameEntity parent)
	{
		base.Setup(parent);
		rb = parent.GetComponent<Rigidbody2D>();
		if (IsValid())
		{
			rb.bodyType = RigidbodyType2D.Kinematic;
		}
	}

	public override void Teardown()
	{
		
	}

	public override void Update()
	{
		Vector3 p = parent.transform.position;
		p += parent.transform.up * Time.deltaTime * Speed;
		parent.transform.position = p;
		if (Vector3.Distance(Vector3.zero, p) > 10f)
		{
			Object.Destroy(parent.gameObject);
		}
	}

	protected override bool IsValid()
	{
		return rb != null;
	}
}
