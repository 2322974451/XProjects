using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RolePartnerData")]
	[Serializable]
	public class RolePartnerData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "partnerid", DataFormat = DataFormat.TwosComplement)]
		public ulong partnerid
		{
			get
			{
				return this._partnerid ?? 0UL;
			}
			set
			{
				this._partnerid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool partneridSpecified
		{
			get
			{
				return this._partnerid != null;
			}
			set
			{
				bool flag = value == (this._partnerid == null);
				if (flag)
				{
					this._partnerid = (value ? new ulong?(this.partnerid) : null);
				}
			}
		}

		private bool ShouldSerializepartnerid()
		{
			return this.partneridSpecified;
		}

		private void Resetpartnerid()
		{
			this.partneridSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "last_leave_partner_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_leave_partner_time
		{
			get
			{
				return this._last_leave_partner_time ?? 0U;
			}
			set
			{
				this._last_leave_partner_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_leave_partner_timeSpecified
		{
			get
			{
				return this._last_leave_partner_time != null;
			}
			set
			{
				bool flag = value == (this._last_leave_partner_time == null);
				if (flag)
				{
					this._last_leave_partner_time = (value ? new uint?(this.last_leave_partner_time) : null);
				}
			}
		}

		private bool ShouldSerializelast_leave_partner_time()
		{
			return this.last_leave_partner_timeSpecified;
		}

		private void Resetlast_leave_partner_time()
		{
			this.last_leave_partner_timeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "taked_chest", DataFormat = DataFormat.TwosComplement)]
		public uint taked_chest
		{
			get
			{
				return this._taked_chest ?? 0U;
			}
			set
			{
				this._taked_chest = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool taked_chestSpecified
		{
			get
			{
				return this._taked_chest != null;
			}
			set
			{
				bool flag = value == (this._taked_chest == null);
				if (flag)
				{
					this._taked_chest = (value ? new uint?(this.taked_chest) : null);
				}
			}
		}

		private bool ShouldSerializetaked_chest()
		{
			return this.taked_chestSpecified;
		}

		private void Resettaked_chest()
		{
			this.taked_chestSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "open_shop_time", DataFormat = DataFormat.TwosComplement)]
		public uint open_shop_time
		{
			get
			{
				return this._open_shop_time ?? 0U;
			}
			set
			{
				this._open_shop_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool open_shop_timeSpecified
		{
			get
			{
				return this._open_shop_time != null;
			}
			set
			{
				bool flag = value == (this._open_shop_time == null);
				if (flag)
				{
					this._open_shop_time = (value ? new uint?(this.open_shop_time) : null);
				}
			}
		}

		private bool ShouldSerializeopen_shop_time()
		{
			return this.open_shop_timeSpecified;
		}

		private void Resetopen_shop_time()
		{
			this.open_shop_timeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "apply_leave_time", DataFormat = DataFormat.TwosComplement)]
		public uint apply_leave_time
		{
			get
			{
				return this._apply_leave_time ?? 0U;
			}
			set
			{
				this._apply_leave_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool apply_leave_timeSpecified
		{
			get
			{
				return this._apply_leave_time != null;
			}
			set
			{
				bool flag = value == (this._apply_leave_time == null);
				if (flag)
				{
					this._apply_leave_time = (value ? new uint?(this.apply_leave_time) : null);
				}
			}
		}

		private bool ShouldSerializeapply_leave_time()
		{
			return this.apply_leave_timeSpecified;
		}

		private void Resetapply_leave_time()
		{
			this.apply_leave_timeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "chest_redpoint", DataFormat = DataFormat.Default)]
		public bool chest_redpoint
		{
			get
			{
				return this._chest_redpoint ?? false;
			}
			set
			{
				this._chest_redpoint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chest_redpointSpecified
		{
			get
			{
				return this._chest_redpoint != null;
			}
			set
			{
				bool flag = value == (this._chest_redpoint == null);
				if (flag)
				{
					this._chest_redpoint = (value ? new bool?(this.chest_redpoint) : null);
				}
			}
		}

		private bool ShouldSerializechest_redpoint()
		{
			return this.chest_redpointSpecified;
		}

		private void Resetchest_redpoint()
		{
			this.chest_redpointSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_time
		{
			get
			{
				return this._last_update_time ?? 0U;
			}
			set
			{
				this._last_update_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_timeSpecified
		{
			get
			{
				return this._last_update_time != null;
			}
			set
			{
				bool flag = value == (this._last_update_time == null);
				if (flag)
				{
					this._last_update_time = (value ? new uint?(this.last_update_time) : null);
				}
			}
		}

		private bool ShouldSerializelast_update_time()
		{
			return this.last_update_timeSpecified;
		}

		private void Resetlast_update_time()
		{
			this.last_update_timeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "compenstateTime", DataFormat = DataFormat.TwosComplement)]
		public uint compenstateTime
		{
			get
			{
				return this._compenstateTime ?? 0U;
			}
			set
			{
				this._compenstateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool compenstateTimeSpecified
		{
			get
			{
				return this._compenstateTime != null;
			}
			set
			{
				bool flag = value == (this._compenstateTime == null);
				if (flag)
				{
					this._compenstateTime = (value ? new uint?(this.compenstateTime) : null);
				}
			}
		}

		private bool ShouldSerializecompenstateTime()
		{
			return this.compenstateTimeSpecified;
		}

		private void ResetcompenstateTime()
		{
			this.compenstateTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _partnerid;

		private uint? _last_leave_partner_time;

		private uint? _taked_chest;

		private uint? _open_shop_time;

		private uint? _apply_leave_time;

		private bool? _chest_redpoint;

		private uint? _last_update_time;

		private uint? _compenstateTime;

		private IExtension extensionObject;
	}
}
