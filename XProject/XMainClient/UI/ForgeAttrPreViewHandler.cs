using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200173B RID: 5947
	internal class ForgeAttrPreViewHandler : DlgHandlerBase
	{
		// Token: 0x0600F5BC RID: 62908 RVA: 0x003789F4 File Offset: 0x00376BF4
		protected override void Init()
		{
			base.Init();
			this.m_doc = XForgeDocument.Doc;
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_scrollView = (base.PanelObject.transform.FindChild("Detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_detailGo = base.PanelObject.transform.FindChild("Detail").gameObject;
			this.m_itemPool.SetupPool(base.PanelObject, base.PanelObject.transform.FindChild("Tpl").gameObject, 3U, true);
			this.m_WithoutAttrGo = base.PanelObject.transform.FindChild("Withoutattr").gameObject;
			this.m_WithAttrGo = base.PanelObject.transform.FindChild("Withattr").gameObject;
		}

		// Token: 0x0600F5BD RID: 62909 RVA: 0x00378AF6 File Offset: 0x00376CF6
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600F5BE RID: 62910 RVA: 0x00378B18 File Offset: 0x00376D18
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600F5BF RID: 62911 RVA: 0x00378B29 File Offset: 0x00376D29
		protected override void OnHide()
		{
			this.m_itemPool.ReturnAll(false);
			base.OnHide();
		}

		// Token: 0x0600F5C0 RID: 62912 RVA: 0x00378B40 File Offset: 0x00376D40
		public override void OnUnload()
		{
			this.m_doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600F5C1 RID: 62913 RVA: 0x00378B58 File Offset: 0x00376D58
		private void FillContent()
		{
			this.m_itemPool.ReturnAll(true);
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				XEquipItem xequipItem = itemByUID as XEquipItem;
				bool flag2 = xequipItem.forgeAttrInfo.ForgeAttr.Count == 0;
				if (flag2)
				{
					this.m_WithoutAttrGo.SetActive(true);
					this.m_WithAttrGo.SetActive(false);
				}
				else
				{
					this.m_WithoutAttrGo.SetActive(false);
					this.m_WithAttrGo.SetActive(true);
				}
				EquipSlotAttrDatas attrData = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)itemByUID.itemID);
				bool flag3 = attrData == null;
				if (!flag3)
				{
					EquipSlotAttrData attrData2 = attrData.GetAttrData(1);
					bool flag4 = attrData2 == null;
					if (!flag4)
					{
						int num = 0;
						for (int i = 0; i < attrData2.AttrDataList.Count; i++)
						{
							EquipAttrData equipAttrData = attrData2.AttrDataList[i];
							bool flag5 = equipAttrData.Prob == 0U;
							if (!flag5)
							{
								string text = XAttributeCommon.GetAttrStr((int)equipAttrData.AttrId);
								bool flag6 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
								if (flag6)
								{
									ProfessionTable.RowData byProfID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID);
									bool flag7 = byProfID != null;
									if (flag7)
									{
										List<int> list;
										bool flag8 = this.m_doc.AttackTypeDic.TryGetValue((int)byProfID.AttackType, out list);
										if (flag8)
										{
											for (int j = 0; j < list.Count; j++)
											{
												bool flag9 = (long)list[j] == (long)((ulong)equipAttrData.AttrId);
												if (flag9)
												{
													text = string.Empty;
													break;
												}
											}
										}
									}
								}
								bool flag10 = text == string.Empty;
								if (!flag10)
								{
									GameObject gameObject = this.m_itemPool.FetchGameObject(false);
									gameObject.transform.parent = this.m_detailGo.transform;
									gameObject.transform.localPosition = this.m_itemPool.TplPos + new Vector3((float)(this.m_itemPool.TplWidth * (num % 2)), (float)(-(float)this.m_itemPool.TplHeight * (num / 2)), 0f);
									IXUILabel ixuilabel = gameObject.transform.FindChild("AttrName").GetComponent("XUILabel") as IXUILabel;
									ixuilabel.SetText(text);
									num++;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F5C2 RID: 62914 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnCloseClicked(IXUISprite spr)
		{
			base.SetVisible(false);
		}

		// Token: 0x04006A72 RID: 27250
		private XForgeDocument m_doc;

		// Token: 0x04006A73 RID: 27251
		private IXUISprite m_closeBtn;

		// Token: 0x04006A74 RID: 27252
		private IXUIScrollView m_scrollView;

		// Token: 0x04006A75 RID: 27253
		private GameObject m_detailGo;

		// Token: 0x04006A76 RID: 27254
		private GameObject m_WithoutAttrGo;

		// Token: 0x04006A77 RID: 27255
		private GameObject m_WithAttrGo;

		// Token: 0x04006A78 RID: 27256
		private XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
