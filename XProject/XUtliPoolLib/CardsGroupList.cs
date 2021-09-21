using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C0 RID: 192
	public class CardsGroupList : CVSReader
	{
		// Token: 0x06000570 RID: 1392 RVA: 0x000188D0 File Offset: 0x00016AD0
		public CardsGroupList.RowData GetByGroupId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CardsGroupList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].GroupId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0001893C File Offset: 0x00016B3C
		protected override void ReadLine(XBinaryReader reader)
		{
			CardsGroupList.RowData rowData = new CardsGroupList.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ShowLevel, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.OpenLevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ShowUp, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.GroupName, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.MapID, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.BreakLevel, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00018A38 File Offset: 0x00016C38
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardsGroupList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E6 RID: 742
		public CardsGroupList.RowData[] Table = null;

		// Token: 0x020002BE RID: 702
		public class RowData
		{
			// Token: 0x0400096C RID: 2412
			public uint GroupId;

			// Token: 0x0400096D RID: 2413
			public uint ShowLevel;

			// Token: 0x0400096E RID: 2414
			public uint OpenLevel;

			// Token: 0x0400096F RID: 2415
			public string ShowUp;

			// Token: 0x04000970 RID: 2416
			public string Detail;

			// Token: 0x04000971 RID: 2417
			public string GroupName;

			// Token: 0x04000972 RID: 2418
			public uint MapID;

			// Token: 0x04000973 RID: 2419
			public uint[] BreakLevel;
		}
	}
}
