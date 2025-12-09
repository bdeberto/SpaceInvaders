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
	protected EntitySpawner_ScriptableObject Weapon = default;
	[SerializeField]
	public PropertyContainer_ScriptableObject PropertyContainer = default;
	[SerializeField]
	public EntityAlignment Alignment = EntityAlignment.UNDEFINED;

	protected EntityController entityController = default;
	protected EntitySpawner entityWeapon = default;
	protected PropertyContainer properties = default;

	void Start()
    {
		if (Controller != null)
		{
			entityController = Controller.GetControllerCopy();
			entityController.Setup(this);
		}
		if (PropertyContainer != null)
		{
			properties = PropertyContainer.GetContainerCopy();
			properties.Setup(this);
		}
		if (Weapon != null)
		{
			entityWeapon = Weapon.GetSpawnerCopy();
			entityWeapon.Setup(this);
		}
		
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
		entityController?.Update();
		properties?.Update();
		entityWeapon?.Update();
		if (properties != null && properties.DeadFlag)
		{
			Destroy(gameObject);
		}
    }

	private void OnDestroy()
	{
		entityController?.Teardown();
		properties?.Teardown();
		entityWeapon?.Teardown();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameEntity other = collision.gameObject.GetComponent<GameEntity>();
		if (other != null && properties != null)
		{
			properties.ApplyInfluence(other.properties);
		}
	}
}
