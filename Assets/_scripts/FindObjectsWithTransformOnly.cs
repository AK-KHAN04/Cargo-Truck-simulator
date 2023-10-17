using UnityEngine;

public class FindObjectsWithTransformOnly : MonoBehaviour
{
    void Start()
    {
        // Find all objects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the object has only the Transform component
            if (HasOnlyTransformComponent(obj))
            {
                Debug.Log("Object with Transform only: " + obj.name);

                // Set the object as a child of the current GameObject
                obj.transform.SetParent(this.transform);
            }
        }
    }



    bool HasOnlyTransformComponent(GameObject obj)
    {
        // Check if the object has no children
        if (obj.transform.childCount > 0)
        {
            return false;
        }

        // Check if the object has only the Transform component
        Component[] components = obj.GetComponents<Component>();
        if (components.Length == 1 && components[0] is Transform)
        {
            return true;
        }

        return false;
    }
}
