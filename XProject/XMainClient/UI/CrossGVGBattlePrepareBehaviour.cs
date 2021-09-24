using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class CrossGVGBattlePrepareBehaviour : GVGBattlePrepareBehaviour
	{

		protected override void Awake()
		{
			base.Awake();
			this.mRankFrame = base.transform.Find("RankFrame").gameObject;
			this.mRevive = (base.transform.Find("LeftTime/Revive").GetComponent("XUIButton") as IXUIButton);
			this.mReviveSymbol = (base.transform.Find("LeftTime/Revive/Label").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
		}

		public GameObject mRankFrame;

		public IGVGBattleMember mRankPanel;

		public IXUIButton mRevive;

		public IXUILabelSymbol mReviveSymbol;
	}
}
