using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OutLookState")]
	[Serializable]
	public class OutLookState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "statetype", DataFormat = DataFormat.TwosComplement)]
		public OutLookStateType statetype
		{
			get
			{
				return this._statetype ?? OutLookStateType.OutLook_Normal;
			}
			set
			{
				this._statetype = new OutLookStateType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool statetypeSpecified
		{
			get
			{
				return this._statetype != null;
			}
			set
			{
				bool flag = value == (this._statetype == null);
				if (flag)
				{
					this._statetype = (value ? new OutLookStateType?(this.statetype) : null);
				}
			}
		}

		private bool ShouldSerializestatetype()
		{
			return this.statetypeSpecified;
		}

		private void Resetstatetype()
		{
			this.statetypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "paramother", DataFormat = DataFormat.TwosComplement)]
		public ulong paramother
		{
			get
			{
				return this._paramother ?? 0UL;
			}
			set
			{
				this._paramother = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramotherSpecified
		{
			get
			{
				return this._paramother != null;
			}
			set
			{
				bool flag = value == (this._paramother == null);
				if (flag)
				{
					this._paramother = (value ? new ulong?(this.paramother) : null);
				}
			}
		}

		private bool ShouldSerializeparamother()
		{
			return this.paramotherSpecified;
		}

		private void Resetparamother()
		{
			this.paramotherSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private OutLookStateType? _statetype;

		private uint? _param;

		private ulong? _paramother;

		private IExtension extensionObject;
	}
}
