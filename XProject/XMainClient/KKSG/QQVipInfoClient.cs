using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QQVipInfoClient")]
	[Serializable]
	public class QQVipInfoClient : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "qq_vip_end", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "qq_svip_end", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "is_bigger_one_month", DataFormat = DataFormat.Default)]
		public bool is_bigger_one_month
		{
			get
			{
				return this._is_bigger_one_month ?? false;
			}
			set
			{
				this._is_bigger_one_month = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_bigger_one_monthSpecified
		{
			get
			{
				return this._is_bigger_one_month != null;
			}
			set
			{
				bool flag = value == (this._is_bigger_one_month == null);
				if (flag)
				{
					this._is_bigger_one_month = (value ? new bool?(this.is_bigger_one_month) : null);
				}
			}
		}

		private bool ShouldSerializeis_bigger_one_month()
		{
			return this.is_bigger_one_monthSpecified;
		}

		private void Resetis_bigger_one_month()
		{
			this.is_bigger_one_monthSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _is_vip;

		private bool? _is_svip;

		private uint? _qq_vip_end;

		private uint? _qq_svip_end;

		private bool? _is_bigger_one_month;

		private IExtension extensionObject;
	}
}
