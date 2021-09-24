using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ReachDesignationNtf
	{

		public static void Process(PtcG2C_ReachDesignationNtf roPtc)
		{
			XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
			xdesignationDocument.OnReachDesignationNtf(roPtc);
		}
	}
}
