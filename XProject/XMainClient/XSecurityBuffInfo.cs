using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B0F RID: 2831
	internal class XSecurityBuffInfo
	{
		// Token: 0x0600A6B6 RID: 42678 RVA: 0x001D5678 File Offset: 0x001D3878
		public bool IsUsefulAttr(XAttributeDefine attr)
		{
			return XSecurityBuffInfo._UsefulAttrs.Contains(attr);
		}

		// Token: 0x0600A6B7 RID: 42679 RVA: 0x001D5698 File Offset: 0x001D3898
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

		// Token: 0x0600A6B8 RID: 42680 RVA: 0x001D56FC File Offset: 0x001D38FC
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

		// Token: 0x0600A6B9 RID: 42681 RVA: 0x001D581C File Offset: 0x001D3A1C
		public void OnReduceDamage(XBuff buff, double value)
		{
			bool flag = buff == null || buff.SkillID == 0U;
			if (!flag)
			{
				this._ReduceDamage.OnChanged(buff, value * 100.0);
			}
		}

		// Token: 0x0600A6BA RID: 42682 RVA: 0x001D5858 File Offset: 0x001D3A58
		public void OnFreeze(XBuff buff)
		{
			bool flag = buff == null || buff.SkillID == 0U;
			if (!flag)
			{
				this._Freeze.OnChanged(buff, 0.0);
			}
		}

		// Token: 0x0600A6BB RID: 42683 RVA: 0x001D5894 File Offset: 0x001D3A94
		public void OnImmortal(XBuff buff)
		{
			bool flag = buff == null || buff.SkillID == 0U;
			if (!flag)
			{
				this._Immortal.OnChanged(buff, 0.0);
			}
		}

		// Token: 0x0600A6BC RID: 42684 RVA: 0x001D58D0 File Offset: 0x001D3AD0
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

		// Token: 0x0600A6BD RID: 42685 RVA: 0x001D58FC File Offset: 0x001D3AFC
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

		// Token: 0x0600A6BE RID: 42686 RVA: 0x001D595D File Offset: 0x001D3B5D
		public static void ProcessNormal(ref XSecurityBuffInfo.BuffInfo buffInfo, XSecurityBuffInfo.AttributeParam param)
		{
			buffInfo.OnChanged(param.buff, XSecurityBuffInfo.GetValue(param, param.value));
		}

		// Token: 0x0600A6BF RID: 42687 RVA: 0x001D597C File Offset: 0x001D3B7C
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

		// Token: 0x0600A6C0 RID: 42688 RVA: 0x001D5A14 File Offset: 0x001D3C14
		private static void _SendData(XSecurityBuffInfo.BuffInfo buffInfo, string keywords)
		{
			XStaticSecurityStatistics.Append(string.Format("Skill{0}Count", keywords), (float)buffInfo._CountTotal);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}EffectMin", keywords), buffInfo._EffectMin);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}EffectMax", keywords), buffInfo._EffectMax);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}TimeMin", keywords), buffInfo._TimeMin);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}TimeMax", keywords), buffInfo._TimeMax);
			XStaticSecurityStatistics.Append(string.Format("Skill{0}TimeTotal", keywords), buffInfo._TimeTotal);
		}

		// Token: 0x04003D48 RID: 15688
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

		// Token: 0x04003D49 RID: 15689
		public XSecurityBuffInfo.BuffInfo _AttackSpeed = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D4A RID: 15690
		public XSecurityBuffInfo.BuffInfo _RunSpeed = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D4B RID: 15691
		public XSecurityBuffInfo.BuffInfo _Critical = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D4C RID: 15692
		public XSecurityBuffInfo.BuffInfo _PhysicalDef = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D4D RID: 15693
		public XSecurityBuffInfo.BuffInfo _Attack = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D4E RID: 15694
		public XSecurityBuffInfo.BuffInfo _Immortal = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D4F RID: 15695
		public XSecurityBuffInfo.BuffInfo _ReduceDamage = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D50 RID: 15696
		public XSecurityBuffInfo.BuffInfo _Freeze = default(XSecurityBuffInfo.BuffInfo);

		// Token: 0x04003D51 RID: 15697
		private static XSecurityBuffInfo.AttributeParam s_AttrParam = new XSecurityBuffInfo.AttributeParam();

		// Token: 0x02001996 RID: 6550
		public struct BuffInfo
		{
			// Token: 0x06011027 RID: 69671 RVA: 0x004537C4 File Offset: 0x004519C4
			public void Reset()
			{
				this._CountTotal = 0;
				this._EffectMax = 0f;
				this._EffectMin = float.MaxValue;
				this._TimeMax = 0f;
				this._TimeMin = float.MaxValue;
				this._TimeTotal = 0f;
			}

			// Token: 0x06011028 RID: 69672 RVA: 0x00453810 File Offset: 0x00451A10
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

			// Token: 0x06011029 RID: 69673 RVA: 0x00453894 File Offset: 0x00451A94
			public void Merge(ref XSecurityBuffInfo.BuffInfo other)
			{
				this._CountTotal += other._CountTotal;
				this._EffectMax = Math.Max(this._EffectMax, other._EffectMax);
				this._EffectMin = Math.Min(this._EffectMin, other._EffectMin);
				this._TimeMax = Math.Max(this._TimeMax, other._TimeMax);
				this._TimeMin = Math.Min(this._TimeMin, other._TimeMin);
				this._TimeTotal += other._TimeTotal;
			}

			// Token: 0x04007F13 RID: 32531
			public int _CountTotal;

			// Token: 0x04007F14 RID: 32532
			public float _EffectMin;

			// Token: 0x04007F15 RID: 32533
			public float _EffectMax;

			// Token: 0x04007F16 RID: 32534
			public float _TimeMin;

			// Token: 0x04007F17 RID: 32535
			public float _TimeMax;

			// Token: 0x04007F18 RID: 32536
			public float _TimeTotal;
		}

		// Token: 0x02001997 RID: 6551
		public class AttributeParam
		{
			// Token: 0x04007F19 RID: 32537
			public XAttributes attributes = null;

			// Token: 0x04007F1A RID: 32538
			public XAttributeDefine attr = XAttributeDefine.XAttr_PhysicalDefMod_Percent;

			// Token: 0x04007F1B RID: 32539
			public double value = 0.0;

			// Token: 0x04007F1C RID: 32540
			public float initValue = 0f;

			// Token: 0x04007F1D RID: 32541
			public XBuff buff = null;
		}
	}
}
