using System;

namespace XUtliPoolLib
{

	public class SuperActivityTime : CVSReader
	{

		public SuperActivityTime.RowData GetByactid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SuperActivityTime.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].actid == key;
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
			SuperActivityTime.RowData rowData = new SuperActivityTime.RowData();
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.systemid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.starttime, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.duration, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.rewardtime, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.pointid, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.needpoint, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.rate, CVSReader.floatParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.starthour, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.datetype, CVSReader.uintParse);
			this.columnno = 12;
			rowData.timestage.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SuperActivityTime.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SuperActivityTime.RowData[] Table = null;

		public class RowData
		{

			public uint actid;

			public uint systemid;

			public uint starttime;

			public uint duration;

			public uint rewardtime;

			public uint pointid;

			public uint needpoint;

			public float rate;

			public uint starthour;

			public uint datetype;

			public SeqListRef<uint> timestage;
		}
	}
}
