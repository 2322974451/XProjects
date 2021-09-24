using System;

namespace XMainClient.UI
{

	public class MyBattleKillInfo
	{

		public void SetInfo(int _contiKillCount, bool _isRevenge = false)
		{
			this.contiKillCount = _contiKillCount;
			this.isRevenge = _isRevenge;
		}

		public int contiKillCount;

		public bool isRevenge;
	}
}
