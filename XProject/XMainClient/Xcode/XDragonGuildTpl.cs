using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildTpl
	{

		public uint id;

		public string title;

		public string desc;

		public uint exp;

		public uint type;

		public SeqListRef<uint> item;

		public int state;

		public uint finishCount;

		public uint doingCount;

		public uint lefttime;
	}
}
