using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamInvite")]
	[Serializable]
	public class TeamInvite : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "inviteID", DataFormat = DataFormat.TwosComplement)]
		public uint inviteID
		{
			get
			{
				return this._inviteID ?? 0U;
			}
			set
			{
				this._inviteID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inviteIDSpecified
		{
			get
			{
				return this._inviteID != null;
			}
			set
			{
				bool flag = value == (this._inviteID == null);
				if (flag)
				{
					this._inviteID = (value ? new uint?(this.inviteID) : null);
				}
			}
		}

		private bool ShouldSerializeinviteID()
		{
			return this.inviteIDSpecified;
		}

		private void ResetinviteID()
		{
			this.inviteIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "invTime", DataFormat = DataFormat.TwosComplement)]
		public uint invTime
		{
			get
			{
				return this._invTime ?? 0U;
			}
			set
			{
				this._invTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invTimeSpecified
		{
			get
			{
				return this._invTime != null;
			}
			set
			{
				bool flag = value == (this._invTime == null);
				if (flag)
				{
					this._invTime = (value ? new uint?(this.invTime) : null);
				}
			}
		}

		private bool ShouldSerializeinvTime()
		{
			return this.invTimeSpecified;
		}

		private void ResetinvTime()
		{
			this.invTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "invguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong invguildid
		{
			get
			{
				return this._invguildid ?? 0UL;
			}
			set
			{
				this._invguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invguildidSpecified
		{
			get
			{
				return this._invguildid != null;
			}
			set
			{
				bool flag = value == (this._invguildid == null);
				if (flag)
				{
					this._invguildid = (value ? new ulong?(this.invguildid) : null);
				}
			}
		}

		private bool ShouldSerializeinvguildid()
		{
			return this.invguildidSpecified;
		}

		private void Resetinvguildid()
		{
			this.invguildidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "invdragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong invdragonguildid
		{
			get
			{
				return this._invdragonguildid ?? 0UL;
			}
			set
			{
				this._invdragonguildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invdragonguildidSpecified
		{
			get
			{
				return this._invdragonguildid != null;
			}
			set
			{
				bool flag = value == (this._invdragonguildid == null);
				if (flag)
				{
					this._invdragonguildid = (value ? new ulong?(this.invdragonguildid) : null);
				}
			}
		}

		private bool ShouldSerializeinvdragonguildid()
		{
			return this.invdragonguildidSpecified;
		}

		private void Resetinvdragonguildid()
		{
			this.invdragonguildidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "invfromroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong invfromroleid
		{
			get
			{
				return this._invfromroleid ?? 0UL;
			}
			set
			{
				this._invfromroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invfromroleidSpecified
		{
			get
			{
				return this._invfromroleid != null;
			}
			set
			{
				bool flag = value == (this._invfromroleid == null);
				if (flag)
				{
					this._invfromroleid = (value ? new ulong?(this.invfromroleid) : null);
				}
			}
		}

		private bool ShouldSerializeinvfromroleid()
		{
			return this.invfromroleidSpecified;
		}

		private void Resetinvfromroleid()
		{
			this.invfromroleidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "invtoroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong invtoroleid
		{
			get
			{
				return this._invtoroleid ?? 0UL;
			}
			set
			{
				this._invtoroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invtoroleidSpecified
		{
			get
			{
				return this._invtoroleid != null;
			}
			set
			{
				bool flag = value == (this._invtoroleid == null);
				if (flag)
				{
					this._invtoroleid = (value ? new ulong?(this.invtoroleid) : null);
				}
			}
		}

		private bool ShouldSerializeinvtoroleid()
		{
			return this.invtoroleidSpecified;
		}

		private void Resetinvtoroleid()
		{
			this.invtoroleidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "invfromrolename", DataFormat = DataFormat.Default)]
		public string invfromrolename
		{
			get
			{
				return this._invfromrolename ?? "";
			}
			set
			{
				this._invfromrolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invfromrolenameSpecified
		{
			get
			{
				return this._invfromrolename != null;
			}
			set
			{
				bool flag = value == (this._invfromrolename == null);
				if (flag)
				{
					this._invfromrolename = (value ? this.invfromrolename : null);
				}
			}
		}

		private bool ShouldSerializeinvfromrolename()
		{
			return this.invfromrolenameSpecified;
		}

		private void Resetinvfromrolename()
		{
			this.invfromrolenameSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "teambrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamBrief teambrief
		{
			get
			{
				return this._teambrief;
			}
			set
			{
				this._teambrief = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _inviteID;

		private uint? _invTime;

		private ulong? _invguildid;

		private ulong? _invdragonguildid;

		private ulong? _invfromroleid;

		private ulong? _invtoroleid;

		private string _invfromrolename;

		private TeamBrief _teambrief = null;

		private IExtension extensionObject;
	}
}
