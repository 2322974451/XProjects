using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginGateData")]
	[Serializable]
	public class LoginGateData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
		public string ip
		{
			get
			{
				return this._ip ?? "";
			}
			set
			{
				this._ip = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ipSpecified
		{
			get
			{
				return this._ip != null;
			}
			set
			{
				bool flag = value == (this._ip == null);
				if (flag)
				{
					this._ip = (value ? this.ip : null);
				}
			}
		}

		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		private void Resetip()
		{
			this.ipSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "zonename", DataFormat = DataFormat.Default)]
		public string zonename
		{
			get
			{
				return this._zonename ?? "";
			}
			set
			{
				this._zonename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool zonenameSpecified
		{
			get
			{
				return this._zonename != null;
			}
			set
			{
				bool flag = value == (this._zonename == null);
				if (flag)
				{
					this._zonename = (value ? this.zonename : null);
				}
			}
		}

		private bool ShouldSerializezonename()
		{
			return this.zonenameSpecified;
		}

		private void Resetzonename()
		{
			this.zonenameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "port", DataFormat = DataFormat.TwosComplement)]
		public int port
		{
			get
			{
				return this._port ?? 0;
			}
			set
			{
				this._port = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool portSpecified
		{
			get
			{
				return this._port != null;
			}
			set
			{
				bool flag = value == (this._port == null);
				if (flag)
				{
					this._port = (value ? new int?(this.port) : null);
				}
			}
		}

		private bool ShouldSerializeport()
		{
			return this.portSpecified;
		}

		private void Resetport()
		{
			this.portSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public int serverid
		{
			get
			{
				return this._serverid ?? 0;
			}
			set
			{
				this._serverid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new int?(this.serverid) : null);
				}
			}
		}

		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "flag", DataFormat = DataFormat.TwosComplement)]
		public uint flag
		{
			get
			{
				return this._flag ?? 0U;
			}
			set
			{
				this._flag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool flagSpecified
		{
			get
			{
				return this._flag != null;
			}
			set
			{
				bool flag = value == (this._flag == null);
				if (flag)
				{
					this._flag = (value ? new uint?(this.flag) : null);
				}
			}
		}

		private bool ShouldSerializeflag()
		{
			return this.flagSpecified;
		}

		private void Resetflag()
		{
			this.flagSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "isbackflow", DataFormat = DataFormat.Default)]
		public bool isbackflow
		{
			get
			{
				return this._isbackflow ?? false;
			}
			set
			{
				this._isbackflow = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isbackflowSpecified
		{
			get
			{
				return this._isbackflow != null;
			}
			set
			{
				bool flag = value == (this._isbackflow == null);
				if (flag)
				{
					this._isbackflow = (value ? new bool?(this.isbackflow) : null);
				}
			}
		}

		private bool ShouldSerializeisbackflow()
		{
			return this.isbackflowSpecified;
		}

		private void Resetisbackflow()
		{
			this.isbackflowSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "backflowlevel", DataFormat = DataFormat.TwosComplement)]
		public uint backflowlevel
		{
			get
			{
				return this._backflowlevel ?? 0U;
			}
			set
			{
				this._backflowlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool backflowlevelSpecified
		{
			get
			{
				return this._backflowlevel != null;
			}
			set
			{
				bool flag = value == (this._backflowlevel == null);
				if (flag)
				{
					this._backflowlevel = (value ? new uint?(this.backflowlevel) : null);
				}
			}
		}

		private bool ShouldSerializebackflowlevel()
		{
			return this.backflowlevelSpecified;
		}

		private void Resetbackflowlevel()
		{
			this.backflowlevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _ip;

		private string _zonename;

		private string _servername;

		private int? _port;

		private int? _serverid;

		private uint? _state;

		private uint? _flag;

		private bool? _isbackflow;

		private uint? _backflowlevel;

		private IExtension extensionObject;
	}
}
