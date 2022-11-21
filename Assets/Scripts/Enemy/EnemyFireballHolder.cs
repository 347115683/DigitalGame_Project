using UnityEngine;

public class EnemyFireballHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

//make them the same scale
    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}