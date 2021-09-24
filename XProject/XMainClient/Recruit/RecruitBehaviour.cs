using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitBehaviour : DlgBehaviourBase
	{

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

		public IXUICheckBox _ToggleTeam;

		public IXUICheckBox _ToggleMember;

		public IXUIButton _BtnClose;

		public Transform m_member;

		public Transform m_group;

		public IXUIButton _Help;

		public GameObject _recruitRed;
	}
}
