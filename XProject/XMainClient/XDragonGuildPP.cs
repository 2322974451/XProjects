using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A11 RID: 2577
	internal class XDragonGuildPP
	{
		// Token: 0x06009DE6 RID: 40422 RVA: 0x0019D098 File Offset: 0x0019B298
		public static int PemissionNameToIndex(string pemstr)
		{
			return XDragonGuildPP.Permission2Int((DragonGuildPermission)Enum.Parse(typeof(DragonGuildPermission), pemstr));
		}

		// Token: 0x06009DE7 RID: 40423 RVA: 0x0019D0C4 File Offset: 0x0019B2C4
		public void InitTable(DragonGuildPermissionTable table)
		{
			this.PositionName.Clear();
			this.PositionColor.Clear();
			this.PositionNameWithColor.Clear();
			XDragonGuildPP.POSITION_COUNT = XDragonGuildPP.Position2Int(DragonGuildPosition.DGPOS_COUNT);
			for (int i = 0; i < XDragonGuildPP.POSITION_COUNT; i++)
			{
				DragonGuildPosition dragonGuildPosition = (DragonGuildPosition)i;
				string @string = XStringDefineProxy.GetString(dragonGuildPosition.ToString());
				this.PositionName.Add(@string);
				this.PositionColor.Add(XSingleton<UiUtility>.singleton.GetItemQualityColor(XDragonGuildPP.POSITION_COUNT - 1 - i));
				this.PositionNameWithColor.Add(string.Format("[{0}]{1}[-]", XSingleton<UiUtility>.singleton.GetItemQualityRGB(XDragonGuildPP.POSITION_COUNT - 1 - i), @string));
			}
			XDragonGuildPP.PERMISSION_COUNT = XDragonGuildPP.Permission2Int(DragonGuildPermission.DGEM_MAX);
			this.DragonGuildPermissionMatrix = new int[XDragonGuildPP.PERMISSION_COUNT][];
			for (int j = 0; j < this.DragonGuildPermissionMatrix.Length; j++)
			{
				this.DragonGuildPermissionMatrix[j] = new int[XDragonGuildPP.POSITION_COUNT];
			}
			for (int k = 0; k < table.Table.Length; k++)
			{
				DragonGuildPermissionTable.RowData rowData = table.Table[k];
				int num = XDragonGuildPP.PemissionNameToIndex(rowData.DragonGuildID);
				this.DragonGuildPermissionMatrix[num][XDragonGuildPP.Position2Int(DragonGuildPosition.DGPOS_LEADER)] = rowData.DGPOS_LEADER;
				this.DragonGuildPermissionMatrix[num][XDragonGuildPP.Position2Int(DragonGuildPosition.DGPOS_VICELEADER)] = rowData.DGPOS_VIVELEADER;
				this.DragonGuildPermissionMatrix[num][XDragonGuildPP.Position2Int(DragonGuildPosition.DGPOS_MEMBER)] = rowData.DGPOS_MEMBER;
			}
		}

		// Token: 0x06009DE8 RID: 40424 RVA: 0x0019D24C File Offset: 0x0019B44C
		public string GetPositionName(DragonGuildPosition position, bool bWithColor = false)
		{
			bool flag = position == DragonGuildPosition.DGPOS_COUNT;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = (bWithColor ? this.PositionNameWithColor[XDragonGuildPP.Position2Int(position)] : this.PositionName[XDragonGuildPP.Position2Int(position)]);
			}
			return result;
		}

		// Token: 0x06009DE9 RID: 40425 RVA: 0x0019D298 File Offset: 0x0019B498
		public Color GetPositionColor(DragonGuildPosition position)
		{
			bool flag = position == DragonGuildPosition.DGPOS_COUNT;
			Color result;
			if (flag)
			{
				result = Color.white;
			}
			else
			{
				result = this.PositionColor[XDragonGuildPP.Position2Int(position)];
			}
			return result;
		}

		// Token: 0x06009DEA RID: 40426 RVA: 0x0019D2CC File Offset: 0x0019B4CC
		public bool HasPermission(DragonGuildPosition pos, DragonGuildPermission pem)
		{
			bool flag = pem == DragonGuildPermission.DGEM_DONOTHING;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = pos == DragonGuildPosition.DGPOS_COUNT || pem == DragonGuildPermission.DGEM_MAX || pos == DragonGuildPosition.DGPOS_INVALID || pem == DragonGuildPermission.DGEM_INVALID;
				result = (!flag2 && this.DragonGuildPermissionMatrix[XDragonGuildPP.Permission2Int(pem)][XDragonGuildPP.Position2Int(pos)] == 1);
			}
			return result;
		}

		// Token: 0x06009DEB RID: 40427 RVA: 0x0019D320 File Offset: 0x0019B520
		public bool HasLowerPosition(DragonGuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
			bool flag = num >= XDragonGuildPP.POSITION_COUNT - 1;
			return !flag;
		}

		// Token: 0x06009DEC RID: 40428 RVA: 0x0019D350 File Offset: 0x0019B550
		public int GetLowerPosition(DragonGuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
			bool flag = num > XDragonGuildPP.POSITION_COUNT - 1;
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = num + 1;
			}
			return result;
		}

		// Token: 0x06009DED RID: 40429 RVA: 0x0019D380 File Offset: 0x0019B580
		public bool HasHigherPosition(DragonGuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
			bool flag = num <= 0;
			return !flag;
		}

		// Token: 0x06009DEE RID: 40430 RVA: 0x0019D3AC File Offset: 0x0019B5AC
		public int GetHigherPosition(DragonGuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
			bool flag = num < 0;
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = num - 1;
			}
			return result;
		}

		// Token: 0x06009DEF RID: 40431 RVA: 0x0019D3D8 File Offset: 0x0019B5D8
		public DragonGuildPermission GetSetPositionPermission(DragonGuildPosition higherPos, DragonGuildPosition targetPos)
		{
			bool flag = targetPos == DragonGuildPosition.DGPOS_COUNT || targetPos == DragonGuildPosition.DGPOS_INVALID;
			DragonGuildPermission result;
			if (flag)
			{
				result = DragonGuildPermission.DGEM_MAX;
			}
			else
			{
				switch (higherPos)
				{
				case DragonGuildPosition.DGPOS_LEADER:
					result = DragonGuildPermission.DGEM_CHANGELEADER;
					break;
				case DragonGuildPosition.DGPOS_VICELEADER:
					result = DragonGuildPermission.DGEM_SET_VICELEADER;
					break;
				case DragonGuildPosition.DGPOS_MEMBER:
					result = DragonGuildPermission.DGEM_DONOTHING;
					break;
				default:
					result = DragonGuildPermission.DGEM_MAX;
					break;
				}
			}
			return result;
		}

		// Token: 0x06009DF0 RID: 40432 RVA: 0x0019D424 File Offset: 0x0019B624
		private static int Position2Int(DragonGuildPosition pos)
		{
			return XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
		}

		// Token: 0x06009DF1 RID: 40433 RVA: 0x0019D43C File Offset: 0x0019B63C
		private static int Permission2Int(DragonGuildPermission pem)
		{
			return XFastEnumIntEqualityComparer<DragonGuildPermission>.ToInt(pem);
		}

		// Token: 0x040037D3 RID: 14291
		public static int POSITION_COUNT;

		// Token: 0x040037D4 RID: 14292
		private List<string> PositionName = new List<string>();

		// Token: 0x040037D5 RID: 14293
		private List<Color> PositionColor = new List<Color>();

		// Token: 0x040037D6 RID: 14294
		private List<string> PositionNameWithColor = new List<string>();

		// Token: 0x040037D7 RID: 14295
		public static int PERMISSION_COUNT;

		// Token: 0x040037D8 RID: 14296
		private int[][] DragonGuildPermissionMatrix;
	}
}
