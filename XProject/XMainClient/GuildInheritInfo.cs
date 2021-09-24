using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildInheritInfo
	{

		public void Set(InheritData info)
		{
			this.uid = info.roleId;
			this.name = info.name;
			this.time = info.time;
			this.level = info.lvl;
			this.sceneId = 4U;
		}

		public string GetLevelString()
		{
			return string.Format("Lv.{0}", this.level);
		}

		public string GetTimeString()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)this.time);
		}

		public string GetSceneName()
		{
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.sceneId);
			return (sceneData == null) ? string.Empty : sceneData.Comment;
		}

		public ulong uid;

		public string name;

		public uint level;

		public uint time;

		public uint sceneId;
	}
}
