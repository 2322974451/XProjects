using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueTeamMemberDetail")]
	[Serializable]
	public class LeagueTeamMemberDetail : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "brief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleOutLookBrief brief
		{
			get
			{
				return this._brief;
			}
			set
			{
				this._brief = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "pkpoint", DataFormat = DataFormat.TwosComplement)]
		public uint pkpoint
		{
			get
			{
				return this._pkpoint ?? 0U;
			}
			set
			{
				this._pkpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pkpointSpecified
		{
			get
			{
				return this._pkpoint != null;
			}
			set
			{
				bool flag = value == (this._pkpoint == null);
				if (flag)
				{
					this._pkpoint = (value ? new uint?(this.pkpoint) : null);
				}
			}
		}

		private bool ShouldSerializepkpoint()
		{
			return this.pkpointSpecified;
		}

		private void Resetpkpoint()
		{
			this.pkpointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleOutLookBrief _brief = null;

		private uint? _pkpoint;

		private IExtension extensionObject;
	}
}
