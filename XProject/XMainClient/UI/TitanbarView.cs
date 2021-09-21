using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A9 RID: 6057
	internal class TitanbarView : DlgBase<TitanbarView, TitanBarBehaviour>
	{
		// Token: 0x1700386D RID: 14445
		// (get) Token: 0x0600FA6A RID: 64106 RVA: 0x0039E1CC File Offset: 0x0039C3CC
		public override string fileName
		{
			get
			{
				return "Hall/TitanBar";
			}
		}

		// Token: 0x1700386E RID: 14446
		// (get) Token: 0x0600FA6B RID: 64107 RVA: 0x0039E1E4 File Offset: 0x0039C3E4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700386F RID: 14447
		// (get) Token: 0x0600FA6C RID: 64108 RVA: 0x0039E1F8 File Offset: 0x0039C3F8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600FA6D RID: 64109 RVA: 0x0039E20C File Offset: 0x0039C40C
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

		// Token: 0x0600FA6E RID: 64110 RVA: 0x0039E270 File Offset: 0x0039C470
		public void SetTitanItems(XSysDefine sys)
		{
			int[] titanItems = this._GetItemIDs(sys);
			this.SetTitanItems(titanItems);
		}

		// Token: 0x0600FA6F RID: 64111 RVA: 0x0039E290 File Offset: 0x0039C490
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

		// Token: 0x0600FA70 RID: 64112 RVA: 0x0039E3C4 File Offset: 0x0039C5C4
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

		// Token: 0x0600FA71 RID: 64113 RVA: 0x0039E408 File Offset: 0x0039C608
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

		// Token: 0x0600FA72 RID: 64114 RVA: 0x0039E480 File Offset: 0x0039C680
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

		// Token: 0x04006DC4 RID: 28100
		private int[] m_DefaultItemID;
	}
}
