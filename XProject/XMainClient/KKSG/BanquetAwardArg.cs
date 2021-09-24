using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BanquetAwardArg")]
	[Serializable]
	public class BanquetAwardArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Banquet_id", DataFormat = DataFormat.TwosComplement)]
		public uint Banquet_id
		{
			get
			{
				return this._Banquet_id ?? 0U;
			}
			set
			{
				this._Banquet_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool Banquet_idSpecified
		{
			get
			{
				return this._Banquet_id != null;
			}
			set
			{
				bool flag = value == (this._Banquet_id == null);
				if (flag)
				{
					this._Banquet_id = (value ? new uint?(this.Banquet_id) : null);
				}
			}
		}

		private bool ShouldSerializeBanquet_id()
		{
			return this.Banquet_idSpecified;
		}

		private void ResetBanquet_id()
		{
			this.Banquet_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _Banquet_id;

		private ulong? _garden_id;

		private IExtension extensionObject;
	}
}
