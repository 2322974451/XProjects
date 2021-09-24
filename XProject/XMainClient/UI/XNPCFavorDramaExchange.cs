using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XNPCFavorDramaExchange : DlgHandlerBase
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
				return "GameSystem/NpcBlessing/NpcChangePresent";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this.exchangeBtn = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.npcReturnItem = base.transform.Find("Bg/ItemNpc");
			this.myItem = base.transform.Find("Bg/ItemPlayer");
			this.closeBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		protected override void OnShow()
		{
			this.RefreshData();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.exchangeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickExchange));
			this.closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
		}

		public override void OnUnload()
		{
			this.doc = null;
			this.role2npc = null;
			this.npc2role = null;
		}

		public override void RefreshData()
		{
			XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
			bool flag = xnpcfavorDrama != null;
			if (flag)
			{
				List<ItemBrief> exchangeInfoByXId = this.doc.GetExchangeInfoByXId(xnpcfavorDrama.GetXNpcId());
				bool flag2 = exchangeInfoByXId != null;
				if (flag2)
				{
					bool flag3 = this.doc.Role2NPC != null && this.doc.NPC2Role != null && this.doc.ExchangeNPCID == XNPCFavorDocument.GetNpcIdByXId(xnpcfavorDrama.GetXNpcId());
					if (flag3)
					{
						this.role2npc = this.doc.Role2NPC;
						this.npc2role = this.doc.NPC2Role;
					}
					else
					{
						bool flag4 = exchangeInfoByXId != null && exchangeInfoByXId.Count > 0 && exchangeInfoByXId.Count % 2 == 0;
						if (flag4)
						{
							int num = exchangeInfoByXId.Count - 1;
							this.role2npc = exchangeInfoByXId[num - 1];
							this.npc2role = exchangeInfoByXId[num];
						}
					}
					bool flag5 = this.role2npc == null || this.npc2role == null;
					if (!flag5)
					{
						this.DrawItem(this.myItem, (int)this.role2npc.itemID, (int)this.role2npc.itemCount);
						this.DrawItem(this.npcReturnItem, (int)this.npc2role.itemID, (int)this.npc2role.itemCount);
					}
				}
			}
		}

		private bool OnClickExchange(IXUIButton btn)
		{
			bool flag = this.role2npc == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.role2npc != null;
				if (flag2)
				{
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)this.role2npc.itemID);
					bool flag3 = itemCount < (ulong)this.role2npc.itemCount;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCExchangeItemNotEnough"), "fece00");
						return true;
					}
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.role2npc.itemID);
					string arg = (itemConf == null) ? string.Empty : itemConf.ItemName[0];
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("NPCExchangeHint"), this.role2npc.itemCount, arg), new ButtonClickEventHandler(this.ConfirmExchange));
				}
				result = true;
			}
			return result;
		}

		private bool OnClickClose(IXUIButton btn)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private bool ConfirmExchange(IXUIButton btn)
		{
			XNPCFavorDrama xnpcfavorDrama = XNPCFavorDocument.IsNpcDialogVisible();
			bool flag = xnpcfavorDrama != null && this.role2npc != null && this.npc2role != null;
			if (flag)
			{
				this.doc.ReqSrvExchangeGift(XNPCFavorDocument.GetNpcIdByXId(xnpcfavorDrama.GetXNpcId()), this.role2npc, this.npc2role);
			}
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private void DrawItem(Transform item, int itemId, int itemNum)
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(item.gameObject, itemId, itemNum, true);
			IXUISprite ixuisprite = item.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)itemId);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			IXUILabel ixuilabel = item.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemId);
			ixuilabel.SetText((itemConf != null) ? itemConf.ItemName[0] : string.Empty);
		}

		private XNPCFavorDocument doc;

		private IXUIButton exchangeBtn = null;

		private Transform npcReturnItem = null;

		private Transform myItem = null;

		private IXUIButton closeBtn = null;

		private ItemBrief role2npc = null;

		private ItemBrief npc2role = null;
	}
}
