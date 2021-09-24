using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillDataUnit")]
	[Serializable]
	public class SkillDataUnit : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "SkillID", DataFormat = DataFormat.TwosComplement)]
		public uint SkillID
		{
			get
			{
				return this._SkillID ?? 0U;
			}
			set
			{
				this._SkillID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIDSpecified
		{
			get
			{
				return this._SkillID != null;
			}
			set
			{
				bool flag = value == (this._SkillID == null);
				if (flag)
				{
					this._SkillID = (value ? new uint?(this.SkillID) : null);
				}
			}
		}

		private bool ShouldSerializeSkillID()
		{
			return this.SkillIDSpecified;
		}

		private void ResetSkillID()
		{
			this.SkillIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "Target", DataFormat = DataFormat.TwosComplement)]
		public ulong Target
		{
			get
			{
				return this._Target ?? 0UL;
			}
			set
			{
				this._Target = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TargetSpecified
		{
			get
			{
				return this._Target != null;
			}
			set
			{
				bool flag = value == (this._Target == null);
				if (flag)
				{
					this._Target = (value ? new ulong?(this.Target) : null);
				}
			}
		}

		private bool ShouldSerializeTarget()
		{
			return this.TargetSpecified;
		}

		private void ResetTarget()
		{
			this.TargetSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "ManualFace", DataFormat = DataFormat.TwosComplement)]
		public int ManualFace
		{
			get
			{
				return this._ManualFace ?? 0;
			}
			set
			{
				this._ManualFace = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ManualFaceSpecified
		{
			get
			{
				return this._ManualFace != null;
			}
			set
			{
				bool flag = value == (this._ManualFace == null);
				if (flag)
				{
					this._ManualFace = (value ? new int?(this.ManualFace) : null);
				}
			}
		}

		private bool ShouldSerializeManualFace()
		{
			return this.ManualFaceSpecified;
		}

		private void ResetManualFace()
		{
			this.ManualFaceSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "Slot", DataFormat = DataFormat.TwosComplement)]
		public int Slot
		{
			get
			{
				return this._Slot ?? 0;
			}
			set
			{
				this._Slot = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SlotSpecified
		{
			get
			{
				return this._Slot != null;
			}
			set
			{
				bool flag = value == (this._Slot == null);
				if (flag)
				{
					this._Slot = (value ? new int?(this.Slot) : null);
				}
			}
		}

		private bool ShouldSerializeSlot()
		{
			return this.SlotSpecified;
		}

		private void ResetSlot()
		{
			this.SlotSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SkillID;

		private ulong? _Target;

		private int? _ManualFace;

		private int? _Slot;

		private IExtension extensionObject;
	}
}
