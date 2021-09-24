using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClientInfo")]
	[Serializable]
	public class ClientInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "PlatID", DataFormat = DataFormat.TwosComplement)]
		public int PlatID
		{
			get
			{
				return this._PlatID ?? 0;
			}
			set
			{
				this._PlatID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool PlatIDSpecified
		{
			get
			{
				return this._PlatID != null;
			}
			set
			{
				bool flag = value == (this._PlatID == null);
				if (flag)
				{
					this._PlatID = (value ? new int?(this.PlatID) : null);
				}
			}
		}

		private bool ShouldSerializePlatID()
		{
			return this.PlatIDSpecified;
		}

		private void ResetPlatID()
		{
			this.PlatIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ClientVersion", DataFormat = DataFormat.Default)]
		public string ClientVersion
		{
			get
			{
				return this._ClientVersion ?? "";
			}
			set
			{
				this._ClientVersion = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ClientVersionSpecified
		{
			get
			{
				return this._ClientVersion != null;
			}
			set
			{
				bool flag = value == (this._ClientVersion == null);
				if (flag)
				{
					this._ClientVersion = (value ? this.ClientVersion : null);
				}
			}
		}

		private bool ShouldSerializeClientVersion()
		{
			return this.ClientVersionSpecified;
		}

		private void ResetClientVersion()
		{
			this.ClientVersionSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "SystemSoftware", DataFormat = DataFormat.Default)]
		public string SystemSoftware
		{
			get
			{
				return this._SystemSoftware ?? "";
			}
			set
			{
				this._SystemSoftware = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SystemSoftwareSpecified
		{
			get
			{
				return this._SystemSoftware != null;
			}
			set
			{
				bool flag = value == (this._SystemSoftware == null);
				if (flag)
				{
					this._SystemSoftware = (value ? this.SystemSoftware : null);
				}
			}
		}

		private bool ShouldSerializeSystemSoftware()
		{
			return this.SystemSoftwareSpecified;
		}

		private void ResetSystemSoftware()
		{
			this.SystemSoftwareSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "SystemHardware", DataFormat = DataFormat.Default)]
		public string SystemHardware
		{
			get
			{
				return this._SystemHardware ?? "";
			}
			set
			{
				this._SystemHardware = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SystemHardwareSpecified
		{
			get
			{
				return this._SystemHardware != null;
			}
			set
			{
				bool flag = value == (this._SystemHardware == null);
				if (flag)
				{
					this._SystemHardware = (value ? this.SystemHardware : null);
				}
			}
		}

		private bool ShouldSerializeSystemHardware()
		{
			return this.SystemHardwareSpecified;
		}

		private void ResetSystemHardware()
		{
			this.SystemHardwareSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "TelecomOper", DataFormat = DataFormat.Default)]
		public string TelecomOper
		{
			get
			{
				return this._TelecomOper ?? "";
			}
			set
			{
				this._TelecomOper = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TelecomOperSpecified
		{
			get
			{
				return this._TelecomOper != null;
			}
			set
			{
				bool flag = value == (this._TelecomOper == null);
				if (flag)
				{
					this._TelecomOper = (value ? this.TelecomOper : null);
				}
			}
		}

		private bool ShouldSerializeTelecomOper()
		{
			return this.TelecomOperSpecified;
		}

		private void ResetTelecomOper()
		{
			this.TelecomOperSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "Network", DataFormat = DataFormat.Default)]
		public string Network
		{
			get
			{
				return this._Network ?? "";
			}
			set
			{
				this._Network = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool NetworkSpecified
		{
			get
			{
				return this._Network != null;
			}
			set
			{
				bool flag = value == (this._Network == null);
				if (flag)
				{
					this._Network = (value ? this.Network : null);
				}
			}
		}

		private bool ShouldSerializeNetwork()
		{
			return this.NetworkSpecified;
		}

		private void ResetNetwork()
		{
			this.NetworkSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "ScreenWidth", DataFormat = DataFormat.TwosComplement)]
		public int ScreenWidth
		{
			get
			{
				return this._ScreenWidth ?? 0;
			}
			set
			{
				this._ScreenWidth = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ScreenWidthSpecified
		{
			get
			{
				return this._ScreenWidth != null;
			}
			set
			{
				bool flag = value == (this._ScreenWidth == null);
				if (flag)
				{
					this._ScreenWidth = (value ? new int?(this.ScreenWidth) : null);
				}
			}
		}

		private bool ShouldSerializeScreenWidth()
		{
			return this.ScreenWidthSpecified;
		}

		private void ResetScreenWidth()
		{
			this.ScreenWidthSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "ScreenHight", DataFormat = DataFormat.TwosComplement)]
		public int ScreenHight
		{
			get
			{
				return this._ScreenHight ?? 0;
			}
			set
			{
				this._ScreenHight = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ScreenHightSpecified
		{
			get
			{
				return this._ScreenHight != null;
			}
			set
			{
				bool flag = value == (this._ScreenHight == null);
				if (flag)
				{
					this._ScreenHight = (value ? new int?(this.ScreenHight) : null);
				}
			}
		}

		private bool ShouldSerializeScreenHight()
		{
			return this.ScreenHightSpecified;
		}

		private void ResetScreenHight()
		{
			this.ScreenHightSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "Density", DataFormat = DataFormat.FixedSize)]
		public float Density
		{
			get
			{
				return this._Density ?? 0f;
			}
			set
			{
				this._Density = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DensitySpecified
		{
			get
			{
				return this._Density != null;
			}
			set
			{
				bool flag = value == (this._Density == null);
				if (flag)
				{
					this._Density = (value ? new float?(this.Density) : null);
				}
			}
		}

		private bool ShouldSerializeDensity()
		{
			return this.DensitySpecified;
		}

		private void ResetDensity()
		{
			this.DensitySpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "LoginChannel", DataFormat = DataFormat.Default)]
		public string LoginChannel
		{
			get
			{
				return this._LoginChannel ?? "";
			}
			set
			{
				this._LoginChannel = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool LoginChannelSpecified
		{
			get
			{
				return this._LoginChannel != null;
			}
			set
			{
				bool flag = value == (this._LoginChannel == null);
				if (flag)
				{
					this._LoginChannel = (value ? this.LoginChannel : null);
				}
			}
		}

		private bool ShouldSerializeLoginChannel()
		{
			return this.LoginChannelSpecified;
		}

		private void ResetLoginChannel()
		{
			this.LoginChannelSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "CpuHardware", DataFormat = DataFormat.Default)]
		public string CpuHardware
		{
			get
			{
				return this._CpuHardware ?? "";
			}
			set
			{
				this._CpuHardware = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool CpuHardwareSpecified
		{
			get
			{
				return this._CpuHardware != null;
			}
			set
			{
				bool flag = value == (this._CpuHardware == null);
				if (flag)
				{
					this._CpuHardware = (value ? this.CpuHardware : null);
				}
			}
		}

		private bool ShouldSerializeCpuHardware()
		{
			return this.CpuHardwareSpecified;
		}

		private void ResetCpuHardware()
		{
			this.CpuHardwareSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "Memory", DataFormat = DataFormat.TwosComplement)]
		public int Memory
		{
			get
			{
				return this._Memory ?? 0;
			}
			set
			{
				this._Memory = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool MemorySpecified
		{
			get
			{
				return this._Memory != null;
			}
			set
			{
				bool flag = value == (this._Memory == null);
				if (flag)
				{
					this._Memory = (value ? new int?(this.Memory) : null);
				}
			}
		}

		private bool ShouldSerializeMemory()
		{
			return this.MemorySpecified;
		}

		private void ResetMemory()
		{
			this.MemorySpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "GLRender", DataFormat = DataFormat.Default)]
		public string GLRender
		{
			get
			{
				return this._GLRender ?? "";
			}
			set
			{
				this._GLRender = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool GLRenderSpecified
		{
			get
			{
				return this._GLRender != null;
			}
			set
			{
				bool flag = value == (this._GLRender == null);
				if (flag)
				{
					this._GLRender = (value ? this.GLRender : null);
				}
			}
		}

		private bool ShouldSerializeGLRender()
		{
			return this.GLRenderSpecified;
		}

		private void ResetGLRender()
		{
			this.GLRenderSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "GLVersion", DataFormat = DataFormat.Default)]
		public string GLVersion
		{
			get
			{
				return this._GLVersion ?? "";
			}
			set
			{
				this._GLVersion = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool GLVersionSpecified
		{
			get
			{
				return this._GLVersion != null;
			}
			set
			{
				bool flag = value == (this._GLVersion == null);
				if (flag)
				{
					this._GLVersion = (value ? this.GLVersion : null);
				}
			}
		}

		private bool ShouldSerializeGLVersion()
		{
			return this.GLVersionSpecified;
		}

		private void ResetGLVersion()
		{
			this.GLVersionSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "DeviceId", DataFormat = DataFormat.Default)]
		public string DeviceId
		{
			get
			{
				return this._DeviceId ?? "";
			}
			set
			{
				this._DeviceId = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DeviceIdSpecified
		{
			get
			{
				return this._DeviceId != null;
			}
			set
			{
				bool flag = value == (this._DeviceId == null);
				if (flag)
				{
					this._DeviceId = (value ? this.DeviceId : null);
				}
			}
		}

		private bool ShouldSerializeDeviceId()
		{
			return this.DeviceIdSpecified;
		}

		private void ResetDeviceId()
		{
			this.DeviceIdSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
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

		[ProtoMember(17, IsRequired = false, Name = "pf", DataFormat = DataFormat.Default)]
		public string pf
		{
			get
			{
				return this._pf ?? "";
			}
			set
			{
				this._pf = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pfSpecified
		{
			get
			{
				return this._pf != null;
			}
			set
			{
				bool flag = value == (this._pf == null);
				if (flag)
				{
					this._pf = (value ? this.pf : null);
				}
			}
		}

		private bool ShouldSerializepf()
		{
			return this.pfSpecified;
		}

		private void Resetpf()
		{
			this.pfSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "starttype", DataFormat = DataFormat.TwosComplement)]
		public StartUpType starttype
		{
			get
			{
				return this._starttype ?? StartUpType.StartUp_Normal;
			}
			set
			{
				this._starttype = new StartUpType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool starttypeSpecified
		{
			get
			{
				return this._starttype != null;
			}
			set
			{
				bool flag = value == (this._starttype == null);
				if (flag)
				{
					this._starttype = (value ? new StartUpType?(this.starttype) : null);
				}
			}
		}

		private bool ShouldSerializestarttype()
		{
			return this.starttypeSpecified;
		}

		private void Resetstarttype()
		{
			this.starttypeSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "logintype", DataFormat = DataFormat.TwosComplement)]
		public LoginType logintype
		{
			get
			{
				return this._logintype ?? LoginType.LOGIN_PASSWORD;
			}
			set
			{
				this._logintype = new LoginType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool logintypeSpecified
		{
			get
			{
				return this._logintype != null;
			}
			set
			{
				bool flag = value == (this._logintype == null);
				if (flag)
				{
					this._logintype = (value ? new LoginType?(this.logintype) : null);
				}
			}
		}

		private bool ShouldSerializelogintype()
		{
			return this.logintypeSpecified;
		}

		private void Resetlogintype()
		{
			this.logintypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _PlatID;

		private string _ClientVersion;

		private string _SystemSoftware;

		private string _SystemHardware;

		private string _TelecomOper;

		private string _Network;

		private int? _ScreenWidth;

		private int? _ScreenHight;

		private float? _Density;

		private string _LoginChannel;

		private string _CpuHardware;

		private int? _Memory;

		private string _GLRender;

		private string _GLVersion;

		private string _DeviceId;

		private string _ip;

		private string _pf;

		private StartUpType? _starttype;

		private string _token;

		private LoginType? _logintype;

		private IExtension extensionObject;
	}
}
