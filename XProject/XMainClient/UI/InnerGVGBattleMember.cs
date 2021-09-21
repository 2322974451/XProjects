using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016E6 RID: 5862
	internal class InnerGVGBattleMember : GVGBattleMemberBase
	{
		// Token: 0x0600F1DF RID: 61919 RVA: 0x00358814 File Offset: 0x00356A14
		protected override void SetupOtherMemberInfo(Transform t, GmfRole role)
		{
			IXUILabel ixuilabel = t.FindChild("Fight").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(role.pkpoint.ToString());
		}
	}
}
