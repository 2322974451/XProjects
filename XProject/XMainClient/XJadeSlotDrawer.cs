using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F0E RID: 3854
	internal class XJadeSlotDrawer : XItemDrawer
	{
		// Token: 0x0600CC87 RID: 52359 RVA: 0x002F15EE File Offset: 0x002EF7EE
		public void DrawItem(GameObject go, uint slot, bool hasLock, XJadeItem realItem)
		{
			this._GetUI(go);
			this.SetupCoverAndBack(slot, hasLock);
			this._SetupAttrIcon(null);
			XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(go, realItem, false);
			this._ClearVariables();
		}

		// Token: 0x0600CC88 RID: 52360 RVA: 0x002F1628 File Offset: 0x002EF828
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

		// Token: 0x0600CC89 RID: 52361 RVA: 0x002F1700 File Offset: 0x002EF900
		protected override void _GetUI(GameObject uiGo)
		{
			base._GetUI(uiGo);
			this.cover = (uiGo.transform.FindChild("Cover").GetComponent("XUISprite") as IXUISprite);
			this.back = (uiGo.transform.FindChild("Back").GetComponent("XUISprite") as IXUISprite);
			this.total = (uiGo.transform.GetComponent("XUISprite") as IXUISprite);
			this.lockJade = (uiGo.transform.FindChild("Lock").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x0600CC8A RID: 52362 RVA: 0x002F17A0 File Offset: 0x002EF9A0
		protected override void _ClearVariables()
		{
			base._ClearVariables();
			this.cover = null;
			this.back = null;
		}

		// Token: 0x04005AEC RID: 23276
		private IXUISprite cover;

		// Token: 0x04005AED RID: 23277
		private IXUISprite back;

		// Token: 0x04005AEE RID: 23278
		private IXUISprite total;

		// Token: 0x04005AEF RID: 23279
		private IXUISprite lockJade;
	}
}
