using System;

namespace XUtliPoolLib
{

	public class DefaultEquip : CVSReader
	{

		public DefaultEquip.RowData GetByProfID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DefaultEquip.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchProfID(key);
			}
			return result;
		}

		private DefaultEquip.RowData BinarySearchProfID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			DefaultEquip.RowData rowData;
			DefaultEquip.RowData rowData2;
			DefaultEquip.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ProfID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ProfID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.ProfID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ProfID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			DefaultEquip.RowData rowData = new DefaultEquip.RowData();
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Helmet, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Face, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Body, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Leg, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Boots, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Glove, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Weapon, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.WeaponPoint, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.WingPoint, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.SecondWeapon, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Wing, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.Tail, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Decal, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Hair, CVSReader.stringParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.TailPoint, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.FishingPoint, CVSReader.stringParse);
			this.columnno = 16;
			base.ReadArray<string>(reader, ref rowData.SideWeaponPoint, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.RootPoint, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<byte>(reader, ref rowData.id, CVSReader.byteParse);
			this.columnno = 19;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DefaultEquip.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DefaultEquip.RowData[] Table = null;

		public class RowData
		{

			public int ProfID;

			public string Helmet;

			public string Face;

			public string Body;

			public string Leg;

			public string Boots;

			public string Glove;

			public string Weapon;

			public string[] WeaponPoint;

			public string WingPoint;

			public string SecondWeapon;

			public string Wing;

			public string Tail;

			public string Decal;

			public string Hair;

			public string TailPoint;

			public string FishingPoint;

			public string[] SideWeaponPoint;

			public string RootPoint;

			public byte id;
		}
	}
}
