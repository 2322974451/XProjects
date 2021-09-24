using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardProfTrialsHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardProfTrialsFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_AgainBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAgainBtnClick));
			this.m_ContinueBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnContinueBtnClick));
		}

		private bool OnContinueBtnClick(IXUIButton btn)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			return true;
		}

		private bool OnAgainBtnClick(IXUIButton btn)
		{
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = XSingleton<XScene>.singleton.SceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			return true;
		}

		private XLevelRewardDocument _doc = null;

		public IXUIButton m_ContinueBtn;

		public IXUIButton m_AgainBtn;
	}
}
