
public interface IHookedComponent
{
    void Setup(GameEntity parent);
    void Update();
    void Teardown();
}
