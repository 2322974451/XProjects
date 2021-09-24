using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleResult")]
	[Serializable]
	public class MobaBattleResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpid
		{
			get
			{
				return this._mvpid ?? 0UL;
			}
			set
			{
				this._mvpid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mvpidSpecified
		{
			get
			{
				return this._mvpid != null;
			}
			set
			{
				bool flag = value == (this._mvpid == null);
				if (flag)
				{
					this._mvpid = (value ? new ulong?(this.mvpid) : null);
				}
			}
		}

		private bool ShouldSerializemvpid()
		{
			return this.mvpidSpecified;
		}

		private void Resetmvpid()
		{
			this.mvpidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "losemvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong losemvpid
		{
			get
			{
				return this._losemvpid ?? 0UL;
			}
			set
			{
				this._losemvpid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losemvpidSpecified
		{
			get
			{
				return this._losemvpid != null;
			}
			set
			{
				bool flag = value == (this._losemvpid == null);
				if (flag)
				{
					this._losemvpid = (value ? new ulong?(this.losemvpid) : null);
				}
			}
		}

		private bool ShouldSerializelosemvpid()
		{
			return this.losemvpidSpecified;
		}

		private void Resetlosemvpid()
		{
			this.losemvpidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "damagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong damagemaxid
		{
			get
			{
				return this._damagemaxid ?? 0UL;
			}
			set
			{
				this._damagemaxid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool damagemaxidSpecified
		{
			get
			{
				return this._damagemaxid != null;
			}
			set
			{
				bool flag = value == (this._damagemaxid == null);
				if (flag)
				{
					this._damagemaxid = (value ? new ulong?(this.damagemaxid) : null);
				}
			}
		}

		private bool ShouldSerializedamagemaxid()
		{
			return this.damagemaxidSpecified;
		}

		private void Resetdamagemaxid()
		{
			this.damagemaxidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "behitdamagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong behitdamagemaxid
		{
			get
			{
				return this._behitdamagemaxid ?? 0UL;
			}
			set
			{
				this._behitdamagemaxid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool behitdamagemaxidSpecified
		{
			get
			{
				return this._behitdamagemaxid != null;
			}
			set
			{
				bool flag = value == (this._behitdamagemaxid == null);
				if (flag)
				{
					this._behitdamagemaxid = (value ? new ulong?(this.behitdamagemaxid) : null);
				}
			}
		}

		private bool ShouldSerializebehitdamagemaxid()
		{
			return this.behitdamagemaxidSpecified;
		}

		private void Resetbehitdamagemaxid()
		{
			this.behitdamagemaxidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _mvpid;

		private ulong? _losemvpid;

		private ulong? _damagemaxid;

		private ulong? _behitdamagemaxid;

		private IExtension extensionObject;
	}
}
