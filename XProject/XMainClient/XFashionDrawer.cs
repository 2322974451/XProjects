using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F0C RID: 3852
	internal class XFashionDrawer : XItemDrawer
	{
		// Token: 0x17003596 RID: 13718
		// (get) Token: 0x0600CC7D RID: 52349 RVA: 0x002F1324 File Offset: 0x002EF524
		protected override string RightDownCornerName
		{
			get
			{
				return "sp_1";
			}
		}

		// Token: 0x0600CC7E RID: 52350 RVA: 0x002F133C File Offset: 0x002EF53C
		public void DrawItem(GameObject go, int fashionID)
		{
			this._GetUI(go);
			base._GetItemData(fashionID);
			bool flag = this.itemdata == null;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				this._SetupIcon();
				this._SetupName(null);
				this._SetupNum(0);
				this._SetupNumTop(null);
				this._SetupAttrIcon(null);
				base._SetupLeftDownCorner(base._GetBindingState(null));
				base._SetupLeftUpCorner(false, "");
				base._SetupRightDownCorner(false);
				base._SetupRightUpCorner(false);
				base._SetUpProf(false);
				base._SetupMask();
				this._ClearVariables();
			}
		}

		// Token: 0x0600CC7F RID: 52351 RVA: 0x002F13E0 File Offset: 0x002EF5E0
		public void DrawItem(GameObject go, ClientFashionData fashion)
		{
			this.DrawItem(go, (int)fashion.itemID);
			this._SetupTime();
		}

		// Token: 0x0600CC80 RID: 52352 RVA: 0x002F13F8 File Offset: 0x002EF5F8
		protected void _SetupNum(int level)
		{
			bool flag = level > 0;
			if (flag)
			{
				base._SetNumUI("+" + level);
			}
			else
			{
				base._SetNumUI(null);
			}
		}

		// Token: 0x0600CC81 RID: 52353 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected void _SetupTime()
		{
		}
	}
}
