using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardStageFailHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardStageFailFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this._retry_return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this._retry_retry_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRetryClicked));
		}

		private bool OnReturnButtonClicked(IXUIButton button)
		{
			XSingleton<XLevelFinishMgr>.singleton.SendLevelFailData();
			this._doc.SendLeaveScene();
			return true;
		}

		private bool OnRetryClicked(IXUIButton button)
		{
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = XSingleton<XScene>.singleton.SceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			return true;
		}

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

		private XLevelRewardDocument _doc = null;

		private IXUIButton _return_button;

		private IXUILabel _fail_tip;

		private GameObject _cancel;

		private GameObject _retry;

		private IXUIButton _retry_return_button;

		private IXUIButton _retry_retry_button;

		private IXUILabel _retry_tip;
	}
}
