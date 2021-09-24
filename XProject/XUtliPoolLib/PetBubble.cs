using System;

namespace XUtliPoolLib
{

	public class PetBubble : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PetBubble.RowData rowData = new PetBubble.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ActionID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ActionFile, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Bubble, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.BubbleTime, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Weights, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.SEFile, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetBubble.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PetBubble.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint ActionID;

			public string ActionFile;

			public string[] Bubble;

			public float BubbleTime;

			public uint Weights;

			public string SEFile;
		}
	}
}
