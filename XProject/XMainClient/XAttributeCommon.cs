using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F39 RID: 3897
	internal class XAttributeCommon
	{
		// Token: 0x0600CEE8 RID: 52968 RVA: 0x00300684 File Offset: 0x002FE884
		public static XAttributeDefine GetAttrLimitAttr(XAttributeDefine currAttr)
		{
			XAttributeDefine result;
			if (currAttr != XAttributeDefine.XAttr_CurrentHP_Basic)
			{
				if (currAttr != XAttributeDefine.XAttr_CurrentSuperArmor_Basic)
				{
					if (currAttr != XAttributeDefine.XAttr_CurrentMP_Basic)
					{
						result = XAttributeDefine.XAttr_Invalid;
					}
					else
					{
						result = XAttributeDefine.XAttr_MaxMP_Total;
					}
				}
				else
				{
					result = XAttributeDefine.XAttr_MaxSuperArmor_Total;
				}
			}
			else
			{
				result = XAttributeDefine.XAttr_MaxHP_Total;
			}
			return result;
		}

		// Token: 0x0600CEE9 RID: 52969 RVA: 0x003006C8 File Offset: 0x002FE8C8
		public static XAttributeDefine GetRegenAttr(XAttributeDefine currAttr)
		{
			XAttributeDefine result;
			if (currAttr != XAttributeDefine.XAttr_CurrentHP_Basic)
			{
				if (currAttr != XAttributeDefine.XAttr_CurrentSuperArmor_Basic)
				{
					if (currAttr != XAttributeDefine.XAttr_CurrentMP_Basic)
					{
						result = XAttributeDefine.XAttr_Invalid;
					}
					else
					{
						result = XAttributeDefine.XAttr_MPRecovery_Total;
					}
				}
				else
				{
					result = XAttributeDefine.XAttr_SuperArmorReg_Total;
				}
			}
			else
			{
				result = XAttributeDefine.XAttr_HPRecovery_Total;
			}
			return result;
		}

		// Token: 0x0600CEEA RID: 52970 RVA: 0x0030070C File Offset: 0x002FE90C
		public static XAttributeDefine GetAttrCurAttr(XAttributeDefine limitAttr)
		{
			if (limitAttr <= XAttributeDefine.XAttr_MaxHP_Percent)
			{
				if (limitAttr <= XAttributeDefine.XAttr_MaxSuperArmor_Basic)
				{
					if (limitAttr != XAttributeDefine.XAttr_MaxHP_Basic)
					{
						if (limitAttr != XAttributeDefine.XAttr_MaxSuperArmor_Basic)
						{
							goto IL_78;
						}
						goto IL_73;
					}
				}
				else
				{
					if (limitAttr == XAttributeDefine.XAttr_MaxMP_Basic)
					{
						goto IL_6E;
					}
					if (limitAttr != XAttributeDefine.XAttr_MaxHP_Percent)
					{
						goto IL_78;
					}
				}
			}
			else if (limitAttr <= XAttributeDefine.XAttr_MaxMP_Percent)
			{
				if (limitAttr == XAttributeDefine.XAttr_MaxSuperArmor_Percent)
				{
					goto IL_73;
				}
				if (limitAttr != XAttributeDefine.XAttr_MaxMP_Percent)
				{
					goto IL_78;
				}
				goto IL_6E;
			}
			else if (limitAttr != XAttributeDefine.XAttr_MaxHP_Total)
			{
				if (limitAttr == XAttributeDefine.XAttr_MaxSuperArmor_Total)
				{
					goto IL_73;
				}
				if (limitAttr != XAttributeDefine.XAttr_MaxMP_Total)
				{
					goto IL_78;
				}
				goto IL_6E;
			}
			return XAttributeDefine.XAttr_CurrentHP_Basic;
			IL_6E:
			return XAttributeDefine.XAttr_CurrentMP_Basic;
			IL_73:
			return XAttributeDefine.XAttr_CurrentSuperArmor_Basic;
			IL_78:
			return XAttributeDefine.XAttr_Invalid;
		}

		// Token: 0x0600CEEB RID: 52971 RVA: 0x00300798 File Offset: 0x002FE998
		public static bool IsBasicRange(int id)
		{
			return id > XAttributeCommon.BasicStart && id < XAttributeCommon.BasicEnd;
		}

		// Token: 0x0600CEEC RID: 52972 RVA: 0x003007C0 File Offset: 0x002FE9C0
		public static bool IsPercentRange(int id)
		{
			return id > XAttributeCommon.PercentStart && id < XAttributeCommon.PercentEnd;
		}

		// Token: 0x0600CEED RID: 52973 RVA: 0x003007E8 File Offset: 0x002FE9E8
		public static bool IsPercentRange(XAttributeDefine attr)
		{
			return XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(attr) > XAttributeCommon.PercentStart && XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(attr) < XAttributeCommon.PercentEnd;
		}

		// Token: 0x0600CEEE RID: 52974 RVA: 0x00300818 File Offset: 0x002FEA18
		public static bool IsTotalRange(int id)
		{
			return id > XAttributeCommon.TotalStart && id < XAttributeCommon.TotalEnd;
		}

		// Token: 0x0600CEEF RID: 52975 RVA: 0x00300840 File Offset: 0x002FEA40
		public static int GetBasicAttr(int id)
		{
			return id % 1000;
		}

		// Token: 0x0600CEF0 RID: 52976 RVA: 0x0030085C File Offset: 0x002FEA5C
		public static string GetAttrStr(int attrid)
		{
			return XStringDefineProxy.GetString((XAttributeDefine)attrid);
		}

		// Token: 0x0600CEF1 RID: 52977 RVA: 0x00300874 File Offset: 0x002FEA74
		public static string GetAttrValueStr(int attrid, float attrValue)
		{
			bool flag = XAttributeCommon.IsPercentRange(attrid);
			string result;
			if (flag)
			{
				result = string.Format((attrValue >= 0f) ? "+{0}%" : "{0}%", attrValue.ToString("0.#"));
			}
			else
			{
				result = string.Format((attrValue >= 0f) ? "+{0}" : "{0}", (int)attrValue).ToString();
			}
			return result;
		}

		// Token: 0x0600CEF2 RID: 52978 RVA: 0x003008E0 File Offset: 0x002FEAE0
		public static string GetAttrValueStr(uint attrid, uint attrValue, bool bWithSignal = true)
		{
			bool flag = XAttributeCommon.IsPercentRange((int)attrid);
			string result;
			if (flag)
			{
				result = string.Format((bWithSignal && attrValue >= 0U) ? "+{0}%" : "{0}%", attrValue.ToString());
			}
			else
			{
				result = string.Format((bWithSignal && attrValue >= 0U) ? "+{0}" : "{0}", attrValue).ToString();
			}
			return result;
		}

		// Token: 0x0600CEF3 RID: 52979 RVA: 0x00300944 File Offset: 0x002FEB44
		public static bool IsFirstLevelAttr(XAttributeDefine attr)
		{
			return XAttributeCommon._FirstLevelAttrs.Contains(attr);
		}

		// Token: 0x04005D07 RID: 23815
		public static readonly int AttrCount = 301;

		// Token: 0x04005D08 RID: 23816
		public static readonly int BasicStart = 0;

		// Token: 0x04005D09 RID: 23817
		public static readonly int BasicEnd = XAttributeCommon.AttrCount;

		// Token: 0x04005D0A RID: 23818
		public static readonly int PercentStart = 1000;

		// Token: 0x04005D0B RID: 23819
		public static readonly int PercentEnd = XAttributeCommon.PercentStart + XAttributeCommon.AttrCount;

		// Token: 0x04005D0C RID: 23820
		public static readonly int TotalStart = 2000;

		// Token: 0x04005D0D RID: 23821
		public static readonly int TotalEnd = XAttributeCommon.TotalStart + XAttributeCommon.AttrCount;

		// Token: 0x04005D0E RID: 23822
		private static readonly HashSet<XAttributeDefine> _FirstLevelAttrs = new HashSet<XAttributeDefine>
		{
			XAttributeDefine.XAttr_Strength_Basic,
			XAttributeDefine.XAttr_Strength_Percent,
			XAttributeDefine.XAttr_Strength_Total,
			XAttributeDefine.XAttr_Agility_Basic,
			XAttributeDefine.XAttr_Agility_Percent,
			XAttributeDefine.XAttr_Agility_Total,
			XAttributeDefine.XAttr_Intelligence_Basic,
			XAttributeDefine.XAttr_Intelligence_Percent,
			XAttributeDefine.XAttr_Intelligence_Total,
			XAttributeDefine.XAttr_Vitality_Basic,
			XAttributeDefine.XAttr_Vitality_Percent,
			XAttributeDefine.XAttr_Vitality_Total
		};
	}
}
