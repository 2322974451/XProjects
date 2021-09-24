using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DERankRes")]
	[Serializable]
	public class DERankRes : IExtensible
	{

		[ProtoMember(1, Name = "ranks", DataFormat = DataFormat.Default)]
		public List<DERank> ranks
		{
			get
			{
				return this._ranks;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "rewardlefttime", DataFormat = DataFormat.TwosComplement)]
		public uint rewardlefttime
		{
			get
			{
				return this._rewardlefttime ?? 0U;
			}
			set
			{
				this._rewardlefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardlefttimeSpecified
		{
			get
			{
				return this._rewardlefttime != null;
			}
			set
			{
				bool flag = value == (this._rewardlefttime == null);
				if (flag)
				{
					this._rewardlefttime = (value ? new uint?(this.rewardlefttime) : null);
				}
			}
		}

		private bool ShouldSerializerewardlefttime()
		{
			return this.rewardlefttimeSpecified;
		}

		private void Resetrewardlefttime()
		{
			this.rewardlefttimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<DERank> _ranks = new List<DERank>();

		private uint? _rewardlefttime;

		private ErrorCode? _errcode;

		private IExtension extensionObject;
	}
}
