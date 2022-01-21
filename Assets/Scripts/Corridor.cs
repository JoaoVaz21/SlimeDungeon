using UnityEngine;

// Enum to specify the direction is heading.
public enum Direction
{
	East, South,

}

public class Corridor
{
	public int startXPos;         // The x coordinate for the start of the corridor.
	public int startYPos;         // The y coordinate for the start of the corridor.
	public int corridorLength;            // How many units long the corridor is.
	public Direction direction;   // Which direction the corridor is heading from it's room.


	// Get the end position of the corridor based on it's start position and which direction it's heading.
	public int EndPositionX
	{
		get
		{
			if ( direction == Direction.South)
				return startXPos;
			if (direction == Direction.East)
				return startXPos + corridorLength - 1;
			return startXPos - corridorLength + 1;
		}
	}


	public int EndPositionY
	{
		get
		{
			if (direction == Direction.East )
				return startYPos;
			
			return startYPos - corridorLength + 1;
		}
	}


	public void SetupCorridor (Room room, IntRange length, IntRange roomWidth, IntRange roomHeight, int columns, int rows, bool firstCorridor)
	{
		// Set a random direction (a random index from 0 to 3, cast to Direction).
	
		direction = (Direction)Random.Range(0, 2);
		


		// Set a random length.
		corridorLength = length.Random;

		// Create a cap for how long the length can be (this will be changed based on the direction and position).
		int maxLength = length.m_Max;

		switch (direction)
		{
		
		case Direction.East:
			startXPos = room.xPos + room.roomWidth;
			startYPos = Random.Range(room.yPos, room.yPos + room.roomHeight - 1);
			maxLength = columns - startXPos - roomWidth.m_Min;
			break;
		case Direction.South:
			startXPos = Random.Range (room.xPos, room.xPos + room.roomWidth);
			startYPos = room.yPos;
			maxLength = startYPos - roomHeight.m_Min;
			break;
		
		}

		// We clamp the length of the corridor to make sure it doesn't go off the board.
		corridorLength = Mathf.Clamp (corridorLength, 1, maxLength);
	}
}