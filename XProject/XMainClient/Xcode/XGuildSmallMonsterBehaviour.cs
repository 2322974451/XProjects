using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSmallMonsterBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_DetailFrame = base.transform.FindChild("Bg/DetailFrame");
			this.m_RankFrame = base.transform.FindChild("Bg/RankFrame");
			Transform transform = this.m_DetailFrame.FindChild("DropFrame/Item");
			this.m_DropItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_CurrentLevel = (this.m_DetailFrame.FindChild("CurrentLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_BeginGame = (this.m_DetailFrame.FindChild("BeginGame").GetComponent("XUIButton") as IXUIButton);
			this.m_RemainTime = (this.m_DetailFrame.FindChild("Pic/RemainTime").GetComponent("XUILabel") as IXUILabel);
			this.m_lblWin = (this.m_DetailFrame.FindChild("WinCondition").GetComponent("XUILabel") as IXUILabel);
			this.m_lblThisday = (this.m_DetailFrame.FindChild("Pic/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_lblNextday = (this.m_DetailFrame.FindChild("Tomorrow").GetComponent("XUILabel") as IXUILabel);
			this.m_btnrwdRank = (this.m_DetailFrame.FindChild("RwdRank").GetComponent("XUIButton") as IXUIButton);
			this.m_btnHelp = (this.m_DetailFrame.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			transform = this.m_RankFrame.FindChild("Bg/Panel/MemberTpl");
			this.m_KillRankPool.SetupPool(transform.parent.gameObject, transform.gameObject, 20U, false);
			this.m_lblEmpt = (this.m_RankFrame.FindChild("Bg/Empty").GetComponent("XUILabel") as IXUILabel);
			this.m_lblType = (this.m_RankFrame.FindChild("Bg/title/title2").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Close;

		public Transform m_DetailFrame;

		public Transform m_RankFrame;

		public XUIPool m_DropItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_CurrentLevel;

		public IXUIButton m_BeginGame;

		public IXUILabel m_RemainTime;

		public IXUILabel m_lblWin;

		public IXUILabel m_lblThisday;

		public IXUILabel m_lblNextday;

		public IXUIButton m_btnrwdRank;

		public IXUIButton m_btnHelp;

		public IXUILabel m_lblEmpt;

		public IXUILabel m_lblType;

		public XUIPool m_KillRankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
