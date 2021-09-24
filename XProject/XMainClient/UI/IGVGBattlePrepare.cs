using System;
using UILib;

namespace XMainClient.UI
{

	internal interface IGVGBattlePrepare : IXUIDlg
	{

		bool IsLoaded();

		void OnEnterSceneFinally();

		void RefreshSection();

		void ReFreshGroup();

		void RefreshInspire();

		void RefreahCountTime(float time);

		void SetResurgence(int leftTime);

		void UpdateDownUp();
	}
}
