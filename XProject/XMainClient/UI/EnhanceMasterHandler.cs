using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017BF RID: 6079
	internal class EnhanceMasterHandler : DlgHandlerBase
	{
		// Token: 0x17003888 RID: 14472
		// (get) Token: 0x0600FBB9 RID: 64441 RVA: 0x003A8270 File Offset: 0x003A6470
		private XEnhanceDocument m_doc
		{
			get
			{
				return XEnhanceDocument.Doc;
			}
		}

		// Token: 0x17003889 RID: 14473
		// (get) Token: 0x0600FBBA RID: 64442 RVA: 0x003A8288 File Offset: 0x003A6488
		protected override string FileName
		{
			get
			{
				return "ItemNew/EnhanceMaster";
			}
		}

		// Token: 0x0600FBBB RID: 64443 RVA: 0x003A82A0 File Offset: 0x003A64A0
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

		// Token: 0x0600FBBC RID: 64444 RVA: 0x003A8419 File Offset: 0x003A6619
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClose));
		}

		// Token: 0x0600FBBD RID: 64445 RVA: 0x003A843B File Offset: 0x003A663B
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FBBE RID: 64446 RVA: 0x003A844C File Offset: 0x003A664C
		protected override void OnHide()
		{
			base.OnHide();
			this.m_AttrPool.ReturnAll(false);
		}

		// Token: 0x0600FBBF RID: 64447 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FBC0 RID: 64448 RVA: 0x003A8463 File Offset: 0x003A6663
		public void RefreshView()
		{
			this.FillContent();
		}

		// Token: 0x0600FBC1 RID: 64449 RVA: 0x003A8470 File Offset: 0x003A6670
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

		// Token: 0x0600FBC2 RID: 64450 RVA: 0x003A8754 File Offset: 0x003A6954
		private void FillAttrItem(GameObject go, uint id, uint value)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString((XAttributeDefine)id));
			ixuilabel = (go.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(string.Format("+{0}", value));
		}

		// Token: 0x0600FBC3 RID: 64451 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClickClose(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		// Token: 0x04006E85 RID: 28293
		private XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006E86 RID: 28294
		private IXUILabel m_HistoryMaxLevel;

		// Token: 0x04006E87 RID: 28295
		private IXUILabel m_NextStageLevel;

		// Token: 0x04006E88 RID: 28296
		private IXUILabel m_effectTipsLab;

		// Token: 0x04006E89 RID: 28297
		private IXUISprite m_closedSpr;

		// Token: 0x04006E8A RID: 28298
		private GameObject m_CurAttrListGo;

		// Token: 0x04006E8B RID: 28299
		private GameObject m_NextStageAttrListGo;

		// Token: 0x04006E8C RID: 28300
		private GameObject m_NoTipsGo;

		// Token: 0x04006E8D RID: 28301
		private GameObject m_MaxTipsGo;

		// Token: 0x04006E8E RID: 28302
		private readonly int m_gap = 30;
	}
}
