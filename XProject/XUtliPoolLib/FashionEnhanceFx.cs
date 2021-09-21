using System;

namespace XUtliPoolLib
{
	// Token: 0x02000231 RID: 561
	public class FashionEnhanceFx : CVSReader
	{
		// Token: 0x06000C70 RID: 3184 RVA: 0x00041684 File Offset: 0x0003F884
		public FashionEnhanceFx.RowData GetByItemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionEnhanceFx.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ItemID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x000416F0 File Offset: 0x0003F8F0
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionEnhanceFx.RowData rowData = new FashionEnhanceFx.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.Fx1, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.Fx2, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Fx3, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.Fx4, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<string>(reader, ref rowData.Fx5, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.Fx6, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.Fx7, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.Fx8, CVSReader.stringParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x00041804 File Offset: 0x0003FA04
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionEnhanceFx.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400077F RID: 1919
		public FashionEnhanceFx.RowData[] Table = null;

		// Token: 0x020003C0 RID: 960
		public class RowData
		{
			// Token: 0x040010E1 RID: 4321
			public int ItemID;

			// Token: 0x040010E2 RID: 4322
			public string[] Fx1;

			// Token: 0x040010E3 RID: 4323
			public string[] Fx2;

			// Token: 0x040010E4 RID: 4324
			public string[] Fx3;

			// Token: 0x040010E5 RID: 4325
			public string[] Fx4;

			// Token: 0x040010E6 RID: 4326
			public string[] Fx5;

			// Token: 0x040010E7 RID: 4327
			public string[] Fx6;

			// Token: 0x040010E8 RID: 4328
			public string[] Fx7;

			// Token: 0x040010E9 RID: 4329
			public string[] Fx8;
		}
	}
}
