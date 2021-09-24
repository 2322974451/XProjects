using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BRRankState")]
	[Serializable]
	public class BRRankState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "confid", DataFormat = DataFormat.TwosComplement)]
		public int confid
		{
			get
			{
				return this._confid ?? 0;
			}
			set
			{
				this._confid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool confidSpecified
		{
			get
			{
				return this._confid != null;
			}
			set
			{
				bool flag = value == (this._confid == null);
				if (flag)
				{
					this._confid = (value ? new int?(this.confid) : null);
				}
			}
		}

		private bool ShouldSerializeconfid()
		{
			return this.confidSpecified;
		}

		private void Resetconfid()
		{
			this.confidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "brbid1", DataFormat = DataFormat.TwosComplement)]
		public int brbid1
		{
			get
			{
				return this._brbid1 ?? 0;
			}
			set
			{
				this._brbid1 = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool brbid1Specified
		{
			get
			{
				return this._brbid1 != null;
			}
			set
			{
				bool flag = value == (this._brbid1 == null);
				if (flag)
				{
					this._brbid1 = (value ? new int?(this.brbid1) : null);
				}
			}
		}

		private bool ShouldSerializebrbid1()
		{
			return this.brbid1Specified;
		}

		private void Resetbrbid1()
		{
			this.brbid1Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "brbid2", DataFormat = DataFormat.TwosComplement)]
		public int brbid2
		{
			get
			{
				return this._brbid2 ?? 0;
			}
			set
			{
				this._brbid2 = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool brbid2Specified
		{
			get
			{
				return this._brbid2 != null;
			}
			set
			{
				bool flag = value == (this._brbid2 == null);
				if (flag)
				{
					this._brbid2 = (value ? new int?(this.brbid2) : null);
				}
			}
		}

		private bool ShouldSerializebrbid2()
		{
			return this.brbid2Specified;
		}

		private void Resetbrbid2()
		{
			this.brbid2Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _confid;

		private int? _brbid1;

		private int? _brbid2;

		private int? _rank;

		private IExtension extensionObject;
	}
}
