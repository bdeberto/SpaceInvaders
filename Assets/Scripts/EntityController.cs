using UnityEngine;

public abstract class EntityController
{

    public abstract void Setup(GameObject parent);

    protected abstract bool IsValid();

    public abstract void Update();

    public abstract void Teardown();
}
