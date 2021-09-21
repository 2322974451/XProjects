using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017D3 RID: 6099
	internal class XNPCFavorDramaExchange : DlgHandlerBase
	{
		// Token: 0x170038A6 RID: 14502
		// (get) Token: 0x0600FCAC RID: 64684 RVA: 0x003AF894 File Offset: 0x003ADA94
		private XNPCFavorDrama operate
		{
			get
			{
				return XNPCFavorDocument.IsNpcDialogVisible();
			}
		}

		// Token: 0x170038A7 RID: 14503
		// (get) Token: 0x0600FCAD RID: 64685 RVA: 0x003AF8AC File Offset: 0x003ADAAC
		protected override string FileName
		{
			get
			{
				return "GameSystem/NpcBlessing/NpcChangePresent";
			}
		}

		// Token: 0x0600FCAE RID: 64686 RVA: 0x003AF8C4 File Offset: 0x003ADAC4
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this.exchangeBtn = (base.transform.Find("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.npcReturnItem = base.transform.Find("Bg/ItemNpc");
			this.myItem = base.transform.Find("Bg/ItemPlayer");
			this.closeBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600FCAF RID: 64687 RVA: 0x001A787A File Offset: 0x001A5A7A
		protected override void OnShow()
		{
			this.RefreshData();
		}

		// Token: 0x0600FCB0 RID: 64688 RVA: 0x003AF95F File Offset: 0x003ADB5F
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.exchangeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickExchange));
			this.closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
		}

		// Token: 0x0600FCB1 RID: 64689 RVA: 0x003AF999 File Offset: 0x003ADB99
		public override void OnUnload()
		{
			this.doc = null;
			this.role2npc = null;
			this.npc2role = null;
		}

		// Token: 0x0600FCB2 RID: 64690 RVA: 0x003AF9B4 File Offset: 0x003ADBB4
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

		// Token: 0x0600FCB3 RID: 64691 RVA: 0x003AFB04 File Offset: 0x003ADD04
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

		// Token: 0x0600FCB4 RID: 64692 RVA: 0x003AFBEC File Offset: 0x003ADDEC
		private bool OnClickClose(IXUIButton btn)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600FCB5 RID: 64693 RVA: 0x003AFC0C File Offset: 0x003ADE0C
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

		// Token: 0x0600FCB6 RID: 64694 RVA: 0x003AFC74 File Offset: 0x003ADE74
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

		// Token: 0x04006F18 RID: 28440
		private XNPCFavorDocument doc;

		// Token: 0x04006F19 RID: 28441
		private IXUIButton exchangeBtn = null;

		// Token: 0x04006F1A RID: 28442
		private Transform npcReturnItem = null;

		// Token: 0x04006F1B RID: 28443
		private Transform myItem = null;

		// Token: 0x04006F1C RID: 28444
		private IXUIButton closeBtn = null;

		// Token: 0x04006F1D RID: 28445
		private ItemBrief role2npc = null;

		// Token: 0x04006F1E RID: 28446
		private ItemBrief npc2role = null;
	}
}
