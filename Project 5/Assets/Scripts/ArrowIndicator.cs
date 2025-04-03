using UnityEngine;
using System.Collections.Generic;

public class ArrowIndicator : MonoBehaviour
{
    [Header("Arrow Settings")]
    public GameObject arrowPrefab;
    public float arrowDistance = 2.0f;
    public float arrowScale = 1.0f;
    public Color arrowColor; 
    
    [Header("Target Settings")]
    [SerializeField] private List<Transform> targets = new List<Transform>();
    
    
    private Dictionary<Transform, GameObject> arrows = new Dictionary<Transform, GameObject>();
    private Transform playerTransform;
    
    void Awake()
    {
        playerTransform = transform;
    }
    
    void Start()
    {
        CreateArrows();
    }
    
    void CreateArrows()
    {
        // Clear existing arrows
        foreach (var arrow in arrows.Values)
        {
            if (arrow != null)
            {
                Destroy(arrow);
            }
        }
        arrows.Clear();
        
       foreach (Transform target in targets)
        {
            if (target != null)
            {
                // Create the arrow
                GameObject arrow = Instantiate(arrowPrefab);
                
                // Apply scale before parenting
                arrow.transform.localScale = Vector3.one * arrowScale;
                
                // Parent to player
                arrow.transform.SetParent(playerTransform, false);
                
                arrow.name = "Arrow_" + target.name;
                
                // Use SpriteRenderer specifically
                // SpriteRenderer spriteRenderer = arrow.GetComponent<SpriteRenderer>();
                // if (spriteRenderer != null)
                // {
                //     spriteRenderer.color = arrowColor; // Use your arrowColor
                // }
                

                arrows.Add(target, arrow);
                
            }
        }
    }
    
    void LateUpdate()
    {
        UpdateArrows();
    }
    
    void UpdateArrows()
    {
        foreach (var pair in arrows)
        {
            Transform target = pair.Key;
            GameObject arrow = pair.Value;
            
            if (target == null || arrow == null) continue;
            
            // Calculate direction to target 
            Vector2 directionToTarget = new Vector2(
                target.position.x - playerTransform.position.x,
                target.position.y - playerTransform.position.y
            ).normalized;
            
            // Position arrow at fixed distance from player in the target direction
            Vector3 desiredPosition = playerTransform.position + new Vector3(
                directionToTarget.x * arrowDistance,
                directionToTarget.y * arrowDistance,
                0 
            );
            arrow.transform.position = desiredPosition;
            
            // Orient arrow to point toward target 
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            // Subtract 90 degrees because the default triangle sprite points up
            arrow.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
    
    public void AddTarget(Transform target)
    {
        if (target == null) return;
        
        if (!targets.Contains(target))
        {
            targets.Add(target);
            
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.localScale = Vector3.one * arrowScale;
            arrow.transform.SetParent(playerTransform, false);
            arrow.name = "Arrow_" + target.name;
            
            // Use SpriteRenderer specifically
            SpriteRenderer spriteRenderer = arrow.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = arrowColor;
            }
        
            
            arrows.Add(target, arrow);
        }
    }
    
    public void RemoveTarget(Transform target)
    {
        if (targets.Contains(target))
        {
            targets.Remove(target);
            
            if (arrows.ContainsKey(target))
            {
                if (arrows[target] != null)
                {
                    Destroy(arrows[target]);
                }
                arrows.Remove(target);
            }
        }
    }
}