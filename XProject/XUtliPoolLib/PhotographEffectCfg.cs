using System;

namespace XUtliPoolLib
{
	// Token: 0x02000146 RID: 326
	public class PhotographEffectCfg : CVSReader
	{
		// Token: 0x0600077E RID: 1918 RVA: 0x00025DE0 File Offset: 0x00023FE0
		protected override void ReadLine(XBinaryReader reader)
		{
			PhotographEffectCfg.RowData rowData = new PhotographEffectCfg.RowData();
			base.Read<uint>(reader, ref rowData.EffectID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Condition.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.EffectName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.EffectRoute, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.ConditionDesc, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00025EC0 File Offset: 0x000240C0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PhotographEffectCfg.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000392 RID: 914
		public PhotographEffectCfg.RowData[] Table = null;

		// Token: 0x02000345 RID: 837
		public class RowData
		{
			// Token: 0x04000CFB RID: 3323
			public uint EffectID;

			// Token: 0x04000CFC RID: 3324
			public SeqListRef<uint> Condition;

			// Token: 0x04000CFD RID: 3325
			public string EffectName;

			// Token: 0x04000CFE RID: 3326
			public string EffectRoute;

			// Token: 0x04000CFF RID: 3327
			public string ConditionDesc;

			// Token: 0x04000D00 RID: 3328
			public string desc;

			// Token: 0x04000D01 RID: 3329
			public uint SystemID;
		}
	}
}
