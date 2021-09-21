using System;

namespace XUtliPoolLib
{
	// Token: 0x02000258 RID: 600
	public class NpcFeelingAttr : CVSReader
	{
		// Token: 0x06000D03 RID: 3331 RVA: 0x00044B28 File Offset: 0x00042D28
		protected override void ReadLine(XBinaryReader reader)
		{
			NpcFeelingAttr.RowData rowData = new NpcFeelingAttr.RowData();
			base.Read<uint>(reader, ref rowData.npcId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.needExp, CVSReader.uintParse);
			this.columnno = 2;
			rowData.Attr.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.RelicsDesc, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x00044BD4 File Offset: 0x00042DD4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NpcFeelingAttr.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A6 RID: 1958
		public NpcFeelingAttr.RowData[] Table = null;

		// Token: 0x020003E7 RID: 999
		public class RowData
		{
			// Token: 0x040011BB RID: 4539
			public uint npcId;

			// Token: 0x040011BC RID: 4540
			public uint level;

			// Token: 0x040011BD RID: 4541
			public uint needExp;

			// Token: 0x040011BE RID: 4542
			public SeqListRef<uint> Attr;

			// Token: 0x040011BF RID: 4543
			public string RelicsDesc;
		}
	}
}
