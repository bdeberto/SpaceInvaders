using UnityEngine;

public class GameEntity : MonoBehaviour
{
    [SerializeField]
    protected PlayerController controller = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller.Setup(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        controller.Update();
    }

	private void OnDestroy()
	{
        controller.Teardown();
	}
}
