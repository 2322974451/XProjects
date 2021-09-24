using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPartnerInfoRes")]
	[Serializable]
	public class GetPartnerInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ulong id
		{
			get
			{
				return this._id ?? 0UL;
			}
			set
			{
				this._id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ulong?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, Name = "memberids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> memberids
		{
			get
			{
				return this._memberids;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "last_leave_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_leave_time
		{
			get
			{
				return this._last_leave_time ?? 0U;
			}
			set
			{
				this._last_leave_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool last_leave_timeSpecified
		{
			get
			{
				return this._last_leave_time != null;
			}
			set
			{
				bool flag = value == (this._last_leave_time == null);
				if (flag)
				{
					this._last_leave_time = (value ? new uint?(this.last_leave_time) : null);
				}
			}
		}

		private bool ShouldSerializelast_leave_time()
		{
			return this.last_leave_timeSpecified;
		}

		private void Resetlast_leave_time()
		{
			this.last_leave_timeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "shop_redpoint", DataFormat = DataFormat.Default)]
		public bool shop_redpoint
		{
			get
			{
				return this._shop_redpoint ?? false;
			}
			set
			{
				this._shop_redpoint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool shop_redpointSpecified
		{
			get
			{
				return this._shop_redpoint != null;
			}
			set
			{
				bool flag = value == (this._shop_redpoint == null);
				if (flag)
				{
					this._shop_redpoint = (value ? new bool?(this.shop_redpoint) : null);
				}
			}
		}

		private bool ShouldSerializeshop_redpoint()
		{
			return this.shop_redpointSpecified;
		}

		private void Resetshop_redpoint()
		{
			this.shop_redpointSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "liveness_redpoint", DataFormat = DataFormat.Default)]
		public bool liveness_redpoint
		{
			get
			{
				return this._liveness_redpoint ?? false;
			}
			set
			{
				this._liveness_redpoint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveness_redpointSpecified
		{
			get
			{
				return this._liveness_redpoint != null;
			}
			set
			{
				bool flag = value == (this._liveness_redpoint == null);
				if (flag)
				{
					this._liveness_redpoint = (value ? new bool?(this.liveness_redpoint) : null);
				}
			}
		}

		private bool ShouldSerializeliveness_redpoint()
		{
			return this.liveness_redpointSpecified;
		}

		private void Resetliveness_redpoint()
		{
			this.liveness_redpointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _id;

		private readonly List<ulong> _memberids = new List<ulong>();

		private uint? _degree;

		private uint? _level;

		private uint? _last_leave_time;

		private bool? _shop_redpoint;

		private bool? _liveness_redpoint;

		private IExtension extensionObject;
	}
}
