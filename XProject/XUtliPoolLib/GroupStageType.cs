using System;

namespace XUtliPoolLib
{
	// Token: 0x02000245 RID: 581
	public class GroupStageType : CVSReader
	{
		// Token: 0x06000CBB RID: 3259 RVA: 0x00042FB8 File Offset: 0x000411B8
		public GroupStageType.RowData GetByStageID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GroupStageType.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].StageID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x00043024 File Offset: 0x00041224
		protected override void ReadLine(XBinaryReader reader)
		{
			GroupStageType.RowData rowData = new GroupStageType.RowData();
			base.Read<uint>(reader, ref rowData.StageID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.StageName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.StagePerent, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Stage2Expedition, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x000430B8 File Offset: 0x000412B8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GroupStageType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000793 RID: 1939
		public GroupStageType.RowData[] Table = null;

		// Token: 0x020003D4 RID: 980
		public class RowData
		{
			// Token: 0x0400113F RID: 4415
			public uint StageID;

			// Token: 0x04001140 RID: 4416
			public string StageName;

			// Token: 0x04001141 RID: 4417
			public uint StagePerent;

			// Token: 0x04001142 RID: 4418
			public int Stage2Expedition;
		}
	}
}
