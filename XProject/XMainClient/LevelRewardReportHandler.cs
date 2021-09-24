using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardReportHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardReportHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.m_Title = (base.PanelObject.transform.Find("Menu/Title").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.Find("Menu/List/Tpl");
			this.m_CheckBoxPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_OKBtn = (base.PanelObject.transform.Find("Menu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_CancelBtn = (base.PanelObject.transform.Find("Menu/Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_OKBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKBtnClick));
			this.m_CancelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelBtnClick));
		}

		public void InitShow(ulong uid, string name, IXUISprite reportBtn)
		{
			this.CurrReportUid = uid;
			this.m_ReportBtn = reportBtn;
			this.m_Title.SetText(string.Format(XStringDefineProxy.GetString("PVPReportTitle"), name));
			this.reportList.Clear();
			this._selectCount = 0;
			this.m_OKBtn.SetEnable(false, false);
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleReportType");
			string[] array = value.Split(new char[]
			{
				'|',
				'='
			});
			this.m_CheckBoxPool.ReturnAll(false);
			Vector3 tplPos = this.m_CheckBoxPool.TplPos;
			int num = 0;
			while (num + 1 < array.Length)
			{
				uint type = uint.Parse(array[num]);
				reportType reportType = new reportType();
				reportType.type = type;
				reportType.state = false;
				this.reportList.Add(reportType);
				GameObject gameObject = this.m_CheckBoxPool.FetchGameObject(false);
				int num2 = this.reportList.Count - 1;
				gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(num2 % LevelRewardReportHandler.COLNUM * this.m_CheckBoxPool.TplWidth), tplPos.y - (float)(num2 / LevelRewardReportHandler.COLNUM * this.m_CheckBoxPool.TplHeight));
				IXUILabel ixuilabel = gameObject.transform.Find("Bg/Text").GetComponent("XUILabel") as IXUILabel;
				IXUICheckBox ixuicheckBox = gameObject.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuilabel.SetText(array[num + 1]);
				ixuicheckBox.ID = (ulong)((long)this.reportList.Count - 1L);
				ixuicheckBox.bChecked = false;
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckBoxClick));
				num += 2;
			}
		}

		public bool OnCheckBoxClick(IXUICheckBox icb)
		{
			int num = (int)icb.ID;
			bool flag = num < this.reportList.Count;
			if (flag)
			{
				bool flag2 = this.reportList[num].state != icb.bChecked;
				if (flag2)
				{
					this._selectCount += (icb.bChecked ? 1 : -1);
					this.m_OKBtn.SetEnable(this._selectCount != 0, false);
					this.reportList[num].state = icb.bChecked;
				}
			}
			return true;
		}

		public bool OnOKBtnClick(IXUIButton btn)
		{
			this._doc.ReportPlayer(this.CurrReportUid, this.reportList);
			bool flag = this.m_ReportBtn != null;
			if (flag)
			{
				this.m_ReportBtn.SetEnabled(false);
			}
			base.SetVisible(false);
			return false;
		}

		public bool OnCancelBtnClick(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private XLevelRewardDocument _doc = null;

		private IXUILabel m_Title;

		private XUIPool m_CheckBoxPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_OKBtn;

		private IXUIButton m_CancelBtn;

		private int _selectCount;

		private static readonly int COLNUM = 3;

		private IXUISprite m_ReportBtn;

		private ulong CurrReportUid;

		private List<reportType> reportList = new List<reportType>();
	}
}
