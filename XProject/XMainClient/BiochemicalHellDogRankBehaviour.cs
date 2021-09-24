using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class BiochemicalHellDogRankBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this._RankScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._RankWrapContent = (base.transform.Find("Panel/FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this._tipsGo = base.transform.FindChild("Tips").gameObject;
		}

		public IXUIButton _Close;

		public IXUIScrollView _RankScrollView;

		public IXUIWrapContent _RankWrapContent;

		public GameObject _tipsGo;
	}
}
