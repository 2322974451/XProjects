using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017AF RID: 6063
	internal class ArtifactFrameHandler : DlgHandlerBase
	{
		// Token: 0x17003875 RID: 14453
		// (get) Token: 0x0600FAC5 RID: 64197 RVA: 0x003A0B5C File Offset: 0x0039ED5C
		public GameObject[] ArtifactGo
		{
			get
			{
				return this.m_artifactGo;
			}
		}

		// Token: 0x17003876 RID: 14454
		// (get) Token: 0x0600FAC6 RID: 64198 RVA: 0x003A0B74 File Offset: 0x0039ED74
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactFrame";
			}
		}

		// Token: 0x0600FAC7 RID: 64199 RVA: 0x003A0B8C File Offset: 0x0039ED8C
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactBagDocument.Doc;
			this.m_templateIds.Add(296U);
			this.m_templateIds.Add(297U);
			this.m_templateIds.Add(298U);
			this.m_templateIds.Add(299U);
			this.TotalAttriPanel = base.PanelObject.transform.FindChild("Panel/TotalAttriPanel");
			Transform transform = base.PanelObject.transform.Find("Panel/Artifacts");
			this.m_ItemPool.SetupPool(transform.gameObject, transform.transform.Find("Tpl").gameObject, (uint)ArtifactFrameHandler.Artifact_Slot_Count, false);
			this.m_AttriBtn = (base.PanelObject.transform.Find("Panel/AttriBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_ComposeBtn = (base.PanelObject.transform.Find("Panel/ComposeBtn").GetComponent("XUIButton") as IXUIButton);
			string prefab_location = string.Empty;
			for (int i = 0; i < ArtifactFrameHandler.Artifact_Slot_Count; i++)
			{
				this.m_artifactGo[i] = this.m_ItemPool.FetchGameObject(false);
				GameObject gameObject = transform.FindChild("Artifact" + i).gameObject;
				this.m_artifactGo[i].transform.localScale = Vector3.one;
				this.m_artifactGo[i].transform.localPosition = gameObject.transform.localPosition;
				this.m_artifactSlots[i] = (this.m_artifactGo[i].transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
				this.m_artifactBg[i] = (gameObject.transform.GetComponent("XUISprite") as IXUISprite);
				this.m_quanlityFx[i] = new ArtifactQuanlityFx();
				bool flag = i < this.m_doc.SuitEffectPosNames.Count;
				if (flag)
				{
					prefab_location = string.Format("Effects/FX_Particle/UIfx/{0}", this.m_doc.SuitEffectPosNames[i]);
					XFx xfx = XSingleton<XFxMgr>.singleton.CreateFx(prefab_location, null, true);
					bool flag2 = xfx != null;
					if (flag2)
					{
						this.m_suitFxs[i] = xfx;
						xfx.SetParent(gameObject.transform);
					}
				}
			}
			DlgHandlerBase.EnsureCreate<XArtifactAttrView<XAttrPlayerFile>>(ref this.m_artifactAttrHandler, this.TotalAttriPanel, false, this);
		}

		// Token: 0x0600FAC8 RID: 64200 RVA: 0x003A0E08 File Offset: 0x0039F008
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_AttriBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAttrBtnClicked));
			this.m_ComposeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnComposeBtnClicked));
			for (int i = 0; i < ArtifactFrameHandler.Artifact_Slot_Count; i++)
			{
				this.m_artifactBg[i].ID = (ulong)((long)i);
				this.m_artifactBg[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSlotBgClick));
				this.m_artifactSlots[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
			}
		}

		// Token: 0x0600FAC9 RID: 64201 RVA: 0x003A0EA7 File Offset: 0x0039F0A7
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowArtifacts();
		}

		// Token: 0x0600FACA RID: 64202 RVA: 0x003A0EB8 File Offset: 0x0039F0B8
		protected override void OnHide()
		{
			base.OnHide();
			this.HideEffects();
			this.RestQuanlityFx();
		}

		// Token: 0x0600FACB RID: 64203 RVA: 0x003A0ED0 File Offset: 0x0039F0D0
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.HideEffects();
		}

		// Token: 0x0600FACC RID: 64204 RVA: 0x003A0EE4 File Offset: 0x0039F0E4
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_ItemPool.ReturnAll(false);
			DlgHandlerBase.EnsureUnload<XArtifactAttrView<XAttrPlayerFile>>(ref this.m_artifactAttrHandler);
			for (int i = 0; i < ArtifactFrameHandler.Artifact_Slot_Count; i++)
			{
				bool flag = this.m_suitFxs[i] != null;
				if (flag)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_suitFxs[i], true);
					this.m_suitFxs[i] = null;
				}
				bool flag2 = this.m_quanlityFx[i] != null;
				if (flag2)
				{
					this.m_quanlityFx[i].Reset();
					this.m_quanlityFx[i] = null;
				}
			}
		}

		// Token: 0x0600FACD RID: 64205 RVA: 0x003A0F80 File Offset: 0x0039F180
		private void RestQuanlityFx()
		{
			for (int i = 0; i < ArtifactFrameHandler.Artifact_Slot_Count; i++)
			{
				bool flag = this.m_quanlityFx[i] != null;
				if (flag)
				{
					this.m_quanlityFx[i].Reset();
				}
			}
		}

		// Token: 0x0600FACE RID: 64206 RVA: 0x003A0FC4 File Offset: 0x0039F1C4
		public void HideEffects()
		{
			for (int i = 0; i < ArtifactFrameHandler.Artifact_Slot_Count; i++)
			{
				bool flag = this.m_suitFxs[i] != null;
				if (flag)
				{
					this.m_suitFxs[i].SetActive(false);
				}
			}
			bool flag2 = this.m_suitUltimateFx != null;
			if (flag2)
			{
				this.m_suitUltimateFx.SetActive(false);
			}
		}

		// Token: 0x0600FACF RID: 64207 RVA: 0x003A1024 File Offset: 0x0039F224
		public void ShowArtifacts()
		{
			XBodyBag artifactBag = XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag;
			for (int i = XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_START); i < XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_END); i++)
			{
				XItemDrawerMgr.Param.bHideBinding = true;
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_artifactGo[i], artifactBag[i]);
				this.m_artifactGo[i].transform.FindChild("Icon/RedPoint").gameObject.SetActive(false);
				bool flag = artifactBag[i] != null && artifactBag[i].itemConf != null;
				if (flag)
				{
					this.SetEffect(this.m_artifactGo[i], artifactBag[i].itemID, i);
				}
				this.m_artifactSlots[i].ID = ((artifactBag[i] != null) ? artifactBag[i].uid : 0UL);
			}
		}

		// Token: 0x0600FAD0 RID: 64208 RVA: 0x003A1114 File Offset: 0x0039F314
		public void SetEquipSlot(int slot, XItem item)
		{
			XItemDrawerMgr.Param.bHideBinding = true;
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_artifactGo[slot], item);
			this.m_artifactGo[slot].transform.FindChild("Icon/RedPoint").gameObject.SetActive(false);
			bool flag = item != null && item.itemConf != null;
			if (flag)
			{
				this.SetEffect(this.m_artifactGo[slot], item.itemID, slot);
			}
			this.m_artifactSlots[slot].ID = ((item != null) ? item.uid : 0UL);
		}

		// Token: 0x0600FAD1 RID: 64209 RVA: 0x003A11A8 File Offset: 0x0039F3A8
		public void UpdateEquipSlot(XItem item)
		{
			bool flag = item == null;
			if (!flag)
			{
				ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)item.itemID);
				bool flag2 = artifactListRowData == null;
				if (!flag2)
				{
					bool flag3 = this.m_artifactSlots[(int)artifactListRowData.ArtifactPos].ID == item.uid;
					if (flag3)
					{
						XItemDrawerMgr.Param.bHideBinding = true;
						XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_artifactGo[(int)artifactListRowData.ArtifactPos], item);
						this.m_artifactGo[(int)artifactListRowData.ArtifactPos].transform.FindChild("Icon/RedPoint").gameObject.SetActive(false);
						bool flag4 = item.itemConf != null;
						if (flag4)
						{
							this.SetEffect(this.m_artifactGo[(int)artifactListRowData.ArtifactPos], item.itemID, (int)artifactListRowData.ArtifactPos);
						}
					}
				}
			}
		}

		// Token: 0x0600FAD2 RID: 64210 RVA: 0x003A1278 File Offset: 0x0039F478
		public void PlaySuitFx(uint suitId)
		{
			bool flag = DlgBase<ArtifactDeityStoveDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				this.HideEffects();
				XBodyBag artifactBag = XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag;
				int num = 0;
				for (int i = XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_START); i < XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_END); i++)
				{
					bool flag2 = artifactBag[i] == null;
					if (!flag2)
					{
						ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)artifactBag[i].itemID);
						bool flag3 = artifactListRowData == null;
						if (!flag3)
						{
							bool flag4 = artifactListRowData.ArtifactSuit == suitId;
							if (flag4)
							{
								bool flag5 = this.m_suitFxs.Length > i && this.m_suitFxs[i] != null;
								if (flag5)
								{
									num++;
									this.m_suitFxs[i].SetActive(true);
								}
							}
						}
					}
				}
				ArtifactSuit suitBySuitId = ArtifactDocument.SuitMgr.GetSuitBySuitId(suitId);
				bool flag6 = (long)num == (long)((ulong)suitBySuitId.MaxSuitEffectCount);
				if (flag6)
				{
					bool flag7 = this.m_suitUltimateFx == null;
					if (flag7)
					{
						this.m_suitUltimateFx = XSingleton<XFxMgr>.singleton.CreateFx(string.Format("Effects/FX_Particle/UIfx/{0}", XSingleton<XStringTable>.singleton.GetString("ArtifactSuitUltimateFxName")), null, true);
					}
					else
					{
						this.m_suitUltimateFx.SetActive(true);
					}
					this.m_suitUltimateFx.Play(base.PanelObject.transform.Find("Panel/Artifacts"), Vector3.zero, Vector3.one, 1f, true, false);
				}
			}
		}

		// Token: 0x0600FAD3 RID: 64211 RVA: 0x003A13FC File Offset: 0x0039F5FC
		private void SetEffect(GameObject go, int itemId, int slot)
		{
			bool flag = slot >= this.m_quanlityFx.Length;
			if (!flag)
			{
				bool flag2 = go == null;
				if (!flag2)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf(itemId);
					bool flag3 = itemConf == null;
					if (!flag3)
					{
						ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)itemId);
						bool flag4 = artifactListRowData == null;
						if (!flag4)
						{
							ArtifactQuanlityFx artifactQuanlityFx = this.m_quanlityFx[slot];
							bool flag5 = artifactQuanlityFx == null;
							if (flag5)
							{
								artifactQuanlityFx = new ArtifactQuanlityFx();
								this.m_quanlityFx[slot] = artifactQuanlityFx;
							}
							ulong key = this.m_doc.MakeKey((uint)itemConf.ItemQuality, artifactListRowData.AttrType);
							string path;
							bool flag6 = !this.m_doc.GetArtifactEffectPath(key, out path);
							if (flag6)
							{
								artifactQuanlityFx.Reset();
							}
							else
							{
								bool flag7 = !artifactQuanlityFx.IsCanReuse(key);
								if (flag7)
								{
									artifactQuanlityFx.SetData(key, go.transform.FindChild("Icon/Icon/Effects"), path);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600FAD4 RID: 64212 RVA: 0x003A14E8 File Offset: 0x0039F6E8
		private void OnSlotBgClick(IXUISprite spr)
		{
			uint num = (uint)spr.ID;
			bool flag = this.m_doc.IsHadThisPosArtifact(num);
			if (flag)
			{
				string artifactPartName = XSingleton<UiUtility>.singleton.GetArtifactPartName((ArtifactPosition)num, true);
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactPosClickPos"), artifactPartName), "fece00");
			}
			else
			{
				bool flag2 = (ulong)num < (ulong)((long)this.m_templateIds.Count);
				if (flag2)
				{
					this.HideEffects();
					XSingleton<UiUtility>.singleton.ShowItemAccess((int)this.m_templateIds[(int)num], null);
				}
			}
		}

		// Token: 0x0600FAD5 RID: 64213 RVA: 0x003A157C File Offset: 0x0039F77C
		public bool OnAttrBtnClicked(IXUIButton button)
		{
			this.HideEffects();
			this.m_artifactAttrHandler.SetBaseData(XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag);
			this.m_artifactAttrHandler.SetVisible(true);
			return true;
		}

		// Token: 0x0600FAD6 RID: 64214 RVA: 0x003A15C4 File Offset: 0x0039F7C4
		public bool OnComposeBtnClicked(IXUIButton button)
		{
			this.HideEffects();
			DlgBase<ArtifactDeityStoveDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Artifact_DeityStove);
			return true;
		}

		// Token: 0x0600FAD7 RID: 64215 RVA: 0x003A15F0 File Offset: 0x0039F7F0
		public void OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID != null;
			if (flag)
			{
				this.HideEffects();
				XBodyBag bodyBag = itemByUID.Description.BodyBag;
				bool flag2 = bodyBag != null && bodyBag.HasItem(itemByUID.uid);
				if (flag2)
				{
					XSingleton<TooltipParam>.singleton.bEquiped = true;
					XSingleton<UiUtility>.singleton.ShowTooltipDialog(itemByUID, null, iSp, true, 0U);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(itemByUID, iSp, true, 0U);
				}
			}
		}

		// Token: 0x04006DF7 RID: 28151
		public static int Artifact_Slot_Count = XBagDocument.ArtifactMax;

		// Token: 0x04006DF8 RID: 28152
		private XArtifactAttrView<XAttrPlayerFile> m_artifactAttrHandler;

		// Token: 0x04006DF9 RID: 28153
		private ArtifactBagDocument m_doc;

		// Token: 0x04006DFA RID: 28154
		public IXUISprite[] m_artifactBg = new IXUISprite[ArtifactFrameHandler.Artifact_Slot_Count];

		// Token: 0x04006DFB RID: 28155
		public IXUISprite[] m_artifactSlots = new IXUISprite[ArtifactFrameHandler.Artifact_Slot_Count];

		// Token: 0x04006DFC RID: 28156
		private GameObject[] m_artifactGo = new GameObject[ArtifactFrameHandler.Artifact_Slot_Count];

		// Token: 0x04006DFD RID: 28157
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006DFE RID: 28158
		private Transform TotalAttriPanel;

		// Token: 0x04006DFF RID: 28159
		private List<uint> m_templateIds = new List<uint>();

		// Token: 0x04006E00 RID: 28160
		private IXUIButton m_AttriBtn;

		// Token: 0x04006E01 RID: 28161
		private IXUIButton m_ComposeBtn;

		// Token: 0x04006E02 RID: 28162
		private ArtifactQuanlityFx[] m_quanlityFx = new ArtifactQuanlityFx[ArtifactFrameHandler.Artifact_Slot_Count];

		// Token: 0x04006E03 RID: 28163
		private XFx[] m_suitFxs = new XFx[ArtifactFrameHandler.Artifact_Slot_Count];

		// Token: 0x04006E04 RID: 28164
		private XFx m_suitUltimateFx;
	}
}
