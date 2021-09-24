using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JadeOperationArg")]
	[Serializable]
	public class JadeOperationArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "OperationType", DataFormat = DataFormat.TwosComplement)]
		public uint OperationType
		{
			get
			{
				return this._OperationType ?? 0U;
			}
			set
			{
				this._OperationType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool OperationTypeSpecified
		{
			get
			{
				return this._OperationType != null;
			}
			set
			{
				bool flag = value == (this._OperationType == null);
				if (flag)
				{
					this._OperationType = (value ? new uint?(this.OperationType) : null);
				}
			}
		}

		private bool ShouldSerializeOperationType()
		{
			return this.OperationTypeSpecified;
		}

		private void ResetOperationType()
		{
			this.OperationTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "EquipUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong EquipUniqueId
		{
			get
			{
				return this._EquipUniqueId ?? 0UL;
			}
			set
			{
				this._EquipUniqueId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool EquipUniqueIdSpecified
		{
			get
			{
				return this._EquipUniqueId != null;
			}
			set
			{
				bool flag = value == (this._EquipUniqueId == null);
				if (flag)
				{
					this._EquipUniqueId = (value ? new ulong?(this.EquipUniqueId) : null);
				}
			}
		}

		private bool ShouldSerializeEquipUniqueId()
		{
			return this.EquipUniqueIdSpecified;
		}

		private void ResetEquipUniqueId()
		{
			this.EquipUniqueIdSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "JadeUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong JadeUniqueId
		{
			get
			{
				return this._JadeUniqueId ?? 0UL;
			}
			set
			{
				this._JadeUniqueId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool JadeUniqueIdSpecified
		{
			get
			{
				return this._JadeUniqueId != null;
			}
			set
			{
				bool flag = value == (this._JadeUniqueId == null);
				if (flag)
				{
					this._JadeUniqueId = (value ? new ulong?(this.JadeUniqueId) : null);
				}
			}
		}

		private bool ShouldSerializeJadeUniqueId()
		{
			return this.JadeUniqueIdSpecified;
		}

		private void ResetJadeUniqueId()
		{
			this.JadeUniqueIdSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "Pos", DataFormat = DataFormat.TwosComplement)]
		public uint Pos
		{
			get
			{
				return this._Pos ?? 0U;
			}
			set
			{
				this._Pos = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool PosSpecified
		{
			get
			{
				return this._Pos != null;
			}
			set
			{
				bool flag = value == (this._Pos == null);
				if (flag)
				{
					this._Pos = (value ? new uint?(this.Pos) : null);
				}
			}
		}

		private bool ShouldSerializePos()
		{
			return this.PosSpecified;
		}

		private void ResetPos()
		{
			this.PosSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _OperationType;

		private ulong? _EquipUniqueId;

		private ulong? _JadeUniqueId;

		private uint? _Pos;

		private IExtension extensionObject;
	}
}
