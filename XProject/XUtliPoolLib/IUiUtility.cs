using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000071 RID: 113
	public interface IUiUtility : IXInterface
	{
		// Token: 0x06000399 RID: 921
		void ShowSystemTip(string text, string rgb = "fece00");

		// Token: 0x0600039A RID: 922
		void ShowSystemTip(int errcode, string rgb = "fece00");

		// Token: 0x0600039B RID: 923
		void ShowItemAccess(int itemid, AccessCallback callback = null);

		// Token: 0x0600039C RID: 924
		void ShowTooltipDialog(int itemID, GameObject icon = null);

		// Token: 0x0600039D RID: 925
		void ShowDetailTooltip(int itemID, GameObject icon = null);

		// Token: 0x0600039E RID: 926
		void ShowTooltipDialogByUID(string strUID, GameObject icon = null);

		// Token: 0x0600039F RID: 927
		void ShowPressToolTips(bool pressed, string content, Vector3 pos, Vector3 offset);

		// Token: 0x060003A0 RID: 928
		string GlobalConfigGetValue(string cfgName);

		// Token: 0x060003A1 RID: 929
		void OnPayCallback(string msg);

		// Token: 0x060003A2 RID: 930
		void OnQQVipPayCallback(string msg);

		// Token: 0x060003A3 RID: 931
		void OnReplayStart();

		// Token: 0x060003A4 RID: 932
		void PushBarrage(string nick, string content);

		// Token: 0x060003A5 RID: 933
		void StartBroadcast(bool start);

		// Token: 0x060003A6 RID: 934
		void OnGameCenterWakeUp(int type);

		// Token: 0x060003A7 RID: 935
		void OnPayMarketingInfo(List<PayMarketingInfo> listInfo);

		// Token: 0x060003A8 RID: 936
		void OnGetPlatFriendsInfo();

		// Token: 0x060003A9 RID: 937
		void SerialHandle3DTouch(string msg);

		// Token: 0x060003AA RID: 938
		void SerialHandleScreenLock(string msg);

		// Token: 0x060003AB RID: 939
		string GetPartitionId();

		// Token: 0x060003AC RID: 940
		string GetRoleId();

		// Token: 0x060003AD RID: 941
		void OnSetBg(bool on);

		// Token: 0x060003AE RID: 942
		void OnSetWebViewMenu(int menutype);

		// Token: 0x060003AF RID: 943
		void OnWebViewBackGame(int backtype);

		// Token: 0x060003B0 RID: 944
		void OnWebViewRefershRefPoint(string jsonstr);

		// Token: 0x060003B1 RID: 945
		void OnWebViewSetheaderInfo(string jsonstr);

		// Token: 0x060003B2 RID: 946
		void OnWebViewCloseLoading(int show);

		// Token: 0x060003B3 RID: 947
		void OnWebViewShowReconnect(int show);

		// Token: 0x060003B4 RID: 948
		void OnWebViewClose();

		// Token: 0x060003B5 RID: 949
		void OnWebViewLiveTab();

		// Token: 0x060003B6 RID: 950
		void ShowPandoraPopView(bool bShow);

		// Token: 0x060003B7 RID: 951
		void NoticeShareResult(string result, ShareCallBackType type);

		// Token: 0x060003B8 RID: 952
		bool CheckQQInstalled();

		// Token: 0x060003B9 RID: 953
		bool CheckWXInstalled();

		// Token: 0x060003BA RID: 954
		void OpenUrl(string url, bool landscape);

		// Token: 0x060003BB RID: 955
		void UpdatePandoraSDKRedPoint(int pandoraSysID, bool showRedPoint, string module);

		// Token: 0x060003BC RID: 956
		void AttachPandoraSDKRedPoint(int sysID, string module);

		// Token: 0x060003BD RID: 957
		void ResetAllPopPLParent();

		// Token: 0x060003BE RID: 958
		void SDKPandoraBuyGoods(string json);

		// Token: 0x060003BF RID: 959
		void ShareToWXFriendBackEnd(string openID, string title, string desc, string tag);

		// Token: 0x060003C0 RID: 960
		void ShareToQQFreindBackEnd(string openID, string title, string desc, string tag, string targetUrl, string imageUrl, string previewText);

		// Token: 0x060003C1 RID: 961
		void PandoraPicShare(string accountType, string scene, string objPath);

		// Token: 0x060003C2 RID: 962
		void OnWXGroupResult(string apiId, string result, int error, WXGroupCallBackType type);

		// Token: 0x060003C3 RID: 963
		void RefreshWXGroupBtn(WXGroupCallBackType type);
	}
}
