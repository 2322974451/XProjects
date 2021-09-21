using System;

namespace XUtliPoolLib
{
	// Token: 0x0200013E RID: 318
	public class PetBubble : CVSReader
	{
		// Token: 0x06000761 RID: 1889 RVA: 0x00025400 File Offset: 0x00023600
		protected override void ReadLine(XBinaryReader reader)
		{
			PetBubble.RowData rowData = new PetBubble.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ActionID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ActionFile, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Bubble, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.BubbleTime, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Weights, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.SEFile, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x000254E0 File Offset: 0x000236E0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetBubble.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400038A RID: 906
		public PetBubble.RowData[] Table = null;

		// Token: 0x0200033D RID: 829
		public class RowData
		{
			// Token: 0x04000CD0 RID: 3280
			public uint id;

			// Token: 0x04000CD1 RID: 3281
			public uint ActionID;

			// Token: 0x04000CD2 RID: 3282
			public string ActionFile;

			// Token: 0x04000CD3 RID: 3283
			public string[] Bubble;

			// Token: 0x04000CD4 RID: 3284
			public float BubbleTime;

			// Token: 0x04000CD5 RID: 3285
			public uint Weights;

			// Token: 0x04000CD6 RID: 3286
			public string SEFile;
		}
	}
}
