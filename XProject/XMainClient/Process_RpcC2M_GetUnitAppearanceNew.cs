using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001447 RID: 5191
	internal class Process_RpcC2M_GetUnitAppearanceNew
	{
		// Token: 0x0600E627 RID: 58919 RVA: 0x0033DF14 File Offset: 0x0033C114
		public static void OnReply(GetUnitAppearanceArg oArg, GetUnitAppearanceRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
					else
					{
						bool flag4 = oArg.type == 1U;
						if (flag4)
						{
							XRankDocument specificDocument = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
							specificDocument.OnGetUnitAppearance(oRes);
						}
						else
						{
							bool flag5 = oArg.type == 2U;
							if (flag5)
							{
								XOtherPlayerInfoDocument specificDocument2 = XDocuments.GetSpecificDocument<XOtherPlayerInfoDocument>(XOtherPlayerInfoDocument.uuID);
								specificDocument2.OnGetUnitAppearance(oRes);
							}
							else
							{
								bool flag6 = oArg.type == 3U;
								if (flag6)
								{
									XFlowerRankDocument specificDocument3 = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
									specificDocument3.OnGetUnitAppearance(oRes);
								}
								else
								{
									bool flag7 = oArg.type == 4U;
									if (flag7)
									{
										XCharacterCommonMenuDocument specificDocument4 = XDocuments.GetSpecificDocument<XCharacterCommonMenuDocument>(XCharacterCommonMenuDocument.uuID);
										specificDocument4.OnGetUnitAppearance(oRes);
									}
									else
									{
										bool flag8 = oArg.type == 5U;
										if (flag8)
										{
											XOtherPlayerInfoDocument specificDocument5 = XDocuments.GetSpecificDocument<XOtherPlayerInfoDocument>(XOtherPlayerInfoDocument.uuID);
											specificDocument5.OnGetSpriteInfoReturn(oRes);
										}
										else
										{
											bool flag9 = oArg.type == 6U;
											if (flag9)
											{
												XOtherPlayerInfoDocument specificDocument6 = XDocuments.GetSpecificDocument<XOtherPlayerInfoDocument>(XOtherPlayerInfoDocument.uuID);
												specificDocument6.OnGetPetInfoReturn(oRes);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600E628 RID: 58920 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetUnitAppearanceArg oArg)
		{
		}
	}
}
