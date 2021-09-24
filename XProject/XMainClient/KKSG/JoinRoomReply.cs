using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JoinRoomReply")]
	[Serializable]
	public class JoinRoomReply : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "url1", DataFormat = DataFormat.Default)]
		public string url1
		{
			get
			{
				return this._url1 ?? "";
			}
			set
			{
				this._url1 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool url1Specified
		{
			get
			{
				return this._url1 != null;
			}
			set
			{
				bool flag = value == (this._url1 == null);
				if (flag)
				{
					this._url1 = (value ? this.url1 : null);
				}
			}
		}

		private bool ShouldSerializeurl1()
		{
			return this.url1Specified;
		}

		private void Reseturl1()
		{
			this.url1Specified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "url2", DataFormat = DataFormat.Default)]
		public string url2
		{
			get
			{
				return this._url2 ?? "";
			}
			set
			{
				this._url2 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool url2Specified
		{
			get
			{
				return this._url2 != null;
			}
			set
			{
				bool flag = value == (this._url2 == null);
				if (flag)
				{
					this._url2 = (value ? this.url2 : null);
				}
			}
		}

		private bool ShouldSerializeurl2()
		{
			return this.url2Specified;
		}

		private void Reseturl2()
		{
			this.url2Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "url3", DataFormat = DataFormat.Default)]
		public string url3
		{
			get
			{
				return this._url3 ?? "";
			}
			set
			{
				this._url3 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool url3Specified
		{
			get
			{
				return this._url3 != null;
			}
			set
			{
				bool flag = value == (this._url3 == null);
				if (flag)
				{
					this._url3 = (value ? this.url3 : null);
				}
			}
		}

		private bool ShouldSerializeurl3()
		{
			return this.url3Specified;
		}

		private void Reseturl3()
		{
			this.url3Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "roomID", DataFormat = DataFormat.TwosComplement)]
		public long roomID
		{
			get
			{
				return this._roomID ?? 0L;
			}
			set
			{
				this._roomID = new long?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roomIDSpecified
		{
			get
			{
				return this._roomID != null;
			}
			set
			{
				bool flag = value == (this._roomID == null);
				if (flag)
				{
					this._roomID = (value ? new long?(this.roomID) : null);
				}
			}
		}

		private bool ShouldSerializeroomID()
		{
			return this.roomIDSpecified;
		}

		private void ResetroomID()
		{
			this.roomIDSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "roomKey", DataFormat = DataFormat.TwosComplement)]
		public long roomKey
		{
			get
			{
				return this._roomKey ?? 0L;
			}
			set
			{
				this._roomKey = new long?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roomKeySpecified
		{
			get
			{
				return this._roomKey != null;
			}
			set
			{
				bool flag = value == (this._roomKey == null);
				if (flag)
				{
					this._roomKey = (value ? new long?(this.roomKey) : null);
				}
			}
		}

		private bool ShouldSerializeroomKey()
		{
			return this.roomKeySpecified;
		}

		private void ResetroomKey()
		{
			this.roomKeySpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "memberID", DataFormat = DataFormat.TwosComplement)]
		public int memberID
		{
			get
			{
				return this._memberID ?? 0;
			}
			set
			{
				this._memberID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberIDSpecified
		{
			get
			{
				return this._memberID != null;
			}
			set
			{
				bool flag = value == (this._memberID == null);
				if (flag)
				{
					this._memberID = (value ? new int?(this.memberID) : null);
				}
			}
		}

		private bool ShouldSerializememberID()
		{
			return this.memberIDSpecified;
		}

		private void ResetmemberID()
		{
			this.memberIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _url1;

		private string _url2;

		private string _url3;

		private long? _roomID;

		private long? _roomKey;

		private int? _memberID;

		private IExtension extensionObject;
	}
}
