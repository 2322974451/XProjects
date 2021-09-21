using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000516 RID: 1302
	[ProtoContract(Name = "TaskRefreshNtf")]
	[Serializable]
	public class TaskRefreshNtf : IExtensible
	{
		// Token: 0x17001477 RID: 5239
		// (get) Token: 0x060042F1 RID: 17137 RVA: 0x0007F5F8 File Offset: 0x0007D7F8
		// (set) Token: 0x060042F2 RID: 17138 RVA: 0x0007F624 File Offset: 0x0007D824
		[ProtoMember(1, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x17001478 RID: 5240
		// (get) Token: 0x060042F3 RID: 17139 RVA: 0x0007F634 File Offset: 0x0007D834
		// (set) Token: 0x060042F4 RID: 17140 RVA: 0x0007F654 File Offset: 0x0007D854
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x060042F5 RID: 17141 RVA: 0x0007F698 File Offset: 0x0007D898
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x060042F6 RID: 17142 RVA: 0x0007F6B0 File Offset: 0x0007D8B0
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17001479 RID: 5241
		// (get) Token: 0x060042F7 RID: 17143 RVA: 0x0007F6BC File Offset: 0x0007D8BC
		// (set) Token: 0x060042F8 RID: 17144 RVA: 0x0007F6E8 File Offset: 0x0007D8E8
		[ProtoMember(2, IsRequired = false, Name = "remain_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint remain_refresh_count
		{
			get
			{
				return this._remain_refresh_count ?? 0U;
			}
			set
			{
				this._remain_refresh_count = new uint?(value);
			}
		}

		// Token: 0x1700147A RID: 5242
		// (get) Token: 0x060042F9 RID: 17145 RVA: 0x0007F6F8 File Offset: 0x0007D8F8
		// (set) Token: 0x060042FA RID: 17146 RVA: 0x0007F718 File Offset: 0x0007D918
		[XmlIgnore]
		[Browsable(false)]
		public bool remain_refresh_countSpecified
		{
			get
			{
				return this._remain_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._remain_refresh_count == null);
				if (flag)
				{
					this._remain_refresh_count = (value ? new uint?(this.remain_refresh_count) : null);
				}
			}
		}

		// Token: 0x060042FB RID: 17147 RVA: 0x0007F75C File Offset: 0x0007D95C
		private bool ShouldSerializeremain_refresh_count()
		{
			return this.remain_refresh_countSpecified;
		}

		// Token: 0x060042FC RID: 17148 RVA: 0x0007F774 File Offset: 0x0007D974
		private void Resetremain_refresh_count()
		{
			this.remain_refresh_countSpecified = false;
		}

		// Token: 0x060042FD RID: 17149 RVA: 0x0007F780 File Offset: 0x0007D980
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010B2 RID: 4274
		private uint? _score;

		// Token: 0x040010B3 RID: 4275
		private uint? _remain_refresh_count;

		// Token: 0x040010B4 RID: 4276
		private IExtension extensionObject;
	}
}
