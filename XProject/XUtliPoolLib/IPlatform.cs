using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200006B RID: 107
	public interface IPlatform : IXInterface
	{
		// Token: 0x0600035B RID: 859
		XPlatformType Platfrom();

		// Token: 0x0600035C RID: 860
		bool IsEdior();

		// Token: 0x0600035D RID: 861
		void SetNoBackupFlag(string fullpath);

		// Token: 0x0600035E RID: 862
		void OnPlatformLogin();

		// Token: 0x0600035F RID: 863
		void OnQQLogin();

		// Token: 0x06000360 RID: 864
		void OnWeChatLogin();

		// Token: 0x06000361 RID: 865
		void OnGuestLogin();

		// Token: 0x06000362 RID: 866
		void LogOut();

		// Token: 0x06000363 RID: 867
		void ResgiterSDONotification(uint serverid, string rolename);

		// Token: 0x06000364 RID: 868
		string GetPFToken();

		// Token: 0x06000365 RID: 869
		string GetVersionServer();

		// Token: 0x06000366 RID: 870
		string GetHostUrl();

		// Token: 0x06000367 RID: 871
		string GetLoginServer(string loginType);

		// Token: 0x06000368 RID: 872
		bool IsPublish();

		// Token: 0x06000369 RID: 873
		bool IsTestMode();

		// Token: 0x0600036A RID: 874
		void SendGameExData(string type, string json);

		// Token: 0x0600036B RID: 875
		void SetPushStatus(bool status);

		// Token: 0x0600036C RID: 876
		string GetHostWithHttpDns(string url);

		// Token: 0x0600036D RID: 877
		bool CheckStatus(string type, string json);

		// Token: 0x0600036E RID: 878
		string GetSDKConfig(string type, string json);

		// Token: 0x0600036F RID: 879
		bool CheckWeChatInstalled();

		// Token: 0x06000370 RID: 880
		string GetChannelID();

		// Token: 0x06000371 RID: 881
		string GetBatteryLevel();

		// Token: 0x06000372 RID: 882
		void SendUserInfo(uint serverID, ulong roleID);

		// Token: 0x06000373 RID: 883
		int GetQualityLevel();

		// Token: 0x06000374 RID: 884
		void MarkLoadlevel(string scene_name);

		// Token: 0x06000375 RID: 885
		void InitApm();

		// Token: 0x06000376 RID: 886
		void MarkLoadlevelCompleted();

		// Token: 0x06000377 RID: 887
		void MarkLevelEnd();

		// Token: 0x06000378 RID: 888
		void SetApmUserID(string userID);

		// Token: 0x06000379 RID: 889
		void SetScreenLightness(int percentage);

		// Token: 0x0600037A RID: 890
		void ResetScreenLightness();

		// Token: 0x0600037B RID: 891
		object CreateClass(EClassType type);

		// Token: 0x0600037C RID: 892
		void ReturnClass(EClassType type, object obj);

		// Token: 0x0600037D RID: 893
		void ClearClass();

		// Token: 0x0600037E RID: 894
		string GetPayBill();

		// Token: 0x0600037F RID: 895
		void Pay(int price, string orderID, string paramID, ulong role, uint serverID);

		// Token: 0x06000380 RID: 896
		void SendExtDara(string key, string param);

		// Token: 0x06000381 RID: 897
		void CreateWXGroup(string param);

		// Token: 0x06000382 RID: 898
		void JoinWXGroup(string param);

		// Token: 0x06000383 RID: 899
		void ShareWithWXGroup(string param);

		// Token: 0x06000384 RID: 900
		void QueryWXGroup(string param);

		// Token: 0x06000385 RID: 901
		string GetMD5(string plainText);

		// Token: 0x06000386 RID: 902
		string UserMd5(string str);

		// Token: 0x06000387 RID: 903
		int GetDensity();

		// Token: 0x06000388 RID: 904
		string GetSim();

		// Token: 0x06000389 RID: 905
		Component AddComponent(GameObject go, EComponentType type);

		// Token: 0x0600038A RID: 906
		void ReloadFMOD();

		// Token: 0x0600038B RID: 907
		INativePlugin GetNativePlugin();
	}
}
