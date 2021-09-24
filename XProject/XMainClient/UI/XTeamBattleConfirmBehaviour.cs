using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamBattleConfirmBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_OK = null;

		public IXUIButton m_Cancel = null;

		public IXUILabel m_DungeonName;

		public IXUIProgress m_Progress;

		public XUIPool m_Pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_GoldGroup;

		public IXUILabel m_statLab;

		public GameObject m_tipsGo;

		public IXUILabel m_CommonTip;

		public GameObject m_RiftPanel;

		public static int RiftBuffCount = 5;

		public GameObject[] m_RiftBuffs;
	}
}
