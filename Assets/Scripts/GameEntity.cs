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
    protected PlayerController Controller = default;
    [SerializeField]
	public PropertyContainer PropertyContainer = null;

	void Start()
    {	
		Controller.Setup(this);
		PropertyContainer.Setup(this);

	}

    void Update()
    {
		Controller.Update();
		PropertyContainer.Update();
		if (PropertyContainer.DeadFlag)
		{
			Destroy(gameObject);
		}
    }

	private void OnDestroy()
	{
		Controller.Teardown();
		PropertyContainer.Teardown();
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
