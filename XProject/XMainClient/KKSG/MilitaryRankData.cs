using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MilitaryRankData")]
	[Serializable]
	public class MilitaryRankData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "military_exploit", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "total_num", DataFormat = DataFormat.TwosComplement)]
		public uint total_num
		{
			get
			{
				return this._total_num ?? 0U;
			}
			set
			{
				this._total_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool total_numSpecified
		{
			get
			{
				return this._total_num != null;
			}
			set
			{
				bool flag = value == (this._total_num == null);
				if (flag)
				{
					this._total_num = (value ? new uint?(this.total_num) : null);
				}
			}
		}

		private bool ShouldSerializetotal_num()
		{
			return this.total_numSpecified;
		}

		private void Resettotal_num()
		{
			this.total_numSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _military_exploit;

		private uint? _military_rank;

		private uint? _total_num;

		private IExtension extensionObject;
	}
}
