using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RankOnce")]
	[Serializable]
	public class RankOnce : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "season", DataFormat = DataFormat.TwosComplement)]
		public uint season
		{
			get
			{
				return this._season ?? 0U;
			}
			set
			{
				this._season = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool seasonSpecified
		{
			get
			{
				return this._season != null;
			}
			set
			{
				bool flag = value == (this._season == null);
				if (flag)
				{
					this._season = (value ? new uint?(this.season) : null);
				}
			}
		}

		private bool ShouldSerializeseason()
		{
			return this.seasonSpecified;
		}

		private void Resetseason()
		{
			this.seasonSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
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
					this._rank = (value ? new uint?(this.rank) : null);
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

		private uint? _season;

		private uint? _rank;

		private IExtension extensionObject;
	}
}
