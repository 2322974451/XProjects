using System;

namespace XMainClient.UI
{

	public interface IWorldBossBattleSource
	{

		void ReqEncourage();

		void ReqEncourageTwo();

		void ReqBattleInfo();

		uint EncourageCount { get; }

		uint GetEncourageCount(int index);
	}
}
