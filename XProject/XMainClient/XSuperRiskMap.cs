using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B24 RID: 2852
	internal class XSuperRiskMap
	{
		// Token: 0x0600A757 RID: 42839 RVA: 0x001D9240 File Offset: 0x001D7440
		public void Clear()
		{
			this.StaticInfo = null;
			this.DynamicInfo = null;
			this.PlayerCoord = Coordinate.Invalid;
			this.PlayerMoveDirection = Direction.Up;
		}

		// Token: 0x0600A758 RID: 42840 RVA: 0x001D9264 File Offset: 0x001D7464
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

		// Token: 0x0600A759 RID: 42841 RVA: 0x001D92E8 File Offset: 0x001D74E8
		protected Direction GetNextTryDirection(Direction dir, int offset)
		{
			return (Direction)((XFastEnumIntEqualityComparer<Direction>.ToInt(dir) + offset) % 4);
		}

		// Token: 0x0600A75A RID: 42842 RVA: 0x001D9304 File Offset: 0x001D7504
		public void MoveNext()
		{
			this.PlayerCoord = this.GoWithDirection(this.PlayerCoord, this.PlayerMoveDirection);
			bool flag = this.StaticInfo.FindMapNode(this.PlayerCoord) == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("SuperRisk: why do I go to a null place??", null, null, null, null, null);
			}
		}

		// Token: 0x0600A75B RID: 42843 RVA: 0x001D935C File Offset: 0x001D755C
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

		// Token: 0x0600A75C RID: 42844 RVA: 0x001D93E8 File Offset: 0x001D75E8
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

		// Token: 0x04003DD2 RID: 15826
		public XSuperRiskMapStaticInfo StaticInfo;

		// Token: 0x04003DD3 RID: 15827
		public XSuperRiskMapDynamicInfo DynamicInfo;

		// Token: 0x04003DD4 RID: 15828
		public Coordinate PlayerCoord;

		// Token: 0x04003DD5 RID: 15829
		public Direction PlayerMoveDirection;

		// Token: 0x04003DD6 RID: 15830
		public XSuperRiskMapRenderer renderer = new XSuperRiskMapRenderer();
	}
}
