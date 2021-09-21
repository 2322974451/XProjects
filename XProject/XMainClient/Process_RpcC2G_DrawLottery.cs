using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200102A RID: 4138
	internal class Process_RpcC2G_DrawLottery
	{
		// Token: 0x0600D553 RID: 54611 RVA: 0x00323C44 File Offset: 0x00321E44
		public static void OnReply(DrawLotteryArg oArg, DrawLotteryRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SPRITE_INFIGHT_SAMETYPE;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
				}
				else
				{
					bool flag3 = oRes.Items.Count == 0;
					if (flag3)
					{
						LotteryType type = (LotteryType)oArg.type;
						if (type - LotteryType.Sprite_Draw_One > 1)
						{
							if (type - LotteryType.Sprite_GoldDraw_One <= 1)
							{
								string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteGoldDrawCost").Split(XGlobalConfig.SequenceSeparator);
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLotteryEggNotEnough"), "fece00");
								bool flag4 = array.Length != 0;
								if (flag4)
								{
									XSingleton<UiUtility>.singleton.ShowItemAccess(int.Parse(array[0]), null);
								}
							}
						}
						else
						{
							string[] array2 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteDrawCost").Split(XGlobalConfig.SequenceSeparator);
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLotteryEggNotEnough"), "fece00");
							bool flag5 = array2.Length != 0;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowItemAccess(int.Parse(array2[0]), null);
							}
						}
					}
					else
					{
						XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
						specificDocument.SetLotteryData(oRes.nextgoodcount);
						specificDocument.SetLotteryResultData(oRes.Items, oRes.spriteppt, (LotteryType)oArg.type);
					}
				}
				XSingleton<XDebug>.singleton.AddLog("recv draw lottery result!", null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600D554 RID: 54612 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DrawLotteryArg oArg)
		{
		}
	}
}
