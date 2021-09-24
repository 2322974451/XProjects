using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RecycleItemOperateView : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			XUIPool xuipool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			xuipool.SetupPool(base.PanelObject.transform.FindChild("Frame/Items").gameObject, base.PanelObject.transform.FindChild("Frame/Items/ItemTpl").gameObject, XRecycleItemDocument.MAX_RECYCLE_COUNT, false);
			for (uint num = 0U; num < XRecycleItemDocument.MAX_RECYCLE_COUNT; num += 1U)
			{
				this.m_ItemContainers[(int)num] = base.PanelObject.transform.FindChild("Frame/Items/Item" + num);
				GameObject gameObject = xuipool.FetchGameObject(false);
				this.m_ItemList[(int)num] = gameObject;
				this.m_ItemIconList[(int)num] = (gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
				gameObject.transform.parent = this.m_ItemContainers[(int)num];
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
			}
			this.m_RecyclingEatTween = (base.PanelObject.transform.FindChild("Frame/Items").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_RecyclingFxParent = base.PanelObject.transform.FindChild("Frame/P/Fire").gameObject;
			this.criticalEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_gorgeous", null, true);
			this._doc = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
			this._doc.OperateView = this;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Frame/DoBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDoClicked));
			int num = 0;
			while ((long)num < (long)((ulong)XRecycleItemDocument.MAX_RECYCLE_COUNT))
			{
				this.m_ItemIconList[num].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
				IXUILongPress ixuilongPress = this.m_ItemIconList[num].gameObject.GetComponent("XUILongPress") as IXUILongPress;
				ixuilongPress.RegisterSpriteLongPressEventHandler(new SpriteClickEventHandler(this._OnItemLongPressed));
				num++;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
			this._ResetItemStates();
		}

		public override void OnUnload()
		{
			this._doc.OperateView = null;
			bool flag = this.m_RecyclingFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_RecyclingFx, true);
				this.m_RecyclingFx = null;
			}
			base.OnUnload();
		}

		private bool _OnShopBtnClicked(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Fasion, 0UL);
			return true;
		}

		private bool _OnDoClicked(IXUIButton btn)
		{
			bool flag = this._doc.SelectedItems.Count == 0;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RECYCLE_SELECTION_EMPTY"), "fece00");
				result = true;
			}
			else
			{
				foreach (KeyValuePair<ulong, ulong> keyValuePair in this._doc.SelectedItems)
				{
					XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(keyValuePair.Key);
					bool flag2 = itemByUID != null && itemByUID.type == 1U;
					if (flag2)
					{
						XEquipItem xequipItem = itemByUID as XEquipItem;
						int @int = XSingleton<XGlobalConfig>.singleton.GetInt("RecycleFirstTipsLevel");
						int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("RecycleSecondTipsLevel");
						bool flag3 = @int >= int2;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddGreenLog("firstLevel should >= secondLevel", null, null, null, null, null);
						}
						bool flag4 = (ulong)xequipItem.enhanceInfo.EnhanceLevel >= (ulong)((long)@int) && (ulong)xequipItem.enhanceInfo.EnhanceLevel < (ulong)((long)int2);
						if (flag4)
						{
							this.OnAddLeftTimeClicked(btn);
							return true;
						}
						bool flag5 = (ulong)xequipItem.enhanceInfo.EnhanceLevel >= (ulong)((long)int2);
						if (flag5)
						{
							btn.ID = (ulong)((long)int2);
							this.SurecClick(btn);
							return true;
						}
					}
				}
				result = this._DoClicked(btn);
			}
			return result;
		}

		private void OnAddLeftTimeClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("Recycle_EnhancedEquip"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._DoClicked));
		}

		private void SurecClick(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("Cannot_recycl"), btn.ID), XStringDefineProxy.GetString("COMMON_OK"));
		}

		private bool _DoClicked(IXUIButton btn)
		{
			DlgBase<RecycleSystemDlg, TabDlgBehaviour>.singleton.ToggleInputBlocker(true);
			this.m_RecyclingEatTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this._OnFinishEatItems));
			this.m_RecyclingEatTween.PlayTween(true, -1f);
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_ItemMelt", true, AudioChannel.Action);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private void _OnFinishEatItems(IXUITweenTool it)
		{
			bool flag = this.m_RecyclingFx == null;
			if (flag)
			{
				this.m_RecyclingFx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_zbhs", null, true);
			}
			this.m_RecyclingFx.SetActive(true);
			this.m_RecyclingFx.Play(this.m_RecyclingFxParent.transform, Vector3.zero, Vector3.one, 1f, false, false);
			this._doc.Recycle();
			this._ResetItemStates();
			DlgBase<RecycleSystemDlg, TabDlgBehaviour>.singleton.ToggleInputBlocker(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._setPosition);
			this._setPosition = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.SetPos), null);
		}

		public void SetPos(object o = null)
		{
			bool flag = this.m_RecyclingFx != null;
			if (flag)
			{
				this.m_RecyclingFx.SetActive(false);
			}
		}

		private void _ResetItemStates()
		{
			this.m_RecyclingEatTween.ResetTween(true);
		}

		private void _OnItemClicked(IXUISprite iSp)
		{
			this._doc.ToggleItemUnSelect(iSp.ID);
		}

		private void _OnItemLongPressed(IXUISprite iSp)
		{
			XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(iSp.ID);
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(bagItemByUID, null, iSp, false, 0U);
		}

		public void Refresh()
		{
			int num = 0;
			foreach (KeyValuePair<ulong, ulong> keyValuePair in this._doc.SelectedItems)
			{
				ulong key = keyValuePair.Key;
				XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(key);
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_ItemList[num], bagItemByUID);
				IXUILabel ixuilabel = this.m_ItemList[num].transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(keyValuePair.Value.ToString());
				this.m_ItemIconList[num].ID = key;
				num++;
			}
			while ((long)num < (long)((ulong)XRecycleItemDocument.MAX_RECYCLE_COUNT))
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_ItemList[num], null);
				this.m_ItemIconList[num].ID = 0UL;
				num++;
			}
		}

		public void ToggleItem(ulong uid, ulong count, bool bSelect)
		{
			int num = -1;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)XRecycleItemDocument.MAX_RECYCLE_COUNT))
			{
				bool flag = this.m_ItemIconList[num2].ID == uid;
				if (flag)
				{
					num = num2;
					break;
				}
				bool flag2 = this.m_ItemIconList[num2].ID == 0UL && num < 0;
				if (flag2)
				{
					num = num2;
				}
				num2++;
			}
			if (bSelect)
			{
				XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(uid);
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_ItemList[num], bagItemByUID);
				IXUILabel ixuilabel = this.m_ItemList[num].transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(count.ToString());
				this.m_ItemIconList[num].ID = uid;
			}
			else
			{
				bool flag3 = this.m_ItemIconList[num].ID == uid;
				if (flag3)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_ItemList[num], null);
					this.m_ItemIconList[num].ID = 0UL;
				}
			}
		}

		public void PlayCritical()
		{
			this.criticalEffect.Play(Vector3.zero, Quaternion.identity, Vector3.one, 1f);
		}

		private XRecycleItemDocument _doc = null;

		private GameObject[] m_ItemList = new GameObject[XRecycleItemDocument.MAX_RECYCLE_COUNT];

		private IXUISprite[] m_ItemIconList = new IXUISprite[XRecycleItemDocument.MAX_RECYCLE_COUNT];

		private Transform[] m_ItemContainers = new Transform[XRecycleItemDocument.MAX_RECYCLE_COUNT];

		private XFx m_RecyclingFx;

		private IXUITweenTool m_RecyclingEatTween;

		private GameObject m_RecyclingFxParent;

		private XFx criticalEffect;

		private uint _setPosition;
	}
}
