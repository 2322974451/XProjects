using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPowerPointCalculator : XSingleton<XPowerPointCalculator>
	{

		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/AttributeList", this.m_AttrTable, false);
				this._async_loader.AddTask("Table/ProfessionConversionParameter", this.m_AttrConvertTable, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				this._BuildPPTWeightMap();
				this._BuildAttrConvertor();
				this.m_AttrTable = null;
				this.m_AttrConvertTable = null;
				result = true;
			}
			return result;
		}

		private void _BuildPPTWeightMap()
		{
			this.m_PPTWeight.Clear();
			for (int i = 0; i < this.m_AttrTable.Table.Length; i++)
			{
				PowerPointCoeffTable.RowData rowData = this.m_AttrTable.Table[i];
				int key = (int)(rowData.Profession << 8 | (uint)rowData.AttributeID);
				bool flag = this.m_PPTWeight.ContainsKey(key);
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Duplicated key in PowerPointCoeffTable: prof = {0} and attr = {1}", rowData.Profession, rowData.AttributeID), null, null, null, null, null);
				}
				else
				{
					this.m_PPTWeight.Add(key, rowData.Weight);
				}
			}
		}

		private void _BuildAttrConvertor()
		{
			this.m_AttrConvertor.Clear();
			List<XTuple<int, double>> list = new List<XTuple<int, double>>();
			for (int i = 0; i < this.m_AttrConvertTable.Table.Length; i++)
			{
				ProfessionConvertTable.RowData rowData = this.m_AttrConvertTable.Table[i];
				int key = rowData.ProfessionID << 8 | rowData.AttributeID;
				bool flag = this.m_AttrConvertor.ContainsKey(key);
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Duplicated key in ProfessionConvertTable: prof = {0} and attr = {1}", rowData.ProfessionID, rowData.AttributeID), null, null, null, null, null);
				}
				else
				{
					list.Clear();
					bool flag2 = rowData.PhysicalAtk != 0.0;
					if (flag2)
					{
						list.Add(new XTuple<int, double>(11, rowData.PhysicalAtk));
					}
					bool flag3 = rowData.MagicAtk != 0.0;
					if (flag3)
					{
						list.Add(new XTuple<int, double>(21, rowData.MagicAtk));
					}
					bool flag4 = rowData.PhysicalDef != 0.0;
					if (flag4)
					{
						list.Add(new XTuple<int, double>(12, rowData.PhysicalDef));
					}
					bool flag5 = rowData.MagicDef != 0.0;
					if (flag5)
					{
						list.Add(new XTuple<int, double>(22, rowData.MagicDef));
					}
					bool flag6 = rowData.MaxHP != 0.0;
					if (flag6)
					{
						list.Add(new XTuple<int, double>(13, rowData.MaxHP));
					}
					bool flag7 = rowData.MaxMP != 0.0;
					if (flag7)
					{
						list.Add(new XTuple<int, double>(23, rowData.MaxMP));
					}
					bool flag8 = rowData.Critical != 0.0;
					if (flag8)
					{
						list.Add(new XTuple<int, double>(31, rowData.Critical));
					}
					bool flag9 = rowData.CritDamage != 0.0;
					if (flag9)
					{
						list.Add(new XTuple<int, double>(111, rowData.CritDamage));
					}
					bool flag10 = rowData.CritResist != 0.0;
					if (flag10)
					{
						list.Add(new XTuple<int, double>(32, rowData.CritResist));
					}
					this.m_AttrConvertor.Add(key, list.ToArray());
				}
			}
		}

		public XTuple<int, double>[] GetConvertCoefficient(int attrid, int prof)
		{
			XTuple<int, double>[] result;
			this.m_AttrConvertor.TryGetValue(this.GetBasicKey(prof, attrid), out result);
			return result;
		}

		public double GetPPT(XItemChangeAttr attr, XAttributes attributes = null, int prof = -1)
		{
			return this.GetPPT(attr.AttrID, attr.AttrValue, attributes, prof);
		}

		public double GetPPT(uint attrid, uint attrvalue, XAttributes attributes = null, int prof = -1)
		{
			return this.GetPPT(attrid, attrvalue, attributes, prof);
		}

		public double GetPPT(uint attrid, double attrvalue, XAttributes attributes = null, int prof = -1)
		{
			int num = (int)attrid;
			double num2 = attrvalue;
			bool flag = attributes == null;
			if (flag)
			{
				attributes = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			}
			bool flag2 = prof < 0;
			if (flag2)
			{
				prof = (int)attributes.BasicTypeID;
			}
			else
			{
				prof %= 10;
			}
			bool flag3 = !XAttributeCommon.IsBasicRange(num);
			if (flag3)
			{
				int basicAttr = XAttributeCommon.GetBasicAttr((int)attrid);
				bool flag4 = XAttributeCommon.IsPercentRange((int)attrid);
				if (flag4)
				{
					num2 = attributes.GetAttr((XAttributeDefine)basicAttr) * num2 / 100.0;
				}
				num = basicAttr;
			}
			bool flag5 = this.m_BasicAttrs.Contains((XAttributeDefine)num);
			double result;
			if (flag5)
			{
				int num3 = prof;
				bool flag6 = num3 == 0;
				if (flag6)
				{
					num3 = (int)attributes.BasicTypeID;
				}
				XTuple<int, double>[] array;
				bool flag7 = this.m_AttrConvertor.TryGetValue(this.GetKey(num3, num), out array);
				if (flag7)
				{
					double num4 = 0.0;
					for (int i = 0; i < array.Length; i++)
					{
						num4 += this._GetPPT(array[i].Item1, array[i].Item2 * num2, prof);
					}
					result = num4;
				}
				else
				{
					result = 0.0;
				}
			}
			else
			{
				result = this._GetPPT(num, num2, prof);
			}
			return result;
		}

		private double _GetPPT(int attrid, double attrvalue, int prof)
		{
			double num;
			bool flag = this.m_PPTWeight.TryGetValue(this.GetBasicKey(prof, attrid), out num);
			double result;
			if (flag)
			{
				result = num * attrvalue;
			}
			else
			{
				bool flag2 = prof > 0 && this.m_PPTWeight.TryGetValue(this.GetKey(attrid), out num);
				if (flag2)
				{
					result = num * attrvalue;
				}
				else
				{
					result = 0.0;
				}
			}
			return result;
		}

		private int GetKey(int prof, int attrid)
		{
			return prof << 8 | attrid;
		}

		private int GetBasicKey(int prof, int attrid)
		{
			return prof % 10 << 8 | attrid;
		}

		private int GetKey(int attrid)
		{
			return attrid;
		}

		private XTableAsyncLoader _async_loader = null;

		private PowerPointCoeffTable m_AttrTable = new PowerPointCoeffTable();

		private ProfessionConvertTable m_AttrConvertTable = new ProfessionConvertTable();

		private Dictionary<int, double> m_PPTWeight = new Dictionary<int, double>();

		private Dictionary<int, XTuple<int, double>[]> m_AttrConvertor = new Dictionary<int, XTuple<int, double>[]>();

		private HashSet<XAttributeDefine> m_BasicAttrs = new HashSet<XAttributeDefine>(default(XFastEnumIntEqualityComparer<XAttributeDefine>))
		{
			XAttributeDefine.XAttr_Strength_Basic,
			XAttributeDefine.XAttr_Intelligence_Basic,
			XAttributeDefine.XAttr_Agility_Basic,
			XAttributeDefine.XAttr_Vitality_Basic
		};
	}
}
