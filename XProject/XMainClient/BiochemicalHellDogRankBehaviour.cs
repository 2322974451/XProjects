using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C74 RID: 3188
	internal class BiochemicalHellDogRankBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B447 RID: 46151 RVA: 0x00232FA0 File Offset: 0x002311A0
		private void Awake()
		{
			this._RankScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._RankWrapContent = (base.transform.Find("Panel/FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this._tipsGo = base.transform.FindChild("Tips").gameObject;
		}

		// Token: 0x040045EC RID: 17900
		public IXUIButton _Close;

		// Token: 0x040045ED RID: 17901
		public IXUIScrollView _RankScrollView;

		// Token: 0x040045EE RID: 17902
		public IXUIWrapContent _RankWrapContent;

		// Token: 0x040045EF RID: 17903
		public GameObject _tipsGo;
	}
}
