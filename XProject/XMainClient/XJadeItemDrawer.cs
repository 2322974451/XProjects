using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XJadeItemDrawer : XItemDrawer
	{

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
