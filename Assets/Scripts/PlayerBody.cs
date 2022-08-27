using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private int _segmentsNumber;
    [SerializeField] private Segment _segment;
    public List<Segment> SegmentAssembly()
    {
        List<Segment> segments = new List<Segment>();
        for (int i = 0; i < _segmentsNumber; i++)
        {
            segments.Add(Instantiate(_segment, transform));
        }
        return segments;
    }
}
