using System;

namespace XUtliPoolLib
{

	public class PushSetting : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PushSetting.RowData rowData = new PushSetting.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ConfigName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.TimeOrSystem, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Time, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.WeekDay, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ConfigKey, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PushSetting.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PushSetting.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public string ConfigName;

			public uint TimeOrSystem;

			public string Time;

			public string WeekDay;

			public string ConfigKey;
		}
	}
}
