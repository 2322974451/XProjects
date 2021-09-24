using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ArtifactDeityStoveOp
	{

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

		public static void OnTimeout(ArtifactDeityStoveOpArg oArg)
		{
		}
	}
}
