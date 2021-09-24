using System;

namespace XMainClient.UI
{

	internal interface IWorldBossBattleView
	{

		void SetLeftTime(uint time);

		void RefreshEncourage();

		bool IsVisible();
	}
}
