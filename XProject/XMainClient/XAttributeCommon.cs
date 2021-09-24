using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAttributeCommon
	{

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

		public static bool IsBasicRange(int id)
		{
			return id > XAttributeCommon.BasicStart && id < XAttributeCommon.BasicEnd;
		}

		public static bool IsPercentRange(int id)
		{
			return id > XAttributeCommon.PercentStart && id < XAttributeCommon.PercentEnd;
		}

		public static bool IsPercentRange(XAttributeDefine attr)
		{
			return XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(attr) > XAttributeCommon.PercentStart && XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(attr) < XAttributeCommon.PercentEnd;
		}

		public static bool IsTotalRange(int id)
		{
			return id > XAttributeCommon.TotalStart && id < XAttributeCommon.TotalEnd;
		}

		public static int GetBasicAttr(int id)
		{
			return id % 1000;
		}

		public static string GetAttrStr(int attrid)
		{
			return XStringDefineProxy.GetString((XAttributeDefine)attrid);
		}

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

		public static bool IsFirstLevelAttr(XAttributeDefine attr)
		{
			return XAttributeCommon._FirstLevelAttrs.Contains(attr);
		}

		public static readonly int AttrCount = 301;

		public static readonly int BasicStart = 0;

		public static readonly int BasicEnd = XAttributeCommon.AttrCount;

		public static readonly int PercentStart = 1000;

		public static readonly int PercentEnd = XAttributeCommon.PercentStart + XAttributeCommon.AttrCount;

		public static readonly int TotalStart = 2000;

		public static readonly int TotalEnd = XAttributeCommon.TotalStart + XAttributeCommon.AttrCount;

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
