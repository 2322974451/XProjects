using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SynDoingGuildInherit")]
	[Serializable]
	public class SynDoingGuildInherit : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleOne", DataFormat = DataFormat.TwosComplement)]
		public ulong roleOne
		{
			get
			{
				return this._roleOne ?? 0UL;
			}
			set
			{
				this._roleOne = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleOneSpecified
		{
			get
			{
				return this._roleOne != null;
			}
			set
			{
				bool flag = value == (this._roleOne == null);
				if (flag)
				{
					this._roleOne = (value ? new ulong?(this.roleOne) : null);
				}
			}
		}

		private bool ShouldSerializeroleOne()
		{
			return this.roleOneSpecified;
		}

		private void ResetroleOne()
		{
			this.roleOneSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleTwo", DataFormat = DataFormat.TwosComplement)]
		public ulong roleTwo
		{
			get
			{
				return this._roleTwo ?? 0UL;
			}
			set
			{
				this._roleTwo = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleTwoSpecified
		{
			get
			{
				return this._roleTwo != null;
			}
			set
			{
				bool flag = value == (this._roleTwo == null);
				if (flag)
				{
					this._roleTwo = (value ? new ulong?(this.roleTwo) : null);
				}
			}
		}

		private bool ShouldSerializeroleTwo()
		{
			return this.roleTwoSpecified;
		}

		private void ResetroleTwo()
		{
			this.roleTwoSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
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
					this._type = (value ? new uint?(this.type) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleOne;

		private ulong? _roleTwo;

		private uint? _type;

		private IExtension extensionObject;
	}
}
