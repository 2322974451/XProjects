using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_PushPraiseNtf
	{

		public static void Process(PtcG2C_PushPraiseNtf roPtc)
		{
			XSingleton<XDebug>.singleton.AddLog("Process_PtcG2C_PushPraiseNtf: ", roPtc.Data.type.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = XScreenShotShareDocument.ShareIndex == CommentType.COMMENT_NEST || XScreenShotShareDocument.ShareIndex == CommentType.COMMENT_DRAGON;
			if (!flag)
			{
				XScreenShotShareDocument.ShareIndex = roPtc.Data.type;
				bool flag2 = XScreenShotShareDocument.ShareIndex == CommentType.COMMENT_PANDORA || XScreenShotShareDocument.ShareIndex == CommentType.COMMENT_SPRITE;
				if (flag2)
				{
					bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
					if (flag3)
					{
						XScreenShotShareDocument specificDocument = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
						specificDocument.CurShareBgType = ((XScreenShotShareDocument.ShareIndex == CommentType.COMMENT_PANDORA) ? ShareBgType.LuckyPandora : ShareBgType.LuckySpriteType);
						specificDocument.SpriteID = roPtc.Data.spriteid;
						XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
						{
							" ",
							specificDocument.CurShareBgType,
							"  ",
							specificDocument.SpriteID
						}), null, null, null, null, null, XDebugColor.XDebug_None);
					}
				}
				else
				{
					bool flag4 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Link_Share);
					if (!flag4)
					{
						bool flag5 = XSingleton<XSceneMgr>.singleton.IsPVPScene() || XSingleton<XSceneMgr>.singleton.IsPVEScene();
						if (flag5)
						{
							XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_Link_Share, EXStage.Hall);
						}
						else
						{
							XScreenShotShareDocument.DoShowShare();
						}
					}
				}
			}
		}
	}
}
