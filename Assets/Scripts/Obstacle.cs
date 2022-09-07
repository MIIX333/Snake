using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector3Int _priceRange;

    public int _priceInBlock;
    public int _currentLenght;
    //[SerializeField] private Material _mat;
    public Material _material;
    public GameObject _gameObject;
    public event UnityAction<int> Process;

    public int LeftCount => _priceInBlock - _currentLenght;

    private void Start()
    {
        _priceInBlock = Random.Range(_priceRange.x, _priceRange.y);
        Process?.Invoke(LeftCount);
        _gameObject = this.gameObject;
        _material = _gameObject.GetComponent<MeshRenderer>().material;
        //SetColor(_priceInBlock);
        float poc = _priceInBlock / 10f;
        //Debug.Log(poc);
        //Renderer rend = new Renderer();
        _material.SetFloat("_gradient", poc);
    }


    //public Gradient Gradient;
    //public Material Material;
    //public int MaxHeat = 200;

    //public void SetColor(int _priceInBlock)
    //{
    //    Material.color = Gradient.Evaluate(_priceInBlock / _priceRange.y);
    //}



    public void TryBreak()
    {
        _currentLenght++;
        Process?.Invoke(LeftCount);
        //float poc = _priceInBlock / 10f;
        //_mat.SetFloat("_gradient", poc);
        if (_currentLenght == _priceInBlock)
        {
            Destroy(gameObject);
        }
    }
}
