using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerController : EntityController
{
	[SerializeField]
	protected float Speed = 2000f;

	protected InputAction moveAction = default;
	protected Rigidbody2D rb = default;

	public override object Clone()
	{
		PlayerController obj = new PlayerController();
		obj.Speed = Speed;
		return obj;
	}

	public override void Setup(GameEntity parent)
	{
		base.Setup(parent);
		rb = parent.GetComponent<Rigidbody2D>();
		rb.bodyType = RigidbodyType2D.Dynamic;
		moveAction = InputSystem.actions.FindAction("Move");
	}

	public override void Teardown()
	{
		
	}

	public override void Update()
	{
		if (IsValid())
		{
			Vector2 moveValue = moveAction.ReadValue<Vector2>();
			rb.AddForceX(moveValue.x * Time.deltaTime * Speed);
			if (rb.linearVelocityX > Speed)
			{
				rb.linearVelocityX = Speed;
			}
		}
	}

	protected override bool IsValid()
	{
		return moveAction != null && rb != null;
	}
}
