using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F3F RID: 3903
	internal class XRoleAttributes : XAttributes
	{
		// Token: 0x1700366B RID: 13931
		// (get) Token: 0x0600CFB1 RID: 53169 RVA: 0x003035FC File Offset: 0x003017FC
		public override uint ID
		{
			get
			{
				return XRoleAttributes.uuID;
			}
		}

		// Token: 0x1700366C RID: 13932
		// (get) Token: 0x0600CFB2 RID: 53170 RVA: 0x00303614 File Offset: 0x00301814
		// (set) Token: 0x0600CFB3 RID: 53171 RVA: 0x0030362C File Offset: 0x0030182C
		public RoleType Profession
		{
			get
			{
				return this._profession;
			}
			set
			{
				this._profession = value;
				bool flag = XAttributes.IsPlayer(base.RoleID);
				if (flag)
				{
					XFileLog.RoleProf = XFastEnumIntEqualityComparer<RoleType>.ToInt(this._profession);
				}
			}
		}

		// Token: 0x1700366D RID: 13933
		// (get) Token: 0x0600CFB4 RID: 53172 RVA: 0x00303660 File Offset: 0x00301860
		// (set) Token: 0x0600CFB5 RID: 53173 RVA: 0x00303668 File Offset: 0x00301868
		public string GuildName { get; set; }

		// Token: 0x1700366E RID: 13934
		// (get) Token: 0x0600CFB6 RID: 53174 RVA: 0x00303671 File Offset: 0x00301871
		// (set) Token: 0x0600CFB7 RID: 53175 RVA: 0x00303679 File Offset: 0x00301879
		public ulong GuildID { get; set; }

		// Token: 0x1700366F RID: 13935
		// (get) Token: 0x0600CFB8 RID: 53176 RVA: 0x00303682 File Offset: 0x00301882
		// (set) Token: 0x0600CFB9 RID: 53177 RVA: 0x0030368A File Offset: 0x0030188A
		public uint DesignationID { get; set; }

		// Token: 0x17003670 RID: 13936
		// (get) Token: 0x0600CFBA RID: 53178 RVA: 0x00303693 File Offset: 0x00301893
		// (set) Token: 0x0600CFBB RID: 53179 RVA: 0x0030369B File Offset: 0x0030189B
		public string SpecialDesignation { get; set; }

		// Token: 0x17003671 RID: 13937
		// (get) Token: 0x0600CFBC RID: 53180 RVA: 0x003036A4 File Offset: 0x003018A4
		// (set) Token: 0x0600CFBD RID: 53181 RVA: 0x003036AC File Offset: 0x003018AC
		public List<uint> PrerogativeSetID { get; set; }

		// Token: 0x17003672 RID: 13938
		// (get) Token: 0x0600CFBE RID: 53182 RVA: 0x003036B5 File Offset: 0x003018B5
		// (set) Token: 0x0600CFBF RID: 53183 RVA: 0x003036BD File Offset: 0x003018BD
		public uint PrerogativeScore { get; set; }

		// Token: 0x17003673 RID: 13939
		// (get) Token: 0x0600CFC0 RID: 53184 RVA: 0x003036C6 File Offset: 0x003018C6
		// (set) Token: 0x0600CFC1 RID: 53185 RVA: 0x003036CE File Offset: 0x003018CE
		public uint MilitaryRank { get; set; }

		// Token: 0x17003674 RID: 13940
		// (get) Token: 0x0600CFC2 RID: 53186 RVA: 0x003036D7 File Offset: 0x003018D7
		// (set) Token: 0x0600CFC3 RID: 53187 RVA: 0x003036DF File Offset: 0x003018DF
		public uint GuildPortrait { get; set; }

		// Token: 0x0600CFC4 RID: 53188 RVA: 0x003036E8 File Offset: 0x003018E8
		public XRoleAttributes()
		{
			this._battle_Statistics = default(XBattleStatistics);
		}

		// Token: 0x0600CFC5 RID: 53189 RVA: 0x0030370C File Offset: 0x0030190C
		public override bool IsBindedSkill(uint id)
		{
			for (int i = 0; i < this.skillSlot.Length; i++)
			{
				bool flag = this.skillSlot[i] == id;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600CFC6 RID: 53190 RVA: 0x0030374B File Offset: 0x0030194B
		public override void InitAttribute(KKSG.Attribute attr)
		{
			this.SkillLevelInfo.SetDefaultLevel(0U);
			base.InitAttribute(attr);
		}

		// Token: 0x17003675 RID: 13941
		// (get) Token: 0x0600CFC7 RID: 53191 RVA: 0x00303764 File Offset: 0x00301964
		public override uint TypeID
		{
			get
			{
				return (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(this.Profession);
			}
		}

		// Token: 0x17003676 RID: 13942
		// (get) Token: 0x0600CFC8 RID: 53192 RVA: 0x00303784 File Offset: 0x00301984
		public override uint BasicTypeID
		{
			get
			{
				return this.TypeID % 10U;
			}
		}

		// Token: 0x17003677 RID: 13943
		// (get) Token: 0x0600CFC9 RID: 53193 RVA: 0x003037A0 File Offset: 0x003019A0
		public override uint Tag
		{
			get
			{
				return EntityMask.Role;
			}
		}

		// Token: 0x17003678 RID: 13944
		// (get) Token: 0x0600CFCA RID: 53194 RVA: 0x003037B8 File Offset: 0x003019B8
		// (set) Token: 0x0600CFCB RID: 53195 RVA: 0x003037D0 File Offset: 0x003019D0
		public bool IsLocalFake
		{
			get
			{
				return this._isLocalFake;
			}
			set
			{
				this._isLocalFake = value;
			}
		}

		// Token: 0x04005D5C RID: 23900
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Role_Attributes");

		// Token: 0x04005D5D RID: 23901
		private RoleType _profession = RoleType.Role_INVALID;

		// Token: 0x04005D66 RID: 23910
		private bool _isLocalFake = false;
	}
}
