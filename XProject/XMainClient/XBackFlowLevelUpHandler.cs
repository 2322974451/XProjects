using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A1B RID: 2587
	internal class XBackFlowLevelUpHandler : DlgHandlerBase
	{
		// Token: 0x17002EBA RID: 11962
		// (get) Token: 0x06009E39 RID: 40505 RVA: 0x0019ED78 File Offset: 0x0019CF78
		protected override string FileName
		{
			get
			{
				return "Hall/BfLevelUpHandler";
			}
		}

		// Token: 0x06009E3A RID: 40506 RVA: 0x0019ED90 File Offset: 0x0019CF90
		protected override void Init()
		{
			base.Init();
			this._gotoBtn = (base.transform.Find("BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._gotoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoLevelUp));
			this._levelUpLabel = (base.transform.Find("Label").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x06009E3B RID: 40507 RVA: 0x0019EE08 File Offset: 0x0019D008
		private bool OnGotoLevelUp(IXUIButton button)
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			for (int i = 0; i < specificDocument.TaskRecord.Tasks.Count; i++)
			{
				XTaskInfo xtaskInfo = specificDocument.TaskRecord.Tasks[i];
				TaskTableNew.RowData tableData = xtaskInfo.TableData;
				bool flag = tableData.TaskType == 8U;
				if (flag)
				{
					uint id = XSingleton<UiUtility>.singleton.ChooseProfData<uint>(tableData.BeginTaskNPCID, 0U);
					XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc(id);
					DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.SetVisible(false, true);
					break;
				}
			}
			return true;
		}

		// Token: 0x06009E3C RID: 40508 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06009E3D RID: 40509 RVA: 0x0019EEBC File Offset: 0x0019D0BC
		protected override void OnShow()
		{
			base.OnShow();
			string @string = XStringDefineProxy.GetString("LevelUpDegreeGift");
			this._levelUpLabel.SetText(string.Format(@string, XBackFlowDocument.Doc.GetLevelUpDegree()));
		}

		// Token: 0x06009E3E RID: 40510 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009E3F RID: 40511 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x04003814 RID: 14356
		private IXUIButton _gotoBtn = null;

		// Token: 0x04003815 RID: 14357
		private IXUILabel _levelUpLabel = null;
	}
}
