using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EquipTooltipDlg : TooltipDlg<EquipTooltipDlg, EquipTooltipDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/EquipToolTipDlg";
			}
		}

		protected override int compareWindowDistance
		{
			get
			{
				return 20;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperatePutOn();
			this.m_OperateList[0, 1] = new TooltipButtonOperateEnhanceTransform();
			this.m_OperateList[0, 2] = new TooltipButtonOperateEnchantTransform();
			this.m_OperateList[0, 3] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Item_Equip);
			this.m_OperateList[0, 4] = new TooltipButtonOperateSmeltReturn();
			this.m_OperateList[1, 0] = new TooltipButtonOperateTakeOff();
			this.m_OperateList[1, 1] = new TooltipButtonOperateEnhance();
			this.m_OperateList[1, 2] = new TooltipButtonOperateSmelt();
			this.m_OperateList[1, 3] = new TooltipButtonOperateForge();
			this.m_OperateList[1, 4] = new TooltipButtonOperateEnchant();
			this.m_OperateList[1, 5] = new TooltipButtonOperateEquipFusion();
			this.m_OperateList[1, 6] = new TooltipButtonOperateEquipUpgrade();
		}

		public override bool HideToolTip(bool forceHide = false)
		{
			bool flag = base.HideToolTip(forceHide);
			bool result;
			if (flag)
			{
				base.uiBehaviour.m_JadeItemPool.ReturnAll(false);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void ShowToolTip(ulong MainUID, ulong CompareUID, bool bShowButtons = true)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(MainUID);
			XItem xitem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(CompareUID);
			bool flag = xitem.uid == 0UL;
			if (flag)
			{
				xitem = null;
			}
			this.ShowToolTip(itemByUID, xitem, bShowButtons, 0U);
		}

		private void _SetEnhanceAttrFrame(GameObject scrollPanel, XEquipItem equipItem, bool bMain)
		{
			GameObject gameObject = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
			gameObject.transform.parent = scrollPanel.transform;
			string itemQualityColorStr = XSingleton<UiUtility>.singleton.GetItemQualityColorStr(1);
			AttrFrameParam attrFrameParam = new AttrFrameParam();
			attrFrameParam.Title = XStringDefineProxy.GetString("TOOLTIP_ENHANCE_ATTR");
			for (int i = 0; i < equipItem.enhanceInfo.EnhanceAttr.Count; i++)
			{
				AttrParam item = default(AttrParam);
				AttrParam.ResetSb();
				AttrParam.Append(equipItem.enhanceInfo.EnhanceAttr[i], itemQualityColorStr, itemQualityColorStr);
				item.SetTextFromSb();
				item.SetValueFromSb();
				attrFrameParam.AttrList.Add(item);
			}
			base.AppendFrame(gameObject, (float)this.SetupAttrFrame(gameObject, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
			XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
		}

		private void _SetJadeAttrFrame(GameObject scrollPanel, XEquipItem equipItem, bool bMain)
		{
			bool flag = equipItem == null;
			if (!flag)
			{
				uint level = 0U;
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag2)
				{
					level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				}
				bool flag3 = XSingleton<TooltipParam>.singleton.mainAttributes != null;
				if (flag3)
				{
					level = XSingleton<TooltipParam>.singleton.mainAttributes.Level;
				}
				XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(equipItem.itemID);
				bool flag4 = equipConf == null;
				if (!flag4)
				{
					bool flag5 = specificDocument.JadeIsOpen(equipConf.EquipPos, level);
					bool flag6 = !flag5;
					if (!flag6)
					{
						GameObject gameObject = null;
						AttrFrameParam attrFrameParam = null;
						for (int i = 0; i < equipItem.jadeInfo.jades.Length; i++)
						{
							XJadeItem xjadeItem = equipItem.jadeInfo.jades[i];
							bool flag7 = xjadeItem == null;
							if (!flag7)
							{
								ItemList.RowData itemConf = XBagDocument.GetItemConf(xjadeItem.itemID);
								bool flag8 = itemConf == null;
								if (!flag8)
								{
									bool flag9 = gameObject == null;
									if (flag9)
									{
										gameObject = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
										gameObject.transform.parent = scrollPanel.gameObject.transform;
										attrFrameParam = new AttrFrameParam();
										attrFrameParam.Title = XStringDefineProxy.GetString("TOOLTIP_JADE_ATTR");
									}
									foreach (XItemChangeAttr attr in xjadeItem.BasicAttr())
									{
										AttrParam item = default(AttrParam);
										AttrParam.ResetSb();
										AttrParam.TextSb.Append(XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, base.profession)).Append("  ");
										AttrParam.Append(attr, "", "");
										item.SetTextFromSb();
										item.SetValueFromSb();
										attrFrameParam.AttrList.Add(item);
									}
								}
							}
						}
						bool flag10 = gameObject != null;
						if (flag10)
						{
							base.AppendFrame(gameObject, (float)this.SetupAttrFrame(gameObject, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
							XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
						}
					}
				}
			}
		}

		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			XEquipItem xequipItem = item as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				GameObject gameObject = goToolTip.transform.FindChild("ScrollPanel").gameObject;
				this.SetBasicAttrFrame(gameObject, item, compareItem, bMain);
				this._SetupRandAndForgeFrame(goToolTip, item, bMain);
				this._SetupEnchantFrame(goToolTip, item, compareItem, bMain);
				bool flag2 = xequipItem.enhanceInfo.EnhanceLevel > 0U;
				if (flag2)
				{
					this._SetEnhanceAttrFrame(gameObject, xequipItem, bMain);
				}
				uint level = 0U;
				bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag3)
				{
					level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				}
				bool flag4 = XSingleton<TooltipParam>.singleton.mainAttributes != null;
				if (flag4)
				{
					level = XSingleton<TooltipParam>.singleton.mainAttributes.Level;
				}
				XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
				bool flag5 = false;
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
				bool flag6 = equipConf != null;
				if (flag6)
				{
					flag5 = specificDocument.JadeIsOpen(equipConf.EquipPos, level);
				}
				bool flag7 = flag5;
				if (flag7)
				{
					this._SetJadeAttrFrame(gameObject, xequipItem, bMain);
				}
			}
		}

		protected new void SetBasicAttrFrame(GameObject scrollPanel, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			GameObject gameObject = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
			gameObject.transform.parent = scrollPanel.transform;
			uint profession = 0U;
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				profession = XSingleton<XEntityMgr>.singleton.Player.BasicTypeID;
			}
			bool flag2 = XSingleton<TooltipParam>.singleton.mainAttributes != null;
			if (flag2)
			{
				profession = XSingleton<TooltipParam>.singleton.mainAttributes.BasicTypeID;
			}
			List<EquipFuseData> nowFuseData = EquipFusionDocument.Doc.GetNowFuseData(item, profession);
			AttrFrameParam attrFrameParam = new AttrFrameParam();
			attrFrameParam.Title = XStringDefineProxy.GetString("TOOLTIP_BASIC_ATTR");
			for (int i = 0; i < nowFuseData.Count; i++)
			{
				AttrParam item2 = default(AttrParam);
				AttrParam.ResetSb();
				AttrParam.TextSb.Append(XAttributeCommon.GetAttrStr((int)nowFuseData[i].AttrId)).Append(" ").Append(nowFuseData[i].BeforeBaseAttrNum);
				bool flag3 = nowFuseData[i].BeforeAddNum > 0U;
				if (flag3)
				{
					AttrParam.ValueSb.Append("+").Append(nowFuseData[i].BeforeAddNum);
				}
				item2.IsShowTipsIcon = nowFuseData[i].IsExtra;
				item2.IconName = "zb_rzsx";
				item2.SetTextFromSb();
				item2.SetValueFromSb();
				attrFrameParam.AttrList.Add(item2);
			}
			base.AppendFrame(gameObject, (float)this.SetupAttrFrame(gameObject, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
			this.SetAttrOther(scrollPanel.transform, attrFrameParam);
			Transform transform = gameObject.transform.FindChild("EquipRz");
			XEquipItem xequipItem = item as XEquipItem;
			bool flag4 = transform != null;
			if (flag4)
			{
				bool flag5 = xequipItem.fuseInfo.BreakNum == 0U;
				if (flag5)
				{
					transform.gameObject.SetActive(false);
				}
				else
				{
					string fuseIconName = EquipFusionDocument.Doc.GetFuseIconName(xequipItem.fuseInfo.BreakNum);
					bool flag6 = fuseIconName != null;
					if (flag6)
					{
						transform.gameObject.SetActive(true);
						IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
						ixuisprite.spriteName = fuseIconName;
					}
				}
			}
			transform = gameObject.transform.FindChild("RzLabel");
			bool flag7 = transform != null;
			if (flag7)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
				bool flag8 = equipConf != null;
				if (flag8)
				{
					bool flag9 = equipConf.FuseCanBreakNum > 0;
					if (flag9)
					{
						transform.gameObject.SetActive(true);
						IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("FuseBreakNum"), xequipItem.fuseInfo.BreakNum, equipConf.FuseCanBreakNum));
					}
					else
					{
						transform.gameObject.SetActive(false);
					}
				}
				else
				{
					transform.gameObject.SetActive(false);
				}
			}
			XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
		}

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			Transform transform = goToolTip.transform;
			GameObject gameObject = transform.FindChild("TopFrame/State").gameObject;
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(data.ItemID);
			base._SetTopFrameLabel(goToolTip, 2, XStringDefineProxy.GetString("ToolTipText_Part"), (equipConf != null) ? XSingleton<UiUtility>.singleton.GetEquipPartName((EquipPosition)equipConf.EquipPos, true) : string.Empty);
			gameObject.SetActive(!bMain || XSingleton<TooltipParam>.singleton.bEquiped);
		}

		protected override int _GetPPT(XItem item, bool bMain, ref string valueText)
		{
			XEquipItem xequipItem = item as XEquipItem;
			bool flag = xequipItem == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				XAttributes attributes = bMain ? XSingleton<TooltipParam>.singleton.mainAttributes : XSingleton<TooltipParam>.singleton.compareAttributes;
				double num = xequipItem.GetPPT(attributes);
				bool bPreview = xequipItem.randAttrInfo.bPreview;
				if (bPreview)
				{
					uint num2 = 0U;
					uint num3 = 0U;
					EquipSlotAttrDatas attrData = XCharacterEquipDocument.RandomAttrMgr.GetAttrData((uint)xequipItem.itemID);
					bool flag2 = attrData != null;
					if (flag2)
					{
						num2 = (uint)num + EquipSlotAttrDatas.GetMinPPT(attrData, attributes, false);
						num3 = (uint)num + EquipSlotAttrDatas.GetMaxPPT(attrData, attributes);
					}
					EquipSlotAttrDatas attrData2 = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)xequipItem.itemID);
					bool flag3 = attrData2 != null;
					if (flag3)
					{
						num2 += (uint)num + EquipSlotAttrDatas.GetMinPPT(attrData, attributes, true);
						num3 += (uint)num + EquipSlotAttrDatas.GetMaxPPT(attrData, attributes);
					}
					valueText = string.Format("{0} - {1}", num2, num3);
					result = -1;
				}
				else
				{
					for (int i = 0; i < xequipItem.randAttrInfo.RandAttr.Count; i++)
					{
						num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xequipItem.randAttrInfo.RandAttr[i], attributes, -1);
					}
					for (int j = 0; j < xequipItem.forgeAttrInfo.ForgeAttr.Count; j++)
					{
						num += (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT(xequipItem.forgeAttrInfo.ForgeAttr[j], attributes, -1);
					}
					valueText = ((uint)num).ToString();
					result = (int)num;
				}
			}
			return result;
		}

		protected override void SetupOtherFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			this._SetupSuitFrame(goToolTip, mainItem, compareItem, bMain);
			this._SetupJadeFrame(goToolTip, mainItem, compareItem, bMain);
			base.SetupOtherFrame(goToolTip, mainItem, compareItem, bMain);
		}

		private void _SetupJadeFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			XEquipItem xequipItem = mainItem as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
				bool flag2 = equipConf == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("equipListRowData == null while id = ", xequipItem.itemID.ToString(), null, null, null, null);
				}
				else
				{
					uint num = 0U;
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
					if (flag3)
					{
						num = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
					}
					bool flag4 = XSingleton<TooltipParam>.singleton.mainAttributes != null;
					if (flag4)
					{
						num = XSingleton<TooltipParam>.singleton.mainAttributes.Level;
					}
					XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
					IXUISprite ixuisprite = goToolTip.transform.FindChild("JadeFrame").GetComponent("XUISprite") as IXUISprite;
					bool flag5 = specificDocument.JadeIsOpen(equipConf.EquipPos, num);
					bool flag6 = !flag5;
					if (flag6)
					{
						ixuisprite.SetVisible(false);
					}
					else
					{
						SeqListRef<uint> slotInfoByPos = specificDocument.GetSlotInfoByPos(equipConf.EquipPos);
						int num2 = 4;
						int i;
						for (i = 0; i < (int)slotInfoByPos.count; i++)
						{
							bool flag7 = i >= num2;
							if (flag7)
							{
								break;
							}
							bool flag8 = num >= slotInfoByPos[i, 1];
							if (flag8)
							{
								GameObject gameObject = base.uiBehaviour.m_JadeItemPool.FetchGameObject(false);
								gameObject.name = "jadeItem" + i;
								Transform transform = goToolTip.transform.FindChild("JadeFrame/Jade" + i);
								gameObject.transform.parent = ixuisprite.gameObject.transform;
								gameObject.transform.localPosition = transform.localPosition;
								gameObject.transform.localScale = Vector3.one;
								XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
								XJadeItem realItem = xequipItem.jadeInfo.jades[i];
								XItemDrawerMgr.Param.Profession = base.profession;
								XSingleton<XItemDrawerMgr>.singleton.jadeSlotDrawer.DrawItem(gameObject, slotInfoByPos[i, 0], false, realItem);
							}
						}
						bool flag9 = i > 0;
						if (flag9)
						{
							this.bHadJade = true;
							ixuisprite.SetVisible(true);
							Vector3 localPosition = ixuisprite.gameObject.transform.localPosition;
							ixuisprite.gameObject.transform.localPosition = new Vector3(localPosition.x, -this.totalFrameHeight, localPosition.z);
							this.totalFrameHeight += (float)ixuisprite.spriteHeight;
						}
						else
						{
							ixuisprite.SetVisible(false);
						}
					}
				}
			}
		}

		private void _SetupRandAndForgeFrame(GameObject goToolTip, XItem mainItem, bool bMain)
		{
			XEquipItem xequipItem = mainItem as XEquipItem;
			bool flag = !xequipItem.randAttrInfo.bPreview && xequipItem.randAttrInfo.RandAttr.Count == 0 && !xequipItem.forgeAttrInfo.bPreview && xequipItem.forgeAttrInfo.ForgeAttr.Count == 0;
			if (!flag)
			{
				EquipSlotAttrDatas attrData = XCharacterEquipDocument.RandomAttrMgr.GetAttrData((uint)xequipItem.itemID);
				EquipSlotAttrDatas attrData2 = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)xequipItem.itemID);
				bool flag2 = attrData == null && attrData2 == null;
				if (!flag2)
				{
					GameObject gameObject = goToolTip.transform.FindChild("ScrollPanel").gameObject;
					GameObject gameObject2 = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
					gameObject2.transform.parent = gameObject.transform;
					string itemQualityColorStr = XSingleton<UiUtility>.singleton.GetItemQualityColorStr(2);
					AttrFrameParam attrFrameParam = new AttrFrameParam();
					attrFrameParam.Title = XStringDefineProxy.GetString("HIDDEN_ATTR");
					bool bPreview = xequipItem.randAttrInfo.bPreview;
					if (bPreview)
					{
						AttrParam item = default(AttrParam);
						AttrParam.ResetSb();
						AttrParam.Append(AttrParam.TextSb, XStringDefineProxy.GetString("HIDDEN_ATTR"), itemQualityColorStr);
						AttrParam.Append(AttrParam.ValueSb, "???", itemQualityColorStr);
						item.SetTextFromSb();
						item.SetValueFromSb();
						attrFrameParam.AttrList.Add(item);
					}
					int count = xequipItem.randAttrInfo.RandAttr.Count;
					List<XItemChangeAttr> list = new List<XItemChangeAttr>();
					for (int i = 0; i < count; i++)
					{
						list.Add(xequipItem.randAttrInfo.RandAttr[i]);
					}
					for (int j = 0; j < xequipItem.forgeAttrInfo.ForgeAttr.Count; j++)
					{
						list.Add(xequipItem.forgeAttrInfo.ForgeAttr[j]);
					}
					for (int k = 0; k < list.Count; k++)
					{
						XItemChangeAttr xitemChangeAttr = list[k];
						bool flag3 = xitemChangeAttr.AttrID == 0U;
						if (!flag3)
						{
							bool flag4 = k < count;
							bool flag5 = flag4;
							EquipSlotAttrDatas equipSlotAttrDatas;
							int slot;
							if (flag5)
							{
								equipSlotAttrDatas = attrData;
								slot = k + 1;
							}
							else
							{
								equipSlotAttrDatas = attrData2;
								slot = count - k + 1;
							}
							bool flag6 = equipSlotAttrDatas == null;
							if (!flag6)
							{
								AttrParam item2 = default(AttrParam);
								AttrParam.ResetSb();
								item2.IsShowTipsIcon = !flag4;
								item2.IconName = "zb_dzsx";
								EquipAttrData attrData3 = equipSlotAttrDatas.GetAttrData(slot, xitemChangeAttr);
								bool flag7 = attrData3 != null;
								if (flag7)
								{
									string color = equipSlotAttrDatas.GetColor(slot, xitemChangeAttr);
									AttrParam.Append(xitemChangeAttr, color, color);
									AttrParam.ValueSb.Append(" [");
									AttrParam.ValueSb.Append(attrData3.RangValue.Min);
									AttrParam.ValueSb.Append(" - ");
									AttrParam.ValueSb.Append(attrData3.RangValue.Max);
									AttrParam.ValueSb.Append("] ");
								}
								else
								{
									AttrParam.Append(xitemChangeAttr, itemQualityColorStr, itemQualityColorStr);
								}
								item2.SetTextFromSb();
								item2.SetValueFromSb();
								attrFrameParam.AttrList.Add(item2);
							}
						}
					}
					base.AppendFrame(gameObject2, (float)this.SetupAttrFrame(gameObject2, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
					XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject2);
				}
			}
		}

		private void _SetupEnchantFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			XEquipItem xequipItem = mainItem as XEquipItem;
			bool flag = !xequipItem.enchantInfo.bHasEnchant;
			if (!flag)
			{
				GameObject gameObject = goToolTip.transform.FindChild("ScrollPanel").gameObject;
				GameObject gameObject2 = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
				gameObject2.transform.parent = gameObject.transform;
				string itemQualityColorStr = XSingleton<UiUtility>.singleton.GetItemQualityColorStr(2);
				AttrFrameParam attrFrameParam = new AttrFrameParam();
				attrFrameParam.Title = XStringDefineProxy.GetString("TOOLTIP_ENCHANT_ATTR");
				XEnchantInfo enchantInfo = xequipItem.enchantInfo;
				bool flag2 = enchantInfo.ChooseAttr > 0U;
				if (flag2)
				{
					for (int i = 0; i < xequipItem.enchantInfo.AttrList.Count; i++)
					{
						bool flag3 = enchantInfo.AttrList[i].AttrID == enchantInfo.ChooseAttr;
						if (flag3)
						{
							AttrParam item = default(AttrParam);
							AttrParam.ResetSb();
							AttrParam.Append(xequipItem.enchantInfo.AttrList[i], "", "");
							item.SetTextFromSb();
							item.SetValueFromSb();
							attrFrameParam.AttrList.Add(item);
						}
					}
				}
				base.AppendFrame(gameObject2, (float)this.SetupAttrFrame(gameObject2, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject2);
			}
		}

		private void _SetupSuitFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			IXUISprite ixuisprite = goToolTip.transform.FindChild("ScrollPanel/SuitFrame").GetComponent("XUISprite") as IXUISprite;
			bool flag = mainItem == null;
			if (flag)
			{
				ixuisprite.SetVisible(false);
			}
			else
			{
				int itemID = mainItem.itemID;
				EquipSuitTable.RowData suit = XCharacterEquipDocument.SuitManager.GetSuit(itemID, true);
				bool flag2 = suit == null;
				if (flag2)
				{
					ixuisprite.SetVisible(false);
				}
				else
				{
					ixuisprite.SetVisible(true);
					bool flag3 = XSingleton<TooltipParam>.singleton.BodyBag == null;
					if (flag3)
					{
						XSingleton<TooltipParam>.singleton.BodyBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag;
					}
					int num = XEquipSuitManager.GetEquipedSuits(suit, XSingleton<TooltipParam>.singleton.BodyBag, null);
					bool flag4 = bMain && XEquipSuitManager.WillChangeEquipedCount(suit, mainItem.itemID, XSingleton<TooltipParam>.singleton.BodyBag);
					if (flag4)
					{
						num++;
					}
					int num2 = 0;
					AttrFrameParam attrFrameParam = new AttrFrameParam();
					for (int i = 0; i < XEquipSuitManager.GetEffectDataCount(); i++)
					{
						int num3 = 0;
						int effectData = XEquipSuitManager.GetEffectData(suit, i, out num3);
						bool flag5 = (float)effectData != 0f;
						if (flag5)
						{
							bool flag6 = i <= num;
							string text;
							string color;
							if (flag6)
							{
								text = "ffffff";
								color = XSingleton<UiUtility>.singleton.GetColorStr(new Color(0.99607843f, 0.80784315f, 0f));
							}
							else
							{
								text = XSingleton<UiUtility>.singleton.GetColorStr(new Color(0.5019608f, 0.5019608f, 0.5019608f));
								color = text;
							}
							AttrParam item = default(AttrParam);
							AttrParam.ResetSb();
							AttrParam.Append(AttrParam.TextSb, XStringDefineProxy.GetString("EQUIP_SUIT_EFFECT", new object[]
							{
								i
							}), color);
							string s = string.Format("{0} +{1}", XStringDefineProxy.GetString((XAttributeDefine)effectData), num3);
							AttrParam.Append(AttrParam.ValueSb, s, text);
							item.SetTextFromSb();
							item.SetValueFromSb();
							attrFrameParam.AttrList.Add(item);
							num2++;
						}
					}
					bool flag7 = num2 > 0;
					if (flag7)
					{
						attrFrameParam.Title = string.Format("({0}/{1})", num, suit.SuitNum);
						base.AppendFrame(ixuisprite.gameObject, (float)this.SetupAttrFrame(ixuisprite.gameObject, attrFrameParam, bMain), null);
					}
					else
					{
						ixuisprite.SetVisible(false);
					}
				}
			}
		}

		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = !this.bShowButtons;
			if (!flag)
			{
				if (bMain)
				{
					XEquipItem xequipItem = item as XEquipItem;
					bool flag2 = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag.HasItem(item.uid);
					if (flag2)
					{
						base._SetupButtonVisiability(goToolTip, 1, item);
					}
					else
					{
						base._SetupButtonVisiability(goToolTip, 0, item);
					}
				}
			}
		}
	}
}
