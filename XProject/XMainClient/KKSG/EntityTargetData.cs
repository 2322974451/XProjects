using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EntityTargetData")]
	[Serializable]
	public class EntityTargetData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "entityUID", DataFormat = DataFormat.TwosComplement)]
		public ulong entityUID
		{
			get
			{
				return this._entityUID ?? 0UL;
			}
			set
			{
				this._entityUID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool entityUIDSpecified
		{
			get
			{
				return this._entityUID != null;
			}
			set
			{
				bool flag = value == (this._entityUID == null);
				if (flag)
				{
					this._entityUID = (value ? new ulong?(this.entityUID) : null);
				}
			}
		}

		private bool ShouldSerializeentityUID()
		{
			return this.entityUIDSpecified;
		}

		private void ResetentityUID()
		{
			this.entityUIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "targetUID", DataFormat = DataFormat.TwosComplement)]
		public ulong targetUID
		{
			get
			{
				return this._targetUID ?? 0UL;
			}
			set
			{
				this._targetUID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool targetUIDSpecified
		{
			get
			{
				return this._targetUID != null;
			}
			set
			{
				bool flag = value == (this._targetUID == null);
				if (flag)
				{
					this._targetUID = (value ? new ulong?(this.targetUID) : null);
				}
			}
		}

		private bool ShouldSerializetargetUID()
		{
			return this.targetUIDSpecified;
		}

		private void ResettargetUID()
		{
			this.targetUIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _entityUID;

		private ulong? _targetUID;

		private IExtension extensionObject;
	}
}
