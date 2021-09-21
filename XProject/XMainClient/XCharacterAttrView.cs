using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EF6 RID: 3830
	internal class XCharacterAttrView<T> : XAttrCommonHandler<T> where T : XAttrCommonFile, new()
	{
		// Token: 0x0600CB44 RID: 52036 RVA: 0x002E4834 File Offset: 0x002E2A34
		public void SetAttributes(XAttributes attributes)
		{
			bool flag = this.m_Attributes != attributes;
			if (flag)
			{
				this.m_Attributes = attributes;
				bool flag2 = base.IsVisible();
				if (flag2)
				{
					this.RefreshData();
				}
			}
		}

		// Token: 0x0600CB45 RID: 52037 RVA: 0x002E486C File Offset: 0x002E2A6C
		public override void SetData()
		{
			base.SetData();
			bool flag = this.m_Attributes == null;
			if (!flag)
			{
				CharacterAttributesList.RowData[] table = XCharacterEquipDocument.AttributeTable.Table;
				XAttrData xattrData = null;
				foreach (CharacterAttributesList.RowData rowData in table)
				{
					bool flag2 = xattrData == null || xattrData.Title != rowData.Section;
					if (flag2)
					{
						xattrData = base._FetchAttrData();
						xattrData.Title = rowData.Section;
						xattrData.Type = AttriDataType.Attri;
					}
					XAttributeDefine attributeID = (XAttributeDefine)rowData.AttributeID;
					xattrData.Left.Add(XStringDefineProxy.GetString(attributeID));
					bool flag3 = XSingleton<XGlobalConfig>.singleton.GetInt("AttriStat") != 0 && this.m_showPerAttr.ContainsKey(attributeID);
					if (flag3)
					{
						double attr = this.m_Attributes.GetAttr(attributeID);
						xattrData.Right.Add(string.Format("{0}({1}%)", XAttributeCommon.GetAttrValueStr(rowData.AttributeID, (uint)attr, false), (int)(this.GetAttrPercent(attributeID, attr) * 100.0)));
					}
					else
					{
						xattrData.Right.Add(XAttributeCommon.GetAttrValueStr(rowData.AttributeID, (uint)this.m_Attributes.GetAttr(attributeID), false));
					}
				}
			}
		}

		// Token: 0x0600CB46 RID: 52038 RVA: 0x002E49BC File Offset: 0x002E2BBC
		private double GetAttrPercent(XAttributeDefine type, double value)
		{
			XCharacterAttrView<T>.AttrType type2;
			bool flag = !this.m_showPerAttr.TryGetValue(type, out type2);
			if (flag)
			{
				type2 = XCharacterAttrView<T>.AttrType.None;
			}
			double max = this.GetMax(type2);
			double min = this.GetMin(type2);
			CombatParamTable.RowData combatParam = XSingleton<XCombat>.singleton.GetCombatParam(this.m_Attributes.Level);
			int baseValue = this.GetBaseValue(type, combatParam);
			double num = this.GetCombatValue(baseValue, value);
			num = ((num > min) ? num : min);
			return (num < max) ? num : max;
		}

		// Token: 0x0600CB47 RID: 52039 RVA: 0x002E4A3C File Offset: 0x002E2C3C
		private double GetMax(XCharacterAttrView<T>.AttrType type)
		{
			double result;
			switch (type)
			{
			case XCharacterAttrView<T>.AttrType.ElementAtk:
				result = XSingleton<XGlobalConfig>.singleton.ElemAtkLimit;
				break;
			case XCharacterAttrView<T>.AttrType.ElementDef:
				result = XSingleton<XGlobalConfig>.singleton.ElemDefLimit;
				break;
			case XCharacterAttrView<T>.AttrType.Critical:
				result = XSingleton<XGlobalConfig>.singleton.CriticalLimit;
				break;
			case XCharacterAttrView<T>.AttrType.CritDamage:
				result = XSingleton<XGlobalConfig>.singleton.CritDamageUpperBound;
				break;
			case XCharacterAttrView<T>.AttrType.PhysicalDef:
				result = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PhycialAvoidenceLimit"));
				break;
			case XCharacterAttrView<T>.AttrType.MagicDef:
				result = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MagicAvoidenceLimit"));
				break;
			default:
				result = 10.0;
				break;
			}
			return result;
		}

		// Token: 0x0600CB48 RID: 52040 RVA: 0x002E4ADC File Offset: 0x002E2CDC
		private double GetMin(XCharacterAttrView<T>.AttrType type)
		{
			double result;
			if (type != XCharacterAttrView<T>.AttrType.CritDamage)
			{
				result = 0.0;
			}
			else
			{
				result = XSingleton<XGlobalConfig>.singleton.CritDamageLowerBound;
			}
			return result;
		}

		// Token: 0x0600CB49 RID: 52041 RVA: 0x002E4B0C File Offset: 0x002E2D0C
		private int GetBaseValue(XAttributeDefine type, CombatParamTable.RowData atkData)
		{
			bool flag = atkData == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				if (type <= XAttributeDefine.XAttr_MagicDef_Total)
				{
					if (type == XAttributeDefine.XAttr_PhysicalDef_Total)
					{
						return atkData.PhysicalDef;
					}
					if (type == XAttributeDefine.XAttr_MagicDef_Total)
					{
						return atkData.MagicDef;
					}
				}
				else
				{
					if (type == XAttributeDefine.XAttr_Critical_Total)
					{
						return atkData.CriticalBase;
					}
					if (type == XAttributeDefine.XAttr_CritDamage_Total)
					{
						return atkData.CritDamageBase;
					}
					switch (type)
					{
					case XAttributeDefine.XAttr_FireAtk_Total:
					case XAttributeDefine.XAttr_WaterAtk_Total:
					case XAttributeDefine.XAttr_LightAtk_Total:
					case XAttributeDefine.XAttr_DarkAtk_Total:
						return atkData.ElementAtk;
					case XAttributeDefine.XAttr_FireDef_Total:
					case XAttributeDefine.XAttr_WaterDef_Total:
					case XAttributeDefine.XAttr_LightDef_Total:
					case XAttributeDefine.XAttr_DarkDef_Total:
						return atkData.ElementDef;
					}
				}
				result = 0;
			}
			return result;
		}

		// Token: 0x0600CB4A RID: 52042 RVA: 0x002E4BC4 File Offset: 0x002E2DC4
		private double GetCombatValue(int combatParam, double value)
		{
			return value / (value + (double)combatParam);
		}

		// Token: 0x040059E2 RID: 23010
		private XAttributes m_Attributes;

		// Token: 0x040059E3 RID: 23011
		private Dictionary<XAttributeDefine, XCharacterAttrView<T>.AttrType> m_showPerAttr = new Dictionary<XAttributeDefine, XCharacterAttrView<T>.AttrType>
		{
			{
				XAttributeDefine.XAttr_PhysicalDef_Total,
				XCharacterAttrView<T>.AttrType.PhysicalDef
			},
			{
				XAttributeDefine.XAttr_MagicDef_Total,
				XCharacterAttrView<T>.AttrType.MagicDef
			},
			{
				XAttributeDefine.XAttr_FireAtk_Total,
				XCharacterAttrView<T>.AttrType.ElementAtk
			},
			{
				XAttributeDefine.XAttr_WaterAtk_Total,
				XCharacterAttrView<T>.AttrType.ElementAtk
			},
			{
				XAttributeDefine.XAttr_LightAtk_Total,
				XCharacterAttrView<T>.AttrType.ElementAtk
			},
			{
				XAttributeDefine.XAttr_DarkAtk_Total,
				XCharacterAttrView<T>.AttrType.ElementAtk
			},
			{
				XAttributeDefine.XAttr_FireDef_Total,
				XCharacterAttrView<T>.AttrType.ElementDef
			},
			{
				XAttributeDefine.XAttr_WaterDef_Total,
				XCharacterAttrView<T>.AttrType.ElementDef
			},
			{
				XAttributeDefine.XAttr_LightDef_Total,
				XCharacterAttrView<T>.AttrType.ElementDef
			},
			{
				XAttributeDefine.XAttr_DarkDef_Total,
				XCharacterAttrView<T>.AttrType.ElementDef
			},
			{
				XAttributeDefine.XAttr_Critical_Total,
				XCharacterAttrView<T>.AttrType.Critical
			},
			{
				XAttributeDefine.XAttr_CritDamage_Total,
				XCharacterAttrView<T>.AttrType.CritDamage
			}
		};

		// Token: 0x020019EB RID: 6635
		private enum AttrType
		{
			// Token: 0x04008096 RID: 32918
			ElementAtk,
			// Token: 0x04008097 RID: 32919
			ElementDef,
			// Token: 0x04008098 RID: 32920
			Critical,
			// Token: 0x04008099 RID: 32921
			CritDamage,
			// Token: 0x0400809A RID: 32922
			PhysicalDef,
			// Token: 0x0400809B RID: 32923
			MagicDef,
			// Token: 0x0400809C RID: 32924
			None
		}
	}
}
