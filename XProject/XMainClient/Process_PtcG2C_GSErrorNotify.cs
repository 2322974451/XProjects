using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001032 RID: 4146
	internal class Process_PtcG2C_GSErrorNotify
	{
		// Token: 0x0600D576 RID: 54646 RVA: 0x003240D0 File Offset: 0x003222D0
		public static void Process(PtcG2C_GSErrorNotify roPtc)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WorldBossSceneID");
			int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("GuildBossSceneID");
			ErrorCode errorno = (ErrorCode)roPtc.Data.errorno;
			if (errorno != ErrorCode.ERR_SCENE_COOLDOWN)
			{
				bool istip = roPtc.Data.istip;
				if (istip)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip((ErrorCode)roPtc.Data.errorno, "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowErrorCode((ErrorCode)roPtc.Data.errorno);
				}
			}
			else
			{
				bool flag = roPtc.Data.param.Count >= 2 && roPtc.Data.param[1] == (uint)@int;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("WorldBoss_CoolDown_Tips"), (int)roPtc.Data.param[0]), "fece00");
				}
				else
				{
					bool flag2 = roPtc.Data.param.Count >= 2 && roPtc.Data.param[1] == (uint)int2;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("GuildBoss_CoolDown_Tips"), (int)roPtc.Data.param[0]), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("SCENE_COOLDOWM_TIME", new object[]
						{
							(roPtc.Data.param.Count == 0) ? "" : XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)roPtc.Data.param[0], 5)
						}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
					}
				}
			}
		}
	}
}
