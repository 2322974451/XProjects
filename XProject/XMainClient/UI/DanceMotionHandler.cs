using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DanceMotionHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			this.m_MotionPanel = base.PanelObject.transform.Find("MotionFrame").gameObject;
			this.m_MotionPanelBg = (base.transform.Find("MotionFrame/Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_MotionList = (base.transform.Find("MotionFrame/MotionSV/MotionList").GetComponent("XUIList") as IXUIList);
			GameObject gameObject = this.m_MotionList.gameObject.transform.Find("DanceTpl").gameObject;
			this.m_MotionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_MotionPool.SetupPool(this.m_MotionList.gameObject, gameObject, 3U, false);
			this.m_MotionList.Refresh();
			this.m_ConditionPanel = base.PanelObject.transform.Find("UnlockFrame").gameObject;
			this.m_ConditionPanel.SetActive(false);
			this.m_ConditionList = (base.transform.Find("UnlockFrame/Condition/ScrollView/ConditionList").GetComponent("XUIList") as IXUIList);
			this.m_ConditionPanelBg = (base.PanelObject.transform.Find("UnlockFrame/Bg").GetComponent("XUISprite") as IXUISprite);
			GameObject gameObject2 = this.m_ConditionList.gameObject.transform.Find("tpl").gameObject;
			this.m_ConditionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_ConditionPool.SetupPool(this.m_ConditionList.gameObject, gameObject2, 3U, false);
			this.m_ConditionList.Refresh();
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_MotionPanelBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMotionPanelClicked));
			this.m_ConditionPanelBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnConditionPanelClose));
		}

		protected override void OnShow()
		{
			base.OnShow();
			Vector3 position = this.m_MotionPanel.transform.position;
			position.y = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.GetSelectDanceMotionBtnPos().y;
			this.m_MotionPanel.transform.position = position;
			position = this.m_ConditionPanel.transform.position;
			position.y = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.GetSelectDanceMotionBtnPos().y;
			this.m_ConditionPanel.transform.position = position;
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.ShowUnlockPanel(false, 0U, 0U);
			bool flag = this.m_LastSelect != null;
			if (flag)
			{
				this.m_LastSelect.SetActive(false);
			}
		}

		private void OnMotionPanelClicked(IXUISprite btn)
		{
			base.SetVisible(false);
		}

		private void OnConditionPanelClose(IXUISprite btn)
		{
			this.ShowUnlockPanel(false, 0U, 0U);
		}

		public void RefreshMotionPanel(List<DanceMotionData> listMotionData)
		{
			bool flag = !base.IsVisible() || !this.m_MotionPanel.activeSelf;
			if (!flag)
			{
				this.m_listMotionData = listMotionData;
				this.m_MotionPool.FakeReturnAll();
				for (int i = 0; i < listMotionData.Count; i++)
				{
					DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(listMotionData[i].motionID);
					GameObject gameObject = this.m_MotionPool.FetchGameObject(false);
					gameObject.name = string.Format("DanceBtn{0}", i);
					gameObject.transform.parent = this.m_MotionList.gameObject.transform;
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(danceConfig.HallBtnIcon, danceConfig.IconAtlas, false);
					ixuisprite.MakePixelPerfect();
					GameObject gameObject2 = gameObject.transform.FindChild("Lock").gameObject;
					gameObject2.SetActive(!XDanceDocument.Doc.IsUnlock(listMotionData[i].valid, danceConfig.Condition));
					IXUIButton ixuibutton = gameObject.transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)i);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDanceMotionBtnClicked));
					GameObject gameObject3 = ixuibutton.gameObject.transform.Find("Select").gameObject;
					gameObject3.SetActive(false);
				}
				this.m_MotionPool.ActualReturnAll(false);
				this.m_MotionList.Refresh();
				this.ShowUnlockPanel(false, 0U, 0U);
			}
		}

		private bool OnDanceMotionBtnClicked(IXUIButton btn)
		{
			bool flag = this.m_LastSelect != null;
			if (flag)
			{
				this.m_LastSelect.SetActive(false);
			}
			this.m_LastSelect = btn.gameObject.transform.Find("Select").gameObject;
			this.m_LastSelect.SetActive(true);
			int num = (int)btn.ID;
			bool flag2 = this.m_listMotionData != null && num < this.m_listMotionData.Count;
			if (flag2)
			{
				uint motionID = this.m_listMotionData[num].motionID;
				GameObject gameObject = btn.gameObject.transform.Find("Lock").gameObject;
				bool activeSelf = gameObject.activeSelf;
				if (activeSelf)
				{
					this.ShowUnlockPanel(true, motionID, this.m_listMotionData[num].valid);
				}
				else
				{
					this.ShowUnlockPanel(false, 0U, 0U);
					XDanceDocument.Doc.ReqStartJustDance(motionID);
				}
			}
			return true;
		}

		private void ShowUnlockPanel(bool show, uint motionID = 0U, uint valid = 0U)
		{
			this.m_ConditionPanel.SetActive(show);
			DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(motionID);
			bool flag = show && danceConfig != null;
			if (flag)
			{
				this.m_ConditionPool.FakeReturnAll();
				for (int i = 0; i < danceConfig.Condition.Count; i++)
				{
					GameObject gameObject = this.m_ConditionPool.FetchGameObject(false);
					gameObject.transform.parent = this.m_ConditionList.gameObject.transform;
					IXUILabel ixuilabel = gameObject.transform.FindChild("condition1").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText((i < danceConfig.ConditionDesc.Length) ? danceConfig.ConditionDesc[i] : "?");
					IXUILabel ixuilabel2 = gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText((i < danceConfig.GoText.Length) ? danceConfig.GoText[i] : "?");
					ixuilabel2.ID = (ulong)((long)((i < danceConfig.GoSystemID.Length) ? danceConfig.GoSystemID[i] : 0));
					ixuilabel2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnGoSystemBtnClicked));
					ixuilabel2.SetVisible(!XDanceDocument.Doc.IsUnlock(valid, danceConfig.Condition[i, 0]));
					GameObject gameObject2 = gameObject.transform.FindChild("ok").gameObject;
					gameObject2.SetActive(XDanceDocument.Doc.IsUnlock(valid, danceConfig.Condition[i, 0]));
				}
				this.m_ConditionPool.ActualReturnAll(false);
				this.m_ConditionList.Refresh();
			}
		}

		private void OnGoSystemBtnClicked(IXUILabel label)
		{
			int sys = (int)label.ID;
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpen(sys);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_SYS_NOTOPEN, "fece00");
			}
			else
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem(sys);
			}
		}

		private IXUIList m_MotionList;

		private XUIPool m_MotionPool;

		private IXUISprite m_MotionPanelBg;

		private GameObject m_MotionPanel;

		private GameObject m_ConditionPanel;

		private IXUIList m_ConditionList;

		private XUIPool m_ConditionPool;

		private IXUISprite m_ConditionPanelBg;

		private List<DanceMotionData> m_listMotionData;

		private GameObject m_LastSelect;
	}
}
