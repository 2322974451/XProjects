using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class JadeEquipHandler : DlgHandlerBase
	{

		public CharacterEquipHandler EquipHandler
		{
			get
			{
				return this.m_EquipHandler;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeEquipFrame";
			}
		}

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

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Jade);
			return true;
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
			XEquipItem equipNew = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
			this.SetEquipNew(equipNew);
		}

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

		protected override void OnHide()
		{
			this.m_EquipHandler.SetVisible(false);
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.powerfullMgr.Unload();
			this._doc.equipHandler = null;
			DlgHandlerBase.EnsureUnload<CharacterEquipHandler>(ref this.m_EquipHandler);
			base.OnUnload();
		}

		public void OnEquipClick(IXUISprite iSp)
		{
			this._doc.SelectEquip(iSp.ID);
		}

		public void OnSelectedEquipClick(IXUISprite iSp)
		{
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(xequipItem, null, iSp, false, 0U);
			}
		}

		private bool OnJadeShopClick(IXUIButton sp)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(198, null);
			return true;
		}

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

		public static void DrawJadeWithAttr(GameObject go, uint slot, XJadeItem jade, uint iconType = 1U)
		{
			XItemDrawerMgr.Param.IconType = iconType;
			XSingleton<XItemDrawerMgr>.singleton.jadeSlotDrawer.DrawItem(go.transform.Find("JadeTpl").gameObject, slot, false, jade);
			JadeEquipHandler.DrawAttr(go, jade);
		}

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

		private bool _OnSelectedJadeUpgradeClicked(IXUIButton btn)
		{
			this._doc.TryToCompose((uint)this.m_SelectedSlotIndex);
			return true;
		}

		private bool _OnSelectedJadeTakeoffClicked(IXUIButton btn)
		{
			this._doc.ReqTakeOffJade((uint)this.m_SelectedSlotIndex);
			return true;
		}

		private bool _OnSelectedJadeChangeClicked(IXUIButton btn)
		{
			this._doc.SelectSlot(this.m_SelectedSlotIndex);
			return true;
		}

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

		private XJadeDocument _doc = null;

		private static uint SLOT_COUNT = 4U;

		private XUIPool m_JadeInfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<GameObject> m_JadeSlots = new List<GameObject>();

		private CharacterEquipHandler m_EquipHandler;

		private GameObject m_SelectedEquip;

		private GameObject m_EmptyEquiped;

		private GameObject m_EquipedPanel;

		private GameObject m_SelectMenu;

		private GameObject m_OperateMenu;

		private IXUITweenTool m_SelectMenuTween;

		private GameObject m_CanReplaceRedpoint;

		private GameObject m_CanUpdateRedpoint;

		private XUIPool m_JadeSlotSmallPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private GameObject m_EquipFrame;

		private GameObject[] m_JadeEquip = new GameObject[10];

		private GameObject[,] m_JadeEquipItem;

		private XItemMorePowerfulTipMgr powerfullMgr = new XItemMorePowerfulTipMgr();

		private IXUIButton m_JadeShop;

		private IXUIButton m_JadeUnload;

		private IXUIButton m_Help;

		private int m_SelectedSlotIndex;

		private string[][] m_SlotLevelLimit;
	}
}
