using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	public class XDragonGuildRankInfo : XBaseRankInfo
	{

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

		public string formatname2;

		public string name2;

		public uint passCount;

		public string passSceneName;
	}
}
