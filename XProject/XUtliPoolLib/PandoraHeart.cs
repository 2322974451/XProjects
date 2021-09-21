using System;

namespace XUtliPoolLib
{
	// Token: 0x02000133 RID: 307
	public class PandoraHeart : CVSReader
	{
		// Token: 0x0600073D RID: 1853 RVA: 0x00024598 File Offset: 0x00022798
		protected override void ReadLine(XBinaryReader reader)
		{
			PandoraHeart.RowData rowData = new PandoraHeart.RowData();
			base.Read<uint>(reader, ref rowData.PandoraID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ProfID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.FireID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot0, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle0, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot1, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle1, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot2, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle2, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.DisplayName0, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.DisplayName1, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.DisplayName2, CVSReader.stringParse);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00024700 File Offset: 0x00022900
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PandoraHeart.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400037F RID: 895
		public PandoraHeart.RowData[] Table = null;

		// Token: 0x02000332 RID: 818
		public class RowData
		{
			// Token: 0x04000C7D RID: 3197
			public uint PandoraID;

			// Token: 0x04000C7E RID: 3198
			public uint ProfID;

			// Token: 0x04000C7F RID: 3199
			public uint FireID;

			// Token: 0x04000C80 RID: 3200
			public uint[] DisplaySlot0;

			// Token: 0x04000C81 RID: 3201
			public uint[] DisplayAngle0;

			// Token: 0x04000C82 RID: 3202
			public uint[] DisplaySlot1;

			// Token: 0x04000C83 RID: 3203
			public uint[] DisplayAngle1;

			// Token: 0x04000C84 RID: 3204
			public uint[] DisplaySlot2;

			// Token: 0x04000C85 RID: 3205
			public uint[] DisplayAngle2;

			// Token: 0x04000C86 RID: 3206
			public string DisplayName0;

			// Token: 0x04000C87 RID: 3207
			public string DisplayName1;

			// Token: 0x04000C88 RID: 3208
			public string DisplayName2;
		}
	}
}
