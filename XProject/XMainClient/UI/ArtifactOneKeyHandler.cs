using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020017B4 RID: 6068
	internal class ArtifactOneKeyHandler : DlgHandlerBase
	{
		// Token: 0x1700387E RID: 14462
		// (get) Token: 0x0600FB13 RID: 64275 RVA: 0x003A3380 File Offset: 0x003A1580
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactOneKeyFrame";
			}
		}

		// Token: 0x0600FB14 RID: 64276 RVA: 0x003A3398 File Offset: 0x003A1598
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactComposeDocument.Doc;
			this.m_closedBtn = (base.PanelObject.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_oneKeyBtn = (base.PanelObject.transform.FindChild("BtnOneKeyCompose").GetComponent("XUIButton") as IXUIButton);
			this.m_checkBoxB = (base.PanelObject.transform.FindChild("Bg/All_B/Category/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_checkBoxA = (base.PanelObject.transform.FindChild("Bg/All_A/Category/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
		}

		// Token: 0x0600FB15 RID: 64277 RVA: 0x003A3460 File Offset: 0x003A1660
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
			this.m_oneKeyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickOneKeyCompose));
			this.m_checkBoxB.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickCheckBox));
			this.m_checkBoxB.ID = 2UL;
			this.m_checkBoxA.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickCheckBox));
			this.m_checkBoxA.ID = 3UL;
		}

		// Token: 0x0600FB16 RID: 64278 RVA: 0x003A34F1 File Offset: 0x003A16F1
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FB17 RID: 64279 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FB18 RID: 64280 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FB19 RID: 64281 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FB1A RID: 64282 RVA: 0x003A3502 File Offset: 0x003A1702
		private void FillContent()
		{
			this.m_selectLst.Clear();
			this.m_checkBoxB.ForceSetFlag(false);
			this.m_checkBoxB.ForceSetFlag(true);
			this.m_checkBoxA.ForceSetFlag(false);
		}

		// Token: 0x0600FB1B RID: 64283 RVA: 0x003A3538 File Offset: 0x003A1738
		private bool OnClickClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600FB1C RID: 64284 RVA: 0x003A3554 File Offset: 0x003A1754
		private bool OnClickOneKeyCompose(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_delayTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_doc.ReqOneKeyCompose(this.m_selectLst);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FB1D RID: 64285 RVA: 0x003A3590 File Offset: 0x003A1790
		private bool OnClickCheckBox(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			if (flag)
			{
				this.m_selectLst.Remove((uint)box.ID);
			}
			else
			{
				uint item = (uint)box.ID;
				bool flag2 = !this.m_selectLst.Contains(item);
				if (flag2)
				{
					this.m_selectLst.Add(item);
				}
			}
			return true;
		}

		// Token: 0x0600FB1E RID: 64286 RVA: 0x003A35F0 File Offset: 0x003A17F0
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x04006E2B RID: 28203
		private ArtifactComposeDocument m_doc;

		// Token: 0x04006E2C RID: 28204
		private IXUIButton m_closedBtn;

		// Token: 0x04006E2D RID: 28205
		private IXUIButton m_oneKeyBtn;

		// Token: 0x04006E2E RID: 28206
		private IXUICheckBox m_checkBoxB;

		// Token: 0x04006E2F RID: 28207
		private IXUICheckBox m_checkBoxA;

		// Token: 0x04006E30 RID: 28208
		private float m_delayTime = 0.5f;

		// Token: 0x04006E31 RID: 28209
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04006E32 RID: 28210
		private List<uint> m_selectLst = new List<uint>();
	}
}
