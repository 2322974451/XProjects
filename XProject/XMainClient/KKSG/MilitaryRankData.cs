using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200058B RID: 1419
	[ProtoContract(Name = "MilitaryRankData")]
	[Serializable]
	public class MilitaryRankData : IExtensible
	{
		// Token: 0x17001713 RID: 5907
		// (get) Token: 0x06004B03 RID: 19203 RVA: 0x0008EA20 File Offset: 0x0008CC20
		// (set) Token: 0x06004B04 RID: 19204 RVA: 0x0008EA4C File Offset: 0x0008CC4C
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

		// Token: 0x17001714 RID: 5908
		// (get) Token: 0x06004B05 RID: 19205 RVA: 0x0008EA5C File Offset: 0x0008CC5C
		// (set) Token: 0x06004B06 RID: 19206 RVA: 0x0008EA7C File Offset: 0x0008CC7C
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

		// Token: 0x06004B07 RID: 19207 RVA: 0x0008EAC0 File Offset: 0x0008CCC0
		private bool ShouldSerializemilitary_exploit()
		{
			return this.military_exploitSpecified;
		}

		// Token: 0x06004B08 RID: 19208 RVA: 0x0008EAD8 File Offset: 0x0008CCD8
		private void Resetmilitary_exploit()
		{
			this.military_exploitSpecified = false;
		}

		// Token: 0x17001715 RID: 5909
		// (get) Token: 0x06004B09 RID: 19209 RVA: 0x0008EAE4 File Offset: 0x0008CCE4
		// (set) Token: 0x06004B0A RID: 19210 RVA: 0x0008EB10 File Offset: 0x0008CD10
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

		// Token: 0x17001716 RID: 5910
		// (get) Token: 0x06004B0B RID: 19211 RVA: 0x0008EB20 File Offset: 0x0008CD20
		// (set) Token: 0x06004B0C RID: 19212 RVA: 0x0008EB40 File Offset: 0x0008CD40
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

		// Token: 0x06004B0D RID: 19213 RVA: 0x0008EB84 File Offset: 0x0008CD84
		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		// Token: 0x06004B0E RID: 19214 RVA: 0x0008EB9C File Offset: 0x0008CD9C
		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		// Token: 0x17001717 RID: 5911
		// (get) Token: 0x06004B0F RID: 19215 RVA: 0x0008EBA8 File Offset: 0x0008CDA8
		// (set) Token: 0x06004B10 RID: 19216 RVA: 0x0008EBD4 File Offset: 0x0008CDD4
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

		// Token: 0x17001718 RID: 5912
		// (get) Token: 0x06004B11 RID: 19217 RVA: 0x0008EBE4 File Offset: 0x0008CDE4
		// (set) Token: 0x06004B12 RID: 19218 RVA: 0x0008EC04 File Offset: 0x0008CE04
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

		// Token: 0x06004B13 RID: 19219 RVA: 0x0008EC48 File Offset: 0x0008CE48
		private bool ShouldSerializetotal_num()
		{
			return this.total_numSpecified;
		}

		// Token: 0x06004B14 RID: 19220 RVA: 0x0008EC60 File Offset: 0x0008CE60
		private void Resettotal_num()
		{
			this.total_numSpecified = false;
		}

		// Token: 0x06004B15 RID: 19221 RVA: 0x0008EC6C File Offset: 0x0008CE6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012A9 RID: 4777
		private uint? _military_exploit;

		// Token: 0x040012AA RID: 4778
		private uint? _military_rank;

		// Token: 0x040012AB RID: 4779
		private uint? _total_num;

		// Token: 0x040012AC RID: 4780
		private IExtension extensionObject;
	}
}
