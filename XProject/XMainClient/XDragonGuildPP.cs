using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildPP
	{

		public static int PemissionNameToIndex(string pemstr)
		{
			return XDragonGuildPP.Permission2Int((DragonGuildPermission)Enum.Parse(typeof(DragonGuildPermission), pemstr));
		}

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

		public bool HasLowerPosition(DragonGuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
			bool flag = num >= XDragonGuildPP.POSITION_COUNT - 1;
			return !flag;
		}

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

		public bool HasHigherPosition(DragonGuildPosition pos)
		{
			int num = XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
			bool flag = num <= 0;
			return !flag;
		}

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

		private static int Position2Int(DragonGuildPosition pos)
		{
			return XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(pos);
		}

		private static int Permission2Int(DragonGuildPermission pem)
		{
			return XFastEnumIntEqualityComparer<DragonGuildPermission>.ToInt(pem);
		}

		public static int POSITION_COUNT;

		private List<string> PositionName = new List<string>();

		private List<Color> PositionColor = new List<Color>();

		private List<string> PositionNameWithColor = new List<string>();

		public static int PERMISSION_COUNT;

		private int[][] DragonGuildPermissionMatrix;
	}
}
