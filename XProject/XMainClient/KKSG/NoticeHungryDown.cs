using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeHungryDown")]
	[Serializable]
	public class NoticeHungryDown : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public ulong petid
		{
			get
			{
				return this._petid ?? 0UL;
			}
			set
			{
				this._petid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new ulong?(this.petid) : null);
				}
			}
		}

		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "hungry", DataFormat = DataFormat.TwosComplement)]
		public uint hungry
		{
			get
			{
				return this._hungry ?? 0U;
			}
			set
			{
				this._hungry = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hungrySpecified
		{
			get
			{
				return this._hungry != null;
			}
			set
			{
				bool flag = value == (this._hungry == null);
				if (flag)
				{
					this._hungry = (value ? new uint?(this.hungry) : null);
				}
			}
		}

		private bool ShouldSerializehungry()
		{
			return this.hungrySpecified;
		}

		private void Resethungry()
		{
			this.hungrySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _petid;

		private uint? _hungry;

		private IExtension extensionObject;
	}
}
