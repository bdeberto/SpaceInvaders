using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
	protected EntitySpawner_ScriptableObject Weapon = default;
	[SerializeField]
	public PropertyContainer PropertyContainer = default;
	[SerializeField]
	public EntityAlignment Alignment = EntityAlignment.UNDEFINED;

	protected EntityController entityController = default;
	protected EntitySpawner entityWeapon = default;

	void Start()
    {
		entityController = Controller.GetControllerCopy();
		entityController.Setup(this);
		PropertyContainer.Setup(this);
		if (Weapon != null)
		{
			entityWeapon = Weapon.GetSpawnerCopy();
		}
		entityWeapon?.Setup(this);
		switch (Alignment)
		{
			case EntityAlignment.PROTAGONIST:
				gameObject.layer = LayerMask.NameToLayer("Protagonist");
				break;
			case EntityAlignment.ANTAGONIST:
				gameObject.layer = LayerMask.NameToLayer("Antagonist");
				break;
			default:
				//leave as default
				break;
		}
	}

    void Update()
    {
		entityController.Update();
		PropertyContainer.Update();
		entityWeapon?.Update();
		if (PropertyContainer.DeadFlag)
		{
			Destroy(gameObject);
		}
    }

	private void OnDestroy()
	{
		entityController.Teardown();
		PropertyContainer.Teardown();
		entityWeapon?.Teardown();
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
