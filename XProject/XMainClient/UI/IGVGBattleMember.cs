using System;
using UnityEngine;

namespace XMainClient.UI
{

	internal interface IGVGBattleMember
	{

		void Setup(GameObject sv, int index);

		void ReFreshData(GVGBattleInfo battleInfo);

		void SetActive(bool active);

		bool IsActive();

		void OnUpdate();

		void Recycle();
	}
}
