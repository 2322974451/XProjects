using System;

namespace XMainClient
{

	internal struct Coordinate
	{

		public Coordinate(int _x, int _y)
		{
			this.x = _x;
			this.y = _y;
		}

		public static Coordinate Invalid = new Coordinate(-100, -100);

		public int x;

		public int y;
	}
}
