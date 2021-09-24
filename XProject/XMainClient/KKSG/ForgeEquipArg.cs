using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ForgeEquipArg")]
	[Serializable]
	public class ForgeEquipArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "isUsedStone", DataFormat = DataFormat.Default)]
		public bool isUsedStone
		{
			get
			{
				return this._isUsedStone ?? false;
			}
			set
			{
				this._isUsedStone = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isUsedStoneSpecified
		{
			get
			{
				return this._isUsedStone != null;
			}
			set
			{
				bool flag = value == (this._isUsedStone == null);
				if (flag)
				{
					this._isUsedStone = (value ? new bool?(this.isUsedStone) : null);
				}
			}
		}

		private bool ShouldSerializeisUsedStone()
		{
			return this.isUsedStoneSpecified;
		}

		private void ResetisUsedStone()
		{
			this.isUsedStoneSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ForgeOpType type
		{
			get
			{
				return this._type ?? ForgeOpType.Forge_Equip;
			}
			set
			{
				this._type = new ForgeOpType?(value);
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
					this._type = (value ? new ForgeOpType?(this.type) : null);
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

		private ulong? _uid;

		private bool? _isUsedStone;

		private ForgeOpType? _type;

		private IExtension extensionObject;
	}
}
