using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EnhanceMasterHandler : DlgHandlerBase
	{

		private XEnhanceDocument m_doc
		{
			get
			{
				return XEnhanceDocument.Doc;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/EnhanceMaster";
			}
		}

		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.FindChild("AttriTpl");
			this.m_AttrPool.SetupPool(base.PanelObject, transform.gameObject, 2U, false);
			this.m_CurAttrListGo = base.PanelObject.transform.FindChild("CurAttrList").gameObject;
			this.m_NextStageAttrListGo = base.PanelObject.transform.FindChild("NextStageAttrList").gameObject;
			this.m_NoTipsGo = base.PanelObject.transform.FindChild("NoTips").gameObject;
			this.m_MaxTipsGo = base.PanelObject.transform.FindChild("MaxTips").gameObject;
			this.m_HistoryMaxLevel = (base.PanelObject.transform.FindChild("HistoryLevel/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_NextStageLevel = (base.PanelObject.transform.FindChild("NextStage/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_effectTipsLab = (base.PanelObject.transform.FindChild("EffectTips").GetComponent("XUILabel") as IXUILabel);
			this.m_closedSpr = (base.PanelObject.transform.FindChild("Bg/Box").GetComponent("XUISprite") as IXUISprite);
			this.m_doc.enhanceMasterView = this;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClose));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_AttrPool.ReturnAll(false);
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void RefreshView()
		{
			this.FillContent();
		}

		private void FillContent()
		{
			this.m_HistoryMaxLevel.SetText(string.Format("{0}{1}", this.m_doc.HistoryMaxLevel, XStringDefineProxy.GetString("LevelName")));
			this.m_NextStageLevel.SetText("");
			this.m_effectTipsLab.SetText(XEquipDocument.GetTips(XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID, this.m_doc.HistoryMaxLevel));
			this.m_AttrPool.ReturnAll(false);
			bool flag = this.m_doc.HistoryMaxLevel == 0U;
			if (flag)
			{
				this.m_NoTipsGo.SetActive(true);
			}
			else
			{
				this.m_NoTipsGo.SetActive(false);
				EnhanceMaster.RowData curStageEnhanceMasterRowData = this.m_doc.GetCurStageEnhanceMasterRowData(this.m_doc.HistoryMaxLevel);
				bool flag2 = curStageEnhanceMasterRowData != null;
				if (flag2)
				{
					for (int i = 0; i < curStageEnhanceMasterRowData.Attribute.Count; i++)
					{
						GameObject gameObject = this.m_AttrPool.FetchGameObject(false);
						gameObject.name = i.ToString();
						gameObject.transform.parent = this.m_CurAttrListGo.transform;
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)i * this.m_gap), 0f);
						this.FillAttrItem(gameObject, curStageEnhanceMasterRowData.Attribute[i, 0], curStageEnhanceMasterRowData.Attribute[i, 1]);
					}
				}
			}
			bool flag3 = this.m_doc.HistoryMaxLevel >= this.m_doc.TheMasterMaxLevel;
			if (flag3)
			{
				this.m_MaxTipsGo.SetActive(true);
			}
			else
			{
				this.m_MaxTipsGo.SetActive(false);
				EnhanceMaster.RowData nextStageEnhanceMasterRowData = this.m_doc.GetNextStageEnhanceMasterRowData(this.m_doc.HistoryMaxLevel);
				bool flag4 = nextStageEnhanceMasterRowData != null;
				if (flag4)
				{
					for (int j = 0; j < nextStageEnhanceMasterRowData.Attribute.Count; j++)
					{
						GameObject gameObject = this.m_AttrPool.FetchGameObject(false);
						gameObject.name = j.ToString();
						gameObject.transform.parent = this.m_NextStageAttrListGo.transform;
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)j * this.m_gap), 0f);
						this.FillAttrItem(gameObject, nextStageEnhanceMasterRowData.Attribute[j, 0], nextStageEnhanceMasterRowData.Attribute[j, 1]);
					}
					this.m_NextStageLevel.SetText(string.Format("{0}{1}", nextStageEnhanceMasterRowData.TotalEnhanceLevel, XStringDefineProxy.GetString("LevelName")));
				}
			}
		}

		private void FillAttrItem(GameObject go, uint id, uint value)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString((XAttributeDefine)id));
			ixuilabel = (go.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(string.Format("+{0}", value));
		}

		private void OnClickClose(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		private XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel m_HistoryMaxLevel;

		private IXUILabel m_NextStageLevel;

		private IXUILabel m_effectTipsLab;

		private IXUISprite m_closedSpr;

		private GameObject m_CurAttrListGo;

		private GameObject m_NextStageAttrListGo;

		private GameObject m_NoTipsGo;

		private GameObject m_MaxTipsGo;

		private readonly int m_gap = 30;
	}
}
