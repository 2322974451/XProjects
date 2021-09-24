using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkRecordSubInfo")]
	[Serializable]
	public class PkRecordSubInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rewardcount", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcount
		{
			get
			{
				return this._rewardcount ?? 0U;
			}
			set
			{
				this._rewardcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcountSpecified
		{
			get
			{
				return this._rewardcount != null;
			}
			set
			{
				bool flag = value == (this._rewardcount == null);
				if (flag)
				{
					this._rewardcount = (value ? new uint?(this.rewardcount) : null);
				}
			}
		}

		private bool ShouldSerializerewardcount()
		{
			return this.rewardcountSpecified;
		}

		private void Resetrewardcount()
		{
			this.rewardcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "seasondata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist seasondata
		{
			get
			{
				return this._seasondata;
			}
			set
			{
				this._seasondata = value;
			}
		}

		[ProtoMember(4, Name = "recs", DataFormat = DataFormat.Default)]
		public List<PkOneRec> recs
		{
			get
			{
				return this._recs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _point;

		private uint? _rewardcount;

		private PkBaseHist _seasondata = null;

		private readonly List<PkOneRec> _recs = new List<PkOneRec>();

		private IExtension extensionObject;
	}
}
