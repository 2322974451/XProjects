using System;

namespace XUtliPoolLib
{

	public class CookingFoodInfo : CVSReader
	{

		public CookingFoodInfo.RowData GetByFoodID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CookingFoodInfo.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].FoodID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			CookingFoodInfo.RowData rowData = new CookingFoodInfo.RowData();
			base.Read<uint>(reader, ref rowData.FoodID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.FoodName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.AddExp, CVSReader.uintParse);
			this.columnno = 3;
			rowData.Ingredients.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.Duration, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.Frequency, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.CookBookID, CVSReader.uintParse);
			this.columnno = 9;
			base.ReadArray<uint>(reader, ref rowData.Profession, CVSReader.uintParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CookingFoodInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CookingFoodInfo.RowData[] Table = null;

		public class RowData
		{

			public uint FoodID;

			public string FoodName;

			public string Desc;

			public uint AddExp;

			public SeqListRef<uint> Ingredients;

			public uint Duration;

			public uint Frequency;

			public uint Level;

			public uint CookBookID;

			public uint[] Profession;
		}
	}
}
