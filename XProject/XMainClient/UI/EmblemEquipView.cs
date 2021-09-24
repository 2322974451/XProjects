using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EmblemEquipView : DlgHandlerBase
	{

		private static int GetSlotIndex(EquipPosition pos)
		{
			int num = XBagDocument.BodyPosition<EquipPosition>(pos);
			bool flag = num >= XEmblemDocument.Position_TotalStart && num < XEmblemDocument.Position_TotalEnd;
			int result;
			if (flag)
			{
				result = num - XEmblemDocument.Position_TotalStart;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/EmblemOperateFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.TotalAttriPanel = base.PanelObject.transform.FindChild("TotalAttriPanel");
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Panel/Btn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickEmblemAccess));
			IXUIButton ixuibutton2 = base.PanelObject.transform.FindChild("Panel/AttriBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAttriBtn));
			this.m_EmblemPool.SetupPool(base.PanelObject.transform.FindChild("Panel/Frame/Emblems").gameObject, base.PanelObject.transform.FindChild("Panel/Frame/Emblems/EmblemTpl").gameObject, (uint)EmblemEquipView.Emblem_Slot_Count, false);
			for (int i = 0; i < EmblemEquipView.Emblem_Slot_Count; i++)
			{
				Transform transform = base.PanelObject.transform.FindChild("Panel/Frame/Emblems/Emblem" + i);
				GameObject gameObject = this.m_EmblemPool.FetchGameObject(false);
				this.m_EmblemBg[i] = gameObject;
				gameObject.transform.localPosition = transform.localPosition;
				gameObject.transform.localScale = transform.localScale;
				this.m_EmblemSlots[i] = (gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
				this.m_EmblemP[i] = (gameObject.transform.FindChild("P").GetComponent("XUISprite") as IXUISprite);
				this.m_EmblemSlotCovers[i] = (gameObject.transform.FindChild("Cover").GetComponent("XUISprite") as IXUISprite);
				this.m_EmblemSlotCovers[i].ID = (ulong)((long)i);
				this.m_EmblemSlotCovers[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSlotCoverClicked));
				this.m_EmblemSlotBgs[i] = (gameObject.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite);
				this.m_EmblemSlotBgs[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSlotBgClicked));
			}
			this.m_BuySlotTween = (base.PanelObject.transform.Find("Panel/Frame/Emblems/Light").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_BuySlotTween.gameObject.SetActive(false);
			DlgHandlerBase.EnsureCreate<XEmbleAttrView<XAttrPlayerFile>>(ref this.embleAttrView, this.TotalAttriPanel, false, this);
			this._doc = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			this._doc._EquipHandler = this;
			this._smeltDoc = XSmeltDocument.Doc;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowEquipments();
			this.m_BuySlotTween.gameObject.SetActive(false);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.ShowEquipments();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XEmbleAttrView<XAttrPlayerFile>>(ref this.embleAttrView);
			this._doc._EquipHandler = null;
			base.OnUnload();
		}

		public void ShowEquipments()
		{
			this._doc.UpdateEquipLockState(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			this._doc.UpdateEquipSlottingState();
			XBodyBag emblemBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag;
			EmblemSlotStatus[] equipLock = this._doc.EquipLock;
			for (int i = XEmblemDocument.Position_TotalStart; i < XEmblemDocument.Position_TotalEnd; i++)
			{
				this.SetSlot(i, emblemBag[i], equipLock[i - XEmblemDocument.Position_TotalStart]);
			}
		}

		public void SetSlot(int slot, XItem item, EmblemSlotStatus slotStatus = null)
		{
			int num = slot - XEmblemDocument.Position_TotalStart;
			bool flag = slotStatus != null && slotStatus.IsLock;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_EmblemBg[num], null);
				this.m_EmblemSlots[num].RegisterSpriteClickEventHandler(null);
				this.m_EmblemBg[num].transform.FindChild("RedPoint").gameObject.SetActive(false);
				this.m_EmblemSlotCovers[num].SetVisible(true);
				this.m_EmblemP[num].gameObject.SetActive(!slotStatus.LevelIsdOpen);
			}
			else
			{
				bool flag2 = item == null || item.itemID == 0 || (ulong)item.type != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM));
				if (flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_EmblemBg[num], null);
					this.m_EmblemSlotCovers[num].SetVisible(false);
					this.m_EmblemP[num].SetVisible(false);
					this.m_EmblemSlots[num].RegisterSpriteClickEventHandler(null);
					this.m_EmblemBg[num].transform.FindChild("RedPoint").gameObject.SetActive(false);
				}
				else
				{
					this.m_EmblemSlotCovers[num].SetVisible(false);
					this.m_EmblemP[num].SetVisible(false);
					XItemDrawerMgr.Param.bHideBinding = true;
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_EmblemBg[num], item);
					bool flag3 = this.m_finalHandle == null;
					if (flag3)
					{
						this.m_EmblemSlots[num].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(CharacterEquipHandler.OnItemClicked));
					}
					this.m_EmblemSlots[num].ID = item.uid;
					bool active = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Smelting) && this._smeltDoc.IsHadRedDot(item);
					this.m_EmblemBg[num].transform.FindChild("RedPoint").gameObject.SetActive(active);
				}
			}
		}

		public void RegisterItemClickEvents(SpriteClickEventHandler handle = null)
		{
			this.m_finalHandle = handle;
			bool flag = this.m_finalHandle == null;
			if (flag)
			{
				for (int i = 0; i < EmblemEquipView.Emblem_Slot_Count; i++)
				{
					this.m_EmblemSlots[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(CharacterEquipHandler.OnItemClicked));
				}
			}
			else
			{
				for (int j = 0; j < EmblemEquipView.Emblem_Slot_Count; j++)
				{
					this.m_EmblemSlots[j].RegisterSpriteClickEventHandler(this.m_finalHandle);
				}
			}
		}

		public void OnSlotBgClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EMBLEM_SLOT_NO_SELECT"), "fece00");
		}

		public bool OnClickEmblemAccess(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_EquipCreate_EmblemSet, 0UL);
			return true;
		}

		public bool OnClickAttriBtn(IXUIButton btn)
		{
			this.embleAttrView.SetBaseData(XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag);
			this.embleAttrView.SetVisible(true);
			return true;
		}

		public void OnSlotCoverClicked(IXUISprite iSp)
		{
			EmblemSlotStatus[] equipLock = this._doc.EquipLock;
			checked
			{
				bool flag = equipLock[(int)((IntPtr)iSp.ID)] == null;
				if (!flag)
				{
					this.m_slottingSlot = iSp.ID;
					bool isLock = equipLock[(int)((IntPtr)iSp.ID)].IsLock;
					if (isLock)
					{
						List<uint> emblemSlotUnlockLevel = this._doc.emblemSlotUnlockLevel;
						int num = unchecked((int)iSp.ID);
						bool flag2 = !equipLock[(int)((IntPtr)iSp.ID)].LevelIsdOpen;
						if (flag2)
						{
							bool flag3 = num < XEmblemDocument.Position_AttrEnd;
							string @string;
							if (flag3)
							{
								@string = XStringDefineProxy.GetString("EMBLEM_ATTR");
							}
							else
							{
								@string = XStringDefineProxy.GetString("EMBLEM_SKILL");
							}
							XSingleton<UiUtility>.singleton.ShowSystemTip(@string + XStringDefineProxy.GetString("EMBLEM_SLOT_OPEN_AT_LEVEL", new object[]
							{
								emblemSlotUnlockLevel[num]
							}), "ff0000");
						}
						else
						{
							bool flag4 = !equipLock[(int)((IntPtr)iSp.ID)].HadSlotting;
							if (flag4)
							{
								int num2 = this._doc.IsCanSlotting(equipLock[(int)((IntPtr)iSp.ID)].Slot);
								bool flag5 = num2 == 0;
								if (flag5)
								{
									XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("SlotThisEmblemNeedMoney"), this._doc.SlottingNeedMoney(equipLock[(int)((IntPtr)iSp.ID)].Slot)), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.EmblemSlotting));
								}
								else
								{
									bool flag6 = num2 == 1;
									if (flag6)
									{
										XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NeedUnlockLastSlotting"), "fece00");
									}
								}
							}
						}
					}
				}
			}
		}

		public void PlayBuySlotFx(int index)
		{
			bool flag = index >= this.m_EmblemBg.Length;
			if (!flag)
			{
				this.m_BuySlotTween.gameObject.transform.localPosition = this.m_EmblemBg[index].transform.localPosition;
				this.m_BuySlotTween.PlayTween(true, -1f);
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_winfavor", true, AudioChannel.Action);
			}
		}

		private bool EmblemSlotting(IXUIButton btn)
		{
			this._doc.ReqEmbleSlotting(this.m_slottingSlot);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		public static void OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID != null;
			if (flag)
			{
				bool flag2 = XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag.HasItem(itemByUID.uid);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowTooltipDialog(itemByUID, null, iSp, true, 0U);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(itemByUID, iSp, true, 0U);
				}
			}
		}

		public XEmblemDocument _doc;

		public XSmeltDocument _smeltDoc;

		public static int Emblem_Slot_Count = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		public GameObject[] m_EmblemBg = new GameObject[EmblemEquipView.Emblem_Slot_Count];

		public IXUISprite[] m_EmblemSlots = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		public IXUISprite[] m_EmblemSlotCovers = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		public IXUISprite[] m_EmblemP = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		public IXUISprite[] m_EmblemSlotBgs = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		public XUIPool m_EmblemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XEmbleAttrView<XAttrPlayerFile> embleAttrView;

		private Transform TotalAttriPanel;

		private IXUITweenTool m_BuySlotTween;

		private SpriteClickEventHandler m_finalHandle = null;

		private ulong m_slottingSlot = 0UL;
	}
}
