using System;
using UnityEngine;

namespace XMainClient
{

	internal class XEmblemItemDrawer : XItemDrawer
	{

		public override void DrawItem(GameObject go, XItem realItem, bool bForceShowNum = false)
		{
			this._GetUI(go);
			bool flag = realItem == null;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				base._GetItemData(realItem.itemID);
				this._SetupIcon();
				this._SetupAttrIcon(null);
				this._SetupName(realItem);
				this._SetupNum(realItem);
				this._SetupNumTop(realItem);
				this.SetCorner(realItem);
				this._ClearVariables();
			}
		}

		private void SetCorner(XItem realItem)
		{
			bool flag = realItem == null;
			if (!flag)
			{
				XEmblemItem xemblemItem = realItem as XEmblemItem;
				base._SetupLeftDownCorner(base._GetBindingState(realItem));
				base._SetupLeftUpCorner(xemblemItem.emblemInfo.thirdslot == 2U && !xemblemItem.bIsSkillEmblem, "");
				base._SetupRightDownCorner(xemblemItem.emblemInfo.thirdslot == 1U && !xemblemItem.bIsSkillEmblem);
				base._SetupRightUpCorner(realItem.Type == ItemType.FRAGMENT);
				base._SetUpProf(false);
				base._SetupMask();
			}
		}
	}
}
