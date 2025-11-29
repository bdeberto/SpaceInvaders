
[System.Serializable]
public abstract class EntityController : IHookedComponent
{
    protected GameEntity parent;

    public virtual void Setup(GameEntity parent)
    {
        this.parent = parent;
    }

    protected abstract bool IsValid();

    public abstract void Update();

    public abstract void Teardown();
}
