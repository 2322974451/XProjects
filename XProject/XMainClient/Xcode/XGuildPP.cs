using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildPP
	{

		public static int PemissionNameToIndex(string pemstr)
		{
			return XGuildPP.Permission2Int((GuildPermission)Enum.Parse(typeof(GuildPermission), pemstr));
		}

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

		public bool HasLowerPosition(GuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
			bool flag = num >= XGuildPP.POSITION_COUNT - 1;
			return !flag;
		}

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

		public bool HasHigherPosition(GuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
			bool flag = num <= 0;
			return !flag;
		}

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

		private static int Position2Int(GuildPosition pos)
		{
			return XFastEnumIntEqualityComparer<GuildPosition>.ToInt(pos);
		}

		private static int Permission2Int(GuildPermission pem)
		{
			return XFastEnumIntEqualityComparer<GuildPermission>.ToInt(pem);
		}

		public static int POSITION_COUNT;

		private List<string> PositionName = new List<string>();

		private List<Color> PositionColor = new List<Color>();

		private List<string> PositionNameWithColor = new List<string>();

		public static int PERMISSION_COUNT;

		private int[][] GuildPermissionMatrix;
	}
}
