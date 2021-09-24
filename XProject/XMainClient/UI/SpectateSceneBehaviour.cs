using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class SpectateSceneBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_canvas = base.transform.FindChild("_canvas");
			Transform transform = base.transform.FindChild("_canvas/fps");
			bool flag = null != transform;
			if (flag)
			{
				this.m_fps = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			Transform transform2 = base.transform.FindChild("_canvas/Spectate/Quit");
			this.m_pause = (transform2.GetComponent("XUIButton") as IXUIButton);
			this.m_sprwifi = (base.transform.FindChild("_canvas/PING/SysWifi").GetComponent("XUISprite") as IXUISprite);
			this.m_lblTime = (base.transform.FindChild("_canvas/PING/TIME").GetComponent("XUILabel") as IXUILabel);
			this.m_sliderBattery = (base.transform.FindChild("_canvas/PING/Battery").GetComponent("XUISlider") as IXUISlider);
			this.m_lblFree = (base.transform.FindChild("_canvas/PING/T2").GetComponent("XUILabel") as IXUILabel);
			this.m_NoticeFrame = base.transform.FindChild("_canvas/NoticeFrame").gameObject;
			Transform transform3 = base.transform.FindChild("_canvas/NoticeFrame/Notice");
			this.m_NoticePos = this.m_NoticeFrame.transform.localPosition;
			this.m_Notice = (transform3.GetComponent("XUILabel") as IXUILabel);
			this.m_NoticeFrame.transform.localPosition = XGameUI.Far_Far_Away;
			this.m_LeftTime = (base.transform.FindChild("_canvas/LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime.SetVisible(false);
			this.m_WarTime = (base.transform.Find("_canvas/WarTime").GetComponent("XUILabel") as IXUILabel);
			this.m_WarTime.SetVisible(false);
			this.m_SceneName = (base.transform.Find("_canvas/Indicate/Bg/Name").GetComponent("XUILabel") as IXUILabel);
			DlgHandlerBase.EnsureCreate<XSpectateTeamMonitorHandler>(ref this.m_SpectateTeamMonitor, base.transform.FindChild("_canvas/TeamFrame").gameObject, null, true);
			DlgHandlerBase.EnsureCreate<BattleIndicateHandler>(ref this.m_IndicateHandler, base.transform.Find("_canvas/Indicate").gameObject, null, false);
			DlgHandlerBase.EnsureCreate<SpectateHandler>(ref this.m_SpectateHandler, base.transform.FindChild("_canvas/Spectate").gameObject, null, true);
			DlgHandlerBase.EnsureCreate<XBattleEnemyInfoHandler>(ref this.m_EnemyInfoHandler, base.transform.FindChild("_canvas/EnemyInfoFrame").gameObject, null, true);
			DlgHandlerBase.EnsureCreate<BattleTargetHandler>(ref this.m_BattleTargetHandler, base.transform.FindChild("_canvas/BattleTaget").gameObject, null, true);
			this.m_CountDownFrame = base.transform.FindChild("_canvas/CountDownFrame");
			this.m_CountDownBeginFrame = this.m_CountDownFrame.FindChild("Begin");
			this.m_CountDownTimeFrame = this.m_CountDownFrame.FindChild("Time");
			this.m_CountDownFrame.gameObject.SetActive(false);
			this.m_StrengthPresevedBar = (base.transform.Find("_canvas/ChargeBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_SightSelect = base.transform.FindChild("_canvas/Spectate/3D25D/Select");
			this.m_3DFree = (base.transform.FindChild("_canvas/Spectate/3D25D/Select/3DFree").GetComponent("XUIButton") as IXUIButton);
			this.m_3D = (base.transform.FindChild("_canvas/Spectate/3D25D/Select/3D").GetComponent("XUIButton") as IXUIButton);
			this.m_25D = (base.transform.FindChild("_canvas/Spectate/3D25D/Select/25D").GetComponent("XUIButton") as IXUIButton);
			this.m_Sight = (base.transform.FindChild("_canvas/Spectate/3D25D/Sight").GetComponent("XUIButton") as IXUIButton);
			this.m_SightPic = (base.transform.FindChild("_canvas/Spectate/3D25D/Sight/Content").GetComponent("XUISprite") as IXUISprite);
			this.m_SelectPic = (base.transform.FindChild("_canvas/Spectate/3D25D/Select/Content").GetComponent("XUISprite") as IXUISprite);
			this.m_barrageOpen = (base.transform.FindChild("_canvas/Spectate/Barrage/open").GetComponent("XUIButton") as IXUIButton);
			this.m_barrageClose = (base.transform.FindChild("_canvas/Spectate/Barrage/close").GetComponent("XUIButton") as IXUIButton);
			this.m_btnShare = (base.transform.FindChild("_canvas/Spectate/Share").GetComponent("XUIButton") as IXUIButton);
		}

		public Transform m_canvas;

		public GameObject m_avatarGO = null;

		public IXUILabel m_fps = null;

		public IXUIButton m_pause = null;

		public IXUISprite m_sprwifi;

		public IXUISlider m_sliderBattery;

		public IXUILabel m_lblTime;

		public IXUILabel m_lblFree;

		public BattleTargetHandler m_BattleTargetHandler;

		public GameObject m_NoticeFrame = null;

		public IXUILabel m_Notice = null;

		public Vector3 m_NoticePos;

		public IXUILabel m_LeftTime = null;

		public XSpectateTeamMonitorHandler m_SpectateTeamMonitor;

		public SpectateHandler m_SpectateHandler;

		public XBattleEnemyInfoHandler m_EnemyInfoHandler;

		public BattleIndicateHandler m_IndicateHandler;

		public IXUILabel m_WarTime;

		public IXUILabel m_SceneName;

		public Transform m_CountDownFrame;

		public Transform m_CountDownBeginFrame;

		public Transform m_CountDownTimeFrame;

		public IXUIProgress m_StrengthPresevedBar;

		public Transform m_SightSelect;

		public IXUISprite m_SightPic;

		public IXUISprite m_SelectPic;

		public IXUIButton m_Sight;

		public IXUIButton m_3DFree;

		public IXUIButton m_3D;

		public IXUIButton m_25D;

		public IXUIButton m_barrageOpen;

		public IXUIButton m_barrageClose;

		public IXUIButton m_btnShare;
	}
}
