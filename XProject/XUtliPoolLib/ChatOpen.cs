using System;

namespace XUtliPoolLib
{

	public class ChatOpen : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ChatOpen.RowData rowData = new ChatOpen.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.opens, CVSReader.intParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.friends, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.posX, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.posY, CVSReader.intParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.alpha, CVSReader.floatParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.pivot, CVSReader.intParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.scale, CVSReader.floatParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.fade, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.real, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.radioX, CVSReader.intParse);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.radioY, CVSReader.intParse);
			this.columnno = 12;
			base.Read<int>(reader, ref rowData.battle, CVSReader.intParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.max, CVSReader.intParse);
			this.columnno = 15;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChatOpen.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ChatOpen.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public int[] opens;

			public uint friends;

			public int posX;

			public int posY;

			public float alpha;

			public int pivot;

			public float scale;

			public int fade;

			public int real;

			public int radioX;

			public int radioY;

			public int battle;

			public uint sceneid;

			public int max;
		}
	}
}
