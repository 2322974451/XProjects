using System;

namespace XMainClient
{
	// Token: 0x020013B6 RID: 5046
	internal class Process_PtcM2C_LargeRoomRoleNtf
	{
		// Token: 0x0600E3D7 RID: 58327 RVA: 0x0033AE6C File Offset: 0x0033906C
		public static void Process(PtcM2C_LargeRoomRoleNtf roPtc)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			specificDocument.UpdateHost(roPtc.Data.name, roPtc.Data.roleid);
		}
	}
}
