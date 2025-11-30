using UnityEngine;

[System.Serializable]
public class EnemyController : EntityController
{
	[SerializeField]
	protected float OscillateSpeed = 2f;
	[SerializeField]
	protected float OscillateAmplitude = 2f;

	protected Rigidbody2D rb = default;
	protected Vector3 startPosition = default;

	public override object Clone()
	{
		EnemyController obj = new EnemyController();
		obj.OscillateSpeed = OscillateSpeed;
		obj.OscillateAmplitude = OscillateAmplitude;
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
		startPosition = parent.transform.position;
	}

	public override void Teardown()
	{
		
	}

	public override void Update()
	{
		Vector3 p = parent.transform.position;
		p.x = startPosition.x + (Mathf.Sin(Time.time * OscillateSpeed) * OscillateAmplitude);
		parent.transform.position = p;
	}

	protected override bool IsValid()
	{
		return rb != null;
	}
}
