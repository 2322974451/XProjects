using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA6 RID: 2982
	internal class LevelRewardReportHandler : DlgHandlerBase
	{
		// Token: 0x1700304A RID: 12362
		// (get) Token: 0x0600AB01 RID: 43777 RVA: 0x001EF7E4 File Offset: 0x001ED9E4
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardReportHandler";
			}
		}

		// Token: 0x0600AB02 RID: 43778 RVA: 0x001EF7FC File Offset: 0x001ED9FC
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

		// Token: 0x0600AB03 RID: 43779 RVA: 0x001EF8D4 File Offset: 0x001EDAD4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_OKBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKBtnClick));
			this.m_CancelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelBtnClick));
		}

		// Token: 0x0600AB04 RID: 43780 RVA: 0x001EF910 File Offset: 0x001EDB10
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

		// Token: 0x0600AB05 RID: 43781 RVA: 0x001EFAE4 File Offset: 0x001EDCE4
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

		// Token: 0x0600AB06 RID: 43782 RVA: 0x001EFB7C File Offset: 0x001EDD7C
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

		// Token: 0x0600AB07 RID: 43783 RVA: 0x001EFBCC File Offset: 0x001EDDCC
		public bool OnCancelBtnClick(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04003FCE RID: 16334
		private XLevelRewardDocument _doc = null;

		// Token: 0x04003FCF RID: 16335
		private IXUILabel m_Title;

		// Token: 0x04003FD0 RID: 16336
		private XUIPool m_CheckBoxPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003FD1 RID: 16337
		private IXUIButton m_OKBtn;

		// Token: 0x04003FD2 RID: 16338
		private IXUIButton m_CancelBtn;

		// Token: 0x04003FD3 RID: 16339
		private int _selectCount;

		// Token: 0x04003FD4 RID: 16340
		private static readonly int COLNUM = 3;

		// Token: 0x04003FD5 RID: 16341
		private IXUISprite m_ReportBtn;

		// Token: 0x04003FD6 RID: 16342
		private ulong CurrReportUid;

		// Token: 0x04003FD7 RID: 16343
		private List<reportType> reportList = new List<reportType>();
	}
}
