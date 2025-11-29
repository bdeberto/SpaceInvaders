using UnityEngine;

public class GameEntity : MonoBehaviour
{
    [SerializeField]
    protected PlayerController Controller = default;
    [SerializeField]
	public PropertyContainer PropertyContainer = null;

	void Start()
    {
		Controller.Setup(gameObject);
		PropertyContainer.Setup(gameObject);

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
