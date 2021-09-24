using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSecurityBuffInfo
	{

		public bool IsUsefulAttr(XAttributeDefine attr)
		{
			return XSecurityBuffInfo._UsefulAttrs.Contains(attr);
		}

		public void Reset()
		{
			this._AttackSpeed.Reset();
			this._RunSpeed.Reset();
			this._Critical.Reset();
			this._PhysicalDef.Reset();
			this._Immortal.Reset();
			this._ReduceDamage.Reset();
			this._Freeze.Reset();
		}

		public void OnAttributeChanged(XAttributes attributes, XBuff buff, XAttributeDefine attr, double value)
		{
			bool flag = attributes == null || buff == null || buff.SkillID == 0U || value <= 0.0;
			if (!flag)
			{
				if (attr <= XAttributeDefine.XATTR_ATTACK_SPEED_Basic)
				{
					if (attr <= XAttributeDefine.XAttr_MagicAtkMod_Basic)
					{
						if (attr == XAttributeDefine.XAttr_PhysicalAtkMod_Basic)
						{
							goto IL_101;
						}
						if (attr == XAttributeDefine.XAttr_PhysicalDefMod_Basic)
						{
							goto IL_F0;
						}
						if (attr != XAttributeDefine.XAttr_MagicAtkMod_Basic)
						{
							return;
						}
						goto IL_101;
					}
					else
					{
						if (attr == XAttributeDefine.XAttr_Critical_Basic)
						{
							goto IL_CE;
						}
						if (attr == XAttributeDefine.XAttr_RUN_SPEED_Basic)
						{
							goto IL_DF;
						}
						if (attr != XAttributeDefine.XATTR_ATTACK_SPEED_Basic)
						{
							return;
						}
					}
				}
				else if (attr <= XAttributeDefine.XAttr_MagicAtkMod_Percent)
				{
					if (attr == XAttributeDefine.XAttr_PhysicalAtkMod_Percent)
					{
						goto IL_101;
					}
					if (attr == XAttributeDefine.XAttr_PhysicalDefMod_Percent)
					{
						goto IL_F0;
					}
					if (attr != XAttributeDefine.XAttr_MagicAtkMod_Percent)
					{
						return;
					}
					goto IL_101;
				}
				else
				{
					if (attr == XAttributeDefine.XAttr_Critical_Percent)
					{
						goto IL_CE;
					}
					if (attr == XAttributeDefine.XAttr_RUN_SPEED_Percent)
					{
						goto IL_DF;
					}
					if (attr != XAttributeDefine.XATTR_ATTACK_SPEED_Percent)
					{
						return;
					}
				}
				this._AttackSpeed.OnChanged(buff, value);
				return;
				IL_CE:
				this._Critical.OnChanged(buff, value);
				return;
				IL_DF:
				this._RunSpeed.OnChanged(buff, value);
				return;
				IL_F0:
				this._PhysicalDef.OnChanged(buff, value);
				return;
				IL_101:
				this._Attack.OnChanged(buff, value);
			}
		}

		public void OnReduceDamage(XBuff buff, double value)
		{
			bool flag = buff == null || buff.SkillID == 0U;
			if (!flag)
			{
				this._ReduceDamage.OnChanged(buff, value * 100.0);
			}
		}

		public void OnFreeze(XBuff buff)
		{
			bool flag = buff == null || buff.SkillID == 0U;
			if (!flag)
			{
				this._Freeze.OnChanged(buff, 0.0);
			}
		}

		public void OnImmortal(XBuff buff)
		{
			bool flag = buff == null || buff.SkillID == 0U;
			if (!flag)
			{
				this._Immortal.OnChanged(buff, 0.0);
			}
		}

		public static XSecurityBuffInfo TryGetStatistics(XEntity entity)
		{
			XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(entity);
			bool flag = xsecurityStatistics == null;
			XSecurityBuffInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = xsecurityStatistics.BuffStatistics;
			}
			return result;
		}

		public static double GetValue(XSecurityBuffInfo.AttributeParam param, double finalValue)
		{
			bool flag = XAttributeCommon.IsBasicRange(XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(param.attr));
			if (flag)
			{
				bool flag2 = param.initValue != 0f;
				if (flag2)
				{
					finalValue = (finalValue - (double)param.initValue) / (double)param.initValue;
				}
			}
			else
			{
				finalValue *= 0.01;
			}
			return finalValue;
		}

		public static void ProcessNormal(ref XSecurityBuffInfo.BuffInfo buffInfo, XSecurityBuffInfo.AttributeParam param)
		{
			buffInfo.OnChanged(param.buff, XSecurityBuffInfo.GetValue(param, param.value));
		}

		public static void SendPlayerData(XSecurityBuffInfo buffInfos)
		{
			XSecurityBuffInfo._SendData(buffInfos._PhysicalDef, "1");
			XSecurityBuffInfo._SendData(buffInfos._Attack, "2");
			XSecurityBuffInfo._SendData(buffInfos._Critical, "3");
			XSecurityBuffInfo._SendData(buffInfos._RunSpeed, "4");
			XSecurityBuffInfo._SendData(buffInfos._AttackSpeed, "5");
			XSecurityBuffInfo._SendData(buffInfos._ReduceDamage, "6");
			XSecurityBuffInfo._SendData(buffInfos._Immortal, "7");
			XSecurityBuffInfo._SendData(buffInfos._Freeze, "8");
		}

		private static void _SendData(XSecurityBuffInfo.BuffInfo buffInfo, string keywords)
		{
			XStaticSecurityStatistics.Append(string.Format("Skill{0}Count", keywords), (float)buffInfo._CountTotal);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}EffectMin", keywords), buffInfo._EffectMin);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}EffectMax", keywords), buffInfo._EffectMax);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}TimeMin", keywords), buffInfo._TimeMin);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}TimeMax", keywords), buffInfo._TimeMax);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}TimeTotal", keywords), buffInfo._TimeTotal);
		}

		private static HashSet<XAttributeDefine> _UsefulAttrs = new HashSet<XAttributeDefine>(default(XFastEnumIntEqualityComparer<XAttributeDefine>))
		{
			XAttributeDefine.XATTR_ATTACK_SPEED_Basic,
			XAttributeDefine.XATTR_ATTACK_SPEED_Percent,
			XAttributeDefine.XAttr_Critical_Basic,
			XAttributeDefine.XAttr_Critical_Percent,
			XAttributeDefine.XAttr_RUN_SPEED_Basic,
			XAttributeDefine.XAttr_RUN_SPEED_Percent,
			XAttributeDefine.XAttr_PhysicalDefMod_Basic,
			XAttributeDefine.XAttr_PhysicalDefMod_Percent,
			XAttributeDefine.XAttr_PhysicalAtkMod_Basic,
			XAttributeDefine.XAttr_PhysicalAtkMod_Percent,
			XAttributeDefine.XAttr_MagicAtkMod_Basic,
			XAttributeDefine.XAttr_MagicAtkMod_Percent
		};

		public XSecurityBuffInfo.BuffInfo _AttackSpeed = default(XSecurityBuffInfo.BuffInfo);

		public XSecurityBuffInfo.BuffInfo _RunSpeed = default(XSecurityBuffInfo.BuffInfo);

		public XSecurityBuffInfo.BuffInfo _Critical = default(XSecurityBuffInfo.BuffInfo);

		public XSecurityBuffInfo.BuffInfo _PhysicalDef = default(XSecurityBuffInfo.BuffInfo);

		public XSecurityBuffInfo.BuffInfo _Attack = default(XSecurityBuffInfo.BuffInfo);

		public XSecurityBuffInfo.BuffInfo _Immortal = default(XSecurityBuffInfo.BuffInfo);

		public XSecurityBuffInfo.BuffInfo _ReduceDamage = default(XSecurityBuffInfo.BuffInfo);

		public XSecurityBuffInfo.BuffInfo _Freeze = default(XSecurityBuffInfo.BuffInfo);

		private static XSecurityBuffInfo.AttributeParam s_AttrParam = new XSecurityBuffInfo.AttributeParam();

		public struct BuffInfo
		{

			public void Reset()
			{
				this._CountTotal = 0;
				this._EffectMax = 0f;
				this._EffectMin = float.MaxValue;
				this._TimeMax = 0f;
				this._TimeMin = float.MaxValue;
				this._TimeTotal = 0f;
			}

			public void OnChanged(XBuff buff, double value)
			{
				this._CountTotal++;
				this._EffectMax = Math.Max(this._EffectMax, (float)value);
				this._EffectMin = Math.Min(this._EffectMin, (float)value);
				float num = buff.ActualDuration * 1000f;
				this._TimeMax = Math.Max(this._TimeMax, num);
				this._TimeMin = Math.Min(this._TimeMin, num);
				this._TimeTotal += num;
			}

			public void Merge(ref XSecurityBuffInfo.BuffInfo other)
			{
				this._CountTotal += other._CountTotal;
				this._EffectMax = Math.Max(this._EffectMax, other._EffectMax);
				this._EffectMin = Math.Min(this._EffectMin, other._EffectMin);
				this._TimeMax = Math.Max(this._TimeMax, other._TimeMax);
				this._TimeMin = Math.Min(this._TimeMin, other._TimeMin);
				this._TimeTotal += other._TimeTotal;
			}

			public int _CountTotal;

			public float _EffectMin;

			public float _EffectMax;

			public float _TimeMin;

			public float _TimeMax;

			public float _TimeTotal;
		}

		public class AttributeParam
		{

			public XAttributes attributes = null;

			public XAttributeDefine attr = XAttributeDefine.XAttr_PhysicalDefMod_Percent;

			public double value = 0.0;

			public float initValue = 0f;

			public XBuff buff = null;
		}
	}
}
