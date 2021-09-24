using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	public class XCaptainPVPRankInfo : XBaseRankInfo
	{

		public override string GetValue()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
			string result;
			if (flag)
			{
				result = string.Concat(new object[]
				{
					this.kill,
					XStringDefineProxy.GetString("KILL"),
					" ",
					this.dead,
					XStringDefineProxy.GetString("DEAD"),
					" ",
					this.assit,
					XStringDefineProxy.GetString("ASSIT")
				});
			}
			else
			{
				result = string.Concat(new object[]
				{
					this.kill,
					XStringDefineProxy.GetString("KILL"),
					" ",
					this.dead,
					XStringDefineProxy.GetString("DEAD")
				});
			}
			return result;
		}

		public int kill;

		public int dead;

		public int assit;
	}
}
