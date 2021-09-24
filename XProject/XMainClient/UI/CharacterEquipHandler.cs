using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CharacterEquipHandler : DlgHandlerBase
	{

		public GameObject[] EquipGo
		{
			get
			{
				return this.m_EquipGo;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/EquipFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i < CharacterEquipHandler.Equip_Slot_Count; i++)
			{
				this.m_EquipBg[i].ID = (ulong)((long)i);
				this.m_EquipBg[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSlotBgClick));
			}
		}

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

		public override void StackRefresh()
		{
			bool flag = this.m_EnhanceMasterEffect != null;
			if (flag)
			{
				this.m_EnhanceMasterEffect.SetActive(false);
			}
			base.StackRefresh();
		}

		private void _StopItemShining()
		{
			foreach (uint token in this._ShiningTimerTokens.Values)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(token);
			}
			this._ShiningTimerTokens.Clear();
		}

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

		public void ShowNormalEquip(bool bFlag)
		{
			this.bNormal = bFlag;
			for (int i = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START); i < XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END); i++)
			{
				this.m_EquipGo[i].SetActive(bFlag);
			}
		}

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

		public static int Equip_Slot_Count = XBagDocument.EquipMax;

		private GameObject[] m_EquipGo = new GameObject[CharacterEquipHandler.Equip_Slot_Count];

		public IXUISprite[] m_EquipSlots = new IXUISprite[CharacterEquipHandler.Equip_Slot_Count];

		public IXUISprite[] m_EquipBg = new IXUISprite[CharacterEquipHandler.Equip_Slot_Count];

		private XItemSelector _ItemSelector = new XItemSelector(0U);

		private XItemMorePowerfulTipMgr _MorePowerfulMgr = new XItemMorePowerfulTipMgr();

		private XItemMorePowerfulTipMgr _WeakMorePowerfulMgr = new XItemMorePowerfulTipMgr();

		private XItemMorePowerfulTipMgr _ItemShining = null;

		private XItemMorePowerfulTipMgr _SuitFxMgr = new XItemMorePowerfulTipMgr();

		private Dictionary<GameObject, uint> _ShiningTimerTokens = new Dictionary<GameObject, uint>();

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private bool bNormal = true;

		private XFx m_EnhanceMasterEffect;

		private ArtifactQuanlityFx[] m_fuseBreakFx = new ArtifactQuanlityFx[CharacterEquipHandler.Equip_Slot_Count];

		private EquipFusionDocument m_doc;

		private string m_enhanceMasterPath = string.Empty;
	}
}
