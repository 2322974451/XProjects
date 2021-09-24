using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EquipFusionSelectHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/EquipFusionSelectWindow";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = EquipFusionDocument.Doc;
			this.m_closeBtn = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_parentTra = base.PanelObject.transform.Find("Bg/Panel");
			this.m_tplPool.SetupPool(base.PanelObject.transform.Find("Bg").gameObject, this.m_parentTra.Find("ItemTpl").gameObject, 2U, false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			this.m_tplPool.ReturnAll(false);
		}

		public override void OnUnload()
		{
			base.OnUnload();
			this.m_tplPool.ReturnAll(false);
		}

		public override void RefreshData()
		{
			base.RefreshData();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		private bool OnClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

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

		private EquipFusionDocument m_doc;

		private IXUIButton m_closeBtn;

		private uint[] m_needMaterial;

		private uint m_needExp = 0U;

		private Transform m_parentTra;

		private XUIPool m_tplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
