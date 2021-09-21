using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001856 RID: 6230
	internal class SpectateSceneBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010330 RID: 66352 RVA: 0x003E5124 File Offset: 0x003E3324
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

		// Token: 0x0400740E RID: 29710
		public Transform m_canvas;

		// Token: 0x0400740F RID: 29711
		public GameObject m_avatarGO = null;

		// Token: 0x04007410 RID: 29712
		public IXUILabel m_fps = null;

		// Token: 0x04007411 RID: 29713
		public IXUIButton m_pause = null;

		// Token: 0x04007412 RID: 29714
		public IXUISprite m_sprwifi;

		// Token: 0x04007413 RID: 29715
		public IXUISlider m_sliderBattery;

		// Token: 0x04007414 RID: 29716
		public IXUILabel m_lblTime;

		// Token: 0x04007415 RID: 29717
		public IXUILabel m_lblFree;

		// Token: 0x04007416 RID: 29718
		public BattleTargetHandler m_BattleTargetHandler;

		// Token: 0x04007417 RID: 29719
		public GameObject m_NoticeFrame = null;

		// Token: 0x04007418 RID: 29720
		public IXUILabel m_Notice = null;

		// Token: 0x04007419 RID: 29721
		public Vector3 m_NoticePos;

		// Token: 0x0400741A RID: 29722
		public IXUILabel m_LeftTime = null;

		// Token: 0x0400741B RID: 29723
		public XSpectateTeamMonitorHandler m_SpectateTeamMonitor;

		// Token: 0x0400741C RID: 29724
		public SpectateHandler m_SpectateHandler;

		// Token: 0x0400741D RID: 29725
		public XBattleEnemyInfoHandler m_EnemyInfoHandler;

		// Token: 0x0400741E RID: 29726
		public BattleIndicateHandler m_IndicateHandler;

		// Token: 0x0400741F RID: 29727
		public IXUILabel m_WarTime;

		// Token: 0x04007420 RID: 29728
		public IXUILabel m_SceneName;

		// Token: 0x04007421 RID: 29729
		public Transform m_CountDownFrame;

		// Token: 0x04007422 RID: 29730
		public Transform m_CountDownBeginFrame;

		// Token: 0x04007423 RID: 29731
		public Transform m_CountDownTimeFrame;

		// Token: 0x04007424 RID: 29732
		public IXUIProgress m_StrengthPresevedBar;

		// Token: 0x04007425 RID: 29733
		public Transform m_SightSelect;

		// Token: 0x04007426 RID: 29734
		public IXUISprite m_SightPic;

		// Token: 0x04007427 RID: 29735
		public IXUISprite m_SelectPic;

		// Token: 0x04007428 RID: 29736
		public IXUIButton m_Sight;

		// Token: 0x04007429 RID: 29737
		public IXUIButton m_3DFree;

		// Token: 0x0400742A RID: 29738
		public IXUIButton m_3D;

		// Token: 0x0400742B RID: 29739
		public IXUIButton m_25D;

		// Token: 0x0400742C RID: 29740
		public IXUIButton m_barrageOpen;

		// Token: 0x0400742D RID: 29741
		public IXUIButton m_barrageClose;

		// Token: 0x0400742E RID: 29742
		public IXUIButton m_btnShare;
	}
}
