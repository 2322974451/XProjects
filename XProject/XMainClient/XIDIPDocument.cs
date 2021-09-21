using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000942 RID: 2370
	internal class XIDIPDocument : XDocComponent
	{
		// Token: 0x17002C1D RID: 11293
		// (get) Token: 0x06008F46 RID: 36678 RVA: 0x0014106C File Offset: 0x0013F26C
		public override uint ID
		{
			get
			{
				return XIDIPDocument.uuID;
			}
		}

		// Token: 0x06008F47 RID: 36679 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008F48 RID: 36680 RVA: 0x00141083 File Offset: 0x0013F283
		public void DealWithIDIPMessage(IdipMessage info)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XStringDefineProxy.GetString("IDIPTitle"), info.message);
		}

		// Token: 0x06008F49 RID: 36681 RVA: 0x001410A4 File Offset: 0x0013F2A4
		public void DealWithIDIPTips(IdipPunishInfo info)
		{
			string text = XSingleton<UiUtility>.singleton.TimeFormatSince1970(info.endTime, XStringDefineProxy.GetString("IDIP_TIPS_TIME"), true);
			string label;
			switch (info.type)
			{
			case 1:
			{
				string arg = XSingleton<UiUtility>.singleton.TimeDuarationFormatString(info.banTime, 5);
				label = string.Format(XStringDefineProxy.GetString("IDIP_TIPS_IDSEALED"), arg, text);
				goto IL_198;
			}
			case 2:
			{
				string arg = XSingleton<UiUtility>.singleton.TimeDuarationFormatString(info.banTime, 5);
				label = string.Format(XStringDefineProxy.GetString("IDIP_TIPS_SILENCE"), arg, text);
				goto IL_198;
			}
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 11:
				label = string.Format(XStringDefineProxy.GetString("IDIP_TIPS_RANK"), text);
				goto IL_198;
			case 10:
				label = string.Format(XStringDefineProxy.GetString("IDIP_TIPS_GUILDRANK"), text);
				goto IL_198;
			case 12:
			{
				bool flag = info.leftTime == 0;
				if (flag)
				{
					this.ZeroRewardBtnState = false;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_IDIP_ZeroReward, true);
					return;
				}
				label = string.Format(XStringDefineProxy.GetString("IDIP_TIPS_ZEROREWARD"), text);
				this.ZeroRewardEndTime = (double)info.leftTime + this.GetNowTime();
				this.ZeroRewardBtnState = true;
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_IDIP_ZeroReward, true);
				goto IL_198;
			}
			case 13:
			case 14:
				label = string.Format(XStringDefineProxy.GetString("IDIP_TIPS_PLAY"), text);
				goto IL_198;
			}
			XSingleton<XDebug>.singleton.AddLog("Undefine IDIP Tips type.", info.type.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			return;
			IL_198:
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"));
		}

		// Token: 0x06008F4A RID: 36682 RVA: 0x00141260 File Offset: 0x0013F460
		private double GetNowTime()
		{
			return (double)(DateTime.Now.Ticks / 10000000L);
		}

		// Token: 0x06008F4B RID: 36683 RVA: 0x00141288 File Offset: 0x0013F488
		public string GetLeftTimeString()
		{
			int num = (int)(this.ZeroRewardEndTime - this.GetNowTime());
			bool flag = num < 0;
			string result;
			if (flag)
			{
				result = "0";
			}
			else
			{
				result = XSingleton<UiUtility>.singleton.TimeDuarationFormatString(num, 5);
			}
			return result;
		}

		// Token: 0x04002F0D RID: 12045
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("IDIPDocument");

		// Token: 0x04002F0E RID: 12046
		public bool ZeroRewardBtnState = false;

		// Token: 0x04002F0F RID: 12047
		public double ZeroRewardEndTime = 0.0;
	}
}
