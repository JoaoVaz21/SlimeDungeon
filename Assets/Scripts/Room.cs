using UnityEngine;

public class Room
{
	public int xPos;                      // The x coordinate of the lower left tile of the room.
	public int yPos;                      // The y coordinate of the lower left tile of the room.
	public int roomWidth;                     // How many tiles wide the room is.
	public int roomHeight;                    // How many tiles high the room is.
	public Direction enteringCorridor;    // The direction of the corridor that is entering this room.


	// This is used for the first room.  It does not have a Corridor parameter since there are no corridors yet.
	public void SetupRoom (IntRange widthRange, IntRange heightRange, int columns, int rows)
	{
		// Set a random width and height.
		roomWidth = widthRange.Random;
		roomHeight = heightRange.Random;

		// Set the x and y coordinates so the room is roughly in the middle of the board.
		xPos = Mathf.RoundToInt(0);
		yPos = Mathf.RoundToInt(rows-roomHeight);
	}


	// This is an overload of the SetupRoom function and has a corridor parameter that represents the corridor entering the room.
	public void SetupRoom (IntRange widthRange, IntRange heightRange, int columns, int rows, Corridor corridor)
	{
		// Set the entering corridor direction.
		enteringCorridor = corridor.direction;

		// Set random values for width and height.
		roomWidth = widthRange.Random;
		roomHeight = heightRange.Random;

		switch (corridor.direction)
		{
		// If the corridor entering this room is going north...

		case Direction.East:
			roomWidth = Mathf.Clamp(roomWidth, 1, columns - corridor.EndPositionX);
			xPos = corridor.EndPositionX;

			yPos = Random.Range (corridor.EndPositionY - roomHeight + 1, corridor.EndPositionY);
			yPos = Mathf.Clamp (yPos, 0, rows - roomHeight);
			break;
		case Direction.South:
			roomHeight = Mathf.Clamp (roomHeight, 1, corridor.EndPositionY);
			yPos = corridor.EndPositionY - roomHeight + 1;

			xPos = Random.Range (corridor.EndPositionX - roomWidth + 1, corridor.EndPositionX);
			xPos = Mathf.Clamp (xPos, 0, columns - roomWidth);
			break;
		
		}
	}
}