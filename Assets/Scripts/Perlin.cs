using UnityEngine;

public class Perlin : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;
    public int depth = 20; // Aumenta la profundidad del terreno

    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    void Update()
    {
        // Puedes mover la lógica de generación de terreno a Start() si no necesitas actualización en tiempo real.
        // offsetX += Time.deltaTime * 0.1f;
        // offsetY += Time.deltaTime * 0.1f;
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height); // Configura el tamaño antes de las alturas
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX; // Corrige las coordenadas
        float yCoord = (float)y / height * scale + offsetY; // Corrige las coordenadas

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
