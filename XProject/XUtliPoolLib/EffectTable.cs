using System;

namespace XUtliPoolLib
{
	// Token: 0x0200022B RID: 555
	public class EffectTable : CVSReader
	{
		// Token: 0x06000C5C RID: 3164 RVA: 0x00041004 File Offset: 0x0003F204
		protected override void ReadLine(XBinaryReader reader)
		{
			EffectTable.RowData rowData = new EffectTable.RowData();
			base.Read<uint>(reader, ref rowData.EffectID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.BuffID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.TemplateBuffID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SkillScript, CVSReader.uintParse);
			this.columnno = 3;
			rowData.EffectParams.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ConstantParams.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<byte>(reader, ref rowData.SortID, CVSReader.byteParse);
			this.columnno = 6;
			base.Read<byte>(reader, ref rowData.CompareSortID, CVSReader.byteParse);
			this.columnno = 7;
			rowData.CompareParams.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x00041118 File Offset: 0x0003F318
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EffectTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000779 RID: 1913
		public EffectTable.RowData[] Table = null;

		// Token: 0x020003BA RID: 954
		public class RowData
		{
			// Token: 0x040010C2 RID: 4290
			public uint EffectID;

			// Token: 0x040010C3 RID: 4291
			public uint BuffID;

			// Token: 0x040010C4 RID: 4292
			public uint TemplateBuffID;

			// Token: 0x040010C5 RID: 4293
			public uint SkillScript;

			// Token: 0x040010C6 RID: 4294
			public SeqListRef<int> EffectParams;

			// Token: 0x040010C7 RID: 4295
			public SeqListRef<string> ConstantParams;

			// Token: 0x040010C8 RID: 4296
			public byte SortID;

			// Token: 0x040010C9 RID: 4297
			public byte CompareSortID;

			// Token: 0x040010CA RID: 4298
			public SeqListRef<uint> CompareParams;
		}
	}
}
