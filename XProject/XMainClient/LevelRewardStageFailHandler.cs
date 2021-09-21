using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BAA RID: 2986
	internal class LevelRewardStageFailHandler : DlgHandlerBase
	{
		// Token: 0x1700304F RID: 12367
		// (get) Token: 0x0600AB40 RID: 43840 RVA: 0x001F2DF8 File Offset: 0x001F0FF8
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardStageFailFrame";
			}
		}

		// Token: 0x0600AB41 RID: 43841 RVA: 0x001F2E0F File Offset: 0x001F100F
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		// Token: 0x0600AB42 RID: 43842 RVA: 0x001F2E30 File Offset: 0x001F1030
		public void InitUI()
		{
			this._return_button = (base.PanelObject.transform.Find("Cancel/Cancel").GetComponent("XUIButton") as IXUIButton);
			this._fail_tip = (base.PanelObject.transform.Find("Cancel/FailedText").GetComponent("XUILabel") as IXUILabel);
			this._retry_return_button = (base.PanelObject.transform.Find("Retry/Cancel").GetComponent("XUIButton") as IXUIButton);
			this._retry_retry_button = (base.PanelObject.transform.Find("Retry/retry").GetComponent("XUIButton") as IXUIButton);
			this._retry_tip = (base.PanelObject.transform.Find("Retry/FailedText").GetComponent("XUILabel") as IXUILabel);
			this._cancel = base.PanelObject.transform.Find("Cancel").gameObject;
			this._retry = base.PanelObject.transform.Find("Retry").gameObject;
		}

		// Token: 0x0600AB43 RID: 43843 RVA: 0x001F2F50 File Offset: 0x001F1150
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this._retry_return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this._retry_retry_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRetryClicked));
		}

		// Token: 0x0600AB44 RID: 43844 RVA: 0x001F2FB0 File Offset: 0x001F11B0
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			XSingleton<XLevelFinishMgr>.singleton.SendLevelFailData();
			this._doc.SendLeaveScene();
			return true;
		}

		// Token: 0x0600AB45 RID: 43845 RVA: 0x001F2FDC File Offset: 0x001F11DC
		private bool OnRetryClicked(IXUIButton button)
		{
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = XSingleton<XScene>.singleton.SceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			return true;
		}

		// Token: 0x0600AB46 RID: 43846 RVA: 0x001F3018 File Offset: 0x001F1218
		protected override void OnShow()
		{
			base.OnShow();
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_TOWER;
			if (flag)
			{
				this._cancel.SetActive(false);
				this._retry.SetActive(true);
				this._retry_tip.SetText(sceneData.FailText);
			}
			else
			{
				this._fail_tip.SetText(sceneData.FailText);
				this._cancel.SetActive(true);
				this._retry.SetActive(false);
			}
		}

		// Token: 0x04004007 RID: 16391
		private XLevelRewardDocument _doc = null;

		// Token: 0x04004008 RID: 16392
		private IXUIButton _return_button;

		// Token: 0x04004009 RID: 16393
		private IXUILabel _fail_tip;

		// Token: 0x0400400A RID: 16394
		private GameObject _cancel;

		// Token: 0x0400400B RID: 16395
		private GameObject _retry;

		// Token: 0x0400400C RID: 16396
		private IXUIButton _retry_return_button;

		// Token: 0x0400400D RID: 16397
		private IXUIButton _retry_retry_button;

		// Token: 0x0400400E RID: 16398
		private IXUILabel _retry_tip;
	}
}
