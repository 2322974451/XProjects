using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001DF RID: 479
	[ProtoContract(Name = "FirstPassRewardNtfData")]
	[Serializable]
	public class FirstPassRewardNtfData : IExtensible
	{
		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x06001B93 RID: 7059 RVA: 0x00036740 File Offset: 0x00034940
		// (set) Token: 0x06001B94 RID: 7060 RVA: 0x0003676C File Offset: 0x0003496C
		[ProtoMember(1, IsRequired = false, Name = "hasFirstPassReward", DataFormat = DataFormat.Default)]
		public bool hasFirstPassReward
		{
			get
			{
				return this._hasFirstPassReward ?? false;
			}
			set
			{
				this._hasFirstPassReward = new bool?(value);
			}
		}

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x06001B95 RID: 7061 RVA: 0x0003677C File Offset: 0x0003497C
		// (set) Token: 0x06001B96 RID: 7062 RVA: 0x0003679C File Offset: 0x0003499C
		[XmlIgnore]
		[Browsable(false)]
		public bool hasFirstPassRewardSpecified
		{
			get
			{
				return this._hasFirstPassReward != null;
			}
			set
			{
				bool flag = value == (this._hasFirstPassReward == null);
				if (flag)
				{
					this._hasFirstPassReward = (value ? new bool?(this.hasFirstPassReward) : null);
				}
			}
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x000367E0 File Offset: 0x000349E0
		private bool ShouldSerializehasFirstPassReward()
		{
			return this.hasFirstPassRewardSpecified;
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x000367F8 File Offset: 0x000349F8
		private void ResethasFirstPassReward()
		{
			this.hasFirstPassRewardSpecified = false;
		}

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x06001B99 RID: 7065 RVA: 0x00036804 File Offset: 0x00034A04
		// (set) Token: 0x06001B9A RID: 7066 RVA: 0x00036830 File Offset: 0x00034A30
		[ProtoMember(2, IsRequired = false, Name = "hasCommendReward", DataFormat = DataFormat.Default)]
		public bool hasCommendReward
		{
			get
			{
				return this._hasCommendReward ?? false;
			}
			set
			{
				this._hasCommendReward = new bool?(value);
			}
		}

		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x06001B9B RID: 7067 RVA: 0x00036840 File Offset: 0x00034A40
		// (set) Token: 0x06001B9C RID: 7068 RVA: 0x00036860 File Offset: 0x00034A60
		[XmlIgnore]
		[Browsable(false)]
		public bool hasCommendRewardSpecified
		{
			get
			{
				return this._hasCommendReward != null;
			}
			set
			{
				bool flag = value == (this._hasCommendReward == null);
				if (flag)
				{
					this._hasCommendReward = (value ? new bool?(this.hasCommendReward) : null);
				}
			}
		}

		// Token: 0x06001B9D RID: 7069 RVA: 0x000368A4 File Offset: 0x00034AA4
		private bool ShouldSerializehasCommendReward()
		{
			return this.hasCommendRewardSpecified;
		}

		// Token: 0x06001B9E RID: 7070 RVA: 0x000368BC File Offset: 0x00034ABC
		private void ResethasCommendReward()
		{
			this.hasCommendRewardSpecified = false;
		}

		// Token: 0x06001B9F RID: 7071 RVA: 0x000368C8 File Offset: 0x00034AC8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006DF RID: 1759
		private bool? _hasFirstPassReward;

		// Token: 0x040006E0 RID: 1760
		private bool? _hasCommendReward;

		// Token: 0x040006E1 RID: 1761
		private IExtension extensionObject;
	}
}
