using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CF6 RID: 3318
	internal class XLevelSealView : DlgHandlerBase
	{
		// Token: 0x1700329D RID: 12957
		// (get) Token: 0x0600B97F RID: 47487 RVA: 0x0025B054 File Offset: 0x00259254
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/LevelSeal";
			}
		}

		// Token: 0x0600B980 RID: 47488 RVA: 0x0025B06C File Offset: 0x0025926C
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

		// Token: 0x0600B981 RID: 47489 RVA: 0x0025B190 File Offset: 0x00259390
		public override void RegisterEvent()
		{
			this.m_NextSealBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnNextSealBtnClick));
		}

		// Token: 0x0600B982 RID: 47490 RVA: 0x0025B1AB File Offset: 0x002593AB
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowNowSeal();
			this.ShowNewInfo();
			this.doc.ReqGetLevelSealInfo();
		}

		// Token: 0x0600B983 RID: 47491 RVA: 0x0025B1CF File Offset: 0x002593CF
		protected override void OnHide()
		{
			this.m_NextSealWindow.SetActive(false);
			this.m_NowSealTex.SetTexturePath("");
			this._CDCounter = null;
			base.OnHide();
		}

		// Token: 0x0600B984 RID: 47492 RVA: 0x0025B1FE File Offset: 0x002593FE
		public override void OnUnload()
		{
			this._CDCounter = null;
			this.doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600B985 RID: 47493 RVA: 0x0025B21C File Offset: 0x0025941C
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.isCountdown && this._CDCounter != null;
			if (flag)
			{
				this._CDCounter.Update();
			}
		}

		// Token: 0x0600B986 RID: 47494 RVA: 0x0025B258 File Offset: 0x00259458
		private bool OnNextSealGoBattleClicked(IXUIButton sp)
		{
			DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Activity, 0UL);
			return true;
		}

		// Token: 0x0600B987 RID: 47495 RVA: 0x0025B287 File Offset: 0x00259487
		private void ShowNextLevelSeal()
		{
			this.doc.ShowNextLevelSeal(false, this.m_NextSealWindow.transform.position);
		}

		// Token: 0x0600B988 RID: 47496 RVA: 0x0025B2A8 File Offset: 0x002594A8
		private bool OnNextSealBtnClick(IXUIButton btn)
		{
			this.ShowNextLevelSeal();
			return true;
		}

		// Token: 0x0600B989 RID: 47497 RVA: 0x0025B2C4 File Offset: 0x002594C4
		public void ShowNowSeal()
		{
			this.m_Condition.SetText(this.doc.GetConditionInfo());
			this.m_NowSeal.SetText(this.doc.GetNowSealTitleInfo());
			this.m_Description.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SEAL_DESCRIPTION")));
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.ShowRemoveSealLeftTime(this.m_LeftTime, ref this._CDCounter, ref this.isCountdown);
		}

		// Token: 0x0600B98A RID: 47498 RVA: 0x0025B340 File Offset: 0x00259540
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

		// Token: 0x04004A24 RID: 18980
		private IXUILabel m_NowSeal;

		// Token: 0x04004A25 RID: 18981
		private IXUILabel m_Condition;

		// Token: 0x04004A26 RID: 18982
		private IXUILabel m_LeftTime;

		// Token: 0x04004A27 RID: 18983
		private IXUILabel m_Description;

		// Token: 0x04004A28 RID: 18984
		private IXUITexture m_NowSealTex;

		// Token: 0x04004A29 RID: 18985
		private GameObject m_NextSealWindow;

		// Token: 0x04004A2A RID: 18986
		private IXUIButton m_NextSealBtn;

		// Token: 0x04004A2B RID: 18987
		private XUIPool m_NewFunctionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004A2C RID: 18988
		private XLevelSealDocument doc = null;

		// Token: 0x04004A2D RID: 18989
		private XLeftTimeCounter _CDCounter = null;

		// Token: 0x04004A2E RID: 18990
		private bool isCountdown = false;
	}
}
