using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001914 RID: 6420
	internal class EmblemEquipView : DlgHandlerBase
	{
		// Token: 0x06010CAF RID: 68783 RVA: 0x004378D0 File Offset: 0x00435AD0
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

		// Token: 0x17003AE2 RID: 15074
		// (get) Token: 0x06010CB0 RID: 68784 RVA: 0x0043790C File Offset: 0x00435B0C
		protected override string FileName
		{
			get
			{
				return "ItemNew/EmblemOperateFrame";
			}
		}

		// Token: 0x06010CB1 RID: 68785 RVA: 0x00437924 File Offset: 0x00435B24
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

		// Token: 0x06010CB2 RID: 68786 RVA: 0x00437BE2 File Offset: 0x00435DE2
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowEquipments();
			this.m_BuySlotTween.gameObject.SetActive(false);
		}

		// Token: 0x06010CB3 RID: 68787 RVA: 0x00437C05 File Offset: 0x00435E05
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.ShowEquipments();
		}

		// Token: 0x06010CB4 RID: 68788 RVA: 0x00437C16 File Offset: 0x00435E16
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XEmbleAttrView<XAttrPlayerFile>>(ref this.embleAttrView);
			this._doc._EquipHandler = null;
			base.OnUnload();
		}

		// Token: 0x06010CB5 RID: 68789 RVA: 0x00437C38 File Offset: 0x00435E38
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

		// Token: 0x06010CB6 RID: 68790 RVA: 0x00437CC0 File Offset: 0x00435EC0
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

		// Token: 0x06010CB7 RID: 68791 RVA: 0x00437EA8 File Offset: 0x004360A8
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

		// Token: 0x06010CB8 RID: 68792 RVA: 0x00437F2C File Offset: 0x0043612C
		public void OnSlotBgClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EMBLEM_SLOT_NO_SELECT"), "fece00");
		}

		// Token: 0x06010CB9 RID: 68793 RVA: 0x00437F4C File Offset: 0x0043614C
		public bool OnClickEmblemAccess(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_EquipCreate_EmblemSet, 0UL);
			return true;
		}

		// Token: 0x06010CBA RID: 68794 RVA: 0x00437F74 File Offset: 0x00436174
		public bool OnClickAttriBtn(IXUIButton btn)
		{
			this.embleAttrView.SetBaseData(XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag);
			this.embleAttrView.SetVisible(true);
			return true;
		}

		// Token: 0x06010CBB RID: 68795 RVA: 0x00437FB4 File Offset: 0x004361B4
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

		// Token: 0x06010CBC RID: 68796 RVA: 0x0043815C File Offset: 0x0043635C
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

		// Token: 0x06010CBD RID: 68797 RVA: 0x004381CC File Offset: 0x004363CC
		private bool EmblemSlotting(IXUIButton btn)
		{
			this._doc.ReqEmbleSlotting(this.m_slottingSlot);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x06010CBE RID: 68798 RVA: 0x004381FC File Offset: 0x004363FC
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

		// Token: 0x04007B2D RID: 31533
		public XEmblemDocument _doc;

		// Token: 0x04007B2E RID: 31534
		public XSmeltDocument _smeltDoc;

		// Token: 0x04007B2F RID: 31535
		public static int Emblem_Slot_Count = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);

		// Token: 0x04007B30 RID: 31536
		public GameObject[] m_EmblemBg = new GameObject[EmblemEquipView.Emblem_Slot_Count];

		// Token: 0x04007B31 RID: 31537
		public IXUISprite[] m_EmblemSlots = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		// Token: 0x04007B32 RID: 31538
		public IXUISprite[] m_EmblemSlotCovers = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		// Token: 0x04007B33 RID: 31539
		public IXUISprite[] m_EmblemP = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		// Token: 0x04007B34 RID: 31540
		public IXUISprite[] m_EmblemSlotBgs = new IXUISprite[EmblemEquipView.Emblem_Slot_Count];

		// Token: 0x04007B35 RID: 31541
		public XUIPool m_EmblemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007B36 RID: 31542
		private XEmbleAttrView<XAttrPlayerFile> embleAttrView;

		// Token: 0x04007B37 RID: 31543
		private Transform TotalAttriPanel;

		// Token: 0x04007B38 RID: 31544
		private IXUITweenTool m_BuySlotTween;

		// Token: 0x04007B39 RID: 31545
		private SpriteClickEventHandler m_finalHandle = null;

		// Token: 0x04007B3A RID: 31546
		private ulong m_slottingSlot = 0UL;
	}
}
