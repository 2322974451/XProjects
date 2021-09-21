using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F0D RID: 3853
	internal class XJadeItemDrawer : XItemDrawer
	{
		// Token: 0x0600CC83 RID: 52355 RVA: 0x002F1434 File Offset: 0x002EF634
		public void DrawItem(GameObject go, int itemid, int itemCount = 0, bool bForceShowNum = false)
		{
			this._GetUI(go);
			bool flag = itemid == 0;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				base._GetItemData(itemid);
				this._SetupIcon();
				this._SetupName(null);
				this._SetupAttrIcon(null);
				base._SetupNum(itemCount, bForceShowNum);
				this._SetupNumTop(null);
				base._SetupLeftDownCorner(base._GetBindingState(null));
				base._SetupLeftUpCorner(false, "");
				base._SetupRightDownCorner(false);
				base._SetupRightUpCorner(false);
				base._SetUpProf(false);
				base._SetupMask();
				this._ClearVariables();
			}
		}

		// Token: 0x0600CC84 RID: 52356 RVA: 0x002F14D8 File Offset: 0x002EF6D8
		public void DrawItem(GameObject go, int itemid, int itemUseCount, bool bForceShowNum, int itemCount)
		{
			this._GetUI(go);
			bool flag = itemid == 0;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				base._GetItemData(itemid);
				this._SetupIcon();
				this._SetupName(null);
				this._SetupAttrIcon(null);
				base._SetupNum(itemUseCount, bForceShowNum, itemCount);
				this._SetupNumTop(null);
				base._SetupLeftDownCorner(base._GetBindingState(null));
				base._SetupLeftUpCorner(false, "");
				base._SetupRightDownCorner(false);
				base._SetupRightUpCorner(false);
				base._SetUpProf(false);
				base._SetupMask();
				this._ClearVariables();
			}
		}

		// Token: 0x0600CC85 RID: 52357 RVA: 0x002F157C File Offset: 0x002EF77C
		protected override void _SetupNumTop(XItem jade)
		{
			bool flag = this.m_numTop != null && this.itemdata != null;
			if (flag)
			{
				XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
				JadeTable jadeTable = specificDocument.jadeTable;
				JadeTable.RowData byJadeID = jadeTable.GetByJadeID((uint)this.itemdata.ItemID);
				bool flag2 = byJadeID != null;
				if (flag2)
				{
					base._SetNumTopUI("Lv." + byJadeID.JadeLevel);
				}
			}
		}
	}
}
