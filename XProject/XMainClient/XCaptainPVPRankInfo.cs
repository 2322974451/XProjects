using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D51 RID: 3409
	public class XCaptainPVPRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC4F RID: 48207 RVA: 0x0026D474 File Offset: 0x0026B674
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

		// Token: 0x04004C6A RID: 19562
		public int kill;

		// Token: 0x04004C6B RID: 19563
		public int dead;

		// Token: 0x04004C6C RID: 19564
		public int assit;
	}
}
