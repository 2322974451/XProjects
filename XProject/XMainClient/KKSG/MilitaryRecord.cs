using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MilitaryRecord")]
	[Serializable]
	public class MilitaryRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank
		{
			get
			{
				return this._military_rank ?? 0U;
			}
			set
			{
				this._military_rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool military_rankSpecified
		{
			get
			{
				return this._military_rank != null;
			}
			set
			{
				bool flag = value == (this._military_rank == null);
				if (flag)
				{
					this._military_rank = (value ? new uint?(this.military_rank) : null);
				}
			}
		}

		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "military_rank_his", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank_his
		{
			get
			{
				return this._military_rank_his ?? 0U;
			}
			set
			{
				this._military_rank_his = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool military_rank_hisSpecified
		{
			get
			{
				return this._military_rank_his != null;
			}
			set
			{
				bool flag = value == (this._military_rank_his == null);
				if (flag)
				{
					this._military_rank_his = (value ? new uint?(this.military_rank_his) : null);
				}
			}
		}

		private bool ShouldSerializemilitary_rank_his()
		{
			return this.military_rank_hisSpecified;
		}

		private void Resetmilitary_rank_his()
		{
			this.military_rank_hisSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "military_exploit", DataFormat = DataFormat.TwosComplement)]
		public uint military_exploit
		{
			get
			{
				return this._military_exploit ?? 0U;
			}
			set
			{
				this._military_exploit = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool military_exploitSpecified
		{
			get
			{
				return this._military_exploit != null;
			}
			set
			{
				bool flag = value == (this._military_exploit == null);
				if (flag)
				{
					this._military_exploit = (value ? new uint?(this.military_exploit) : null);
				}
			}
		}

		private bool ShouldSerializemilitary_exploit()
		{
			return this.military_exploitSpecified;
		}

		private void Resetmilitary_exploit()
		{
			this.military_exploitSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "military_exploit_his", DataFormat = DataFormat.TwosComplement)]
		public uint military_exploit_his
		{
			get
			{
				return this._military_exploit_his ?? 0U;
			}
			set
			{
				this._military_exploit_his = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool military_exploit_hisSpecified
		{
			get
			{
				return this._military_exploit_his != null;
			}
			set
			{
				bool flag = value == (this._military_exploit_his == null);
				if (flag)
				{
					this._military_exploit_his = (value ? new uint?(this.military_exploit_his) : null);
				}
			}
		}

		private bool ShouldSerializemilitary_exploit_his()
		{
			return this.military_exploit_hisSpecified;
		}

		private void Resetmilitary_exploit_his()
		{
			this.military_exploit_hisSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, Name = "achieve_rank", DataFormat = DataFormat.TwosComplement)]
		public List<uint> achieve_rank
		{
			get
			{
				return this._achieve_rank;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _military_rank;

		private uint? _military_rank_his;

		private uint? _military_exploit;

		private uint? _military_exploit_his;

		private uint? _last_update_time;

		private readonly List<uint> _achieve_rank = new List<uint>();

		private IExtension extensionObject;
	}
}
