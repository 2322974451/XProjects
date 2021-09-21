using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA2 RID: 2978
	internal class LevelRewardProfTrialsHandler : DlgHandlerBase
	{
		// Token: 0x17003047 RID: 12359
		// (get) Token: 0x0600AAE4 RID: 43748 RVA: 0x001EEA5C File Offset: 0x001ECC5C
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardProfTrialsFrame";
			}
		}

		// Token: 0x0600AAE5 RID: 43749 RVA: 0x001EEA74 File Offset: 0x001ECC74
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.m_AgainBtn = (base.PanelObject.transform.Find("Bg/Again").GetComponent("XUIButton") as IXUIButton);
			this.m_ContinueBtn = (base.PanelObject.transform.Find("Bg/Continue").GetComponent("XUIButton") as IXUIButton);
			XProfessionChangeDocument specificDocument = XDocuments.GetSpecificDocument<XProfessionChangeDocument>(XProfessionChangeDocument.uuID);
			bool flag = XSingleton<XScene>.singleton.SceneID == specificDocument.SceneID;
			GameObject gameObject = base.PanelObject.transform.Find("Bg/FX/UI_LevelRewardProfTrialsFrame_Clip01/Clip_03_shiliantongguo").gameObject;
			GameObject gameObject2 = base.PanelObject.transform.Find("Bg/FX/UI_LevelRewardProfTrialsFrame_Clip01/Clip_03_tiyanwancheng").gameObject;
			gameObject.SetActive(!flag);
			gameObject2.SetActive(flag);
		}

		// Token: 0x0600AAE6 RID: 43750 RVA: 0x001EEB54 File Offset: 0x001ECD54
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_AgainBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAgainBtnClick));
			this.m_ContinueBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnContinueBtnClick));
		}

		// Token: 0x0600AAE7 RID: 43751 RVA: 0x001EEB90 File Offset: 0x001ECD90
		private bool OnContinueBtnClick(IXUIButton btn)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			return true;
		}

		// Token: 0x0600AAE8 RID: 43752 RVA: 0x001EEBB0 File Offset: 0x001ECDB0
		private bool OnAgainBtnClick(IXUIButton btn)
		{
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = XSingleton<XScene>.singleton.SceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			return true;
		}

		// Token: 0x04003FBA RID: 16314
		private XLevelRewardDocument _doc = null;

		// Token: 0x04003FBB RID: 16315
		public IXUIButton m_ContinueBtn;

		// Token: 0x04003FBC RID: 16316
		public IXUIButton m_AgainBtn;
	}
}
