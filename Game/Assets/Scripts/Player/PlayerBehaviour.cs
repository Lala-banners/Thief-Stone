using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Vector2Int PlayerPosition { get; private set; }
    /// <summary>
    /// This value is more for animation speed than anything
    /// </summary>
    [SerializeField] private float moveSpeed = 2.0f;

    private List<TileBehaviour> path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSpace(Vector2Int destination)
    {
        path = GridManager.Instance.FindPath(PlayerPosition, destination);
        StartCoroutine(nameof(Movement));
    }

    private IEnumerator Movement()
    {
        for (int i = 1; i < path.Count; i++)
        {
            float increment = 0.0f;
            Vector3 start = transform.position;
            Vector3 end = path[i].transform.position;
            while (increment < 1.0f)
            {
                increment += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(start, end, increment);
                yield return null;
            }
            transform.position = end;
        }
        PlayerPosition = path[path.Count - 1].Coords;
    }
}
