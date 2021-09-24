using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class HistoryMaxStruct
	{

		public void Replace()
		{
			bool flag = !this.IsInit;
			if (flag)
			{
				this.PreLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				this.IsInit = true;
			}
		}

		public uint PreLevel = 0U;

		private bool IsInit = false;
	}
}
