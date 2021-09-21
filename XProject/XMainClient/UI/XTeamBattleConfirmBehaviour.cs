using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001861 RID: 6241
	internal class XTeamBattleConfirmBehaviour : DlgBehaviourBase
	{
		// Token: 0x060103FD RID: 66557 RVA: 0x003ED998 File Offset: 0x003EBB98
		private void Awake()
		{
			this.m_OK = (base.transform.FindChild("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Cancel = (base.transform.FindChild("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_DungeonName = (base.transform.FindChild("Bg/DungeonName").GetComponent("XUILabel") as IXUILabel);
			this.m_Progress = (base.transform.FindChild("Bg/Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.m_GoldGroup = base.transform.Find("Bg/RewardHunt").gameObject;
			Transform transform = base.transform.Find("Bg/Members/Tpl");
			this.m_Pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_statLab = (base.transform.FindChild("Bg/Start").GetComponent("XUILabel") as IXUILabel);
			this.m_tipsGo = base.transform.FindChild("LetsMakeFriends").gameObject;
			this.m_CommonTip = (base.transform.FindChild("Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_RiftPanel = base.transform.Find("Bg/RiftBuff").gameObject;
			this.m_RiftBuffs = new GameObject[XTeamBattleConfirmBehaviour.RiftBuffCount];
			for (int i = 0; i < XTeamBattleConfirmBehaviour.RiftBuffCount; i++)
			{
				this.m_RiftBuffs[i] = this.m_RiftPanel.transform.Find("BossBuff" + i).gameObject;
			}
		}

		// Token: 0x040074C7 RID: 29895
		public IXUIButton m_OK = null;

		// Token: 0x040074C8 RID: 29896
		public IXUIButton m_Cancel = null;

		// Token: 0x040074C9 RID: 29897
		public IXUILabel m_DungeonName;

		// Token: 0x040074CA RID: 29898
		public IXUIProgress m_Progress;

		// Token: 0x040074CB RID: 29899
		public XUIPool m_Pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040074CC RID: 29900
		public GameObject m_GoldGroup;

		// Token: 0x040074CD RID: 29901
		public IXUILabel m_statLab;

		// Token: 0x040074CE RID: 29902
		public GameObject m_tipsGo;

		// Token: 0x040074CF RID: 29903
		public IXUILabel m_CommonTip;

		// Token: 0x040074D0 RID: 29904
		public GameObject m_RiftPanel;

		// Token: 0x040074D1 RID: 29905
		public static int RiftBuffCount = 5;

		// Token: 0x040074D2 RID: 29906
		public GameObject[] m_RiftBuffs;
	}
}
