using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016E5 RID: 5861
	internal class CrossGVGBattleMember : GVGBattleMemberBase
	{
		// Token: 0x0600F1DD RID: 61917 RVA: 0x003587CC File Offset: 0x003569CC
		protected override void SetupOtherMemberInfo(Transform t, GmfRole role)
		{
			IXUILabel ixuilabel = t.FindChild("Fight").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(role.ppt.ToString());
		}
	}
}
