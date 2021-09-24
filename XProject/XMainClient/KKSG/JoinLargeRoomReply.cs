using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JoinLargeRoomReply")]
	[Serializable]
	public class JoinLargeRoomReply : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "url", DataFormat = DataFormat.Default)]
		public string url
		{
			get
			{
				return this._url ?? "";
			}
			set
			{
				this._url = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool urlSpecified
		{
			get
			{
				return this._url != null;
			}
			set
			{
				bool flag = value == (this._url == null);
				if (flag)
				{
					this._url = (value ? this.url : null);
				}
			}
		}

		private bool ShouldSerializeurl()
		{
			return this.urlSpecified;
		}

		private void Reseturl()
		{
			this.urlSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "key", DataFormat = DataFormat.TwosComplement)]
		public uint key
		{
			get
			{
				return this._key ?? 0U;
			}
			set
			{
				this._key = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool keySpecified
		{
			get
			{
				return this._key != null;
			}
			set
			{
				bool flag = value == (this._key == null);
				if (flag)
				{
					this._key = (value ? new uint?(this.key) : null);
				}
			}
		}

		private bool ShouldSerializekey()
		{
			return this.keySpecified;
		}

		private void Resetkey()
		{
			this.keySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "bussniessid", DataFormat = DataFormat.TwosComplement)]
		public uint bussniessid
		{
			get
			{
				return this._bussniessid ?? 0U;
			}
			set
			{
				this._bussniessid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bussniessidSpecified
		{
			get
			{
				return this._bussniessid != null;
			}
			set
			{
				bool flag = value == (this._bussniessid == null);
				if (flag)
				{
					this._bussniessid = (value ? new uint?(this.bussniessid) : null);
				}
			}
		}

		private bool ShouldSerializebussniessid()
		{
			return this.bussniessidSpecified;
		}

		private void Resetbussniessid()
		{
			this.bussniessidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
		public ulong roomid
		{
			get
			{
				return this._roomid ?? 0UL;
			}
			set
			{
				this._roomid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roomidSpecified
		{
			get
			{
				return this._roomid != null;
			}
			set
			{
				bool flag = value == (this._roomid == null);
				if (flag)
				{
					this._roomid = (value ? new ulong?(this.roomid) : null);
				}
			}
		}

		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "roomkey", DataFormat = DataFormat.TwosComplement)]
		public ulong roomkey
		{
			get
			{
				return this._roomkey ?? 0UL;
			}
			set
			{
				this._roomkey = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roomkeySpecified
		{
			get
			{
				return this._roomkey != null;
			}
			set
			{
				bool flag = value == (this._roomkey == null);
				if (flag)
				{
					this._roomkey = (value ? new ulong?(this.roomkey) : null);
				}
			}
		}

		private bool ShouldSerializeroomkey()
		{
			return this.roomkeySpecified;
		}

		private void Resetroomkey()
		{
			this.roomkeySpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public uint memberid
		{
			get
			{
				return this._memberid ?? 0U;
			}
			set
			{
				this._memberid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberidSpecified
		{
			get
			{
				return this._memberid != null;
			}
			set
			{
				bool flag = value == (this._memberid == null);
				if (flag)
				{
					this._memberid = (value ? new uint?(this.memberid) : null);
				}
			}
		}

		private bool ShouldSerializememberid()
		{
			return this.memberidSpecified;
		}

		private void Resetmemberid()
		{
			this.memberidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _url;

		private uint? _key;

		private uint? _bussniessid;

		private ulong? _roomid;

		private ulong? _roomkey;

		private uint? _memberid;

		private ulong? _roleid;

		private uint? _param;

		private IExtension extensionObject;
	}
}
