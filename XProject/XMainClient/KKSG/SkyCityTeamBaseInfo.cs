using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityTeamBaseInfo")]
	[Serializable]
	public class SkyCityTeamBaseInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public int teamid
		{
			get
			{
				return this._teamid ?? 0;
			}
			set
			{
				this._teamid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new int?(this.teamid) : null);
				}
			}
		}

		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lv", DataFormat = DataFormat.TwosComplement)]
		public uint lv
		{
			get
			{
				return this._lv ?? 0U;
			}
			set
			{
				this._lv = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lvSpecified
		{
			get
			{
				return this._lv != null;
			}
			set
			{
				bool flag = value == (this._lv == null);
				if (flag)
				{
					this._lv = (value ? new uint?(this.lv) : null);
				}
			}
		}

		private bool ShouldSerializelv()
		{
			return this.lvSpecified;
		}

		private void Resetlv()
		{
			this.lvSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
		public uint job
		{
			get
			{
				return this._job ?? 0U;
			}
			set
			{
				this._job = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jobSpecified
		{
			get
			{
				return this._job != null;
			}
			set
			{
				bool flag = value == (this._job == null);
				if (flag)
				{
					this._job = (value ? new uint?(this.job) : null);
				}
			}
		}

		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "online", DataFormat = DataFormat.Default)]
		public bool online
		{
			get
			{
				return this._online ?? false;
			}
			set
			{
				this._online = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onlineSpecified
		{
			get
			{
				return this._online != null;
			}
			set
			{
				bool flag = value == (this._online == null);
				if (flag)
				{
					this._online = (value ? new bool?(this.online) : null);
				}
			}
		}

		private bool ShouldSerializeonline()
		{
			return this.onlineSpecified;
		}

		private void Resetonline()
		{
			this.onlineSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _teamid;

		private ulong? _uid;

		private string _name;

		private uint? _lv;

		private uint? _ppt;

		private uint? _job;

		private bool? _online;

		private IExtension extensionObject;
	}
}
