using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SmeltItemArg")]
	[Serializable]
	public class SmeltItemArg : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public uint slot
		{
			get
			{
				return this._slot ?? 0U;
			}
			set
			{
				this._slot = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new uint?(this.slot) : null);
				}
			}
		}

		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isForge", DataFormat = DataFormat.Default)]
		public bool isForge
		{
			get
			{
				return this._isForge ?? false;
			}
			set
			{
				this._isForge = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isForgeSpecified
		{
			get
			{
				return this._isForge != null;
			}
			set
			{
				bool flag = value == (this._isForge == null);
				if (flag)
				{
					this._isForge = (value ? new bool?(this.isForge) : null);
				}
			}
		}

		private bool ShouldSerializeisForge()
		{
			return this.isForgeSpecified;
		}

		private void ResetisForge()
		{
			this.isForgeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _slot;

		private bool? _isForge;

		private IExtension extensionObject;
	}
}
