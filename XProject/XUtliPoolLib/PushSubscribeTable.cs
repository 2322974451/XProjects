using System;

namespace XUtliPoolLib
{

	public class PushSubscribeTable : CVSReader
	{

		public PushSubscribeTable.RowData GetByMsgId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PushSubscribeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].MsgId == key;
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
			PushSubscribeTable.RowData rowData = new PushSubscribeTable.RowData();
			base.Read<uint>(reader, ref rowData.MsgId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<bool>(reader, ref rowData.IsShow, CVSReader.boolParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.SubscribeDescription, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.CancelDescription, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PushSubscribeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PushSubscribeTable.RowData[] Table = null;

		public class RowData
		{

			public uint MsgId;

			public bool IsShow;

			public string SubscribeDescription;

			public string CancelDescription;
		}
	}
}
