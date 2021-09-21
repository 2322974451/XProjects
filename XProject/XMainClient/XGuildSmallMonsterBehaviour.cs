using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E3D RID: 3645
	internal class XGuildSmallMonsterBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C3DC RID: 50140 RVA: 0x002A9834 File Offset: 0x002A7A34
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

		// Token: 0x040054E3 RID: 21731
		public IXUIButton m_Close;

		// Token: 0x040054E4 RID: 21732
		public Transform m_DetailFrame;

		// Token: 0x040054E5 RID: 21733
		public Transform m_RankFrame;

		// Token: 0x040054E6 RID: 21734
		public XUIPool m_DropItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040054E7 RID: 21735
		public IXUILabel m_CurrentLevel;

		// Token: 0x040054E8 RID: 21736
		public IXUIButton m_BeginGame;

		// Token: 0x040054E9 RID: 21737
		public IXUILabel m_RemainTime;

		// Token: 0x040054EA RID: 21738
		public IXUILabel m_lblWin;

		// Token: 0x040054EB RID: 21739
		public IXUILabel m_lblThisday;

		// Token: 0x040054EC RID: 21740
		public IXUILabel m_lblNextday;

		// Token: 0x040054ED RID: 21741
		public IXUIButton m_btnrwdRank;

		// Token: 0x040054EE RID: 21742
		public IXUIButton m_btnHelp;

		// Token: 0x040054EF RID: 21743
		public IXUILabel m_lblEmpt;

		// Token: 0x040054F0 RID: 21744
		public IXUILabel m_lblType;

		// Token: 0x040054F1 RID: 21745
		public XUIPool m_KillRankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
