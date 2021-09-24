using System;

namespace XUtliPoolLib
{

	public class RiftType : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RiftType.RowData rowData = new RiftType.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.sceneid, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.worldlevel, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.bufflibrary, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.buffcounts, CVSReader.intParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiftType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RiftType.RowData[] Table = null;

		public class RowData
		{

			public int id;

			public int sceneid;

			public int worldlevel;

			public int bufflibrary;

			public int buffcounts;
		}
	}
}
