using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildSchoolHallRankData")]
	[Serializable]
	public class GuildSchoolHallRankData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public uint roleprofession
		{
			get
			{
				return this._roleprofession ?? 0U;
			}
			set
			{
				this._roleprofession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleprofessionSpecified
		{
			get
			{
				return this._roleprofession != null;
			}
			set
			{
				bool flag = value == (this._roleprofession == null);
				if (flag)
				{
					this._roleprofession = (value ? new uint?(this.roleprofession) : null);
				}
			}
		}

		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "weeklyschoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyschoolpoint
		{
			get
			{
				return this._weeklyschoolpoint ?? 0U;
			}
			set
			{
				this._weeklyschoolpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyschoolpointSpecified
		{
			get
			{
				return this._weeklyschoolpoint != null;
			}
			set
			{
				bool flag = value == (this._weeklyschoolpoint == null);
				if (flag)
				{
					this._weeklyschoolpoint = (value ? new uint?(this.weeklyschoolpoint) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyschoolpoint()
		{
			return this.weeklyschoolpointSpecified;
		}

		private void Resetweeklyschoolpoint()
		{
			this.weeklyschoolpointSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "weeklyhallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weeklyhallpoint
		{
			get
			{
				return this._weeklyhallpoint ?? 0U;
			}
			set
			{
				this._weeklyhallpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeklyhallpointSpecified
		{
			get
			{
				return this._weeklyhallpoint != null;
			}
			set
			{
				bool flag = value == (this._weeklyhallpoint == null);
				if (flag)
				{
					this._weeklyhallpoint = (value ? new uint?(this.weeklyhallpoint) : null);
				}
			}
		}

		private bool ShouldSerializeweeklyhallpoint()
		{
			return this.weeklyhallpointSpecified;
		}

		private void Resetweeklyhallpoint()
		{
			this.weeklyhallpointSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public uint updatetime
		{
			get
			{
				return this._updatetime ?? 0U;
			}
			set
			{
				this._updatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new uint?(this.updatetime) : null);
				}
			}
		}

		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _rolename;

		private uint? _roleprofession;

		private uint? _weeklyschoolpoint;

		private uint? _weeklyhallpoint;

		private uint? _updatetime;

		private IExtension extensionObject;
	}
}
