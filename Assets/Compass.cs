using UnityEngine;

public static class Compass
{
	public enum Direction
	{
		E = 0, NE = 1,
		N = 2, NW = 3,
		W = 4, SW = 5,
		S = 6, SE = 7
	}

	public static Direction GetDirection(Vector3 delta) {
		float angle = Mathf.Atan2(delta.y, delta.x);
		return (Direction) (Mathf.RoundToInt(8 * angle / (2 * Mathf.PI) + 8) % 8);
	}
};