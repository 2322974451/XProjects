using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A30 RID: 2608
	internal class RecruitBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009F0A RID: 40714 RVA: 0x001A4CB4 File Offset: 0x001A2EB4
		private void Awake()
		{
			this._ToggleTeam = (base.transform.Find("Bg/Toggle/ToggleTeam").GetComponent("XUICheckBox") as IXUICheckBox);
			this._ToggleTeam.ID = (ulong)((long)XFastEnumIntEqualityComparer<RecruitToggle>.ToInt(RecruitToggle.ToggleTeam));
			this._ToggleMember = (base.transform.Find("Bg/Toggle/ToggleMember").GetComponent("XUICheckBox") as IXUICheckBox);
			this._ToggleMember.ID = (ulong)((long)XFastEnumIntEqualityComparer<RecruitToggle>.ToInt(RecruitToggle.ToggleMember));
			this.m_member = base.transform.Find("Bg/Member");
			this.m_group = base.transform.Find("Bg/Group");
			this._BtnClose = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this._recruitRed = base.transform.Find("Bg/Toggle/ToggleTeam/RedPoint").gameObject;
			this._Help = (base.transform.Find("Bg/P/p/Help").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040038B1 RID: 14513
		public IXUICheckBox _ToggleTeam;

		// Token: 0x040038B2 RID: 14514
		public IXUICheckBox _ToggleMember;

		// Token: 0x040038B3 RID: 14515
		public IXUIButton _BtnClose;

		// Token: 0x040038B4 RID: 14516
		public Transform m_member;

		// Token: 0x040038B5 RID: 14517
		public Transform m_group;

		// Token: 0x040038B6 RID: 14518
		public IXUIButton _Help;

		// Token: 0x040038B7 RID: 14519
		public GameObject _recruitRed;
	}
}
