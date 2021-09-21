using System;

namespace XUtliPoolLib
{
	// Token: 0x02000259 RID: 601
	public class NpcUniteAttr : CVSReader
	{
		// Token: 0x06000D06 RID: 3334 RVA: 0x00044C14 File Offset: 0x00042E14
		protected override void ReadLine(XBinaryReader reader)
		{
			NpcUniteAttr.RowData rowData = new NpcUniteAttr.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.npcId, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			rowData.Attr.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x00044CDC File Offset: 0x00042EDC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NpcUniteAttr.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A7 RID: 1959
		public NpcUniteAttr.RowData[] Table = null;

		// Token: 0x020003E8 RID: 1000
		public class RowData
		{
			// Token: 0x040011C0 RID: 4544
			public uint id;

			// Token: 0x040011C1 RID: 4545
			public uint[] npcId;

			// Token: 0x040011C2 RID: 4546
			public uint level;

			// Token: 0x040011C3 RID: 4547
			public SeqListRef<uint> Attr;

			// Token: 0x040011C4 RID: 4548
			public string Name;

			// Token: 0x040011C5 RID: 4549
			public string Icon;
		}
	}
}
