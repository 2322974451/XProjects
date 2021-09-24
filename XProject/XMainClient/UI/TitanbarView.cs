using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class TitanbarView : DlgBase<TitanbarView, TitanBarBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/TitanBar";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("DefaultTitanItems").Split(XGlobalConfig.ListSeparator);
			this.m_DefaultItemID = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.m_DefaultItemID[i] = int.Parse(array[i]);
			}
		}

		public void SetTitanItems(XSysDefine sys)
		{
			int[] titanItems = this._GetItemIDs(sys);
			this.SetTitanItems(titanItems);
		}

		public void SetTitanItems(int[] itemids)
		{
			base.uiBehaviour.m_ItemPool.FakeReturnAll();
			for (int i = 0; i < base.uiBehaviour.m_ItemList.Count; i++)
			{
				base.uiBehaviour.m_ItemList[i].Recycle();
			}
			base.uiBehaviour.m_ItemList.Clear();
			bool flag = itemids != null;
			if (flag)
			{
				Vector3 tplPos = base.uiBehaviour.m_ItemPool.TplPos;
				for (int j = 0; j < itemids.Length; j++)
				{
					XTitanItem data = XDataPool<XTitanItem>.GetData();
					base.uiBehaviour.m_ItemList.Add(data);
					GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x - (float)(base.uiBehaviour.m_ItemPool.TplWidth * (itemids.Length - 1 - j)), tplPos.y, tplPos.z);
					data.Set(itemids[j], gameObject);
				}
			}
			base.uiBehaviour.m_ItemPool.ActualReturnAll(false);
		}

		public void TryRefresh(List<int> itemids)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				for (int i = 0; i < itemids.Count; i++)
				{
					this.TryRefresh(itemids[i]);
				}
			}
		}

		public void TryRefresh(int itemid)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				for (int i = 0; i < base.uiBehaviour.m_ItemList.Count; i++)
				{
					bool flag2 = base.uiBehaviour.m_ItemList[i].ItemID == itemid;
					if (flag2)
					{
						base.uiBehaviour.m_ItemList[i].RefreshValue(true);
						break;
					}
				}
			}
		}

		private int[] _GetItemIDs(XSysDefine sys)
		{
			OpenSystemTable.RowData sysData = XSingleton<XGameSysMgr>.singleton.GetSysData(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys));
			bool flag = sysData == null;
			int[] result;
			if (flag)
			{
				result = this.m_DefaultItemID;
			}
			else
			{
				result = sysData.TitanItems;
			}
			return result;
		}

		private int[] m_DefaultItemID;
	}
}
