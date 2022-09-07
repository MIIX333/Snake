using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private Vector2Int _foodRange;
    private int _foodCount;


    private void Start()
    {
        _foodCount = Random.Range(_foodRange.x, _foodRange.y);
        _counter.text = _foodCount.ToString();
    }

    public int Swallow()
    {
        Destroy(gameObject);
        return _foodCount;
    }


    //[SerializeField] private Collider _food;
    //[SerializeField] private Player _player;

    ////public Vector3 distance;


    //public void Swallow()
    //{
    //    if (true)
    //    {

    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //if (collision.collider.TryGetComponent(out Player player))
    //    //{
    //    //    _player.segmentsCounter.Add();
    //    //    Debug.Log(_player.segmentsCounter);
    //    //}


    //}

    ////private void OnTriggerEnter(Collider other)
    ////{
    ////    if (other.TryGetComponent(out Player player))
    ////    {
    ////        _player.segmentsCounter.Add(0);
    ////        Debug.Log(_player.segmentsCounter);
    ////    }

    ////}

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{


    //}
}
