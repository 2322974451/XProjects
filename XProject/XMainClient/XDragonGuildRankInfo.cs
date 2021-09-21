using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D73 RID: 3443
	public class XDragonGuildRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC9A RID: 48282 RVA: 0x0026E0C4 File Offset: 0x0026C2C4
		public void ProcessData(DragonGuildInfo info)
		{
			this.id = info.id;
			this.name = info.name;
			bool flag = info.sceneId == 0U;
			if (flag)
			{
				this.passSceneName = XStringDefineProxy.GetString("DRAGON_GUILD_NO_PASS_SCENE");
			}
			else
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(info.sceneId);
				bool flag2 = sceneData != null;
				if (flag2)
				{
					this.passSceneName = sceneData.Comment;
				}
				else
				{
					this.passSceneName = XStringDefineProxy.GetString("DRAGON_GUILD_NO_PASS_SCENE");
					XSingleton<XDebug>.singleton.AddErrorLog2("XDragonGuildRankInfo|can't finde scene id=", new object[]
					{
						info.sceneId
					});
				}
			}
			this.value = (ulong)info.sceneCnt;
		}

		// Token: 0x04004C82 RID: 19586
		public string formatname2;

		// Token: 0x04004C83 RID: 19587
		public string name2;

		// Token: 0x04004C84 RID: 19588
		public uint passCount;

		// Token: 0x04004C85 RID: 19589
		public string passSceneName;
	}
}
