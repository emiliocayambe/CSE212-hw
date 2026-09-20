/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        // Get the boolean array [left, right, up, down] for the current location
        var allowedDirections = _mazeMap[(_currX, _currY)];

        // Index 0 represents the left direction
        if (!allowedDirections[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // If movement is allowed, update the current X coordinate
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        // Get the boolean array for the current location
        var allowedDirections = _mazeMap[(_currX, _currY)];

        // Index 1 represents the right direction
        if (!allowedDirections[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // If movement is allowed, update the current X coordinate
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        // Get the boolean array for the current location
        var allowedDirections = _mazeMap[(_currX, _currY)];

        // Index 2 represents the up direction
        if (!allowedDirections[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // If movement is allowed, update the current Y coordinate
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        // Get the boolean array for the current location
        var allowedDirections = _mazeMap[(_currX, _currY)];

        // Index 3 represents the down direction
        if (!allowedDirections[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // If movement is allowed, update the current Y coordinate
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}