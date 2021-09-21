using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200046A RID: 1130
	[ProtoContract(Name = "AncientTimesRes")]
	[Serializable]
	public class AncientTimesRes : IExtensible
	{
		// Token: 0x17001223 RID: 4643
		// (get) Token: 0x06003B2D RID: 15149 RVA: 0x000711B8 File Offset: 0x0006F3B8
		// (set) Token: 0x06003B2E RID: 15150 RVA: 0x000711E4 File Offset: 0x0006F3E4
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17001224 RID: 4644
		// (get) Token: 0x06003B2F RID: 15151 RVA: 0x000711F4 File Offset: 0x0006F3F4
		// (set) Token: 0x06003B30 RID: 15152 RVA: 0x00071214 File Offset: 0x0006F414
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06003B31 RID: 15153 RVA: 0x00071258 File Offset: 0x0006F458
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06003B32 RID: 15154 RVA: 0x00071270 File Offset: 0x0006F470
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17001225 RID: 4645
		// (get) Token: 0x06003B33 RID: 15155 RVA: 0x0007127C File Offset: 0x0006F47C
		// (set) Token: 0x06003B34 RID: 15156 RVA: 0x000712A8 File Offset: 0x0006F4A8
		[ProtoMember(2, IsRequired = false, Name = "reward", DataFormat = DataFormat.TwosComplement)]
		public uint reward
		{
			get
			{
				return this._reward ?? 0U;
			}
			set
			{
				this._reward = new uint?(value);
			}
		}

		// Token: 0x17001226 RID: 4646
		// (get) Token: 0x06003B35 RID: 15157 RVA: 0x000712B8 File Offset: 0x0006F4B8
		// (set) Token: 0x06003B36 RID: 15158 RVA: 0x000712D8 File Offset: 0x0006F4D8
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardSpecified
		{
			get
			{
				return this._reward != null;
			}
			set
			{
				bool flag = value == (this._reward == null);
				if (flag)
				{
					this._reward = (value ? new uint?(this.reward) : null);
				}
			}
		}

		// Token: 0x06003B37 RID: 15159 RVA: 0x0007131C File Offset: 0x0006F51C
		private bool ShouldSerializereward()
		{
			return this.rewardSpecified;
		}

		// Token: 0x06003B38 RID: 15160 RVA: 0x00071334 File Offset: 0x0006F534
		private void Resetreward()
		{
			this.rewardSpecified = false;
		}

		// Token: 0x06003B39 RID: 15161 RVA: 0x00071340 File Offset: 0x0006F540
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EB3 RID: 3763
		private ErrorCode? _error;

		// Token: 0x04000EB4 RID: 3764
		private uint? _reward;

		// Token: 0x04000EB5 RID: 3765
		private IExtension extensionObject;
	}
}
