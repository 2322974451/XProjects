using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200129C RID: 4764
	internal class Process_RpcC2G_QuerySceneTime
	{
		// Token: 0x0600DF52 RID: 57170 RVA: 0x003346A4 File Offset: 0x003328A4
		public static void OnReply(QuerySceneTimeArg oArg, QuerySceneTimeRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool syncMode = XSingleton<XGame>.singleton.SyncMode;
				if (syncMode)
				{
					bool flag2 = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_WAIT && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_FIGHT;
					if (flag2)
					{
						XBattleDocument xbattleDoc = XSingleton<XGame>.singleton.Doc.XBattleDoc;
						XSpectateSceneDocument xspectateSceneDoc = XSingleton<XGame>.singleton.Doc.XSpectateSceneDoc;
						bool flag3 = oRes.time >= 0;
						if (flag3)
						{
							xbattleDoc.ResetSceneTime(oRes.time);
							xspectateSceneDoc.ResetSceneTime(oRes.time);
						}
						bool flag4 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RIFT;
						if (flag4)
						{
							XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
							specificDocument.ResSceneTime(oRes.time);
						}
					}
				}
			}
		}

		// Token: 0x0600DF53 RID: 57171 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QuerySceneTimeArg oArg)
		{
		}
	}
}
