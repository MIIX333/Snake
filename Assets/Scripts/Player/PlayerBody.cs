using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    
    [SerializeField] private Segment _segment;
    public List<Segment> SegmentAssembly(int count)
    {
        List<Segment> segments = new();
        for (int i = 0; i < count; i++)
        {
            segments.Add(Instantiate(_segment, transform));
        }
        return segments;
    }
}
