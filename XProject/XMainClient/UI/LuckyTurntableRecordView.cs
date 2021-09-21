using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017E8 RID: 6120
	internal class LuckyTurntableRecordView : DlgBase<LuckyTurntableRecordView, LuckyTurntableRecordBehaviour>
	{
		// Token: 0x170038BB RID: 14523
		// (get) Token: 0x0600FDB0 RID: 64944 RVA: 0x003B8824 File Offset: 0x003B6A24
		public override string fileName
		{
			get
			{
				return "OperatingActivity/LuckyRecordDlg";
			}
		}

		// Token: 0x0600FDB1 RID: 64945 RVA: 0x003B883C File Offset: 0x003B6A3C
		protected override void Init()
		{
			this.m_btnBack = (base.uiBehaviour.transform.Find("backclick").GetComponent("XUIButton") as IXUIButton);
			this.m_btnClose = (base.uiBehaviour.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_root = base.uiBehaviour.transform.Find("Bg/ScrollView");
			GameObject gameObject = base.uiBehaviour.transform.Find("Bg/ScrollView/Item").gameObject;
			this.m_ItemPool.SetupPool(this.m_root.gameObject, gameObject, 8U, false);
		}

		// Token: 0x0600FDB2 RID: 64946 RVA: 0x003B88F0 File Offset: 0x003B6AF0
		public void ShowList(List<KeyValuePair<int, int>> list)
		{
			this.m_map.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in list)
			{
				bool flag = !this.m_map.ContainsKey(keyValuePair.Key);
				if (flag)
				{
					this.m_map[keyValuePair.Key] = 0;
				}
				Dictionary<int, int> map = this.m_map;
				int key = keyValuePair.Key;
				map[key] += keyValuePair.Value;
			}
			this.SetVisibleWithAnimation(true, null);
			this.RefreshList();
		}

		// Token: 0x0600FDB3 RID: 64947 RVA: 0x003B89B0 File Offset: 0x003B6BB0
		public void RefreshList()
		{
			this.m_ItemPool.ReturnAll(false);
			List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>(this.m_map);
			list.Sort(delegate(KeyValuePair<int, int> a, KeyValuePair<int, int> b)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(a.Key);
				ItemList.RowData itemConf2 = XBagDocument.GetItemConf(b.Key);
				bool flag = itemConf == null;
				int result;
				if (flag)
				{
					result = 1;
				}
				else
				{
					bool flag2 = itemConf2 == null;
					if (flag2)
					{
						result = -1;
					}
					else
					{
						bool flag3 = itemConf.ItemQuality > itemConf2.ItemQuality;
						if (flag3)
						{
							result = -1;
						}
						else
						{
							bool flag4 = itemConf.ItemQuality < itemConf2.ItemQuality;
							if (flag4)
							{
								result = 1;
							}
							else
							{
								result = itemConf.SortID.CompareTo(itemConf2.SortID);
							}
						}
					}
				}
				return result;
			});
			for (int i = 0; i < list.Count; i++)
			{
				KeyValuePair<int, int> keyValuePair = list[i];
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.name = keyValuePair.Key.ToString();
				gameObject.transform.localPosition = new Vector3((float)(i * this.m_ItemPool.TplWidth), 0f, 0f) + this.m_ItemPool.TplPos;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)keyValuePair.Key);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, keyValuePair.Key, keyValuePair.Value, false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x0600FDB4 RID: 64948 RVA: 0x003B8AEA File Offset: 0x003B6CEA
		public override void RegisterEvent()
		{
			this.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_btnBack.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600FDB5 RID: 64949 RVA: 0x003B8B20 File Offset: 0x003B6D20
		private bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x04006FF8 RID: 28664
		private IXUIButton m_btnBack;

		// Token: 0x04006FF9 RID: 28665
		private IXUIButton m_btnClose;

		// Token: 0x04006FFA RID: 28666
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006FFB RID: 28667
		private Transform m_root;

		// Token: 0x04006FFC RID: 28668
		private Dictionary<int, int> m_map = new Dictionary<int, int>();
	}
}
