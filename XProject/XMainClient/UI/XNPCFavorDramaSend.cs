using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XNPCFavorDramaSend : DlgHandlerBase
	{

		private XNPCFavorDrama operate
		{
			get
			{
				return XNPCFavorDocument.IsNpcDialogVisible();
			}
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/NpcBlessing/NpcSendPresent";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this.m_LeftTimes = (base.transform.Find("LeftTimes").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		protected override void OnShow()
		{
			this.RefreshData();
		}

		public override void OnUnload()
		{
			this.doc = null;
		}

		public override void RefreshData()
		{
			this.m_LeftTimes.SetText(this.doc.GiveLeftCount.ToString());
			this.RefreshList();
		}

		public override void RegisterEvent()
		{
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdate));
		}

		private void RefreshList()
		{
			XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
			bool flag = xnpcfavorDrama != null;
			if (flag)
			{
				this.likeItems = this.doc.GetLikeItemsByXId(xnpcfavorDrama.GetXNpcId());
				bool flag2 = this.likeItems != null;
				if (flag2)
				{
					this.likeItems.Sort(new Comparison<NpcLikeItem>(XNPCFavorDramaSend.Compare));
					this.m_WrapContent.SetContentCount(this.likeItems.Count, false);
					this.m_ScrollView.ResetPosition();
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("Error , Send Gift to UnActived Npc!", null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
		}

		private void WrapListUpdate(Transform item, int index)
		{
			bool flag = this.likeItems == null || index >= this.likeItems.Count;
			if (flag)
			{
				for (int i = 0; i < item.childCount; i++)
				{
					item.GetChild(i).gameObject.SetActive(false);
				}
			}
			else
			{
				for (int j = 0; j < item.childCount; j++)
				{
					item.GetChild(j).gameObject.SetActive(true);
				}
				NpcLikeItem npcLikeItem = this.likeItems[index];
				this.DrawItem(item, npcLikeItem.itemid, npcLikeItem.itemcount, npcLikeItem.addexp, index, npcLikeItem.type);
			}
		}

		private static int Compare(NpcLikeItem x, NpcLikeItem y)
		{
			bool flag = x.type != y.type;
			int result;
			if (flag)
			{
				result = XFastEnumIntEqualityComparer<NpcFlItemType>.ToInt(x.type) - XFastEnumIntEqualityComparer<NpcFlItemType>.ToInt(y.type);
			}
			else
			{
				result = (int)(x.itemid - y.itemid);
			}
			return result;
		}

		private void DrawItem(Transform item, uint itemId, uint itemNum, uint favorAdd, int index, NpcFlItemType type)
		{
			IXUIButton ixuibutton = item.FindChild("SendBtn").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel = item.FindChild("friendship/Num").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = item.FindChild("HaveGot/Num").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = item.FindChild("Item/Name").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = item.FindChild("BgNormal").gameObject;
			GameObject gameObject2 = item.FindChild("BgSpecial").gameObject;
			Transform transform = item.FindChild("Item");
			GameObject gameObject3 = transform.gameObject;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject3, (int)itemId, (int)itemNum, true);
			IXUISprite ixuisprite = transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)itemId;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemId);
			ixuilabel3.SetText((itemConf != null) ? itemConf.ItemName[0] : string.Empty);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)itemId);
			string text = itemCount + "/" + itemNum;
			bool flag = itemCount < (ulong)itemNum;
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
			ixuilabel2.SetText(text);
			ixuibutton.ID = (ulong)((long)index);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSendBtn));
			ixuilabel.SetText(favorAdd.ToString());
			bool flag2 = type == NpcFlItemType.NPCFL_ITEM_TRIGGER_FAVOR;
			if (flag2)
			{
				gameObject.SetActive(false);
				gameObject2.SetActive(true);
			}
			else
			{
				gameObject.SetActive(true);
				gameObject2.SetActive(false);
			}
		}

		private bool OnClickSendBtn(IXUIButton btn)
		{
			bool flag = this.doc.GiveLeftCount <= 0U;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_NPCFL_GIVE_GIFT_COUNT_LESS"), "fece00");
				result = true;
			}
			else
			{
				int num = (int)btn.ID;
				bool flag2 = this.likeItems == null || num >= this.likeItems.Count;
				if (flag2)
				{
					result = true;
				}
				else
				{
					NpcLikeItem npcLikeItem = this.likeItems[num];
					uint itemid = npcLikeItem.itemid;
					uint itemcount = npcLikeItem.itemcount;
					uint addexp = npcLikeItem.addexp;
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)itemid);
					bool flag3 = itemCount < (ulong)itemcount;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCSendItemNotEnough"), "fece00");
					}
					else
					{
						NpcFeelingOneNpc oneNpcByXId = this.doc.GetOneNpcByXId(this.operate.GetXNpcId());
						bool flag4 = oneNpcByXId == null;
						if (flag4)
						{
							return true;
						}
						bool flag5 = oneNpcByXId.level >= this.doc.NpcFlLevTop;
						if (flag5)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_NPCFL_NPC_LEVEL_MAX"), "fece00");
							return true;
						}
						bool flag6 = this.doc.IsCanLevelUp(oneNpcByXId);
						if (flag6)
						{
							NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.operate.GetXNpcId());
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("NPCFavorisFull"), npcTableInfoByXId.name), "fece00");
							return true;
						}
						bool flag7 = this.operate != null;
						if (flag7)
						{
							this.doc.ReqSrvGiveGift(oneNpcByXId.npcid, npcLikeItem);
							ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemid);
							string arg = (itemConf == null) ? string.Empty : itemConf.ItemName[0];
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("NPCSendHint"), itemcount, arg, addexp), "fece00");
						}
					}
					result = true;
				}
			}
			return result;
		}

		private XNPCFavorDocument doc;

		private IXUILabel m_LeftTimes;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private List<NpcLikeItem> likeItems;
	}
}
