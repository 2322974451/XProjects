using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	public class XBaseRankInfo
	{

		public virtual void ProcessData(RankData data)
		{
		}

		public static string GetUnderLineName(string s)
		{
			return XSingleton<XCommon>.singleton.StringCombine("[u]", s, "[-]");
		}

		public virtual string GetValue()
		{
			return this.value.ToString();
		}

		public uint rank;

		public ulong id;

		public string name;

		public string formatname;

		public ulong value;

		public uint guildicon;

		public string guildname;

		public StartUpType startType;

		public List<uint> setid = new List<uint>();
	}
}
