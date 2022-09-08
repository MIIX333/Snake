using UnityEngine;
using Random = System.Random;

public class Generator : MonoBehaviour
{
    private ObstacleGeneratingUnit[] _obstacleGeneratingUnits;
    private WallGeneratingUnit[] _wallGeneratingUnits;
    private FoodGeneratingUnit[] _foodGeneratingUnits;

    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;
    [SerializeField] private int _spawnChance;
    [SerializeField] private int _repeat;
    [SerializeField] private int _wallChance;
    [SerializeField] private int _foodChance;

    [SerializeField] private Transform _storage;
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private Wall _wall;
    [SerializeField] private Food _food;
    [SerializeField] private Road _road;
    [SerializeField] private FinishLinePoint _finishLinePoint;
    [SerializeField] private Game _game;

    private void Start()
    {
        _obstacleGeneratingUnits = GetComponentsInChildren<ObstacleGeneratingUnit>();
        _wallGeneratingUnits = GetComponentsInChildren<WallGeneratingUnit>();
        _foodGeneratingUnits = GetComponentsInChildren<FoodGeneratingUnit>();

        for (int i = 0; i <= _repeat; i++)
        {
            MoveGenerator(_distanceBetweenFullLine);
            GenerateRandomLine(_wallGeneratingUnits, _wall.gameObject, _wallChance, RandomFullLine());
            GenerateRandomLine(_foodGeneratingUnits, _food.gameObject, _foodChance);
            GenerateFullLine(_obstacleGeneratingUnits, _obstacle.gameObject);
            MoveGenerator(_distanceBetweenRandomLine);
            GenerateRandomLine(_wallGeneratingUnits, _wall.gameObject, _wallChance , RandomRandomLine());
            GenerateRandomLine(_obstacleGeneratingUnits, _obstacle.gameObject, _spawnChance);
            _road.transform.localScale = new Vector3(_repeat * 5, _road.transform.localScale.y, _road.transform.localScale.z);
            _finishLinePoint.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }
    }
    private void GenerateFullLine(GeneratingUnit[] generatingUnits,GameObject generationProduct)
    {
        for (int i = 0; i < generatingUnits.Length; i++)
        {
            GenerateUnit(generatingUnits[i].transform.position, generationProduct);
        }
    }

    public int RandomFullLine()
    {
        int LevelIndex = _game.LevelIndex;
        Random random = new(LevelIndex);
        int RFL = RandomRange(random,1, _distanceBetweenFullLine);
        return RFL;
    }

    public int RandomRandomLine()
    {
        int LevelIndex = _game.LevelIndex;
        Random random = new(LevelIndex);
        int RRL = RandomRange(random, 1, _distanceBetweenRandomLine);
        return RRL;
    }

    private void GenerateRandomLine(GeneratingUnit[] generatingUnits,GameObject generationProduct,int _spawnChance, int scaleZ = 2,float offsetZ = 0)
    {
        int LevelIndex = _game.LevelIndex;
        Random random = new(LevelIndex);
        for (int i = 0; i < generatingUnits.Length; i++)
        {
            if (RandomRange(random,0, 101) < _spawnChance)
            {
                GameObject gameObject = GenerateUnit(generatingUnits[i].transform.position, generationProduct,offsetZ);
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, scaleZ);

            }
        }
    }

    private GameObject GenerateUnit(Vector3 GeneratingUnit, GameObject generationProduct,float offsetZ = 0)
    {
        GeneratingUnit.z -= offsetZ; 
        return Instantiate(generationProduct, GeneratingUnit, Quaternion.identity, _storage);
    }

    private void MoveGenerator(int distance)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
    }
    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }
}