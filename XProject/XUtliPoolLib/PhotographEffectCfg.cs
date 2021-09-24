using System;

namespace XUtliPoolLib
{

	public class PhotographEffectCfg : CVSReader
	{

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

		public PhotographEffectCfg.RowData[] Table = null;

		public class RowData
		{

			public uint EffectID;

			public SeqListRef<uint> Condition;

			public string EffectName;

			public string EffectRoute;

			public string ConditionDesc;

			public string desc;

			public uint SystemID;
		}
	}
}
