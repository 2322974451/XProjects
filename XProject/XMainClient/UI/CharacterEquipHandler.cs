using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001910 RID: 6416
	internal class CharacterEquipHandler : DlgHandlerBase
	{
		// Token: 0x17003AD8 RID: 15064
		// (get) Token: 0x06010C65 RID: 68709 RVA: 0x004359EC File Offset: 0x00433BEC
		public GameObject[] EquipGo
		{
			get
			{
				return this.m_EquipGo;
			}
		}

		// Token: 0x17003AD9 RID: 15065
		// (get) Token: 0x06010C66 RID: 68710 RVA: 0x00435A04 File Offset: 0x00433C04
		protected override string FileName
		{
			get
			{
				return "ItemNew/EquipFrame";
			}
		}

		// Token: 0x06010C67 RID: 68711 RVA: 0x00435A1C File Offset: 0x00433C1C
		protected override void Init()
		{
			base.Init();
			this.m_doc = EquipFusionDocument.Doc;
			this.m_ItemPool.SetupPool(base.PanelObject, base.PanelObject.transform.Find("ItemTpl").gameObject, (uint)CharacterEquipHandler.Equip_Slot_Count, false);
			for (int i = 0; i < CharacterEquipHandler.Equip_Slot_Count; i++)
			{
				this.m_EquipGo[i] = this.m_ItemPool.FetchGameObject(false);
				GameObject gameObject = base.PanelObject.transform.FindChild("Part" + i).gameObject;
				this.m_EquipGo[i].transform.localPosition = gameObject.transform.localPosition;
				this.m_EquipSlots[i] = (this.m_EquipGo[i].transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
				this.m_EquipBg[i] = (gameObject.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite);
			}
			this._MorePowerfulMgr.Load("ItemMorePowerfulTip2");
			this._MorePowerfulMgr.SetupPool(base.PanelObject);
			this._WeakMorePowerfulMgr.SetupPool(base.PanelObject);
			Transform transform = base.PanelObject.transform.Find("SuitFx");
			bool flag = transform != null;
			if (flag)
			{
				this._SuitFxMgr.LoadFromUI(transform.gameObject);
				this._SuitFxMgr.SetupPool(base.PanelObject);
			}
		}

		// Token: 0x06010C68 RID: 68712 RVA: 0x00435BB8 File Offset: 0x00433DB8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i < CharacterEquipHandler.Equip_Slot_Count; i++)
			{
				this.m_EquipBg[i].ID = (ulong)((long)i);
				this.m_EquipBg[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSlotBgClick));
			}
		}

		// Token: 0x06010C69 RID: 68713 RVA: 0x00435C10 File Offset: 0x00433E10
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.m_EnhanceMasterEffect != null;
			if (flag)
			{
				this.m_EnhanceMasterEffect.SetActive(false);
			}
			this._ItemSelector.Hide();
			this._MorePowerfulMgr.ReturnAll();
			this._WeakMorePowerfulMgr.ReturnAll();
			this._SuitFxMgr.ReturnAll();
			this.ShowEquipments();
		}

		// Token: 0x06010C6A RID: 68714 RVA: 0x00435C78 File Offset: 0x00433E78
		protected override void OnHide()
		{
			bool flag = this.m_EnhanceMasterEffect != null;
			if (flag)
			{
				this.m_EnhanceMasterEffect.SetActive(false);
			}
			this._StopItemShining();
			this.RestQuanlityFx();
			base.OnHide();
		}

		// Token: 0x06010C6B RID: 68715 RVA: 0x00435CB8 File Offset: 0x00433EB8
		public override void OnUnload()
		{
			this._ItemSelector.Unload();
			this._MorePowerfulMgr.Unload();
			this._WeakMorePowerfulMgr.Unload();
			this._SuitFxMgr.Unload();
			bool flag = this.m_EnhanceMasterEffect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_EnhanceMasterEffect, true);
				this.m_EnhanceMasterEffect = null;
			}
			this._StopItemShining();
			for (int i = 0; i < CharacterEquipHandler.Equip_Slot_Count; i++)
			{
				bool flag2 = this.m_fuseBreakFx[i] != null;
				if (flag2)
				{
					this.m_fuseBreakFx[i].Reset();
					this.m_fuseBreakFx[i] = null;
				}
			}
			base.OnUnload();
		}

		// Token: 0x06010C6C RID: 68716 RVA: 0x00435D6C File Offset: 0x00433F6C
		public override void StackRefresh()
		{
			bool flag = this.m_EnhanceMasterEffect != null;
			if (flag)
			{
				this.m_EnhanceMasterEffect.SetActive(false);
			}
			base.StackRefresh();
		}

		// Token: 0x06010C6D RID: 68717 RVA: 0x00435DA0 File Offset: 0x00433FA0
		private void _StopItemShining()
		{
			foreach (uint token in this._ShiningTimerTokens.Values)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
			}
			this._ShiningTimerTokens.Clear();
		}

		// Token: 0x06010C6E RID: 68718 RVA: 0x00435E10 File Offset: 0x00434010
		private void _StartItemShining()
		{
			this._StopItemShining();
			this._ItemShining.FakeReturnAll();
			for (int i = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START); i < XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END); i++)
			{
				bool flag = this.m_EquipSlots[i].ID == 0UL;
				if (!flag)
				{
					GameObject gameObject = this._ItemShining.SetTip(this.m_EquipSlots[i]);
					this._ShowItemShining(gameObject);
					gameObject.transform.FindChild("Icon").gameObject.SetActive(false);
				}
			}
			this._ItemShining.ActualReturnAll();
		}

		// Token: 0x06010C6F RID: 68719 RVA: 0x00435EAC File Offset: 0x004340AC
		private void _ShowItemShining(object o)
		{
			GameObject gameObject = o as GameObject;
			bool flag = this._ShiningTimerTokens.ContainsKey(gameObject);
			if (flag)
			{
				IXUISpriteAnimation ixuispriteAnimation = gameObject.transform.FindChild("Icon").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
				ixuispriteAnimation.Reset();
				ixuispriteAnimation.gameObject.SetActive(true);
			}
			float interval = XSingleton<XCommon>.singleton.RandomFloat(3f, 15f);
			this._ShiningTimerTokens[gameObject] = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this._ShowItemShining), gameObject);
		}

		// Token: 0x06010C70 RID: 68720 RVA: 0x00435F44 File Offset: 0x00434144
		public void SetRedPoints(List<int> equipList)
		{
			this._MorePowerfulMgr.ReturnAll();
			bool flag = equipList != null;
			if (flag)
			{
				foreach (int num in equipList)
				{
					this._MorePowerfulMgr.SetTip(this.m_EquipSlots[num]);
				}
			}
		}

		// Token: 0x06010C71 RID: 68721 RVA: 0x00435FBC File Offset: 0x004341BC
		public void SetArrows(List<int> equipList)
		{
			this._WeakMorePowerfulMgr.ReturnAll();
			bool flag = equipList != null;
			if (flag)
			{
				foreach (int num in equipList)
				{
					this._WeakMorePowerfulMgr.SetTip(this.m_EquipSlots[num]);
				}
			}
		}

		// Token: 0x06010C72 RID: 68722 RVA: 0x00436034 File Offset: 0x00434234
		public void ShowEquipments()
		{
			XBodyBag equipBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag;
			for (int i = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START); i < XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END); i++)
			{
				XItemDrawerMgr.Param.bHideBinding = true;
				bool flag = equipBag[i] != null;
				if (flag)
				{
					this.m_EquipGo[i].SetActive(true);
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_EquipGo[i], equipBag[i]);
					this.m_EquipSlots[i].ID = equipBag[i].uid;
					XEquipItem xequipItem = equipBag[i] as XEquipItem;
					this.SetEffect(this.m_EquipGo[i], xequipItem.fuseInfo.BreakNum, i);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_EquipGo[i], null);
					this.m_EquipSlots[i].ID = 0UL;
					this.SetEffect(this.m_EquipGo[i], 0U, i);
				}
			}
		}

		// Token: 0x06010C73 RID: 68723 RVA: 0x00436140 File Offset: 0x00434340
		public void ShowNormalEquip(bool bFlag)
		{
			this.bNormal = bFlag;
			for (int i = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START); i < XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END); i++)
			{
				this.m_EquipGo[i].SetActive(bFlag);
			}
		}

		// Token: 0x17003ADA RID: 15066
		// (get) Token: 0x06010C74 RID: 68724 RVA: 0x00436184 File Offset: 0x00434384
		public string EnhanceMasterPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_enhanceMasterPath);
				if (flag)
				{
					this.m_enhanceMasterPath = XSingleton<XGlobalConfig>.singleton.GetValue("EnhanceMasterEffectPath");
				}
				return this.m_enhanceMasterPath;
			}
		}

		// Token: 0x06010C75 RID: 68725 RVA: 0x004361C0 File Offset: 0x004343C0
		public void PlayEnhanceMasterEffect()
		{
			bool flag = this.m_EnhanceMasterEffect != null;
			if (flag)
			{
				this.m_EnhanceMasterEffect.SetActive(false);
			}
			bool flag2 = this.m_EnhanceMasterEffect == null;
			if (flag2)
			{
				this.m_EnhanceMasterEffect = XSingleton<XFxMgr>.singleton.CreateFx(this.EnhanceMasterPath, null, true);
			}
			else
			{
				bool flag3 = this.m_EnhanceMasterEffect != null;
				if (flag3)
				{
					this.m_EnhanceMasterEffect.SetActive(true);
				}
			}
			this.m_EnhanceMasterEffect.Play(base.PanelObject.transform.parent.parent, Vector3.zero, Vector3.one, 1f, true, false);
		}

		// Token: 0x06010C76 RID: 68726 RVA: 0x00436260 File Offset: 0x00434460
		private void SetEffect(GameObject go, uint breakLevel, int slot)
		{
			bool flag = slot >= this.m_fuseBreakFx.Length;
			if (!flag)
			{
				bool flag2 = go == null;
				if (!flag2)
				{
					ArtifactQuanlityFx artifactQuanlityFx = this.m_fuseBreakFx[slot];
					bool flag3 = artifactQuanlityFx == null;
					if (flag3)
					{
						artifactQuanlityFx = new ArtifactQuanlityFx();
						this.m_fuseBreakFx[slot] = artifactQuanlityFx;
					}
					string path;
					bool flag4 = !this.m_doc.GetEffectPath(breakLevel, out path);
					if (flag4)
					{
						artifactQuanlityFx.Reset();
					}
					else
					{
						bool flag5 = !artifactQuanlityFx.IsCanReuse((ulong)breakLevel);
						if (flag5)
						{
							artifactQuanlityFx.SetData((ulong)breakLevel, go.transform.FindChild("Icon/Icon/Effects"), path);
						}
					}
				}
			}
		}

		// Token: 0x06010C77 RID: 68727 RVA: 0x00436300 File Offset: 0x00434500
		private void RestQuanlityFx()
		{
			for (int i = 0; i < CharacterEquipHandler.Equip_Slot_Count; i++)
			{
				bool flag = this.m_fuseBreakFx[i] != null;
				if (flag)
				{
					this.m_fuseBreakFx[i].Reset();
				}
			}
		}

		// Token: 0x06010C78 RID: 68728 RVA: 0x00436344 File Offset: 0x00434544
		public void UpdateEquipSlot(XItem item)
		{
			bool flag = item == null;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					bool flag3 = this.m_EquipSlots[(int)equipConf.EquipPos].ID == item.uid;
					if (flag3)
					{
						XItemDrawerMgr.Param.bHideBinding = true;
						XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_EquipGo[(int)equipConf.EquipPos], item);
						XEquipItem xequipItem = item as XEquipItem;
						this.SetEffect(this.m_EquipGo[(int)equipConf.EquipPos], xequipItem.fuseInfo.BreakNum, (int)equipConf.EquipPos);
					}
				}
			}
		}

		// Token: 0x06010C79 RID: 68729 RVA: 0x004363E8 File Offset: 0x004345E8
		public void SetEquipSlot(int slot, XItem item)
		{
			XItemDrawerMgr.Param.bHideBinding = true;
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_EquipGo[slot], item);
			this.m_EquipSlots[slot].ID = ((item != null) ? item.uid : 0UL);
			bool flag = item != null;
			if (flag)
			{
				XEquipItem xequipItem = item as XEquipItem;
				this.SetEffect(this.m_EquipGo[slot], xequipItem.fuseInfo.BreakNum, slot);
			}
			else
			{
				this.SetEffect(this.m_EquipGo[slot], 0U, slot);
			}
		}

		// Token: 0x06010C7A RID: 68730 RVA: 0x00436470 File Offset: 0x00434670
		public void RegisterItemClickEvents(SpriteClickEventHandler handle = null)
		{
			SpriteClickEventHandler eventHandler = handle;
			bool flag = handle == null;
			if (flag)
			{
				eventHandler = new SpriteClickEventHandler(CharacterEquipHandler.OnItemClicked);
			}
			for (int i = 0; i < CharacterEquipHandler.Equip_Slot_Count; i++)
			{
				this.m_EquipSlots[i].RegisterSpriteClickEventHandler(eventHandler);
			}
		}

		// Token: 0x06010C7B RID: 68731 RVA: 0x004364BC File Offset: 0x004346BC
		public void SelectEquip(ulong uid)
		{
			bool flag = uid == 0UL;
			if (flag)
			{
				this._ItemSelector.Hide();
			}
			else
			{
				for (int i = 0; i < CharacterEquipHandler.Equip_Slot_Count; i++)
				{
					bool flag2 = this.m_EquipSlots[i].ID == uid;
					if (flag2)
					{
						this._ItemSelector.Select(this.m_EquipSlots[i]);
						break;
					}
				}
			}
		}

		// Token: 0x06010C7C RID: 68732 RVA: 0x00436524 File Offset: 0x00434724
		public static void OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID != null;
			if (flag)
			{
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

		// Token: 0x06010C7D RID: 68733 RVA: 0x004365AC File Offset: 0x004347AC
		private void _OnSlotBgClick(IXUISprite iSp)
		{
			EquipPosition equipPosition = (EquipPosition)iSp.ID;
			string text = XSingleton<UiUtility>.singleton.GetEquipPartName(equipPosition, true);
			bool flag = equipPosition == EquipPosition.Earrings || equipPosition == EquipPosition.Rings || equipPosition == EquipPosition.Necklace;
			if (flag)
			{
				text = XStringDefineProxy.GetString("SHIPIN_FROM", new object[]
				{
					text
				});
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
		}

		// Token: 0x06010C7E RID: 68734 RVA: 0x0043660C File Offset: 0x0043480C
		public void PlaySuitFx(List<int> equipPos)
		{
			this._SuitFxMgr.FakeReturnAll();
			for (int i = 0; i < equipPos.Count; i++)
			{
				GameObject gameObject = this._SuitFxMgr.SetTip(this.m_EquipSlots[equipPos[i]]);
				IXUITweenTool ixuitweenTool = gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.PlayTween(true, -1f);
			}
			this._SuitFxMgr.ActualReturnAll();
		}

		// Token: 0x04007AF1 RID: 31473
		public static int Equip_Slot_Count = XBagDocument.EquipMax;

		// Token: 0x04007AF2 RID: 31474
		private GameObject[] m_EquipGo = new GameObject[CharacterEquipHandler.Equip_Slot_Count];

		// Token: 0x04007AF3 RID: 31475
		public IXUISprite[] m_EquipSlots = new IXUISprite[CharacterEquipHandler.Equip_Slot_Count];

		// Token: 0x04007AF4 RID: 31476
		public IXUISprite[] m_EquipBg = new IXUISprite[CharacterEquipHandler.Equip_Slot_Count];

		// Token: 0x04007AF5 RID: 31477
		private XItemSelector _ItemSelector = new XItemSelector(0U);

		// Token: 0x04007AF6 RID: 31478
		private XItemMorePowerfulTipMgr _MorePowerfulMgr = new XItemMorePowerfulTipMgr();

		// Token: 0x04007AF7 RID: 31479
		private XItemMorePowerfulTipMgr _WeakMorePowerfulMgr = new XItemMorePowerfulTipMgr();

		// Token: 0x04007AF8 RID: 31480
		private XItemMorePowerfulTipMgr _ItemShining = null;

		// Token: 0x04007AF9 RID: 31481
		private XItemMorePowerfulTipMgr _SuitFxMgr = new XItemMorePowerfulTipMgr();

		// Token: 0x04007AFA RID: 31482
		private Dictionary<GameObject, uint> _ShiningTimerTokens = new Dictionary<GameObject, uint>();

		// Token: 0x04007AFB RID: 31483
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007AFC RID: 31484
		private bool bNormal = true;

		// Token: 0x04007AFD RID: 31485
		private XFx m_EnhanceMasterEffect;

		// Token: 0x04007AFE RID: 31486
		private ArtifactQuanlityFx[] m_fuseBreakFx = new ArtifactQuanlityFx[CharacterEquipHandler.Equip_Slot_Count];

		// Token: 0x04007AFF RID: 31487
		private EquipFusionDocument m_doc;

		// Token: 0x04007B00 RID: 31488
		private string m_enhanceMasterPath = string.Empty;
	}
}
