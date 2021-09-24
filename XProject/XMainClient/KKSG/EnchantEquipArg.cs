using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnchantEquipArg")]
	[Serializable]
	public class EnchantEquipArg : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "enchantid", DataFormat = DataFormat.TwosComplement)]
		public uint enchantid
		{
			get
			{
				return this._enchantid ?? 0U;
			}
			set
			{
				this._enchantid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enchantidSpecified
		{
			get
			{
				return this._enchantid != null;
			}
			set
			{
				bool flag = value == (this._enchantid == null);
				if (flag)
				{
					this._enchantid = (value ? new uint?(this.enchantid) : null);
				}
			}
		}

		private bool ShouldSerializeenchantid()
		{
			return this.enchantidSpecified;
		}

		private void Resetenchantid()
		{
			this.enchantidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _enchantid;

		private IExtension extensionObject;
	}
}
