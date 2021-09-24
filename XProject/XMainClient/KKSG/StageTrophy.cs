using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageTrophy")]
	[Serializable]
	public class StageTrophy : IExtensible
	{

		[ProtoMember(1, Name = "trophydata", DataFormat = DataFormat.Default)]
		public List<StageTrophyData> trophydata
		{
			get
			{
				return this._trophydata;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "total_score", DataFormat = DataFormat.TwosComplement)]
		public ulong total_score
		{
			get
			{
				return this._total_score ?? 0UL;
			}
			set
			{
				this._total_score = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool total_scoreSpecified
		{
			get
			{
				return this._total_score != null;
			}
			set
			{
				bool flag = value == (this._total_score == null);
				if (flag)
				{
					this._total_score = (value ? new ulong?(this.total_score) : null);
				}
			}
		}

		private bool ShouldSerializetotal_score()
		{
			return this.total_scoreSpecified;
		}

		private void Resettotal_score()
		{
			this.total_scoreSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "honour_rank", DataFormat = DataFormat.TwosComplement)]
		public uint honour_rank
		{
			get
			{
				return this._honour_rank ?? 0U;
			}
			set
			{
				this._honour_rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool honour_rankSpecified
		{
			get
			{
				return this._honour_rank != null;
			}
			set
			{
				bool flag = value == (this._honour_rank == null);
				if (flag)
				{
					this._honour_rank = (value ? new uint?(this.honour_rank) : null);
				}
			}
		}

		private bool ShouldSerializehonour_rank()
		{
			return this.honour_rankSpecified;
		}

		private void Resethonour_rank()
		{
			this.honour_rankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<StageTrophyData> _trophydata = new List<StageTrophyData>();

		private ulong? _total_score;

		private uint? _honour_rank;

		private IExtension extensionObject;
	}
}
