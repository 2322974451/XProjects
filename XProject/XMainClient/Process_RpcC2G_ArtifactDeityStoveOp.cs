using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015CB RID: 5579
	internal class Process_RpcC2G_ArtifactDeityStoveOp
	{
		// Token: 0x0600EC56 RID: 60502 RVA: 0x00346E98 File Offset: 0x00345098
		public static void OnReply(ArtifactDeityStoveOpArg oArg, ArtifactDeityStoveOpRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				switch (oArg.type)
				{
				case ArtifactDeityStoveOpType.ArtifactDeityStove_Recast:
					ArtifactRecastDocument.Doc.OnReqRecastBack(oRes);
					break;
				case ArtifactDeityStoveOpType.ArtifactDeityStove_Fuse:
					ArtifactFuseDocument.Doc.OnReqFuseBack(oRes);
					break;
				case ArtifactDeityStoveOpType.ArtifactDeityStove_Inscription:
					ArtifactInscriptionDocument.Doc.OnReqInscriptionBack(oRes);
					break;
				case ArtifactDeityStoveOpType.ArtifactDeityStove_Refine:
				case ArtifactDeityStoveOpType.ArtifactDeityStove_RefineRetain:
				case ArtifactDeityStoveOpType.ArtifactDeityStove_RefineReplace:
					ArtifactRefinedDocument.Doc.OnReqRefinedBack(oArg.type, oRes);
					break;
				}
			}
		}

		// Token: 0x0600EC57 RID: 60503 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ArtifactDeityStoveOpArg oArg)
		{
		}
	}
}
