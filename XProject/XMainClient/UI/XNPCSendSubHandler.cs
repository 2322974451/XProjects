using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XNPCSendSubHandler : DlgHandlerBase
	{

		public void SetParentHandler(XNPCFavorHandler handler = null)
		{
			this._parentHandler = handler;
		}

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

		protected override void OnShow()
		{
			this.RefreshData();
		}

		public override void RefreshData()
		{
			this.RefreshRelics();
			this.RefreshItems();
		}

		public override void RegisterEvent()
		{
			this._NextLevel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickNextAdditionBtn));
			this._LevelUpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLevelUpBtn));
			this._SendBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSendBtn));
		}

		public override void OnUnload()
		{
			this.m_doc = null;
			this._parentHandler = null;
		}

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

		private XNPCFavorHandler _parentHandler = null;

		private XNPCFavorDocument m_doc;

		private IXUIScrollView m_ScrollView;

		private Transform _items;

		protected XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUISprite _RelicsSpr;

		private IXUILabel _RelicsName;

		private IXUILabel _RelicsLevel;

		private IXUILabel _RelicsDesc;

		private IXUILabel _RelicsAddition;

		private IXUILabel _curAttr;

		private IXUIButton _NextLevel;

		private IXUIButton _LevelUpBtn;

		private GameObject _LevelUpRedPoint;

		private IXUIButton _SendBtn;
	}
}
