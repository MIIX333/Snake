using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform _storage;
    [SerializeField] private int _repeat;
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;
    [SerializeField] private int _spawnChance;
    private ObstacleGeneratingUnit[] _obstacleGeneratingUnits;
    [SerializeField] private Wall _wall;
    [SerializeField] private int _wallChance;
    private WallGeneratingUnit[] _wallGeneratingUnits;
    private FoodGeneratingUnit[] _foodGeneratingUnits;
    [SerializeField] private int _foodChance;
    [SerializeField] private Food _food;
    //[SerializeField] private FinishLine _finish;
    [SerializeField] private Road _road;
    //[SerializeField] private Material _mat;
    //public FinishLine _finishLine;
    public test _test;
    public FinishLinePoint _finishLinePoint;


    private void Start()
    {
        _obstacleGeneratingUnits = GetComponentsInChildren<ObstacleGeneratingUnit>();
        _wallGeneratingUnits = GetComponentsInChildren<WallGeneratingUnit>();
        _foodGeneratingUnits = GetComponentsInChildren<FoodGeneratingUnit>();
        
        float pol = Random.Range(1.0f, _distanceBetweenFullLine);
        float tol = Random.Range(1.0f, _distanceBetweenRandomLine);

        for (int i = 0; i <= _repeat; i++)
        {
            MoveGenerator(_distanceBetweenFullLine);
            GenerateRandomLine(_wallGeneratingUnits, _wall.gameObject, _wallChance, Dist()/*,_distanceBetweenFullLine,*/ /* / 2.0f*/);
            GenerateRandomLine(_foodGeneratingUnits, _food.gameObject, _foodChance);
            GenerateFullLine(_obstacleGeneratingUnits, _obstacle.gameObject);
            MoveGenerator(_distanceBetweenRandomLine);
            GenerateRandomLine(_wallGeneratingUnits, _wall.gameObject, _wallChance , Dict()/*,_distanceBetweenRandomLine,*//* / 2.0f*/);
            GenerateRandomLine(_obstacleGeneratingUnits, _obstacle.gameObject, _spawnChance);
            //if (i == _repeat)
            //{
            //    _finishLine.transform.position = _test.transform.position;
            //    //Finish(transform.position, _finish.gameObject, _distanceBetweenFullLine);
            //}
            _road.transform.localScale = new Vector3(_repeat * 5, _road.transform.localScale.y, _road.transform.localScale.z);
            _finishLinePoint.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
            //_finishLine.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void GenerateFullLine(GeneratingUnit[] generatingUnits,GameObject generationProduct)
    {
        for (int i = 0; i < generatingUnits.Length; i++)
        {
            GenerateUnit(generatingUnits[i].transform.position, generationProduct);
            //for (int j = 0; j <= _repeat; i++)
            //{
            //    if (j == _repeat)
            //    {
            //        _finishLine.transform.position = _test.transform.position;
            //    }
            //}
        }
    }


    public int Dist()
    {
        int pol = Random.Range(1, _distanceBetweenFullLine);
        return pol;
    }

    public int Dict()
    {
        int tol = Random.Range(1, _distanceBetweenRandomLine);
        return tol;
    }


    private void GenerateRandomLine(GeneratingUnit[] generatingUnits,GameObject generationProduct,int _spawnChance, int scaleZ = 2,float offsetZ = 0)
    {
        for (int i = 0; i < generatingUnits.Length; i++)
        {
            if (Random.Range(0, 101) < _spawnChance)
            {
                GameObject gameObject = GenerateUnit(generatingUnits[i].transform.position, generationProduct,offsetZ);
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, scaleZ);

            }
        }
    }

    //private GameObject GenRoad()
    //{

    //}

    private GameObject GenerateUnit(Vector3 GeneratingUnit, GameObject generationProduct,float offsetZ = 0)
    {
        //float poc = _obstacle._priceInBlock / 10f;
        //generationProduct.GetComponent<Renderer>().sharedMaterial.SetFloat("_gradient", poc);
        //Renderer rend = new Renderer();
        GeneratingUnit.z -= offsetZ; 
        return Instantiate(generationProduct, GeneratingUnit, Quaternion.identity, _storage);
    }

    private void MoveGenerator(int distance)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
    }
    //public GameObject Finish(Vector3 transformpoition, GameObject product, float distance)
    //{
    //    transform.position = new Vector3(transform.position.x, 0, transform.position.z + distance);
    //    transformpoition = transform.position;
    //    return Instantiate(product, transformpoition, Quaternion.identity);
    //}

    //private void RoadGen()
    //{

    //}
}
