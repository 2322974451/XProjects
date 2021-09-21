using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C9 RID: 201
	public class CookingFoodInfo : CVSReader
	{
		// Token: 0x0600058F RID: 1423 RVA: 0x000194C0 File Offset: 0x000176C0
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

		// Token: 0x06000590 RID: 1424 RVA: 0x0001952C File Offset: 0x0001772C
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

		// Token: 0x06000591 RID: 1425 RVA: 0x0001965C File Offset: 0x0001785C
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

		// Token: 0x040002EF RID: 751
		public CookingFoodInfo.RowData[] Table = null;

		// Token: 0x020002C7 RID: 711
		public class RowData
		{
			// Token: 0x040009A9 RID: 2473
			public uint FoodID;

			// Token: 0x040009AA RID: 2474
			public string FoodName;

			// Token: 0x040009AB RID: 2475
			public string Desc;

			// Token: 0x040009AC RID: 2476
			public uint AddExp;

			// Token: 0x040009AD RID: 2477
			public SeqListRef<uint> Ingredients;

			// Token: 0x040009AE RID: 2478
			public uint Duration;

			// Token: 0x040009AF RID: 2479
			public uint Frequency;

			// Token: 0x040009B0 RID: 2480
			public uint Level;

			// Token: 0x040009B1 RID: 2481
			public uint CookBookID;

			// Token: 0x040009B2 RID: 2482
			public uint[] Profession;
		}
	}
}
