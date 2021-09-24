using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryLotteryCDRes")]
	[Serializable]
	public class QueryLotteryCDRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public uint cooldown
		{
			get
			{
				return this._cooldown ?? 0U;
			}
			set
			{
				this._cooldown = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooldownSpecified
		{
			get
			{
				return this._cooldown != null;
			}
			set
			{
				bool flag = value == (this._cooldown == null);
				if (flag)
				{
					this._cooldown = (value ? new uint?(this.cooldown) : null);
				}
			}
		}

		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "goldbuycount", DataFormat = DataFormat.TwosComplement)]
		public uint goldbuycount
		{
			get
			{
				return this._goldbuycount ?? 0U;
			}
			set
			{
				this._goldbuycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldbuycountSpecified
		{
			get
			{
				return this._goldbuycount != null;
			}
			set
			{
				bool flag = value == (this._goldbuycount == null);
				if (flag)
				{
					this._goldbuycount = (value ? new uint?(this.goldbuycount) : null);
				}
			}
		}

		private bool ShouldSerializegoldbuycount()
		{
			return this.goldbuycountSpecified;
		}

		private void Resetgoldbuycount()
		{
			this.goldbuycountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "goldbuycooldown", DataFormat = DataFormat.TwosComplement)]
		public uint goldbuycooldown
		{
			get
			{
				return this._goldbuycooldown ?? 0U;
			}
			set
			{
				this._goldbuycooldown = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldbuycooldownSpecified
		{
			get
			{
				return this._goldbuycooldown != null;
			}
			set
			{
				bool flag = value == (this._goldbuycooldown == null);
				if (flag)
				{
					this._goldbuycooldown = (value ? new uint?(this.goldbuycooldown) : null);
				}
			}
		}

		private bool ShouldSerializegoldbuycooldown()
		{
			return this.goldbuycooldownSpecified;
		}

		private void Resetgoldbuycooldown()
		{
			this.goldbuycooldownSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "goldbaodi", DataFormat = DataFormat.TwosComplement)]
		public uint goldbaodi
		{
			get
			{
				return this._goldbaodi ?? 0U;
			}
			set
			{
				this._goldbaodi = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldbaodiSpecified
		{
			get
			{
				return this._goldbaodi != null;
			}
			set
			{
				bool flag = value == (this._goldbaodi == null);
				if (flag)
				{
					this._goldbaodi = (value ? new uint?(this.goldbaodi) : null);
				}
			}
		}

		private bool ShouldSerializegoldbaodi()
		{
			return this.goldbaodiSpecified;
		}

		private void Resetgoldbaodi()
		{
			this.goldbaodiSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "coinbaodi", DataFormat = DataFormat.TwosComplement)]
		public uint coinbaodi
		{
			get
			{
				return this._coinbaodi ?? 0U;
			}
			set
			{
				this._coinbaodi = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool coinbaodiSpecified
		{
			get
			{
				return this._coinbaodi != null;
			}
			set
			{
				bool flag = value == (this._coinbaodi == null);
				if (flag)
				{
					this._coinbaodi = (value ? new uint?(this.coinbaodi) : null);
				}
			}
		}

		private bool ShouldSerializecoinbaodi()
		{
			return this.coinbaodiSpecified;
		}

		private void Resetcoinbaodi()
		{
			this.coinbaodiSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _cooldown;

		private uint? _goldbuycount;

		private uint? _goldbuycooldown;

		private uint? _goldbaodi;

		private uint? _coinbaodi;

		private IExtension extensionObject;
	}
}
