using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamChanged")]
	[Serializable]
	public class TeamChanged : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamBrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamBrief teamBrief
		{
			get
			{
				return this._teamBrief;
			}
			set
			{
				this._teamBrief = value;
			}
		}

		[ProtoMember(2, Name = "leaveMember", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> leaveMember
		{
			get
			{
				return this._leaveMember;
			}
		}

		[ProtoMember(3, Name = "addMember", DataFormat = DataFormat.Default)]
		public List<TeamMember> addMember
		{
			get
			{
				return this._addMember;
			}
		}

		[ProtoMember(4, Name = "chgstateMember", DataFormat = DataFormat.Default)]
		public List<TeamMember> chgstateMember
		{
			get
			{
				return this._chgstateMember;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private TeamBrief _teamBrief = null;

		private readonly List<ulong> _leaveMember = new List<ulong>();

		private readonly List<TeamMember> _addMember = new List<TeamMember>();

		private readonly List<TeamMember> _chgstateMember = new List<TeamMember>();

		private IExtension extensionObject;
	}
}
