using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XJadeSlotDrawer : XItemDrawer
	{

		public void DrawItem(GameObject go, uint slot, bool hasLock, XJadeItem realItem)
		{
			this._GetUI(go);
			this.SetupCoverAndBack(slot, hasLock);
			this._SetupAttrIcon(null);
			XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(go, realItem, false);
			this._ClearVariables();
		}

		private void SetupCoverAndBack(uint slot, bool hasLock)
		{
			bool flag = !XJadeInfo.SlotExists(slot);
			if (flag)
			{
				if (hasLock)
				{
					this.cover.SetVisible(true);
					this.lockJade.SetVisible(true);
					this.total.SetVisible(true);
				}
				else
				{
					this.lockJade.SetVisible(false);
					this.cover.SetVisible(false);
					this.back.SetVisible(false);
					this.total.SetVisible(false);
				}
			}
			else
			{
				this.total.SetVisible(true);
				this.lockJade.SetVisible(false);
				this.cover.SetVisible(false);
				this.back.SetVisible(true);
				this.back.SetSprite("iconly_" + slot);
			}
		}

		protected override void _GetUI(GameObject uiGo)
		{
			base._GetUI(uiGo);
			this.cover = (uiGo.transform.FindChild("Cover").GetComponent("XUISprite") as IXUISprite);
			this.back = (uiGo.transform.FindChild("Back").GetComponent("XUISprite") as IXUISprite);
			this.total = (uiGo.transform.GetComponent("XUISprite") as IXUISprite);
			this.lockJade = (uiGo.transform.FindChild("Lock").GetComponent("XUISprite") as IXUISprite);
		}

		protected override void _ClearVariables()
		{
			base._ClearVariables();
			this.cover = null;
			this.back = null;
		}

		private IXUISprite cover;

		private IXUISprite back;

		private IXUISprite total;

		private IXUISprite lockJade;
	}
}
