using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F1 RID: 241
	public class FirstPassTable : CVSReader
	{
		// Token: 0x06000641 RID: 1601 RVA: 0x0001E46C File Offset: 0x0001C66C
		public FirstPassTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FirstPassTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001E4D8 File Offset: 0x0001C6D8
		protected override void ReadLine(XBinaryReader reader)
		{
			FirstPassTable.RowData rowData = new FirstPassTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.RewardID, CVSReader.intParse);
			this.columnno = 2;
			rowData.CommendReward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.SystemId, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Des, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.BgTexName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.NestType, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.RankTittle, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0001E5EC File Offset: 0x0001C7EC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FirstPassTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400033D RID: 829
		public FirstPassTable.RowData[] Table = null;

		// Token: 0x020002F0 RID: 752
		public class RowData
		{
			// Token: 0x04000ACF RID: 2767
			public int ID;

			// Token: 0x04000AD0 RID: 2768
			public int[] SceneID;

			// Token: 0x04000AD1 RID: 2769
			public int RewardID;

			// Token: 0x04000AD2 RID: 2770
			public SeqListRef<int> CommendReward;

			// Token: 0x04000AD3 RID: 2771
			public int SystemId;

			// Token: 0x04000AD4 RID: 2772
			public string Des;

			// Token: 0x04000AD5 RID: 2773
			public string BgTexName;

			// Token: 0x04000AD6 RID: 2774
			public uint NestType;

			// Token: 0x04000AD7 RID: 2775
			public string RankTittle;
		}
	}
}
