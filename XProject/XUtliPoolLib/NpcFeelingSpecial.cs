using System;

namespace XUtliPoolLib
{
	// Token: 0x0200025A RID: 602
	public class NpcFeelingSpecial : CVSReader
	{
		// Token: 0x06000D09 RID: 3337 RVA: 0x00044D1C File Offset: 0x00042F1C
		protected override void ReadLine(XBinaryReader reader)
		{
			NpcFeelingSpecial.RowData rowData = new NpcFeelingSpecial.RowData();
			base.Read<uint>(reader, ref rowData.npcId, CVSReader.uintParse);
			this.columnno = 0;
			rowData.enhanceReduce.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x00044D7C File Offset: 0x00042F7C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NpcFeelingSpecial.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A8 RID: 1960
		public NpcFeelingSpecial.RowData[] Table = null;

		// Token: 0x020003E9 RID: 1001
		public class RowData
		{
			// Token: 0x040011C6 RID: 4550
			public uint npcId;

			// Token: 0x040011C7 RID: 4551
			public SeqListRef<uint> enhanceReduce;
		}
	}
}
