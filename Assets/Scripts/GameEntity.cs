using UnityEngine;

public enum EntityAlignment
{
	PROTAGONIST = 0,
	ANTAGONIST,
	UNDEFINED,
}

public class GameEntity : MonoBehaviour
{
    [SerializeField]
    protected ShipController_ScriptableObject Controller = default;
	[SerializeField]
	protected ShipGun Weapon = default;
	[SerializeField]
	public PropertyContainer PropertyContainer = null;

	void Start()
    {	
		Controller.GetController().Setup(this);
		PropertyContainer.Setup(this);
		Weapon.Setup(this);
	}

    void Update()
    {
		Controller.GetController().Update();
		PropertyContainer.Update();
		Weapon.Update();
		if (PropertyContainer.DeadFlag)
		{
			Destroy(gameObject);
		}
    }

	private void OnDestroy()
	{
		Controller.GetController().Teardown();
		PropertyContainer.Teardown();
		Weapon.Teardown();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameEntity other = collision.gameObject.GetComponent<GameEntity>();
		if (other != null)
		{
			PropertyContainer.ApplyInfluence(other.PropertyContainer);
		}
	}
}
