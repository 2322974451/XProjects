using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReviveArg")]
	[Serializable]
	public class ReviveArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "selectBuff", DataFormat = DataFormat.TwosComplement)]
		public uint selectBuff
		{
			get
			{
				return this._selectBuff ?? 0U;
			}
			set
			{
				this._selectBuff = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool selectBuffSpecified
		{
			get
			{
				return this._selectBuff != null;
			}
			set
			{
				bool flag = value == (this._selectBuff == null);
				if (flag)
				{
					this._selectBuff = (value ? new uint?(this.selectBuff) : null);
				}
			}
		}

		private bool ShouldSerializeselectBuff()
		{
			return this.selectBuffSpecified;
		}

		private void ResetselectBuff()
		{
			this.selectBuffSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ReviveType type
		{
			get
			{
				return this._type ?? ReviveType.ReviveNone;
			}
			set
			{
				this._type = new ReviveType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new ReviveType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "clientinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ClientReviveInfo clientinfo
		{
			get
			{
				return this._clientinfo;
			}
			set
			{
				this._clientinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _selectBuff;

		private ReviveType? _type;

		private ClientReviveInfo _clientinfo = null;

		private IExtension extensionObject;
	}
}
