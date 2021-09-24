using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRoleAttributes : XAttributes
	{

		public override uint ID
		{
			get
			{
				return XRoleAttributes.uuID;
			}
		}

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

		public string GuildName { get; set; }

		public ulong GuildID { get; set; }

		public uint DesignationID { get; set; }

		public string SpecialDesignation { get; set; }

		public List<uint> PrerogativeSetID { get; set; }

		public uint PrerogativeScore { get; set; }

		public uint MilitaryRank { get; set; }

		public uint GuildPortrait { get; set; }

		public XRoleAttributes()
		{
			this._battle_Statistics = default(XBattleStatistics);
		}

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

		public override void InitAttribute(KKSG.Attribute attr)
		{
			this.SkillLevelInfo.SetDefaultLevel(0U);
			base.InitAttribute(attr);
		}

		public override uint TypeID
		{
			get
			{
				return (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(this.Profession);
			}
		}

		public override uint BasicTypeID
		{
			get
			{
				return this.TypeID % 10U;
			}
		}

		public override uint Tag
		{
			get
			{
				return EntityMask.Role;
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Role_Attributes");

		private RoleType _profession = RoleType.Role_INVALID;

		private bool _isLocalFake = false;
	}
}
