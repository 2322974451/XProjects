using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017D6 RID: 6102
	internal class XNPCSendSubHandler : DlgHandlerBase
	{
		// Token: 0x0600FCD3 RID: 64723 RVA: 0x003B0B79 File Offset: 0x003AED79
		public void SetParentHandler(XNPCFavorHandler handler = null)
		{
			this._parentHandler = handler;
		}

		// Token: 0x0600FCD4 RID: 64724 RVA: 0x003B0B84 File Offset: 0x003AED84
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this._items = null;
			this._items = base.transform.Find("Panel/Items");
			this.m_ScrollView = (this._items.GetComponent("XUIScrollView") as IXUIScrollView);
			this._itemPool.SetupPool(this._items.gameObject, this._items.Find("Item").gameObject, 4U, false);
			this._RelicsSpr = (base.transform.FindChild("EquipItem").GetComponent("XUISprite") as IXUISprite);
			this._RelicsName = (base.transform.FindChild("Title/EquipName").GetComponent("XUILabel") as IXUILabel);
			this._RelicsLevel = (base.transform.FindChild("Title/Level").GetComponent("XUILabel") as IXUILabel);
			this._RelicsDesc = (base.transform.FindChild("Title/Tips").GetComponent("XUILabel") as IXUILabel);
			this._RelicsAddition = (base.transform.FindChild("EquipEffect/Value").GetComponent("XUILabel") as IXUILabel);
			this._curAttr = (base.transform.FindChild("EquipEffect/AttrValue").GetComponent("XUILabel") as IXUILabel);
			this._NextLevel = (base.transform.FindChild("NextLevelBtn").GetComponent("XUIButton") as IXUIButton);
			this._LevelUpBtn = (base.transform.FindChild("LevelUpBtn").GetComponent("XUIButton") as IXUIButton);
			this._LevelUpRedPoint = base.transform.FindChild("LevelUpBtn/RedPoint").gameObject;
			this._LevelUpRedPoint.SetActive(false);
			this._SendBtn = (base.transform.FindChild("GoBtn").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600FCD5 RID: 64725 RVA: 0x001A787A File Offset: 0x001A5A7A
		protected override void OnShow()
		{
			this.RefreshData();
		}

		// Token: 0x0600FCD6 RID: 64726 RVA: 0x003B0D84 File Offset: 0x003AEF84
		public override void RefreshData()
		{
			this.RefreshRelics();
			this.RefreshItems();
		}

		// Token: 0x0600FCD7 RID: 64727 RVA: 0x003B0D98 File Offset: 0x003AEF98
		public override void RegisterEvent()
		{
			this._NextLevel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickNextAdditionBtn));
			this._LevelUpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLevelUpBtn));
			this._SendBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSendBtn));
		}

		// Token: 0x0600FCD8 RID: 64728 RVA: 0x003B0DEE File Offset: 0x003AEFEE
		public override void OnUnload()
		{
			this.m_doc = null;
			this._parentHandler = null;
		}

		// Token: 0x0600FCD9 RID: 64729 RVA: 0x003B0E00 File Offset: 0x003AF000
		private void RefreshRelics()
		{
			bool flag = this._parentHandler._selectedNPCID == 0U;
			if (!flag)
			{
				NpcFeelingOneNpc oneNpc = this.m_doc.GetOneNpc(this._parentHandler._selectedNPCID);
				NpcFeeling.RowData npcTableInfoById = XNPCFavorDocument.GetNpcTableInfoById(this._parentHandler._selectedNPCID);
				this._RelicsSpr.SetSprite(npcTableInfoById.relicsIcon);
				this._RelicsName.SetText(npcTableInfoById.relicsName);
				this._RelicsLevel.SetText(string.Format("Lv.{0}", (oneNpc == null) ? 0U : oneNpc.level));
				this._RelicsDesc.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(npcTableInfoById.relicsDesc));
				uint lev = (oneNpc != null) ? oneNpc.level : 0U;
				NpcFeelingAttr.RowData attrDataByLevel = XNPCFavorDocument.GetAttrDataByLevel(npcTableInfoById.npcId, lev);
				bool flag2 = attrDataByLevel != null;
				if (flag2)
				{
					StringBuilder sb = XNPCFavorDocument.sb;
					sb.Length = 0;
					int i = 0;
					int count = attrDataByLevel.Attr.Count;
					while (i < count)
					{
						uint attrid = attrDataByLevel.Attr[i, 0];
						uint attrValue = attrDataByLevel.Attr[i, 1];
						bool flag3 = i != 0;
						if (flag3)
						{
							sb.Append(" ");
						}
						sb.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid), (oneNpc != null) ? XAttributeCommon.GetAttrValueStr(attrid, attrValue, true) : "+0"));
						i++;
					}
					this._curAttr.SetText(sb.ToString());
				}
				else
				{
					this._curAttr.SetText(string.Empty);
				}
				NpcFeelingAttr.RowData npcAttrByIdLev = XNPCFavorDocument.GetNpcAttrByIdLev(npcTableInfoById.npcId, (oneNpc == null) ? 0U : oneNpc.level);
				bool flag4 = npcAttrByIdLev != null;
				if (flag4)
				{
					this._RelicsAddition.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(npcAttrByIdLev.RelicsDesc));
				}
				else
				{
					this._RelicsAddition.SetText(string.Empty);
				}
				this._LevelUpRedPoint.SetActive(this.m_doc.IsCanLevelUp(oneNpc));
			}
		}

		// Token: 0x0600FCDA RID: 64730 RVA: 0x003B1010 File Offset: 0x003AF210
		private void RefreshItems()
		{
			this._itemPool.ReturnAll(false);
			bool flag = this._parentHandler._selectedNPCID > 0U;
			if (flag)
			{
				NpcFeelingOneNpc oneNpc = this.m_doc.GetOneNpc(this._parentHandler._selectedNPCID);
				bool flag2 = oneNpc != null;
				if (flag2)
				{
					List<NpcLikeItem> likeitem = oneNpc.likeitem;
					bool flag3 = likeitem != null;
					if (flag3)
					{
						for (int i = 0; i < likeitem.Count; i++)
						{
							this.DrawItem((int)likeitem[i].itemid, (int)likeitem[i].itemcount, i);
						}
					}
				}
				else
				{
					NpcFeeling.RowData npcTableInfoById = XNPCFavorDocument.GetNpcTableInfoById(this._parentHandler._selectedNPCID);
					SeqListRef<uint> clientItem = npcTableInfoById.clientItem;
					for (int j = 0; j < clientItem.Count; j++)
					{
						this.DrawItem((int)clientItem[j, 0], (int)clientItem[j, 1], j);
					}
				}
			}
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600FCDB RID: 64731 RVA: 0x003B111C File Offset: 0x003AF31C
		private void DrawItem(int itemId, int itemNum, int i)
		{
			Transform transform = this.DrawItem(itemId, itemNum, this._items, i);
			IXUILabel ixuilabel = transform.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(itemId);
			string text = itemCount + "/" + itemNum;
			bool flag = itemCount < (ulong)((long)itemNum);
			if (flag)
			{
				text = string.Concat(new object[]
				{
					"[ff0000]",
					itemCount,
					"/",
					itemNum,
					"[-]"
				});
			}
			ixuilabel.SetText(text);
		}

		// Token: 0x0600FCDC RID: 64732 RVA: 0x003B11C8 File Offset: 0x003AF3C8
		private Transform DrawItem(int itemID, int num, Transform parent, int index)
		{
			GameObject gameObject = this._itemPool.FetchGameObject(false);
			gameObject.transform.parent = parent;
			gameObject.transform.localPosition = new Vector3((float)(index * this._itemPool.TplWidth), 0f, 0f);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemID, num, true);
			IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)itemID);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			return gameObject.transform;
		}

		// Token: 0x0600FCDD RID: 64733 RVA: 0x003B127C File Offset: 0x003AF47C
		private bool OnClickSendBtn(IXUIButton btn)
		{
			bool flag = this._parentHandler._selectedNPCID == 0U;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				NpcFeelingOneNpc oneNpc = this.m_doc.GetOneNpc(this._parentHandler._selectedNPCID);
				bool flag2 = oneNpc != null;
				if (flag2)
				{
					uint npcXIdById = XNPCFavorDocument.GetNpcXIdById(this._parentHandler._selectedNPCID);
					XSingleton<UiUtility>.singleton.CloseModalDlg();
					XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc(npcXIdById);
					bool flag3 = XSingleton<XInput>.singleton.LastNpc != null;
					if (flag3)
					{
						this.m_doc.View.Close(true);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCNotInScene"), "fece00");
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCNotActive"), "fece00");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600FCDE RID: 64734 RVA: 0x003B1360 File Offset: 0x003AF560
		private bool OnClickLevelUpBtn(IXUIButton btn)
		{
			bool flag = this._parentHandler._selectedNPCID == 0U;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				NpcFeelingOneNpc oneNpc = this.m_doc.GetOneNpc(this._parentHandler._selectedNPCID);
				bool flag2 = oneNpc != null;
				if (flag2)
				{
					bool flag3 = this.m_doc.IsCanLevelUp(oneNpc);
					if (flag3)
					{
						this.m_doc.ReqSrvLevelUp(this._parentHandler._selectedNPCID);
					}
					else
					{
						bool flag4 = oneNpc.level == this.m_doc.NpcFlLevTop;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_NPCFL_NPC_LEVEL_MAX"), "fece00");
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCLessEXP"), "fece00");
						}
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCNotActive"), "fece00");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600FCDF RID: 64735 RVA: 0x003B1450 File Offset: 0x003AF650
		private bool OnClickNextAdditionBtn(IXUIButton btn)
		{
			bool flag = this._parentHandler._selectedNPCID == 0U;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				NpcFeelingOneNpc oneNpc = this.m_doc.GetOneNpc(this._parentHandler._selectedNPCID);
				bool flag2 = oneNpc != null;
				if (flag2)
				{
					uint selectedNPCID = this._parentHandler._selectedNPCID;
					NpcFeelingAttr.RowData attrDataByLevel = XNPCFavorDocument.GetAttrDataByLevel(selectedNPCID, oneNpc.level + 1U);
					bool flag3 = attrDataByLevel != null;
					if (flag3)
					{
						string @string = XStringDefineProxy.GetString("NPCNextAddition");
						SeqListRef<uint> attr = attrDataByLevel.Attr;
						StringBuilder sb = XNPCFavorDocument.sb;
						sb.Length = 0;
						for (int i = 0; i < attr.Count; i++)
						{
							uint attrid = attr[i, 0];
							uint attrValue = attr[i, 1];
							bool flag4 = i != 0;
							if (flag4)
							{
								sb.Append("\n");
							}
							sb.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid), XAttributeCommon.GetAttrValueStr(attrid, attrValue, true)));
						}
						string label = sb.ToString();
						XSingleton<UiUtility>.singleton.ShowModalDialogWithTitle(@string, label, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), null, 50);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCRelicsLevelMAX"), "fece00");
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCNotActive"), "fece00");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x04006F2D RID: 28461
		private XNPCFavorHandler _parentHandler = null;

		// Token: 0x04006F2E RID: 28462
		private XNPCFavorDocument m_doc;

		// Token: 0x04006F2F RID: 28463
		private IXUIScrollView m_ScrollView;

		// Token: 0x04006F30 RID: 28464
		private Transform _items;

		// Token: 0x04006F31 RID: 28465
		protected XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006F32 RID: 28466
		private IXUISprite _RelicsSpr;

		// Token: 0x04006F33 RID: 28467
		private IXUILabel _RelicsName;

		// Token: 0x04006F34 RID: 28468
		private IXUILabel _RelicsLevel;

		// Token: 0x04006F35 RID: 28469
		private IXUILabel _RelicsDesc;

		// Token: 0x04006F36 RID: 28470
		private IXUILabel _RelicsAddition;

		// Token: 0x04006F37 RID: 28471
		private IXUILabel _curAttr;

		// Token: 0x04006F38 RID: 28472
		private IXUIButton _NextLevel;

		// Token: 0x04006F39 RID: 28473
		private IXUIButton _LevelUpBtn;

		// Token: 0x04006F3A RID: 28474
		private GameObject _LevelUpRedPoint;

		// Token: 0x04006F3B RID: 28475
		private IXUIButton _SendBtn;
	}
}
