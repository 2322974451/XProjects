using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E39 RID: 3641
	internal class XGuildPP
	{
		// Token: 0x0600C3C5 RID: 50117 RVA: 0x002A8F58 File Offset: 0x002A7158
		public static int PemissionNameToIndex(string pemstr)
		{
			return XGuildPP.Permission2Int((GuildPermission)Enum.Parse(typeof(GuildPermission), pemstr));
		}

		// Token: 0x0600C3C6 RID: 50118 RVA: 0x002A8F84 File Offset: 0x002A7184
		public void InitTable(GuildPermissionTable table)
		{
			this.PositionName.Clear();
			this.PositionColor.Clear();
			this.PositionNameWithColor.Clear();
			XGuildPP.POSITION_COUNT = XGuildPP.Position2Int(GuildPosition.GPOS_COUNT);
			for (int i = 0; i < XGuildPP.POSITION_COUNT; i++)
			{
				GuildPosition guildPosition = (GuildPosition)i;
				string @string = XStringDefineProxy.GetString(guildPosition.ToString());
				this.PositionName.Add(@string);
				this.PositionColor.Add(XSingleton<UiUtility>.singleton.GetItemQualityColor(XGuildPP.POSITION_COUNT - 1 - i));
				this.PositionNameWithColor.Add(string.Format("[{0}]{1}[-]", XSingleton<UiUtility>.singleton.GetItemQualityRGB(XGuildPP.POSITION_COUNT - 1 - i), @string));
			}
			XGuildPP.PERMISSION_COUNT = XGuildPP.Permission2Int(GuildPermission.GPEM_MAX);
			this.GuildPermissionMatrix = new int[XGuildPP.PERMISSION_COUNT][];
			for (int j = 0; j < this.GuildPermissionMatrix.Length; j++)
			{
				this.GuildPermissionMatrix[j] = new int[XGuildPP.POSITION_COUNT];
			}
			for (int k = 0; k < table.Table.Length; k++)
			{
				GuildPermissionTable.RowData rowData = table.Table[k];
				int num = XGuildPP.PemissionNameToIndex(rowData.GuildID);
				this.GuildPermissionMatrix[num][XGuildPP.Position2Int(GuildPosition.GPOS_LEADER)] = rowData.GPOS_LEADER;
				this.GuildPermissionMatrix[num][XGuildPP.Position2Int(GuildPosition.GPOS_VICELEADER)] = rowData.GPOS_VICELEADER;
				this.GuildPermissionMatrix[num][XGuildPP.Position2Int(GuildPosition.GPOS_OFFICER)] = rowData.GPOS_OFFICER;
				this.GuildPermissionMatrix[num][XGuildPP.Position2Int(GuildPosition.GPOS_ELITEMEMBER)] = rowData.GPOS_ELITEMEMBER;
				this.GuildPermissionMatrix[num][XGuildPP.Position2Int(GuildPosition.GPOS_MEMBER)] = rowData.GPOS_MEMBER;
			}
		}

		// Token: 0x0600C3C7 RID: 50119 RVA: 0x002A9144 File Offset: 0x002A7344
		public string GetPositionName(GuildPosition position, bool bWithColor = false)
		{
			bool flag = position == GuildPosition.GPOS_COUNT;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = (bWithColor ? this.PositionNameWithColor[XGuildPP.Position2Int(position)] : this.PositionName[XGuildPP.Position2Int(position)]);
			}
			return result;
		}

		// Token: 0x0600C3C8 RID: 50120 RVA: 0x002A9190 File Offset: 0x002A7390
		public Color GetPositionColor(GuildPosition position)
		{
			bool flag = position == GuildPosition.GPOS_COUNT;
			Color result;
			if (flag)
			{
				result = Color.white;
			}
			else
			{
				result = this.PositionColor[XGuildPP.Position2Int(position)];
			}
			return result;
		}

		// Token: 0x0600C3C9 RID: 50121 RVA: 0x002A91C4 File Offset: 0x002A73C4
		public bool HasPermission(GuildPosition pos, GuildPermission pem)
		{
			bool flag = pem == GuildPermission.GPEM_DONOTHING;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = pos == GuildPosition.GPOS_COUNT || pem == GuildPermission.GPEM_MAX || pos == GuildPosition.GPOS_INVALID || pem == GuildPermission.GPEM_INVALID;
				result = (!flag2 && this.GuildPermissionMatrix[XGuildPP.Permission2Int(pem)][XGuildPP.Position2Int(pos)] == 1);
			}
			return result;
		}

		// Token: 0x0600C3CA RID: 50122 RVA: 0x002A9218 File Offset: 0x002A7418
		public bool HasLowerPosition(GuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
			bool flag = num >= XGuildPP.POSITION_COUNT - 1;
			return !flag;
		}

		// Token: 0x0600C3CB RID: 50123 RVA: 0x002A9248 File Offset: 0x002A7448
		public int GetLowerPosition(GuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
			bool flag = num > XGuildPP.POSITION_COUNT - 1;
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

		// Token: 0x0600C3CC RID: 50124 RVA: 0x002A9278 File Offset: 0x002A7478
		public bool HasHigherPosition(GuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
			bool flag = num <= 0;
			return !flag;
		}

		// Token: 0x0600C3CD RID: 50125 RVA: 0x002A92A4 File Offset: 0x002A74A4
		public int GetHigherPosition(GuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
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

		// Token: 0x0600C3CE RID: 50126 RVA: 0x002A92D0 File Offset: 0x002A74D0
		public GuildPermission GetSetPositionPermission(GuildPosition higherPos, GuildPosition targetPos)
		{
			bool flag = targetPos == GuildPosition.GPOS_COUNT || targetPos == GuildPosition.GPOS_INVALID;
			GuildPermission result;
			if (flag)
			{
				result = GuildPermission.GPEM_MAX;
			}
			else
			{
				switch (higherPos)
				{
				case GuildPosition.GPOS_LEADER:
					result = GuildPermission.GPEM_CHANGELEADER;
					break;
				case GuildPosition.GPOS_VICELEADER:
					result = GuildPermission.GPEM_SET_VICELEADER;
					break;
				case GuildPosition.GPOS_OFFICER:
					result = GuildPermission.GPEM_SET_OFFICER;
					break;
				case GuildPosition.GPOS_ELITEMEMBER:
				case GuildPosition.GPOS_MEMBER:
					result = GuildPermission.GPEM_SET_ELITEMEMBER;
					break;
				default:
					result = GuildPermission.GPEM_MAX;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600C3CF RID: 50127 RVA: 0x002A9328 File Offset: 0x002A7528
		private static int Position2Int(GuildPosition pos)
		{
			return XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
		}

		// Token: 0x0600C3D0 RID: 50128 RVA: 0x002A9340 File Offset: 0x002A7540
		private static int Permission2Int(GuildPermission pem)
		{
			return XFastEnumIntEqualityComparer<GuildPermission>.ToInt(pem);
		}

		// Token: 0x040054BB RID: 21691
		public static int POSITION_COUNT;

		// Token: 0x040054BC RID: 21692
		private List<string> PositionName = new List<string>();

		// Token: 0x040054BD RID: 21693
		private List<Color> PositionColor = new List<Color>();

		// Token: 0x040054BE RID: 21694
		private List<string> PositionNameWithColor = new List<string>();

		// Token: 0x040054BF RID: 21695
		public static int PERMISSION_COUNT;

		// Token: 0x040054C0 RID: 21696
		private int[][] GuildPermissionMatrix;
	}
}
