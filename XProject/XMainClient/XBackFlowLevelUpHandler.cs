using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBackFlowLevelUpHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Hall/BfLevelUpHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._gotoBtn = (base.transform.Find("BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._gotoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoLevelUp));
			this._levelUpLabel = (base.transform.Find("Label").GetComponent("XUILabel") as IXUILabel);
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			string @string = XStringDefineProxy.GetString("LevelUpDegreeGift");
			this._levelUpLabel.SetText(string.Format(@string, XBackFlowDocument.Doc.GetLevelUpDegree()));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private IXUIButton _gotoBtn = null;

		private IXUILabel _levelUpLabel = null;
	}
}
