using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class LuckyTurntableRecordView : DlgBase<LuckyTurntableRecordView, LuckyTurntableRecordBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "OperatingActivity/LuckyRecordDlg";
			}
		}

		protected override void Init()
		{
			this.m_btnBack = (base.uiBehaviour.transform.Find("backclick").GetComponent("XUIButton") as IXUIButton);
			this.m_btnClose = (base.uiBehaviour.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_root = base.uiBehaviour.transform.Find("Bg/ScrollView");
			GameObject gameObject = base.uiBehaviour.transform.Find("Bg/ScrollView/Item").gameObject;
			this.m_ItemPool.SetupPool(this.m_root.gameObject, gameObject, 8U, false);
		}

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

		public override void RegisterEvent()
		{
			this.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_btnBack.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		private bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private IXUIButton m_btnBack;

		private IXUIButton m_btnClose;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_root;

		private Dictionary<int, int> m_map = new Dictionary<int, int>();
	}
}
