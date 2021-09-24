using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class ArtifactOneKeyHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactOneKeyFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactComposeDocument.Doc;
			this.m_closedBtn = (base.PanelObject.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_oneKeyBtn = (base.PanelObject.transform.FindChild("BtnOneKeyCompose").GetComponent("XUIButton") as IXUIButton);
			this.m_checkBoxB = (base.PanelObject.transform.FindChild("Bg/All_B/Category/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_checkBoxA = (base.PanelObject.transform.FindChild("Bg/All_A/Category/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void FillContent()
		{
			this.m_selectLst.Clear();
			this.m_checkBoxB.ForceSetFlag(false);
			this.m_checkBoxB.ForceSetFlag(true);
			this.m_checkBoxA.ForceSetFlag(false);
		}

		private bool OnClickClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

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

		private ArtifactComposeDocument m_doc;

		private IXUIButton m_closedBtn;

		private IXUIButton m_oneKeyBtn;

		private IXUICheckBox m_checkBoxB;

		private IXUICheckBox m_checkBoxA;

		private float m_delayTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private List<uint> m_selectLst = new List<uint>();
	}
}
