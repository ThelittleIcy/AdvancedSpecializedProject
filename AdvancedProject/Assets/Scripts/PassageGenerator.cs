using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageGenerator : MonoBehaviour
{
    [SerializeField]
    private int m_amount = 0;
    [SerializeField]
    private int m_height = 0, m_length = 0;
    [SerializeField]
    private GameObject m_prefab;

    private List<GameObject> m_createdObjects = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while(m_createdObjects.Count != m_amount)
        {
            if(m_createdObjects.Count == 0)
            {
                int rndX = Random.Range(-m_length/2 + 1, m_length/2 - 1);
                int rndY = Random.Range(-m_height/2 + 1, m_height/2 - 1);
                CreateNew(transform.position.x + rndX, transform.position.y + rndY);
            }
            else
            {
                int rndX = Random.Range(-m_length/2 + 1, m_length/2 - 1);
                int rndY = Random.Range(-m_height/2 + 1, m_height/2 - 1);
                foreach (GameObject obj in m_createdObjects)
                {
                    if(obj.transform.position.x == transform.position.x + rndX 
                        || obj.transform.position.x == transform.position.x + rndX + 1 
                        || obj.transform.position.x == transform.position.x + rndX - 1
                        || obj.transform.position.x == transform.position.x + rndX + 2
                        || obj.transform.position.x == transform.position.x + rndX - 2)
                    {
                        yield return null;
                    }
                    if(obj.transform.position.y == transform.position.y + rndY  
                        || obj.transform.position.y == transform.position.y + rndY + 1 
                        || obj.transform.position.y == transform.position.y + rndY - 1
                        || obj.transform.position.y == transform.position.y + rndY + 2
                        || obj.transform.position.y == transform.position.y + rndY - 2)
                    {
                        yield return null;
                    }
                    // Möglichkeit alle in einer Y Reihe
                }
                CreateNew(transform.position.x + rndX, transform.position.y + rndY);
            }
        }
    }

    private void CreateNew(float _posX, float _posY)
    {
        GameObject newObstacle = Instantiate(m_prefab,new Vector3(_posX,_posY, 0),Quaternion.identity, this.transform);
        m_createdObjects.Add(newObstacle);
        GameManager.Instance.Obstacles.Add(newObstacle);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(m_length, m_height, 0));

    }
}
