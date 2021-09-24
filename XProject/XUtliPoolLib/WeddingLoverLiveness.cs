using System;

namespace XUtliPoolLib
{

	public class WeddingLoverLiveness : CVSReader
	{

		public WeddingLoverLiveness.RowData GetByindex(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			WeddingLoverLiveness.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].index == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			WeddingLoverLiveness.RowData rowData = new WeddingLoverLiveness.RowData();
			base.Read<uint>(reader, ref rowData.index, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.liveness, CVSReader.uintParse);
			this.columnno = 1;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.boxPic, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WeddingLoverLiveness.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public WeddingLoverLiveness.RowData[] Table = null;

		public class RowData
		{

			public uint index;

			public uint liveness;

			public SeqListRef<uint> viewabledrop;

			public string boxPic;
		}
	}
}
