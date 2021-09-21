using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D8 RID: 1752
	[ProtoContract(Name = "OneMentorApplyMasterShow")]
	[Serializable]
	public class OneMentorApplyMasterShow : IExtensible
	{
		// Token: 0x170024DD RID: 9437
		// (get) Token: 0x0600746E RID: 29806 RVA: 0x000DEC68 File Offset: 0x000DCE68
		// (set) Token: 0x0600746F RID: 29807 RVA: 0x000DEC80 File Offset: 0x000DCE80
		[ProtoMember(1, IsRequired = false, Name = "oneMaster", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo oneMaster
		{
			get
			{
				return this._oneMaster;
			}
			set
			{
				this._oneMaster = value;
			}
		}

		// Token: 0x170024DE RID: 9438
		// (get) Token: 0x06007470 RID: 29808 RVA: 0x000DEC8C File Offset: 0x000DCE8C
		// (set) Token: 0x06007471 RID: 29809 RVA: 0x000DECB9 File Offset: 0x000DCEB9
		[ProtoMember(2, IsRequired = false, Name = "audioID", DataFormat = DataFormat.TwosComplement)]
		public ulong audioID
		{
			get
			{
				return this._audioID ?? 0UL;
			}
			set
			{
				this._audioID = new ulong?(value);
			}
		}

		// Token: 0x170024DF RID: 9439
		// (get) Token: 0x06007472 RID: 29810 RVA: 0x000DECC8 File Offset: 0x000DCEC8
		// (set) Token: 0x06007473 RID: 29811 RVA: 0x000DECE8 File Offset: 0x000DCEE8
		[XmlIgnore]
		[Browsable(false)]
		public bool audioIDSpecified
		{
			get
			{
				return this._audioID != null;
			}
			set
			{
				bool flag = value == (this._audioID == null);
				if (flag)
				{
					this._audioID = (value ? new ulong?(this.audioID) : null);
				}
			}
		}

		// Token: 0x06007474 RID: 29812 RVA: 0x000DED2C File Offset: 0x000DCF2C
		private bool ShouldSerializeaudioID()
		{
			return this.audioIDSpecified;
		}

		// Token: 0x06007475 RID: 29813 RVA: 0x000DED44 File Offset: 0x000DCF44
		private void ResetaudioID()
		{
			this.audioIDSpecified = false;
		}

		// Token: 0x170024E0 RID: 9440
		// (get) Token: 0x06007476 RID: 29814 RVA: 0x000DED50 File Offset: 0x000DCF50
		// (set) Token: 0x06007477 RID: 29815 RVA: 0x000DED71 File Offset: 0x000DCF71
		[ProtoMember(3, IsRequired = false, Name = "applyWords", DataFormat = DataFormat.Default)]
		public string applyWords
		{
			get
			{
				return this._applyWords ?? "";
			}
			set
			{
				this._applyWords = value;
			}
		}

		// Token: 0x170024E1 RID: 9441
		// (get) Token: 0x06007478 RID: 29816 RVA: 0x000DED7C File Offset: 0x000DCF7C
		// (set) Token: 0x06007479 RID: 29817 RVA: 0x000DED98 File Offset: 0x000DCF98
		[XmlIgnore]
		[Browsable(false)]
		public bool applyWordsSpecified
		{
			get
			{
				return this._applyWords != null;
			}
			set
			{
				bool flag = value == (this._applyWords == null);
				if (flag)
				{
					this._applyWords = (value ? this.applyWords : null);
				}
			}
		}

		// Token: 0x0600747A RID: 29818 RVA: 0x000DEDC8 File Offset: 0x000DCFC8
		private bool ShouldSerializeapplyWords()
		{
			return this.applyWordsSpecified;
		}

		// Token: 0x0600747B RID: 29819 RVA: 0x000DEDE0 File Offset: 0x000DCFE0
		private void ResetapplyWords()
		{
			this.applyWordsSpecified = false;
		}

		// Token: 0x170024E2 RID: 9442
		// (get) Token: 0x0600747C RID: 29820 RVA: 0x000DEDEC File Offset: 0x000DCFEC
		// (set) Token: 0x0600747D RID: 29821 RVA: 0x000DEE18 File Offset: 0x000DD018
		[ProtoMember(4, IsRequired = false, Name = "hasApply", DataFormat = DataFormat.Default)]
		public bool hasApply
		{
			get
			{
				return this._hasApply ?? false;
			}
			set
			{
				this._hasApply = new bool?(value);
			}
		}

		// Token: 0x170024E3 RID: 9443
		// (get) Token: 0x0600747E RID: 29822 RVA: 0x000DEE28 File Offset: 0x000DD028
		// (set) Token: 0x0600747F RID: 29823 RVA: 0x000DEE48 File Offset: 0x000DD048
		[XmlIgnore]
		[Browsable(false)]
		public bool hasApplySpecified
		{
			get
			{
				return this._hasApply != null;
			}
			set
			{
				bool flag = value == (this._hasApply == null);
				if (flag)
				{
					this._hasApply = (value ? new bool?(this.hasApply) : null);
				}
			}
		}

		// Token: 0x06007480 RID: 29824 RVA: 0x000DEE8C File Offset: 0x000DD08C
		private bool ShouldSerializehasApply()
		{
			return this.hasApplySpecified;
		}

		// Token: 0x06007481 RID: 29825 RVA: 0x000DEEA4 File Offset: 0x000DD0A4
		private void ResethasApply()
		{
			this.hasApplySpecified = false;
		}

		// Token: 0x06007482 RID: 29826 RVA: 0x000DEEB0 File Offset: 0x000DD0B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BAA RID: 7082
		private RoleBriefInfo _oneMaster = null;

		// Token: 0x04001BAB RID: 7083
		private ulong? _audioID;

		// Token: 0x04001BAC RID: 7084
		private string _applyWords;

		// Token: 0x04001BAD RID: 7085
		private bool? _hasApply;

		// Token: 0x04001BAE RID: 7086
		private IExtension extensionObject;
	}
}
