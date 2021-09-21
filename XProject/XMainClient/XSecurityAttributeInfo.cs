using System;
using System.Collections.Generic;
using System.Text;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B12 RID: 2834
	internal class XSecurityAttributeInfo
	{
		// Token: 0x0600A6CE RID: 42702 RVA: 0x001D6044 File Offset: 0x001D4244
		public void OnAttributeChange(XAttributeDefine attr, double delta)
		{
			bool flag = attr == XAttributeDefine.XAttr_CurrentHP_Basic;
			if (flag)
			{
				this._Hp.OnChange(delta);
			}
			else
			{
				bool flag2 = attr == XAttributeDefine.XAttr_CurrentMP_Basic;
				if (flag2)
				{
					this._Mp.OnChange(delta);
				}
			}
		}

		// Token: 0x0600A6CF RID: 42703 RVA: 0x001D6080 File Offset: 0x001D4280
		public void Reset()
		{
			this._Hp.Reset();
			this._Mp.Reset();
		}

		// Token: 0x0600A6D0 RID: 42704 RVA: 0x001D609C File Offset: 0x001D429C
		public void OnAttach(XEntity entity)
		{
			bool flag = entity == null || !entity.IsPlayer || entity.Attributes == null;
			if (!flag)
			{
				bool flag2 = this._PlayerInitAttrKeyList == null;
				if (flag2)
				{
					this._PlayerInitAttrKeyList = new List<string>();
				}
				bool flag3 = this._PlayerInitAttrValueList == null;
				if (flag3)
				{
					this._PlayerInitAttrValueList = new List<string>();
				}
				this._PlayerInitAttrKeyList.Clear();
				this._PlayerInitAttrValueList.Clear();
				this._PreserveBasicAttrs(entity.Attributes);
			}
		}

		// Token: 0x0600A6D1 RID: 42705 RVA: 0x001D611C File Offset: 0x001D431C
		public bool IsUsefulAttr(XAttributeDefine attr)
		{
			return attr == XAttributeDefine.XAttr_CurrentMP_Basic || attr == XAttributeDefine.XAttr_CurrentHP_Basic;
		}

		// Token: 0x0600A6D2 RID: 42706 RVA: 0x001D613B File Offset: 0x001D433B
		public void SendData()
		{
			this._SendData(ref this._Hp, "HP");
			this._SendData(ref this._Mp, "MP");
			this.SendPlayerInitData();
		}

		// Token: 0x0600A6D3 RID: 42707 RVA: 0x001D616C File Offset: 0x001D436C
		private void _SendData(ref XSecurityAttributeInfo.AttrInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append(string.Format("PlayerHeal{0}Count", keywords), info._IncCount);
			XStaticSecurityStatistics.Append(string.Format("PlayerHeal{0}Max", keywords), info._IncMax);
			XStaticSecurityStatistics.Append(string.Format("PlayerHeal{0}Min", keywords), info._IncMin);
			XStaticSecurityStatistics.Append(string.Format("PlayerHeal{0}Total", keywords), info._IncTotal);
			XStaticSecurityStatistics.Append(string.Format("PlayerDamage{0}Count", keywords), info._DecCount);
			XStaticSecurityStatistics.Append(string.Format("PlayerDamage{0}Max", keywords), info._DecMax);
			XStaticSecurityStatistics.Append(string.Format("PlayerDamage{0}Min", keywords), info._DecMin);
			XStaticSecurityStatistics.Append(string.Format("PlayerDamage{0}Total", keywords), info._DecTotal);
		}

		// Token: 0x0600A6D4 RID: 42708 RVA: 0x001D6234 File Offset: 0x001D4434
		public void SendPlayerInitData()
		{
			bool flag = this._PlayerInitAttrKeyList == null || this._PlayerInitAttrValueList == null;
			if (!flag)
			{
				bool flag2 = this._PlayerInitAttrKeyList.Count != this._PlayerInitAttrValueList.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("_PlayerInitAttrKeyList.Count != _PlayerInitAttrValueList.Count ", this._PlayerInitAttrKeyList.Count.ToString(), " != ", this._PlayerInitAttrValueList.Count.ToString(), null, null);
				}
				else
				{
					for (int i = 0; i < this._PlayerInitAttrKeyList.Count; i++)
					{
						XStaticSecurityStatistics.Append(this._PlayerInitAttrKeyList[i], this._PlayerInitAttrValueList[i]);
					}
				}
			}
		}

		// Token: 0x0600A6D5 RID: 42709 RVA: 0x001D62FC File Offset: 0x001D44FC
		private void _PreserveBasicAttrs(XAttributes attributes)
		{
			XStaticSecurityStatistics.Append("RoleAtk", attributes.GetAttr(XAttributeDefine.XAttr_PhysicalAtkMod_Total), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			XStaticSecurityStatistics.Append("RoleMAtk", attributes.GetAttr(XAttributeDefine.XAttr_MagicAtkMod_Total), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			XStaticSecurityStatistics.Append("RoleHP", attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			XStaticSecurityStatistics.Append("RoleMP", attributes.GetAttr(XAttributeDefine.XAttr_MaxMP_Total), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			XStaticSecurityStatistics.Append("RoleDef", attributes.GetAttr(XAttributeDefine.XAttr_PhysicalDefMod_Total), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			XStaticSecurityStatistics.Append("RoleMDef", attributes.GetAttr(XAttributeDefine.XAttr_MagicDefMod_Total), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			List<XAttributeDefine> list = new List<XAttributeDefine>();
			list.Clear();
			list.Add(XAttributeDefine.XAttr_FinalDamage_Total);
			list.Add(XAttributeDefine.XAttr_Critical_Total);
			list.Add(XAttributeDefine.XAttr_CritDamage_Total);
			list.Add(XAttributeDefine.XAttr_CritResist_Total);
			list.Add(XAttributeDefine.XAttr_Paralyze_Total);
			list.Add(XAttributeDefine.XAttr_ParaResist_Total);
			list.Add(XAttributeDefine.XAttr_Stun_Total);
			list.Add(XAttributeDefine.XAttr_StunResist_Total);
			XStaticSecurityStatistics.Append("Roleinf1", XSecurityAttributeInfo._GetMergeAttrs(attributes, list), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			list.Clear();
			list.Add(XAttributeDefine.XAttr_FireAtk_Total);
			list.Add(XAttributeDefine.XAttr_WaterAtk_Total);
			list.Add(XAttributeDefine.XAttr_LightAtk_Total);
			list.Add(XAttributeDefine.XAttr_DarkAtk_Total);
			list.Add(XAttributeDefine.XAttr_FireDef_Total);
			list.Add(XAttributeDefine.XAttr_WaterDef_Total);
			list.Add(XAttributeDefine.XAttr_LightDef_Total);
			list.Add(XAttributeDefine.XAttr_DarkDef_Total);
			XStaticSecurityStatistics.Append("Roleinf2", XSecurityAttributeInfo._GetMergeAttrs(attributes, list), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
			list.Clear();
			list.Add(XAttributeDefine.XAttr_Strength_Total);
			list.Add(XAttributeDefine.XAttr_Agility_Total);
			list.Add(XAttributeDefine.XAttr_Intelligence_Total);
			list.Add(XAttributeDefine.XAttr_Vitality_Total);
			XStaticSecurityStatistics.Append("Roleinf3", XSecurityAttributeInfo._GetMergeAttrs(attributes, list), this._PlayerInitAttrKeyList, this._PlayerInitAttrValueList);
		}

		// Token: 0x0600A6D6 RID: 42710 RVA: 0x001D653C File Offset: 0x001D473C
		private static string _GetMergeAttrs(XAttributes attributes, List<XAttributeDefine> attrs)
		{
			StringBuilder shareSB = XSingleton<XCommon>.singleton.shareSB;
			shareSB.Length = 0;
			for (int i = 0; i < attrs.Count; i++)
			{
				bool flag = i != 0;
				if (flag)
				{
					shareSB.Append(',');
				}
				shareSB.Append(((long)attributes.GetAttr(attrs[i])).ToString());
			}
			return shareSB.ToString();
		}

		// Token: 0x04003D5E RID: 15710
		private XSecurityAttributeInfo.AttrInfo _Hp = default(XSecurityAttributeInfo.AttrInfo);

		// Token: 0x04003D5F RID: 15711
		private XSecurityAttributeInfo.AttrInfo _Mp = default(XSecurityAttributeInfo.AttrInfo);

		// Token: 0x04003D60 RID: 15712
		private List<string> _PlayerInitAttrKeyList;

		// Token: 0x04003D61 RID: 15713
		private List<string> _PlayerInitAttrValueList;

		// Token: 0x02001998 RID: 6552
		private struct AttrInfo
		{
			// Token: 0x0601102B RID: 69675 RVA: 0x00453960 File Offset: 0x00451B60
			public void Reset()
			{
				this._IncCount = 0f;
				this._IncMax = 0f;
				this._IncMin = float.MaxValue;
				this._IncTotal = 0f;
				this._DecCount = 0f;
				this._DecMax = 0f;
				this._DecMin = float.MaxValue;
				this._DecTotal = 0f;
			}

			// Token: 0x0601102C RID: 69676 RVA: 0x004539C8 File Offset: 0x00451BC8
			public void OnChange(double delta)
			{
				bool flag = delta > 0.0;
				if (flag)
				{
					this._IncCount += 1f;
					this._IncTotal += (float)delta;
					this._IncMax = Math.Max((float)delta, this._IncMax);
					this._IncMin = Math.Min((float)delta, this._IncMin);
				}
				else
				{
					this._DecCount += 1f;
					this._DecTotal += (float)(-(float)delta);
					this._DecMax = Math.Max((float)(-(float)delta), this._DecMax);
					this._DecMin = Math.Min((float)(-(float)delta), this._DecMin);
				}
			}

			// Token: 0x04007F1E RID: 32542
			public float _IncCount;

			// Token: 0x04007F1F RID: 32543
			public float _IncMax;

			// Token: 0x04007F20 RID: 32544
			public float _IncMin;

			// Token: 0x04007F21 RID: 32545
			public float _IncTotal;

			// Token: 0x04007F22 RID: 32546
			public float _DecCount;

			// Token: 0x04007F23 RID: 32547
			public float _DecMax;

			// Token: 0x04007F24 RID: 32548
			public float _DecMin;

			// Token: 0x04007F25 RID: 32549
			public float _DecTotal;
		}
	}
}
