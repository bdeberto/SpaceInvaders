using UnityEngine;

[CreateAssetMenu(fileName = "PropertyContainer", menuName = "Game Data/Property Container")]
public class PropertyContainer_ScriptableObject : ScriptableObject
{
	public PropertyContainer Target = default;

	public PropertyContainer GetContainerCopy()
	{
		return (PropertyContainer)Target.Clone();
	}
}
