using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetPartnerDetailInfoRes")]
	[Serializable]
	public class GetPartnerDetailInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "members", DataFormat = DataFormat.Default)]
		public List<PartnerMemberDetail> members
		{
			get
			{
				return this._members;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "shop_redpoint", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "liveness_redpoint", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "partnerid", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<PartnerMemberDetail> _members = new List<PartnerMemberDetail>();

		private bool? _shop_redpoint;

		private bool? _liveness_redpoint;

		private uint? _degree;

		private uint? _level;

		private ulong? _partnerid;

		private IExtension extensionObject;
	}
}
