using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelSealView : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/LevelSeal";
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			this.doc.View = this;
			this.m_NowSeal = (base.transform.Find("Bg/NowSeal/p/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_Condition = (base.transform.Find("Bg/NowSeal/p/Condition").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTime = (base.transform.Find("Bg/NowSeal/p/LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_NowSealTex = (base.transform.Find("Bg/NowSeal/Tex/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_Description = (base.transform.Find("Bg/NowSeal/p/Description").GetComponent("XUILabel") as IXUILabel);
			this.m_NextSealBtn = (base.transform.Find("Bg/NowSeal/NextSealBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_NextSealWindow = base.transform.Find("Bg/NextSeal").gameObject;
		}

		public override void RegisterEvent()
		{
			this.m_NextSealBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnNextSealBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowNowSeal();
			this.ShowNewInfo();
			this.doc.ReqGetLevelSealInfo();
		}

		protected override void OnHide()
		{
			this.m_NextSealWindow.SetActive(false);
			this.m_NowSealTex.SetTexturePath("");
			this._CDCounter = null;
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._CDCounter = null;
			this.doc.View = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.isCountdown && this._CDCounter != null;
			if (flag)
			{
				this._CDCounter.Update();
			}
		}

		private bool OnNextSealGoBattleClicked(IXUIButton sp)
		{
			DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Activity, 0UL);
			return true;
		}

		private void ShowNextLevelSeal()
		{
			this.doc.ShowNextLevelSeal(false, this.m_NextSealWindow.transform.position);
		}

		private bool OnNextSealBtnClick(IXUIButton btn)
		{
			this.ShowNextLevelSeal();
			return true;
		}

		public void ShowNowSeal()
		{
			this.m_Condition.SetText(this.doc.GetConditionInfo());
			this.m_NowSeal.SetText(this.doc.GetNowSealTitleInfo());
			this.m_Description.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SEAL_DESCRIPTION")));
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.ShowRemoveSealLeftTime(this.m_LeftTime, ref this._CDCounter, ref this.isCountdown);
		}

		public void ShowNewInfo()
		{
			uint removeSealType = this.doc.GetRemoveSealType(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(removeSealType);
			bool flag = !string.IsNullOrEmpty(levelSealType.NowSealImage);
			if (flag)
			{
				this.m_NowSealTex.SetTexturePath(levelSealType.NowSealImage);
			}
		}

		private IXUILabel m_NowSeal;

		private IXUILabel m_Condition;

		private IXUILabel m_LeftTime;

		private IXUILabel m_Description;

		private IXUITexture m_NowSealTex;

		private GameObject m_NextSealWindow;

		private IXUIButton m_NextSealBtn;

		private XUIPool m_NewFunctionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XLevelSealDocument doc = null;

		private XLeftTimeCounter _CDCounter = null;

		private bool isCountdown = false;
	}
}
