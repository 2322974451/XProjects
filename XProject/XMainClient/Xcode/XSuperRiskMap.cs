using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSuperRiskMap
	{

		public void Clear()
		{
			this.StaticInfo = null;
			this.DynamicInfo = null;
			this.PlayerCoord = Coordinate.Invalid;
			this.PlayerMoveDirection = Direction.Up;
		}

		public Direction StartMoveNext(ref Coordinate targetCoord)
		{
			this.PlayerMoveDirection = this.GetNextTryDirection(this.PlayerMoveDirection, 3);
			for (int i = 0; i < 4; i++)
			{
				Coordinate coordinate = this.GoWithDirection(this.PlayerCoord, this.PlayerMoveDirection);
				bool flag = this.StaticInfo.FindMapNode(coordinate) != null;
				if (flag)
				{
					targetCoord = coordinate;
					break;
				}
				this.PlayerMoveDirection = this.GetNextTryDirection(this.PlayerMoveDirection, 1);
			}
			return this.PlayerMoveDirection;
		}

		protected Direction GetNextTryDirection(Direction dir, int offset)
		{
			return (Direction)((XFastEnumIntEqualityComparer<Direction>.ToInt(dir) + offset) % 4);
		}

		public void MoveNext()
		{
			this.PlayerCoord = this.GoWithDirection(this.PlayerCoord, this.PlayerMoveDirection);
			bool flag = this.StaticInfo.FindMapNode(this.PlayerCoord) == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("SuperRisk: why do I go to a null place??", null, null, null, null, null);
			}
		}

		protected Coordinate GoWithDirection(Coordinate c, Direction dir)
		{
			Coordinate result;
			switch (dir)
			{
			case Direction.Right:
				result = new Coordinate(c.x + 1, c.y);
				break;
			case Direction.Down:
				result = new Coordinate(c.x, c.y + 1);
				break;
			case Direction.Left:
				result = new Coordinate(c.x - 1, c.y);
				break;
			case Direction.Up:
				result = new Coordinate(c.x, c.y - 1);
				break;
			default:
				result = new Coordinate(-1, -1);
				break;
			}
			return result;
		}

		public bool GetNodeGroup(Coordinate c, out char group)
		{
			XSuperRiskMapNode xsuperRiskMapNode = this.StaticInfo.FindMapNode(c);
			bool flag = xsuperRiskMapNode != null;
			bool result;
			if (flag)
			{
				group = xsuperRiskMapNode.group;
				result = true;
			}
			else
			{
				group = ' ';
				result = false;
			}
			return result;
		}

		public XSuperRiskMapStaticInfo StaticInfo;

		public XSuperRiskMapDynamicInfo DynamicInfo;

		public Coordinate PlayerCoord;

		public Direction PlayerMoveDirection;

		public XSuperRiskMapRenderer renderer = new XSuperRiskMapRenderer();
	}
}
