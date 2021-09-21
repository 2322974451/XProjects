using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000080 RID: 128
	public interface IXIFlyMgr : IXInterface
	{
		// Token: 0x06000452 RID: 1106
		int StartRecord();

		// Token: 0x06000453 RID: 1107
		void StopRecord();

		// Token: 0x06000454 RID: 1108
		void Cancel();

		// Token: 0x06000455 RID: 1109
		string StartTransMp3(string destFileName);

		// Token: 0x06000456 RID: 1110
		AudioClip GetAudioClip(string filepath);

		// Token: 0x06000457 RID: 1111
		void SetCallback(Action<string> action);

		// Token: 0x06000458 RID: 1112
		void SetVoiceCallback(Action<string> action);

		// Token: 0x06000459 RID: 1113
		bool IsIFlyListening();

		// Token: 0x0600045A RID: 1114
		bool IsRecordFileExist();

		// Token: 0x0600045B RID: 1115
		bool IsInited();

		// Token: 0x0600045C RID: 1116
		bool ScreenShotQQShare(string filepath, string isZone);

		// Token: 0x0600045D RID: 1117
		bool ScreenShotWeChatShare(string filepath, string isZone);

		// Token: 0x0600045E RID: 1118
		bool ScreenShotSave(string filepath);

		// Token: 0x0600045F RID: 1119
		bool RefreshAndroidPhotoView(string androidpath);

		// Token: 0x06000460 RID: 1120
		bool ShareWechatLink(string desc, string logopath, string url, bool issession);

		// Token: 0x06000461 RID: 1121
		bool ShareWechatLinkWithMediaTag(string desc, string logopath, string url, bool issession, string media);

		// Token: 0x06000462 RID: 1122
		bool ShareQZoneLink(string title, string summary, string url, string logopath, bool issession);

		// Token: 0x06000463 RID: 1123
		bool OnOpenWebView();

		// Token: 0x06000464 RID: 1124
		void OnInitWebViewInfo(int platform, string openid, string serverid, string roleid, string nickname);

		// Token: 0x06000465 RID: 1125
		void OnEvalJsScript(string script);

		// Token: 0x06000466 RID: 1126
		void OnCloseWebView();

		// Token: 0x06000467 RID: 1127
		void OnScreenLock(bool islock);

		// Token: 0x06000468 RID: 1128
		void RefershWebViewShow(bool show);

		// Token: 0x06000469 RID: 1129
		MonoBehaviour GetMonoBehavior();
	}
}
