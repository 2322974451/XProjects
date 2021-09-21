using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A26 RID: 2598
	internal class CapacityDownDlg : DlgBase<CapacityDownDlg, CapacityBehaviour>
	{
		// Token: 0x17002EC8 RID: 11976
		// (get) Token: 0x06009EB1 RID: 40625 RVA: 0x001A2630 File Offset: 0x001A0830
		public override string fileName
		{
			get
			{
				return "GameSystem/CapacityDownDlg";
			}
		}

		// Token: 0x17002EC9 RID: 11977
		// (get) Token: 0x06009EB2 RID: 40626 RVA: 0x001A2648 File Offset: 0x001A0848
		public override int layer
		{
			get
			{
				return 99;
			}
		}

		// Token: 0x17002ECA RID: 11978
		// (get) Token: 0x06009EB3 RID: 40627 RVA: 0x001A265C File Offset: 0x001A085C
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002ECB RID: 11979
		// (get) Token: 0x06009EB4 RID: 40628 RVA: 0x001A2670 File Offset: 0x001A0870
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06009EB5 RID: 40629 RVA: 0x001A2683 File Offset: 0x001A0883
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x06009EB6 RID: 40630 RVA: 0x001A2690 File Offset: 0x001A0890
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closeSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickCloseSpr));
			base.uiBehaviour.m_checkBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickChexckBox));
		}

		// Token: 0x06009EB7 RID: 40631 RVA: 0x001A26DF File Offset: 0x001A08DF
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06009EB8 RID: 40632 RVA: 0x001A26E9 File Offset: 0x001A08E9
		protected override void Init()
		{
			base.Init();
			this.IsInit = true;
			this.m_optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
		}

		// Token: 0x06009EB9 RID: 40633 RVA: 0x001A270A File Offset: 0x001A090A
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009EBA RID: 40634 RVA: 0x001A2714 File Offset: 0x001A0914
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x06009EBB RID: 40635 RVA: 0x001A2725 File Offset: 0x001A0925
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x06009EBC RID: 40636 RVA: 0x001A2730 File Offset: 0x001A0930
		public void InitPPT()
		{
			bool flag = !this.m_init;
			if (flag)
			{
				this.m_init = true;
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag2 = player != null;
				if (flag2)
				{
					XPlayerAttributes xplayerAttributes = player.Attributes as XPlayerAttributes;
					bool flag3 = xplayerAttributes != null;
					if (flag3)
					{
						this.m_oldPPT = (int)xplayerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
					}
				}
			}
		}

		// Token: 0x06009EBD RID: 40637 RVA: 0x001A2794 File Offset: 0x001A0994
		public void UpdatePPT(int newPPT)
		{
			bool flag = !EquipFusionDocument.IsEquipDown || newPPT > this.m_oldPPT;
			if (flag)
			{
				this.m_oldPPT = newPPT;
				EquipFusionDocument.IsEquipDown = false;
			}
			else
			{
				EquipFusionDocument.IsEquipDown = false;
				this.m_oldPPT = newPPT;
				this.m_define = XOptionsDefine.OD_NO_CAPACITYDOWN_TIPS;
				this.m_strKey = "PowerDownTips";
				this.m_optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				bool flag2 = this.m_optionsDoc.GetValue(this.m_define) == 1;
				if (!flag2)
				{
					this.SetVisible(true, true);
				}
			}
		}

		// Token: 0x06009EBE RID: 40638 RVA: 0x001A2820 File Offset: 0x001A0A20
		public void ShowRecycleTips()
		{
			this.m_define = XOptionsDefine.OD_RECYCLE_TIPS;
			this.m_strKey = "RecycleTips";
			this.m_optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			bool flag = this.m_optionsDoc.GetValue(this.m_define) == 1;
			if (!flag)
			{
				this.SetVisible(true, true);
			}
		}

		// Token: 0x06009EBF RID: 40639 RVA: 0x001A2878 File Offset: 0x001A0A78
		public void ShowTips(XOptionsDefine opt, string key)
		{
			this.m_define = opt;
			this.m_strKey = key;
			this.m_optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			bool flag = this.m_optionsDoc.GetValue(this.m_define) == 1;
			if (!flag)
			{
				this.SetVisible(true, true);
			}
		}

		// Token: 0x06009EC0 RID: 40640 RVA: 0x001A28C8 File Offset: 0x001A0AC8
		private void FillContent()
		{
			base.uiBehaviour.m_checkBox.bChecked = false;
			base.uiBehaviour.m_checkBox.ForceSetFlag(false);
			base.uiBehaviour.m_lable.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString(this.m_strKey)));
		}

		// Token: 0x06009EC1 RID: 40641 RVA: 0x001A2925 File Offset: 0x001A0B25
		private void OnClickCloseSpr(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x06009EC2 RID: 40642 RVA: 0x001A2934 File Offset: 0x001A0B34
		private bool OnClickChexckBox(IXUICheckBox box)
		{
			bool isInit = this.IsInit;
			bool result;
			if (isInit)
			{
				this.IsInit = false;
				result = false;
			}
			else
			{
				bool flag = this.m_optionsDoc.GetValue(this.m_define) == 1;
				if (flag)
				{
					this.m_optionsDoc.SetValue(this.m_define, 0, true);
				}
				else
				{
					this.m_optionsDoc.SetValue(this.m_define, 1, true);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x04003873 RID: 14451
		public int m_oldPPT = 0;

		// Token: 0x04003874 RID: 14452
		private bool m_init = false;

		// Token: 0x04003875 RID: 14453
		private XOptionsDocument m_optionsDoc;

		// Token: 0x04003876 RID: 14454
		public bool IsInit = false;

		// Token: 0x04003877 RID: 14455
		private XOptionsDefine m_define;

		// Token: 0x04003878 RID: 14456
		private string m_strKey;
	}
}
