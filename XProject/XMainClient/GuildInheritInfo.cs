using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000926 RID: 2342
	internal class GuildInheritInfo
	{
		// Token: 0x06008D81 RID: 36225 RVA: 0x001364F2 File Offset: 0x001346F2
		public void Set(InheritData info)
		{
			this.uid = info.roleId;
			this.name = info.name;
			this.time = info.time;
			this.level = info.lvl;
			this.sceneId = 4U;
		}

		// Token: 0x06008D82 RID: 36226 RVA: 0x0013652C File Offset: 0x0013472C
		public string GetLevelString()
		{
			return string.Format("Lv.{0}", this.level);
		}

		// Token: 0x06008D83 RID: 36227 RVA: 0x00136554 File Offset: 0x00134754
		public string GetTimeString()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)this.time);
		}

		// Token: 0x06008D84 RID: 36228 RVA: 0x00136578 File Offset: 0x00134778
		public string GetSceneName()
		{
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.sceneId);
			return (sceneData == null) ? string.Empty : sceneData.Comment;
		}

		// Token: 0x04002DE6 RID: 11750
		public ulong uid;

		// Token: 0x04002DE7 RID: 11751
		public string name;

		// Token: 0x04002DE8 RID: 11752
		public uint level;

		// Token: 0x04002DE9 RID: 11753
		public uint time;

		// Token: 0x04002DEA RID: 11754
		public uint sceneId;
	}
}
