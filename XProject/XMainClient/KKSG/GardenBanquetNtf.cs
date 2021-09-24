using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenBanquetNtf")]
	[Serializable]
	public class GardenBanquetNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "banquet_id", DataFormat = DataFormat.TwosComplement)]
		public uint banquet_id
		{
			get
			{
				return this._banquet_id ?? 0U;
			}
			set
			{
				this._banquet_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool banquet_idSpecified
		{
			get
			{
				return this._banquet_id != null;
			}
			set
			{
				bool flag = value == (this._banquet_id == null);
				if (flag)
				{
					this._banquet_id = (value ? new uint?(this.banquet_id) : null);
				}
			}
		}

		private bool ShouldSerializebanquet_id()
		{
			return this.banquet_idSpecified;
		}

		private void Resetbanquet_id()
		{
			this.banquet_idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "banquet_stage", DataFormat = DataFormat.TwosComplement)]
		public uint banquet_stage
		{
			get
			{
				return this._banquet_stage ?? 0U;
			}
			set
			{
				this._banquet_stage = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool banquet_stageSpecified
		{
			get
			{
				return this._banquet_stage != null;
			}
			set
			{
				bool flag = value == (this._banquet_stage == null);
				if (flag)
				{
					this._banquet_stage = (value ? new uint?(this.banquet_stage) : null);
				}
			}
		}

		private bool ShouldSerializebanquet_stage()
		{
			return this.banquet_stageSpecified;
		}

		private void Resetbanquet_stage()
		{
			this.banquet_stageSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "timesTSWK", DataFormat = DataFormat.TwosComplement)]
		public uint timesTSWK
		{
			get
			{
				return this._timesTSWK ?? 0U;
			}
			set
			{
				this._timesTSWK = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timesTSWKSpecified
		{
			get
			{
				return this._timesTSWK != null;
			}
			set
			{
				bool flag = value == (this._timesTSWK == null);
				if (flag)
				{
					this._timesTSWK = (value ? new uint?(this.timesTSWK) : null);
				}
			}
		}

		private bool ShouldSerializetimesTSWK()
		{
			return this.timesTSWKSpecified;
		}

		private void ResettimesTSWK()
		{
			this.timesTSWKSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _garden_id;

		private uint? _banquet_id;

		private uint? _banquet_stage;

		private uint? _timesTSWK;

		private IExtension extensionObject;
	}
}
