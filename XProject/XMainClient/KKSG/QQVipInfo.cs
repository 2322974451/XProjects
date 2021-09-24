using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QQVipInfo")]
	[Serializable]
	public class QQVipInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "is_vip", DataFormat = DataFormat.Default)]
		public bool is_vip
		{
			get
			{
				return this._is_vip ?? false;
			}
			set
			{
				this._is_vip = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_vipSpecified
		{
			get
			{
				return this._is_vip != null;
			}
			set
			{
				bool flag = value == (this._is_vip == null);
				if (flag)
				{
					this._is_vip = (value ? new bool?(this.is_vip) : null);
				}
			}
		}

		private bool ShouldSerializeis_vip()
		{
			return this.is_vipSpecified;
		}

		private void Resetis_vip()
		{
			this.is_vipSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "is_svip", DataFormat = DataFormat.Default)]
		public bool is_svip
		{
			get
			{
				return this._is_svip ?? false;
			}
			set
			{
				this._is_svip = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_svipSpecified
		{
			get
			{
				return this._is_svip != null;
			}
			set
			{
				bool flag = value == (this._is_svip == null);
				if (flag)
				{
					this._is_svip = (value ? new bool?(this.is_svip) : null);
				}
			}
		}

		private bool ShouldSerializeis_svip()
		{
			return this.is_svipSpecified;
		}

		private void Resetis_svip()
		{
			this.is_svipSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "is_year_vip", DataFormat = DataFormat.Default)]
		public bool is_year_vip
		{
			get
			{
				return this._is_year_vip ?? false;
			}
			set
			{
				this._is_year_vip = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_year_vipSpecified
		{
			get
			{
				return this._is_year_vip != null;
			}
			set
			{
				bool flag = value == (this._is_year_vip == null);
				if (flag)
				{
					this._is_year_vip = (value ? new bool?(this.is_year_vip) : null);
				}
			}
		}

		private bool ShouldSerializeis_year_vip()
		{
			return this.is_year_vipSpecified;
		}

		private void Resetis_year_vip()
		{
			this.is_year_vipSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "qq_vip_start", DataFormat = DataFormat.TwosComplement)]
		public uint qq_vip_start
		{
			get
			{
				return this._qq_vip_start ?? 0U;
			}
			set
			{
				this._qq_vip_start = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qq_vip_startSpecified
		{
			get
			{
				return this._qq_vip_start != null;
			}
			set
			{
				bool flag = value == (this._qq_vip_start == null);
				if (flag)
				{
					this._qq_vip_start = (value ? new uint?(this.qq_vip_start) : null);
				}
			}
		}

		private bool ShouldSerializeqq_vip_start()
		{
			return this.qq_vip_startSpecified;
		}

		private void Resetqq_vip_start()
		{
			this.qq_vip_startSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "qq_vip_end", DataFormat = DataFormat.TwosComplement)]
		public uint qq_vip_end
		{
			get
			{
				return this._qq_vip_end ?? 0U;
			}
			set
			{
				this._qq_vip_end = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qq_vip_endSpecified
		{
			get
			{
				return this._qq_vip_end != null;
			}
			set
			{
				bool flag = value == (this._qq_vip_end == null);
				if (flag)
				{
					this._qq_vip_end = (value ? new uint?(this.qq_vip_end) : null);
				}
			}
		}

		private bool ShouldSerializeqq_vip_end()
		{
			return this.qq_vip_endSpecified;
		}

		private void Resetqq_vip_end()
		{
			this.qq_vip_endSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "qq_svip_start", DataFormat = DataFormat.TwosComplement)]
		public uint qq_svip_start
		{
			get
			{
				return this._qq_svip_start ?? 0U;
			}
			set
			{
				this._qq_svip_start = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qq_svip_startSpecified
		{
			get
			{
				return this._qq_svip_start != null;
			}
			set
			{
				bool flag = value == (this._qq_svip_start == null);
				if (flag)
				{
					this._qq_svip_start = (value ? new uint?(this.qq_svip_start) : null);
				}
			}
		}

		private bool ShouldSerializeqq_svip_start()
		{
			return this.qq_svip_startSpecified;
		}

		private void Resetqq_svip_start()
		{
			this.qq_svip_startSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "qq_svip_end", DataFormat = DataFormat.TwosComplement)]
		public uint qq_svip_end
		{
			get
			{
				return this._qq_svip_end ?? 0U;
			}
			set
			{
				this._qq_svip_end = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qq_svip_endSpecified
		{
			get
			{
				return this._qq_svip_end != null;
			}
			set
			{
				bool flag = value == (this._qq_svip_end == null);
				if (flag)
				{
					this._qq_svip_end = (value ? new uint?(this.qq_svip_end) : null);
				}
			}
		}

		private bool ShouldSerializeqq_svip_end()
		{
			return this.qq_svip_endSpecified;
		}

		private void Resetqq_svip_end()
		{
			this.qq_svip_endSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "qq_year_vip_start", DataFormat = DataFormat.TwosComplement)]
		public uint qq_year_vip_start
		{
			get
			{
				return this._qq_year_vip_start ?? 0U;
			}
			set
			{
				this._qq_year_vip_start = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qq_year_vip_startSpecified
		{
			get
			{
				return this._qq_year_vip_start != null;
			}
			set
			{
				bool flag = value == (this._qq_year_vip_start == null);
				if (flag)
				{
					this._qq_year_vip_start = (value ? new uint?(this.qq_year_vip_start) : null);
				}
			}
		}

		private bool ShouldSerializeqq_year_vip_start()
		{
			return this.qq_year_vip_startSpecified;
		}

		private void Resetqq_year_vip_start()
		{
			this.qq_year_vip_startSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "qq_year_vip_end", DataFormat = DataFormat.TwosComplement)]
		public uint qq_year_vip_end
		{
			get
			{
				return this._qq_year_vip_end ?? 0U;
			}
			set
			{
				this._qq_year_vip_end = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool qq_year_vip_endSpecified
		{
			get
			{
				return this._qq_year_vip_end != null;
			}
			set
			{
				bool flag = value == (this._qq_year_vip_end == null);
				if (flag)
				{
					this._qq_year_vip_end = (value ? new uint?(this.qq_year_vip_end) : null);
				}
			}
		}

		private bool ShouldSerializeqq_year_vip_end()
		{
			return this.qq_year_vip_endSpecified;
		}

		private void Resetqq_year_vip_end()
		{
			this.qq_year_vip_endSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "vip_newbie_rewarded", DataFormat = DataFormat.Default)]
		public bool vip_newbie_rewarded
		{
			get
			{
				return this._vip_newbie_rewarded ?? false;
			}
			set
			{
				this._vip_newbie_rewarded = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vip_newbie_rewardedSpecified
		{
			get
			{
				return this._vip_newbie_rewarded != null;
			}
			set
			{
				bool flag = value == (this._vip_newbie_rewarded == null);
				if (flag)
				{
					this._vip_newbie_rewarded = (value ? new bool?(this.vip_newbie_rewarded) : null);
				}
			}
		}

		private bool ShouldSerializevip_newbie_rewarded()
		{
			return this.vip_newbie_rewardedSpecified;
		}

		private void Resetvip_newbie_rewarded()
		{
			this.vip_newbie_rewardedSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "svip_newbie_rewarded", DataFormat = DataFormat.Default)]
		public bool svip_newbie_rewarded
		{
			get
			{
				return this._svip_newbie_rewarded ?? false;
			}
			set
			{
				this._svip_newbie_rewarded = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool svip_newbie_rewardedSpecified
		{
			get
			{
				return this._svip_newbie_rewarded != null;
			}
			set
			{
				bool flag = value == (this._svip_newbie_rewarded == null);
				if (flag)
				{
					this._svip_newbie_rewarded = (value ? new bool?(this.svip_newbie_rewarded) : null);
				}
			}
		}

		private bool ShouldSerializesvip_newbie_rewarded()
		{
			return this.svip_newbie_rewardedSpecified;
		}

		private void Resetsvip_newbie_rewarded()
		{
			this.svip_newbie_rewardedSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "is_xinyue_vip", DataFormat = DataFormat.Default)]
		public bool is_xinyue_vip
		{
			get
			{
				return this._is_xinyue_vip ?? false;
			}
			set
			{
				this._is_xinyue_vip = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_xinyue_vipSpecified
		{
			get
			{
				return this._is_xinyue_vip != null;
			}
			set
			{
				bool flag = value == (this._is_xinyue_vip == null);
				if (flag)
				{
					this._is_xinyue_vip = (value ? new bool?(this.is_xinyue_vip) : null);
				}
			}
		}

		private bool ShouldSerializeis_xinyue_vip()
		{
			return this.is_xinyue_vipSpecified;
		}

		private void Resetis_xinyue_vip()
		{
			this.is_xinyue_vipSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _is_vip;

		private bool? _is_svip;

		private bool? _is_year_vip;

		private uint? _qq_vip_start;

		private uint? _qq_vip_end;

		private uint? _qq_svip_start;

		private uint? _qq_svip_end;

		private uint? _qq_year_vip_start;

		private uint? _qq_year_vip_end;

		private bool? _vip_newbie_rewarded;

		private bool? _svip_newbie_rewarded;

		private bool? _is_xinyue_vip;

		private IExtension extensionObject;
	}
}
