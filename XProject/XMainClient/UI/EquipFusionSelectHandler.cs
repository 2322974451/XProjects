using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016E1 RID: 5857
	internal class EquipFusionSelectHandler : DlgHandlerBase
	{
		// Token: 0x17003754 RID: 14164
		// (get) Token: 0x0600F1B3 RID: 61875 RVA: 0x00357904 File Offset: 0x00355B04
		protected override string FileName
		{
			get
			{
				return "ItemNew/EquipFusionSelectWindow";
			}
		}

		// Token: 0x0600F1B4 RID: 61876 RVA: 0x0035791C File Offset: 0x00355B1C
		protected override void Init()
		{
			base.Init();
			this.m_doc = EquipFusionDocument.Doc;
			this.m_closeBtn = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_parentTra = base.PanelObject.transform.Find("Bg/Panel");
			this.m_tplPool.SetupPool(base.PanelObject.transform.Find("Bg").gameObject, this.m_parentTra.Find("ItemTpl").gameObject, 2U, false);
		}

		// Token: 0x0600F1B5 RID: 61877 RVA: 0x003579BE File Offset: 0x00355BBE
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
		}

		// Token: 0x0600F1B6 RID: 61878 RVA: 0x003579E0 File Offset: 0x00355BE0
		protected override void OnShow()
		{
			base.OnShow();
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					this.m_needMaterial = equipConf.FuseCoreItems;
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player == null;
					if (!flag3)
					{
						XEquipItem xequipItem = itemByUID as XEquipItem;
						EquipFusionTable.RowData fuseData = this.m_doc.GetFuseData(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, equipConf, xequipItem.fuseInfo.BreakNum);
						bool flag4 = fuseData == null;
						if (!flag4)
						{
							this.m_needExp = fuseData.NeedExpPerLevel;
							this.FillItems();
						}
					}
				}
			}
		}

		// Token: 0x0600F1B7 RID: 61879 RVA: 0x00357AA0 File Offset: 0x00355CA0
		protected override void OnHide()
		{
			base.OnHide();
			this.m_tplPool.ReturnAll(false);
		}

		// Token: 0x0600F1B8 RID: 61880 RVA: 0x00357AB7 File Offset: 0x00355CB7
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_tplPool.ReturnAll(false);
		}

		// Token: 0x0600F1B9 RID: 61881 RVA: 0x00209F22 File Offset: 0x00208122
		public override void RefreshData()
		{
			base.RefreshData();
		}

		// Token: 0x0600F1BA RID: 61882 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F1BB RID: 61883 RVA: 0x00357AD0 File Offset: 0x00355CD0
		private void FillItems()
		{
			this.m_tplPool.ReturnAll(false);
			for (int i = 0; i < this.m_needMaterial.Length; i++)
			{
				GameObject gameObject = this.m_tplPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_parentTra;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(this.m_tplPool.TplWidth * (i % 2)), (float)(-(float)this.m_tplPool.TplHeight * (i / 2)), 0f);
				uint num = this.m_needMaterial[i];
				ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)num);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num, 0, false);
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)i);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItem));
				IXUILabel ixuilabel = gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.gameObject.SetActive(true);
				uint addExp = this.m_doc.GetAddExp(num);
				uint num2 = 0U;
				bool flag = addExp > 0U;
				if (flag)
				{
					num2 = ((this.m_needExp % addExp == 0U) ? (this.m_needExp / addExp) : (this.m_needExp / addExp + 1U));
				}
				bool flag2 = itemCount >= (ulong)num2;
				if (flag2)
				{
					ixuilabel.SetText(string.Format("[00ff00]{0}[-]/{1}", itemCount, num2));
				}
				else
				{
					ixuilabel.SetText(string.Format("[ff0000]{0}[-]/{1}", itemCount, num2));
				}
			}
		}

		// Token: 0x0600F1BC RID: 61884 RVA: 0x00357C98 File Offset: 0x00355E98
		private bool OnClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600F1BD RID: 61885 RVA: 0x00357CB4 File Offset: 0x00355EB4
		private void OnClickItem(IXUISprite spr)
		{
			int num = (int)spr.ID;
			bool flag = num >= this.m_needMaterial.Length;
			if (!flag)
			{
				this.m_doc.AddMaterial((int)this.m_needMaterial[num]);
				base.SetVisible(false);
			}
		}

		// Token: 0x0400675C RID: 26460
		private EquipFusionDocument m_doc;

		// Token: 0x0400675D RID: 26461
		private IXUIButton m_closeBtn;

		// Token: 0x0400675E RID: 26462
		private uint[] m_needMaterial;

		// Token: 0x0400675F RID: 26463
		private uint m_needExp = 0U;

		// Token: 0x04006760 RID: 26464
		private Transform m_parentTra;

		// Token: 0x04006761 RID: 26465
		private XUIPool m_tplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
