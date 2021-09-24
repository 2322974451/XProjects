using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactFrameHandler : DlgHandlerBase
	{

		public GameObject[] ArtifactGo
		{
			get
			{
				return this.m_artifactGo;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactFrame";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowArtifacts();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.HideEffects();
			this.RestQuanlityFx();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.HideEffects();
		}

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

		public bool OnAttrBtnClicked(IXUIButton button)
		{
			this.HideEffects();
			this.m_artifactAttrHandler.SetBaseData(XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag);
			this.m_artifactAttrHandler.SetVisible(true);
			return true;
		}

		public bool OnComposeBtnClicked(IXUIButton button)
		{
			this.HideEffects();
			DlgBase<ArtifactDeityStoveDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Artifact_DeityStove);
			return true;
		}

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

		public static int Artifact_Slot_Count = XBagDocument.ArtifactMax;

		private XArtifactAttrView<XAttrPlayerFile> m_artifactAttrHandler;

		private ArtifactBagDocument m_doc;

		public IXUISprite[] m_artifactBg = new IXUISprite[ArtifactFrameHandler.Artifact_Slot_Count];

		public IXUISprite[] m_artifactSlots = new IXUISprite[ArtifactFrameHandler.Artifact_Slot_Count];

		private GameObject[] m_artifactGo = new GameObject[ArtifactFrameHandler.Artifact_Slot_Count];

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform TotalAttriPanel;

		private List<uint> m_templateIds = new List<uint>();

		private IXUIButton m_AttriBtn;

		private IXUIButton m_ComposeBtn;

		private ArtifactQuanlityFx[] m_quanlityFx = new ArtifactQuanlityFx[ArtifactFrameHandler.Artifact_Slot_Count];

		private XFx[] m_suitFxs = new XFx[ArtifactFrameHandler.Artifact_Slot_Count];

		private XFx m_suitUltimateFx;
	}
}
