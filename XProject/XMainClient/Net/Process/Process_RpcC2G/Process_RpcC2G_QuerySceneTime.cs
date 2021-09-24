using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QuerySceneTime
	{

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

		public static void OnTimeout(QuerySceneTimeArg oArg)
		{
		}
	}
}
