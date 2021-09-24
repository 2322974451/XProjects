using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CapacityDownDlg : DlgBase<CapacityDownDlg, CapacityBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/CapacityDownDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 99;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closeSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickCloseSpr));
			base.uiBehaviour.m_checkBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickChexckBox));
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.IsInit = true;
			this.m_optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		private void FillContent()
		{
			base.uiBehaviour.m_checkBox.bChecked = false;
			base.uiBehaviour.m_checkBox.ForceSetFlag(false);
			base.uiBehaviour.m_lable.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString(this.m_strKey)));
		}

		private void OnClickCloseSpr(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

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

		public int m_oldPPT = 0;

		private bool m_init = false;

		private XOptionsDocument m_optionsDoc;

		public bool IsInit = false;

		private XOptionsDefine m_define;

		private string m_strKey;
	}
}
