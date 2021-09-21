using System;

namespace XUtliPoolLib
{
	// Token: 0x0200026B RID: 619
	public class RiftBuffSuitMonsterType : CVSReader
	{
		// Token: 0x06000D41 RID: 3393 RVA: 0x00045F14 File Offset: 0x00044114
		protected override void ReadLine(XBinaryReader reader)
		{
			RiftBuffSuitMonsterType.RowData rowData = new RiftBuffSuitMonsterType.RowData();
			rowData.buff.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.suitmonstertype, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.atlas, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.scription, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x00045FC0 File Offset: 0x000441C0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiftBuffSuitMonsterType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B9 RID: 1977
		public RiftBuffSuitMonsterType.RowData[] Table = null;

		// Token: 0x020003FA RID: 1018
		public class RowData
		{
			// Token: 0x0400121A RID: 4634
			public SeqRef<uint> buff;

			// Token: 0x0400121B RID: 4635
			public uint[] suitmonstertype;

			// Token: 0x0400121C RID: 4636
			public string atlas;

			// Token: 0x0400121D RID: 4637
			public string icon;

			// Token: 0x0400121E RID: 4638
			public string scription;
		}
	}
}
