using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SpriteChangedNtf
	{

		public static void Process(PtcG2C_SpriteChangedNtf roPtc)
		{
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			specificDocument.OnSpriteChange(roPtc);
		}
	}
}
