using System;

namespace XUtliPoolLib
{
	// Token: 0x020000ED RID: 237
	public class FestScene : CVSReader
	{
		// Token: 0x06000634 RID: 1588 RVA: 0x0001E080 File Offset: 0x0001C280
		public FestScene.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FestScene.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0001E0EC File Offset: 0x0001C2EC
		protected override void ReadLine(XBinaryReader reader)
		{
			FestScene.RowData rowData = new FestScene.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.PicPath, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.RewardList, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001E164 File Offset: 0x0001C364
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestScene.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000339 RID: 825
		public FestScene.RowData[] Table = null;

		// Token: 0x020002EC RID: 748
		public class RowData
		{
			// Token: 0x04000ABD RID: 2749
			public uint id;

			// Token: 0x04000ABE RID: 2750
			public string PicPath;

			// Token: 0x04000ABF RID: 2751
			public uint[] RewardList;
		}
	}
}
