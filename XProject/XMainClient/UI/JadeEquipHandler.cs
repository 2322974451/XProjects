using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200191E RID: 6430
	internal class JadeEquipHandler : DlgHandlerBase
	{
		// Token: 0x17003AF1 RID: 15089
		// (get) Token: 0x06010D26 RID: 68902 RVA: 0x0043B9AC File Offset: 0x00439BAC
		public CharacterEquipHandler EquipHandler
		{
			get
			{
				return this.m_EquipHandler;
			}
		}

		// Token: 0x17003AF2 RID: 15090
		// (get) Token: 0x06010D27 RID: 68903 RVA: 0x0043B9C4 File Offset: 0x00439BC4
		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeEquipFrame";
			}
		}

		// Token: 0x06010D28 RID: 68904 RVA: 0x0043B9DC File Offset: 0x00439BDC
		protected override void Init()
		{
			base.Init();
			this.m_SlotLevelLimit = new string[XSingleton<XGlobalConfig>.singleton.MaxEquipPosType + 1][];
			JadeEquipHandler.SLOT_COUNT = 0U;
			for (int i = 1; i <= XSingleton<XGlobalConfig>.singleton.MaxEquipPosType; i++)
			{
				this.m_SlotLevelLimit[i] = XSingleton<XGlobalConfig>.singleton.GetValue("JadeOpenLevel" + i).Split(XGlobalConfig.ListSeparator);
				bool flag = JadeEquipHandler.SLOT_COUNT == 0U;
				if (flag)
				{
					JadeEquipHandler.SLOT_COUNT = (uint)this.m_SlotLevelLimit[i].Length;
				}
				else
				{
					bool flag2 = JadeEquipHandler.SLOT_COUNT != (uint)this.m_SlotLevelLimit[i].Length;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("JadeOpenLevels are not the same.", null, null, null, null, null);
					}
				}
			}
			this.m_JadeEquipItem = new GameObject[XBagDocument.EquipMax, (int)JadeEquipHandler.SLOT_COUNT];
			this._doc = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			this._doc.equipHandler = this;
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_EquipedPanel = base.PanelObject.transform.Find("EquipedPanel").gameObject;
			this.m_SelectMenu = this.m_EquipedPanel.transform.Find("SelectMenu").gameObject;
			this.m_OperateMenu = this.m_EquipedPanel.transform.Find("OperateMenu").gameObject;
			this.m_EmptyEquiped = base.PanelObject.transform.Find("Empty").gameObject;
			this.m_SelectMenuTween = (this.m_SelectMenu.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_CanReplaceRedpoint = this.m_OperateMenu.transform.Find("BtnChange/RedPoint").gameObject;
			this.m_CanUpdateRedpoint = this.m_OperateMenu.transform.Find("BtnUpgrade/RedPoint").gameObject;
			this.m_SelectedEquip = base.PanelObject.transform.Find("SelectedEquip").gameObject;
			Transform transform = this.m_EquipedPanel.transform.FindChild("JadeInfoTpl");
			this.powerfullMgr.LoadFromUI(transform.Find("RedPoint").gameObject);
			this.powerfullMgr.SetupPool(base.PanelObject);
			this.m_JadeInfoPool.SetupPool(transform.parent.gameObject, transform.gameObject, JadeEquipHandler.SLOT_COUNT, false);
			int num = 0;
			while ((long)num < (long)((ulong)JadeEquipHandler.SLOT_COUNT))
			{
				GameObject gameObject = this.m_JadeInfoPool.FetchGameObject(false);
				gameObject.transform.localPosition = this.m_EquipedPanel.transform.Find("Pos" + num).localPosition;
				this.m_JadeSlots.Add(gameObject);
				num++;
			}
			this.m_EquipFrame = base.PanelObject.transform.FindChild("EquipFrame").gameObject;
			this.m_JadeSlotSmallPool.SetupPool(this.m_EquipFrame, this.m_EquipFrame.transform.FindChild("JadeTpl").gameObject, 10U, false);
			for (int j = 0; j < 10; j++)
			{
				GameObject gameObject2 = this.m_EquipFrame.transform.FindChild("Part" + j).gameObject;
				GameObject gameObject3 = this.m_JadeSlotSmallPool.FetchGameObject(false);
				this.m_JadeEquip[j] = gameObject3;
				XSingleton<UiUtility>.singleton.AddChild(this.m_EquipFrame, gameObject3);
				gameObject3.transform.localPosition = gameObject2.transform.localPosition;
				int num2 = 0;
				while ((long)num2 < (long)((ulong)JadeEquipHandler.SLOT_COUNT))
				{
					transform = gameObject3.transform.FindChild("Jade" + num2);
					bool flag3 = transform != null;
					if (flag3)
					{
						this.m_JadeEquipItem[j, num2] = transform.gameObject;
					}
					else
					{
						this.m_JadeEquipItem[j, num2] = null;
					}
					num2++;
				}
			}
			this.m_JadeShop = (base.PanelObject.transform.FindChild("JadeShop").GetComponent("XUIButton") as IXUIButton);
			this.m_JadeUnload = (base.PanelObject.transform.FindChild("JadeUnload").GetComponent("XUIButton") as IXUIButton);
			DlgHandlerBase.EnsureCreate<CharacterEquipHandler>(ref this.m_EquipHandler, this.m_EquipFrame, this, true);
			this.m_EquipHandler.ShowNormalEquip(true);
			this.m_EquipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this.OnEquipClick));
		}

		// Token: 0x06010D29 RID: 68905 RVA: 0x0043BEA8 File Offset: 0x0043A0A8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_JadeShop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJadeShopClick));
			this.m_JadeUnload.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJadeUnloadClick));
			IXUIButton ixuibutton = this.m_OperateMenu.transform.Find("BtnUpgrade").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = this.m_SelectMenu.transform.Find("BtnTakeoff").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton3 = this.m_OperateMenu.transform.Find("BtnChange").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSelectedJadeUpgradeClicked));
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSelectedJadeTakeoffClicked));
			ixuibutton3.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSelectedJadeChangeClicked));
			IXUISprite ixuisprite = this.m_SelectedEquip.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedEquipClick));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x06010D2A RID: 68906 RVA: 0x0043BFEC File Offset: 0x0043A1EC
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Jade);
			return true;
		}

		// Token: 0x06010D2B RID: 68907 RVA: 0x0043C00C File Offset: 0x0043A20C
		protected override void OnShow()
		{
			base.OnShow();
			this.m_EquipHandler.SetVisible(true);
			List<int> powerfulEquips = this._doc.UpdateRedPoints();
			for (int i = 0; i < XBagDocument.BagDoc.EquipBag.Length; i++)
			{
				XItem xitem = XBagDocument.BagDoc.EquipBag[i];
				bool flag = xitem == null || xitem.itemID == 0;
				if (flag)
				{
					this.m_JadeEquip[i].SetActive(false);
				}
				else
				{
					this.m_JadeEquip[i].SetActive(true);
					this.RefreshSmallJade(i);
				}
			}
			this._DefaultSelect(powerfulEquips);
		}

		// Token: 0x06010D2C RID: 68908 RVA: 0x0043C0B4 File Offset: 0x0043A2B4
		private void _DefaultSelect(List<int> powerfulEquips)
		{
			int[] array = new int[]
			{
				4,
				3,
				2,
				1,
				0,
				9,
				8,
				7,
				6,
				5
			};
			int num = -1;
			int num2 = -1;
			XBodyBag equipBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag;
			for (int i = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START); i < XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_END); i++)
			{
				int num3 = int.MinValue;
				XItem xitem = equipBag[i];
				bool flag = xitem != null && xitem.itemID != 0;
				if (flag)
				{
					num3 = array[i];
					for (int j = 0; j < powerfulEquips.Count; j++)
					{
						bool flag2 = powerfulEquips[j] == i;
						if (flag2)
						{
							num3 += 10;
							break;
						}
					}
				}
				bool flag3 = num < num3;
				if (flag3)
				{
					num = num3;
					num2 = i;
				}
			}
			bool flag4 = num2 >= 0;
			if (flag4)
			{
				XItem xitem2 = equipBag[num2];
				this._doc.SelectEquip(xitem2.uid);
			}
			else
			{
				this._doc.SelectEquip(0UL);
			}
		}

		// Token: 0x06010D2D RID: 68909 RVA: 0x0043C1D0 File Offset: 0x0043A3D0
		public override void StackRefresh()
		{
			base.StackRefresh();
			XEquipItem equipNew = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
			this.SetEquipNew(equipNew);
		}

		// Token: 0x06010D2E RID: 68910 RVA: 0x0043C214 File Offset: 0x0043A414
		private void RefreshSmallJade(int pos)
		{
			XItem xitem = XBagDocument.BagDoc.EquipBag[pos];
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(xitem.uid) as XEquipItem;
			int i = 0;
			bool flag = xequipItem != null;
			if (flag)
			{
				SeqListRef<uint> slotInfoByPos = this._doc.GetSlotInfoByPos((byte)pos);
				while (i < (int)slotInfoByPos.count)
				{
					bool flag2 = (long)i >= (long)((ulong)JadeEquipHandler.SLOT_COUNT);
					if (flag2)
					{
						break;
					}
					GameObject gameObject = this.m_JadeEquipItem[pos, i];
					bool flag3 = gameObject != null;
					if (flag3)
					{
						XJadeItem xjadeItem = xequipItem.jadeInfo.jades[i];
						bool flag4 = this._doc.SlotLevelIsOpen((byte)pos, i);
						if (flag4)
						{
							gameObject.SetActive(true);
							GameObject gameObject2 = gameObject.transform.Find("Icon").gameObject;
							gameObject2.SetActive(xjadeItem != null);
						}
						else
						{
							gameObject.SetActive(false);
						}
					}
					i++;
				}
				while ((long)i < (long)((ulong)JadeEquipHandler.SLOT_COUNT))
				{
					GameObject gameObject3 = this.m_JadeEquipItem[pos, i];
					bool flag5 = gameObject3 != null;
					if (flag5)
					{
						gameObject3.SetActive(false);
					}
					i++;
				}
			}
		}

		// Token: 0x06010D2F RID: 68911 RVA: 0x0043C362 File Offset: 0x0043A562
		protected override void OnHide()
		{
			this.m_EquipHandler.SetVisible(false);
			base.OnHide();
		}

		// Token: 0x06010D30 RID: 68912 RVA: 0x0043C379 File Offset: 0x0043A579
		public override void OnUnload()
		{
			this.powerfullMgr.Unload();
			this._doc.equipHandler = null;
			DlgHandlerBase.EnsureUnload<CharacterEquipHandler>(ref this.m_EquipHandler);
			base.OnUnload();
		}

		// Token: 0x06010D31 RID: 68913 RVA: 0x0043C3A7 File Offset: 0x0043A5A7
		public void OnEquipClick(IXUISprite iSp)
		{
			this._doc.SelectEquip(iSp.ID);
		}

		// Token: 0x06010D32 RID: 68914 RVA: 0x0043C3BC File Offset: 0x0043A5BC
		public void OnSelectedEquipClick(IXUISprite iSp)
		{
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(xequipItem, null, iSp, false, 0U);
			}
		}

		// Token: 0x06010D33 RID: 68915 RVA: 0x0043C40C File Offset: 0x0043A60C
		private bool OnJadeShopClick(IXUIButton sp)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(198, null);
			return true;
		}

		// Token: 0x06010D34 RID: 68916 RVA: 0x0043C430 File Offset: 0x0043A630
		private bool OnJadeUnloadClick(IXUIButton sp)
		{
			XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			bool flag = specificDocument.selectedEquip == 0UL;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("JADE_DIALOG_NOEQUIP"), "fece00");
				result = false;
			}
			else
			{
				RpcC2G_TakeOffAllJade rpcC2G_TakeOffAllJade = new RpcC2G_TakeOffAllJade();
				rpcC2G_TakeOffAllJade.oArg.uid = specificDocument.selectedEquip;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TakeOffAllJade);
				result = true;
			}
			return result;
		}

		// Token: 0x06010D35 RID: 68917 RVA: 0x0043C4A0 File Offset: 0x0043A6A0
		public void SetEquipNew(XEquipItem equip)
		{
			this.m_EquipHandler.ShowEquipments();
			this._ToggleOperateMenu(false, 0);
			this.m_JadeSlots.Clear();
			this.m_JadeInfoPool.FakeReturnAll();
			XItemDrawerMgr.Param.bHideBinding = true;
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_SelectedEquip, equip);
			this.m_EmptyEquiped.SetActive(equip == null);
			this.m_EquipedPanel.SetActive(equip != null);
			bool flag = equip != null;
			if (flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(equip.itemID);
				bool flag2 = equipConf == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("equipListRowData == null while id = ", equip.itemID.ToString(), null, null, null, null);
					return;
				}
				bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
				if (flag3)
				{
					return;
				}
				uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				SeqListRef<uint> slotInfoByPos = this._doc.GetSlotInfoByPos(equipConf.EquipPos);
				for (int i = 0; i < (int)slotInfoByPos.count; i++)
				{
					bool flag4 = (long)i >= (long)((ulong)JadeEquipHandler.SLOT_COUNT);
					if (flag4)
					{
						break;
					}
					GameObject gameObject = this.m_JadeInfoPool.FetchGameObject(false);
					gameObject.transform.localPosition = this.m_EquipedPanel.transform.Find("Pos" + i.ToString()).localPosition;
					this.m_JadeSlots.Add(gameObject);
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)i);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSlotClicked));
					GameObject gameObject2 = gameObject.transform.Find("HasJade").gameObject;
					GameObject gameObject3 = gameObject.transform.Find("Empty").gameObject;
					GameObject gameObject4 = gameObject.transform.Find("Lock").gameObject;
					bool flag5 = level >= slotInfoByPos[i, 1];
					if (flag5)
					{
						XJadeItem xjadeItem = equip.jadeInfo.jades[i];
						gameObject2.SetActive(xjadeItem != null);
						gameObject3.SetActive(xjadeItem == null);
						gameObject4.SetActive(false);
						bool flag6 = xjadeItem != null;
						if (flag6)
						{
							xjadeItem.bBinding = false;
							JadeEquipHandler.DrawJadeWithAttr(gameObject2, slotInfoByPos[i, 0], xjadeItem, 1U);
						}
						else
						{
							JadeEquipHandler.DrawJadeWithAttr(gameObject3, slotInfoByPos[i, 0], xjadeItem, 1U);
						}
					}
					else
					{
						gameObject2.SetActive(false);
						gameObject3.SetActive(false);
						gameObject4.SetActive(true);
						IXUILabel ixuilabel = gameObject4.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(slotInfoByPos[i, 1].ToString());
					}
				}
				int pos;
				bool flag7 = !XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag.GetItemPos(equip.uid, out pos);
				if (flag7)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("No Find Equip uid=" + equip.uid, null, null, null, null, null);
					return;
				}
				this.RefreshSmallJade(pos);
			}
			this.m_JadeInfoPool.ActualReturnAll(false);
			int num = this.RecalcMorePowerfulTip();
			bool flag8 = num >= 0;
			if (flag8)
			{
				this._ToggleOperateMenu(true, num);
			}
		}

		// Token: 0x06010D36 RID: 68918 RVA: 0x0043C810 File Offset: 0x0043AA10
		public static void DrawJadeWithAttr(GameObject go, uint slot, XJadeItem jade, uint iconType = 1U)
		{
			XItemDrawerMgr.Param.IconType = iconType;
			XSingleton<XItemDrawerMgr>.singleton.jadeSlotDrawer.DrawItem(go.transform.Find("JadeTpl").gameObject, slot, false, jade);
			JadeEquipHandler.DrawAttr(go, jade);
		}

		// Token: 0x06010D37 RID: 68919 RVA: 0x0043C850 File Offset: 0x0043AA50
		public static void DrawAttr(GameObject go, XJadeItem jade)
		{
			bool flag = jade != null;
			if (flag)
			{
				IXUILabel ixuilabel = go.transform.Find("AttrName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = go.transform.Find("AttrValue").GetComponent("XUILabel") as IXUILabel;
				ItemList.RowData itemConf = XBagDocument.GetItemConf(jade.itemID);
				bool flag2 = itemConf != null && jade.changeAttr.Count > 0;
				if (flag2)
				{
					ixuilabel.SetText(XAttributeCommon.GetAttrStr((int)jade.changeAttr[0].AttrID));
					ixuilabel2.SetText(XAttributeCommon.GetAttrValueStr(jade.changeAttr[0].AttrID, jade.changeAttr[0].AttrValue, true));
					Color itemQualityColor = XSingleton<UiUtility>.singleton.GetItemQualityColor((int)itemConf.ItemQuality);
					ixuilabel.SetColor(itemQualityColor);
					ixuilabel2.SetColor(itemQualityColor);
				}
				else
				{
					ixuilabel.SetText(string.Empty);
					ixuilabel2.SetText(string.Empty);
				}
			}
		}

		// Token: 0x06010D38 RID: 68920 RVA: 0x0043C960 File Offset: 0x0043AB60
		private void _OnSlotClicked(IXUISprite iSp)
		{
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					int num = (int)iSp.ID;
					XJadeItem xjadeItem = xequipItem.jadeInfo.jades[num];
					bool flag3 = !this._doc.SlotLevelIsOpen(equipConf.EquipPos, num);
					if (!flag3)
					{
						bool flag4 = xjadeItem != null;
						if (flag4)
						{
							this._ToggleOperateMenu(true, num);
						}
						else
						{
							uint slot = this._doc.GetSlot(equipConf.EquipPos, num);
							bool flag5 = slot != XJadeInfo.SLOT_NOTOPEN && slot != XJadeInfo.SLOT_NOTEXIST;
							if (flag5)
							{
								this._doc.SelectSlot(num);
							}
						}
					}
				}
			}
		}

		// Token: 0x06010D39 RID: 68921 RVA: 0x0043CA4C File Offset: 0x0043AC4C
		private void _ToggleOperateMenu(bool bShow, int slotIndex = 0)
		{
			if (bShow)
			{
				this.m_SelectedSlotIndex = slotIndex;
				this.m_SelectMenu.SetActive(true);
				this.m_OperateMenu.SetActive(true);
				this.m_SelectMenuTween.PlayTween(true, -1f);
				XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
				bool flag = xequipItem == null;
				if (flag)
				{
					this.m_CanReplaceRedpoint.SetActive(false);
				}
				this.m_CanReplaceRedpoint.SetActive(this._doc.CanReplace(xequipItem, slotIndex));
				this.m_CanUpdateRedpoint.SetActive(this._doc.CanUpdate(xequipItem, slotIndex));
				this.m_SelectMenu.transform.localPosition = this.m_JadeSlots[this.m_SelectedSlotIndex].transform.localPosition;
			}
			else
			{
				this.m_SelectMenu.SetActive(false);
				this.m_OperateMenu.SetActive(false);
			}
		}

		// Token: 0x06010D3A RID: 68922 RVA: 0x0043CB50 File Offset: 0x0043AD50
		private bool _OnSelectedJadeUpgradeClicked(IXUIButton btn)
		{
			this._doc.TryToCompose((uint)this.m_SelectedSlotIndex);
			return true;
		}

		// Token: 0x06010D3B RID: 68923 RVA: 0x0043CB78 File Offset: 0x0043AD78
		private bool _OnSelectedJadeTakeoffClicked(IXUIButton btn)
		{
			this._doc.ReqTakeOffJade((uint)this.m_SelectedSlotIndex);
			return true;
		}

		// Token: 0x06010D3C RID: 68924 RVA: 0x0043CBA0 File Offset: 0x0043ADA0
		private bool _OnSelectedJadeChangeClicked(IXUIButton btn)
		{
			this._doc.SelectSlot(this.m_SelectedSlotIndex);
			return true;
		}

		// Token: 0x06010D3D RID: 68925 RVA: 0x0043CBC8 File Offset: 0x0043ADC8
		public int RecalcMorePowerfulTip()
		{
			int num = -1;
			bool flag = false;
			this.powerfullMgr.ReturnAll();
			bool flag2 = this._doc.selectedEquip == 0UL;
			int result;
			if (flag2)
			{
				result = num;
			}
			else
			{
				XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
				bool flag3 = xequipItem == null;
				if (flag3)
				{
					result = num;
				}
				else
				{
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
					bool flag4 = equipConf == null;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("equipListRowData == null while id = ", xequipItem.itemID.ToString(), null, null, null, null);
						result = num;
					}
					else
					{
						SeqListRef<uint> slotInfoByPos = this._doc.GetSlotInfoByPos(equipConf.EquipPos);
						int num2 = 0;
						while ((long)num2 < (long)((ulong)JadeEquipHandler.SLOT_COUNT) && num2 < (int)slotInfoByPos.count)
						{
							bool flag5 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null || slotInfoByPos[num2, 1] > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
							if (!flag5)
							{
								bool flag6 = false;
								bool flag7 = false;
								bool flag8 = this._doc.CanUpdate(xequipItem, num2);
								if (flag8)
								{
									flag6 = true;
								}
								else
								{
									bool flag9 = this._doc.CanReplace(xequipItem, num2);
									if (flag9)
									{
										XJadeItem xjadeItem = xequipItem.jadeInfo.jades[num2];
										bool flag10 = xjadeItem != null;
										if (!flag10)
										{
											flag7 = true;
										}
										flag6 = true;
									}
								}
								bool flag11 = flag6;
								if (flag11)
								{
									GameObject gameObject = this.m_JadeSlots[num2];
									IXUISprite tip = gameObject.GetComponent("XUISprite") as IXUISprite;
									this.powerfullMgr.SetTip(tip);
									bool flag12 = !flag && !flag7;
									if (flag12)
									{
										num = num2;
										flag = true;
									}
								}
								else
								{
									bool flag13 = num < 0;
									if (flag13)
									{
										bool flag14 = XJadeInfo.SlotHasJade(num2, xequipItem.jadeInfo);
										if (flag14)
										{
											num = num2;
										}
									}
								}
							}
							num2++;
						}
						result = num;
					}
				}
			}
			return result;
		}

		// Token: 0x04007B75 RID: 31605
		private XJadeDocument _doc = null;

		// Token: 0x04007B76 RID: 31606
		private static uint SLOT_COUNT = 4U;

		// Token: 0x04007B77 RID: 31607
		private XUIPool m_JadeInfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007B78 RID: 31608
		private List<GameObject> m_JadeSlots = new List<GameObject>();

		// Token: 0x04007B79 RID: 31609
		private CharacterEquipHandler m_EquipHandler;

		// Token: 0x04007B7A RID: 31610
		private GameObject m_SelectedEquip;

		// Token: 0x04007B7B RID: 31611
		private GameObject m_EmptyEquiped;

		// Token: 0x04007B7C RID: 31612
		private GameObject m_EquipedPanel;

		// Token: 0x04007B7D RID: 31613
		private GameObject m_SelectMenu;

		// Token: 0x04007B7E RID: 31614
		private GameObject m_OperateMenu;

		// Token: 0x04007B7F RID: 31615
		private IXUITweenTool m_SelectMenuTween;

		// Token: 0x04007B80 RID: 31616
		private GameObject m_CanReplaceRedpoint;

		// Token: 0x04007B81 RID: 31617
		private GameObject m_CanUpdateRedpoint;

		// Token: 0x04007B82 RID: 31618
		private XUIPool m_JadeSlotSmallPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007B83 RID: 31619
		private GameObject m_EquipFrame;

		// Token: 0x04007B84 RID: 31620
		private GameObject[] m_JadeEquip = new GameObject[10];

		// Token: 0x04007B85 RID: 31621
		private GameObject[,] m_JadeEquipItem;

		// Token: 0x04007B86 RID: 31622
		private XItemMorePowerfulTipMgr powerfullMgr = new XItemMorePowerfulTipMgr();

		// Token: 0x04007B87 RID: 31623
		private IXUIButton m_JadeShop;

		// Token: 0x04007B88 RID: 31624
		private IXUIButton m_JadeUnload;

		// Token: 0x04007B89 RID: 31625
		private IXUIButton m_Help;

		// Token: 0x04007B8A RID: 31626
		private int m_SelectedSlotIndex;

		// Token: 0x04007B8B RID: 31627
		private string[][] m_SlotLevelLimit;
	}
}
