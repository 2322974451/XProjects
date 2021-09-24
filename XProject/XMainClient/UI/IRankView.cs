using System;

namespace XMainClient.UI
{

	internal interface IRankView
	{

		void RefreshPage();

		bool IsVisible();

		void RefreshVoice(ulong[] roleids, int[] states);

		void HideVoice();
	}
}
