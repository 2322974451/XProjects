using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XIDIPDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XIDIPDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void DealWithIDIPMessage(IdipMessage info)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XStringDefineProxy.GetString("IDIPTitle"), info.message);
		}

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

		private double GetNowTime()
		{
			return (double)(DateTime.Now.Ticks / 10000000L);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("IDIPDocument");

		public bool ZeroRewardBtnState = false;

		public double ZeroRewardEndTime = 0.0;
	}
}
