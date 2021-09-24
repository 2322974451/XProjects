using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JadeComposeArg")]
	[Serializable]
	public class JadeComposeArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ComposeType", DataFormat = DataFormat.TwosComplement)]
		public uint ComposeType
		{
			get
			{
				return this._ComposeType ?? 0U;
			}
			set
			{
				this._ComposeType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ComposeTypeSpecified
		{
			get
			{
				return this._ComposeType != null;
			}
			set
			{
				bool flag = value == (this._ComposeType == null);
				if (flag)
				{
					this._ComposeType = (value ? new uint?(this.ComposeType) : null);
				}
			}
		}

		private bool ShouldSerializeComposeType()
		{
			return this.ComposeTypeSpecified;
		}

		private void ResetComposeType()
		{
			this.ComposeTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "JadeUniqueId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "EquipUniqueId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "SlotPos", DataFormat = DataFormat.TwosComplement)]
		public uint SlotPos
		{
			get
			{
				return this._SlotPos ?? 0U;
			}
			set
			{
				this._SlotPos = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SlotPosSpecified
		{
			get
			{
				return this._SlotPos != null;
			}
			set
			{
				bool flag = value == (this._SlotPos == null);
				if (flag)
				{
					this._SlotPos = (value ? new uint?(this.SlotPos) : null);
				}
			}
		}

		private bool ShouldSerializeSlotPos()
		{
			return this.SlotPosSpecified;
		}

		private void ResetSlotPos()
		{
			this.SlotPosSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "AddLevel", DataFormat = DataFormat.TwosComplement)]
		public uint AddLevel
		{
			get
			{
				return this._AddLevel ?? 0U;
			}
			set
			{
				this._AddLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool AddLevelSpecified
		{
			get
			{
				return this._AddLevel != null;
			}
			set
			{
				bool flag = value == (this._AddLevel == null);
				if (flag)
				{
					this._AddLevel = (value ? new uint?(this.AddLevel) : null);
				}
			}
		}

		private bool ShouldSerializeAddLevel()
		{
			return this.AddLevelSpecified;
		}

		private void ResetAddLevel()
		{
			this.AddLevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _ComposeType;

		private ulong? _JadeUniqueId;

		private ulong? _EquipUniqueId;

		private uint? _SlotPos;

		private uint? _AddLevel;

		private IExtension extensionObject;
	}
}
