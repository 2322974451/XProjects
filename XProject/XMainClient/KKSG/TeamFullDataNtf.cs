using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamFullDataNtf")]
	[Serializable]
	public class TeamFullDataNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "hasTeam", DataFormat = DataFormat.Default)]
		public bool hasTeam
		{
			get
			{
				return this._hasTeam ?? false;
			}
			set
			{
				this._hasTeam = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasTeamSpecified
		{
			get
			{
				return this._hasTeam != null;
			}
			set
			{
				bool flag = value == (this._hasTeam == null);
				if (flag)
				{
					this._hasTeam = (value ? new bool?(this.hasTeam) : null);
				}
			}
		}

		private bool ShouldSerializehasTeam()
		{
			return this.hasTeamSpecified;
		}

		private void ResethasTeam()
		{
			this.hasTeamSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "teamBrief", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, Name = "members", DataFormat = DataFormat.Default)]
		public List<TeamMember> members
		{
			get
			{
				return this._members;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _hasTeam;

		private TeamBrief _teamBrief = null;

		private readonly List<TeamMember> _members = new List<TeamMember>();

		private IExtension extensionObject;
	}
}
