using System;

namespace XMainClient
{

	internal class Process_PtcM2C_LargeRoomRoleNtf
	{

		public static void Process(PtcM2C_LargeRoomRoleNtf roPtc)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			specificDocument.UpdateHost(roPtc.Data.name, roPtc.Data.roleid);
		}
	}
}
