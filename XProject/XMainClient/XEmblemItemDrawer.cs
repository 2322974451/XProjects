using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F0B RID: 3851
	internal class XEmblemItemDrawer : XItemDrawer
	{
		// Token: 0x0600CC7A RID: 52346 RVA: 0x002F121C File Offset: 0x002EF41C
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

		// Token: 0x0600CC7B RID: 52347 RVA: 0x002F1290 File Offset: 0x002EF490
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
