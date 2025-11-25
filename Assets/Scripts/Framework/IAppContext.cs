

public interface IAppContext
{
	IGameContext gameContext { get; }
	IMenuContext menuContext { get; }

	void Setup();
	void Update();
	void Teardown();
}
