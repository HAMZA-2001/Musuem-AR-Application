using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionManager : MonoBehaviour
{
    public GameObject sphere;
    public GameObject key;
    public TextMeshProUGUI youWonText;

    private bool isCollisionDetected = false;

    void Update()
    {
        if (!isCollisionDetected && CheckCollision(sphere, key))
        {
            isCollisionDetected = true;
            youWonText.gameObject.SetActive(true);
        }
    }

    bool CheckCollision(GameObject obj1, GameObject obj2)
    {
        Collider[] colliders1 = obj1.GetComponentsInChildren<Collider>();
        Collider[] colliders2 = obj2.GetComponentsInChildren<Collider>();

        foreach (Collider collider1 in colliders1)
        {
            foreach (Collider collider2 in colliders2)
            {
                if (collider1.bounds.Intersects(collider2.bounds))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
