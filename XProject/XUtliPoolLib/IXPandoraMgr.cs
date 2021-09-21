using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000089 RID: 137
	public interface IXPandoraMgr : IXInterface
	{
		// Token: 0x06000480 RID: 1152
		void SetUseHttps(int use);

		// Token: 0x06000481 RID: 1153
		void PandoraLogin(string openid, string acctype, string area, string areaID, string appId, string roleID, string accessToken, string payToken, string gameVersion, string platID);

		// Token: 0x06000482 RID: 1154
		void PopPLPanel();

		// Token: 0x06000483 RID: 1155
		void CloseAllPandoraPanel();

		// Token: 0x06000484 RID: 1156
		void ClosePandoraTabPanel(string module);

		// Token: 0x06000485 RID: 1157
		void SetPandoraPanelParent(string panelName, GameObject panelParent);

		// Token: 0x06000486 RID: 1158
		void PandoraDo(Dictionary<string, string> commandDict);

		// Token: 0x06000487 RID: 1159
		void PandoraDoJson(string json);

		// Token: 0x06000488 RID: 1160
		void PandoraInit(bool isProductEnvironment, string rootName = "");

		// Token: 0x06000489 RID: 1161
		void PandoraLogout();

		// Token: 0x0600048A RID: 1162
		void SetFont(Font font);

		// Token: 0x0600048B RID: 1163
		void NoticePandoraShareResult(string result);

		// Token: 0x0600048C RID: 1164
		void LoadProgramAsset();

		// Token: 0x0600048D RID: 1165
		void SetUserData(Dictionary<string, string> data);

		// Token: 0x0600048E RID: 1166
		void SetGameCallback(Action<Dictionary<string, string>> callback);

		// Token: 0x0600048F RID: 1167
		void SetJsonGameCallback(Action<string> callback);

		// Token: 0x06000490 RID: 1168
		bool IsActivityTabShow(string tabName);

		// Token: 0x06000491 RID: 1169
		bool IsActivityTabShow(int sysID);

		// Token: 0x06000492 RID: 1170
		bool IsActivityTabShowByContent(string tabContent);

		// Token: 0x06000493 RID: 1171
		void PopPreLossActivity(bool pop);

		// Token: 0x06000494 RID: 1172
		void NoticePandoraBuyGoodsResult(string result);

		// Token: 0x06000495 RID: 1173
		List<ActivityTabInfo> GetAllTabInfo();

		// Token: 0x06000496 RID: 1174
		List<ActivityPopInfo> GetAllPopInfo();

		// Token: 0x06000497 RID: 1175
		void OnJsonPandoraEvent(string json);

		// Token: 0x06000498 RID: 1176
		Bounds GetBoundsIncludesChildren(Transform trans);
	}
}
