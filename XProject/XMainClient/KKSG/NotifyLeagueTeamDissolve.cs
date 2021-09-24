using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyLeagueTeamDissolve")]
	[Serializable]
	public class NotifyLeagueTeamDissolve : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "leave_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong leave_roleid
		{
			get
			{
				return this._leave_roleid ?? 0UL;
			}
			set
			{
				this._leave_roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leave_roleidSpecified
		{
			get
			{
				return this._leave_roleid != null;
			}
			set
			{
				bool flag = value == (this._leave_roleid == null);
				if (flag)
				{
					this._leave_roleid = (value ? new ulong?(this.leave_roleid) : null);
				}
			}
		}

		private bool ShouldSerializeleave_roleid()
		{
			return this.leave_roleidSpecified;
		}

		private void Resetleave_roleid()
		{
			this.leave_roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "leave_rolename", DataFormat = DataFormat.Default)]
		public string leave_rolename
		{
			get
			{
				return this._leave_rolename ?? "";
			}
			set
			{
				this._leave_rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leave_rolenameSpecified
		{
			get
			{
				return this._leave_rolename != null;
			}
			set
			{
				bool flag = value == (this._leave_rolename == null);
				if (flag)
				{
					this._leave_rolename = (value ? this.leave_rolename : null);
				}
			}
		}

		private bool ShouldSerializeleave_rolename()
		{
			return this.leave_rolenameSpecified;
		}

		private void Resetleave_rolename()
		{
			this.leave_rolenameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _leave_roleid;

		private string _leave_rolename;

		private IExtension extensionObject;
	}
}
