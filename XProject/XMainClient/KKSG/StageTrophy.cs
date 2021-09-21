using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F2 RID: 1522
	[ProtoContract(Name = "StageTrophy")]
	[Serializable]
	public class StageTrophy : IExtensible
	{
		// Token: 0x17001C48 RID: 7240
		// (get) Token: 0x06005A79 RID: 23161 RVA: 0x000AC3F0 File Offset: 0x000AA5F0
		[ProtoMember(1, Name = "trophydata", DataFormat = DataFormat.Default)]
		public List<StageTrophyData> trophydata
		{
			get
			{
				return this._trophydata;
			}
		}

		// Token: 0x17001C49 RID: 7241
		// (get) Token: 0x06005A7A RID: 23162 RVA: 0x000AC408 File Offset: 0x000AA608
		// (set) Token: 0x06005A7B RID: 23163 RVA: 0x000AC435 File Offset: 0x000AA635
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

		// Token: 0x17001C4A RID: 7242
		// (get) Token: 0x06005A7C RID: 23164 RVA: 0x000AC444 File Offset: 0x000AA644
		// (set) Token: 0x06005A7D RID: 23165 RVA: 0x000AC464 File Offset: 0x000AA664
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

		// Token: 0x06005A7E RID: 23166 RVA: 0x000AC4A8 File Offset: 0x000AA6A8
		private bool ShouldSerializetotal_score()
		{
			return this.total_scoreSpecified;
		}

		// Token: 0x06005A7F RID: 23167 RVA: 0x000AC4C0 File Offset: 0x000AA6C0
		private void Resettotal_score()
		{
			this.total_scoreSpecified = false;
		}

		// Token: 0x17001C4B RID: 7243
		// (get) Token: 0x06005A80 RID: 23168 RVA: 0x000AC4CC File Offset: 0x000AA6CC
		// (set) Token: 0x06005A81 RID: 23169 RVA: 0x000AC4F8 File Offset: 0x000AA6F8
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

		// Token: 0x17001C4C RID: 7244
		// (get) Token: 0x06005A82 RID: 23170 RVA: 0x000AC508 File Offset: 0x000AA708
		// (set) Token: 0x06005A83 RID: 23171 RVA: 0x000AC528 File Offset: 0x000AA728
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

		// Token: 0x06005A84 RID: 23172 RVA: 0x000AC56C File Offset: 0x000AA76C
		private bool ShouldSerializehonour_rank()
		{
			return this.honour_rankSpecified;
		}

		// Token: 0x06005A85 RID: 23173 RVA: 0x000AC584 File Offset: 0x000AA784
		private void Resethonour_rank()
		{
			this.honour_rankSpecified = false;
		}

		// Token: 0x06005A86 RID: 23174 RVA: 0x000AC590 File Offset: 0x000AA790
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001604 RID: 5636
		private readonly List<StageTrophyData> _trophydata = new List<StageTrophyData>();

		// Token: 0x04001605 RID: 5637
		private ulong? _total_score;

		// Token: 0x04001606 RID: 5638
		private uint? _honour_rank;

		// Token: 0x04001607 RID: 5639
		private IExtension extensionObject;
	}
}
