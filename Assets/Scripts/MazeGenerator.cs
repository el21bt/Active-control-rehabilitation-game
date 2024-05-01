using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private Transform _groundObject;
    [SerializeField] private MazeCell _mazeCellPrefab;

    [SerializeField] private int _mazeWidth;

    [SerializeField] private int _mazeDepth;

    public int cell_size;

    private int offsetValue;

    private MazeCell[,] _mazeGrid; 


    IEnumerator Start()
    {
        if (cell_size == 2)
        {
            offsetValue = 9;
        }
        else if (cell_size == 4)
        {
            offsetValue = 8;
        }

        _mazeGrid = new MazeCell [_mazeWidth, _mazeDepth];

        for(int x = 0; x < _mazeWidth; x+=cell_size)
        {
            for(int z = 0 ; z < _mazeDepth ; z+=cell_size)
            {
                MazeCell newCell = Instantiate(_mazeCellPrefab, new Vector3(x-offsetValue, 0, z-offsetValue), Quaternion.identity);
                newCell.transform.localScale = new Vector3(cell_size/2, 3, cell_size/2); // Adjust the scale based on cell_size
                newCell.transform.SetParent(_groundObject); // Set the ground object as the parent
                _mazeGrid[x, z] = newCell;

            }
        }

        yield return GenerateMaze(null, _mazeGrid[0, 0]);

        //TransformMaze(new Vector3(-9, 0, -9));
    }

    private IEnumerator GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        //yield return new WaitForSeconds(0.0001f);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                yield return GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);

        
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x + offsetValue;
        int z = (int)currentCell.transform.position.z + offsetValue;

        if (x + cell_size < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + cell_size, z];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - cell_size >= 0)
        {
            var cellToLeft = _mazeGrid[x - cell_size, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + cell_size < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + cell_size];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - cell_size >= 0)
        {
            var cellToBack = _mazeGrid[x, z - cell_size];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }

    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }
        if (previousCell.transform.position.x < currentCell.transform.position.x){
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }
        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }
        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }
        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }

    }

}
