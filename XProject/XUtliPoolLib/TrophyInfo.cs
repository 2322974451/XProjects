using System;

namespace XUtliPoolLib
{
	// Token: 0x02000243 RID: 579
	public class TrophyInfo : CVSReader
	{
		// Token: 0x06000CB5 RID: 3253 RVA: 0x00042D08 File Offset: 0x00040F08
		protected override void ReadLine(XBinaryReader reader)
		{
			TrophyInfo.RowData rowData = new TrophyInfo.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 1;
			rowData.TrophyScore.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Third, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.ThirdPara, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.Second, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.SecondPara, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.First, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.FirstPara, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.ThirdDesc, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.SecondDesc, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.FirstDesc, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x00042EA4 File Offset: 0x000410A4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TrophyInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000791 RID: 1937
		public TrophyInfo.RowData[] Table = null;

		// Token: 0x020003D2 RID: 978
		public class RowData
		{
			// Token: 0x0400112D RID: 4397
			public uint ID;

			// Token: 0x0400112E RID: 4398
			public uint SceneID;

			// Token: 0x0400112F RID: 4399
			public SeqRef<uint> TrophyScore;

			// Token: 0x04001130 RID: 4400
			public uint Third;

			// Token: 0x04001131 RID: 4401
			public uint ThirdPara;

			// Token: 0x04001132 RID: 4402
			public uint Second;

			// Token: 0x04001133 RID: 4403
			public uint SecondPara;

			// Token: 0x04001134 RID: 4404
			public uint First;

			// Token: 0x04001135 RID: 4405
			public uint FirstPara;

			// Token: 0x04001136 RID: 4406
			public string Name;

			// Token: 0x04001137 RID: 4407
			public string ThirdDesc;

			// Token: 0x04001138 RID: 4408
			public string SecondDesc;

			// Token: 0x04001139 RID: 4409
			public string FirstDesc;

			// Token: 0x0400113A RID: 4410
			public string Icon;
		}
	}
}
