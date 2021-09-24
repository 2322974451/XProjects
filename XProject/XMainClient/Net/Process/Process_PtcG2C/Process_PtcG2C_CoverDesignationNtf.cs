using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_CoverDesignationNtf
	{

		public static void Process(PtcG2C_CoverDesignationNtf roPtc)
		{
			XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
			xdesignationDocument.SetCoverDesignationID(roPtc.Data.designationID, roPtc.Data.desname);
		}
	}
}
