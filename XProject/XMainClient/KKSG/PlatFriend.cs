using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlatFriend")]
	[Serializable]
	public class PlatFriend : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "nickname", DataFormat = DataFormat.Default)]
		public string nickname
		{
			get
			{
				return this._nickname ?? "";
			}
			set
			{
				this._nickname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nicknameSpecified
		{
			get
			{
				return this._nickname != null;
			}
			set
			{
				bool flag = value == (this._nickname == null);
				if (flag)
				{
					this._nickname = (value ? this.nickname : null);
				}
			}
		}

		private bool ShouldSerializenickname()
		{
			return this.nicknameSpecified;
		}

		private void Resetnickname()
		{
			this.nicknameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "bigpic", DataFormat = DataFormat.Default)]
		public string bigpic
		{
			get
			{
				return this._bigpic ?? "";
			}
			set
			{
				this._bigpic = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bigpicSpecified
		{
			get
			{
				return this._bigpic != null;
			}
			set
			{
				bool flag = value == (this._bigpic == null);
				if (flag)
				{
					this._bigpic = (value ? this.bigpic : null);
				}
			}
		}

		private bool ShouldSerializebigpic()
		{
			return this.bigpicSpecified;
		}

		private void Resetbigpic()
		{
			this.bigpicSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "midpic", DataFormat = DataFormat.Default)]
		public string midpic
		{
			get
			{
				return this._midpic ?? "";
			}
			set
			{
				this._midpic = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool midpicSpecified
		{
			get
			{
				return this._midpic != null;
			}
			set
			{
				bool flag = value == (this._midpic == null);
				if (flag)
				{
					this._midpic = (value ? this.midpic : null);
				}
			}
		}

		private bool ShouldSerializemidpic()
		{
			return this.midpicSpecified;
		}

		private void Resetmidpic()
		{
			this.midpicSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "smallpic", DataFormat = DataFormat.Default)]
		public string smallpic
		{
			get
			{
				return this._smallpic ?? "";
			}
			set
			{
				this._smallpic = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool smallpicSpecified
		{
			get
			{
				return this._smallpic != null;
			}
			set
			{
				bool flag = value == (this._smallpic == null);
				if (flag)
				{
					this._smallpic = (value ? this.smallpic : null);
				}
			}
		}

		private bool ShouldSerializesmallpic()
		{
			return this.smallpicSpecified;
		}

		private void Resetsmallpic()
		{
			this.smallpicSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _openid;

		private string _nickname;

		private string _bigpic;

		private string _midpic;

		private string _smallpic;

		private IExtension extensionObject;
	}
}
