using System;
using UnityEngine;

namespace XMainClient
{

	internal class XFashionDrawer : XItemDrawer
	{

		protected override string RightDownCornerName
		{
			get
			{
				return "sp_1";
			}
		}

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

		public void DrawItem(GameObject go, ClientFashionData fashion)
		{
			this.DrawItem(go, (int)fashion.itemID);
			this._SetupTime();
		}

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

		protected void _SetupTime()
		{
		}
	}
}
