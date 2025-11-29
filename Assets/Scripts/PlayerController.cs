using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerController : EntityController
{
	public float Speed = 2000f;

	InputAction moveAction = default;
	Rigidbody2D rb = default;

	public override void Setup(GameEntity parent)
	{
		base.Setup(parent);
		rb = parent.GetComponent<Rigidbody2D>();
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
