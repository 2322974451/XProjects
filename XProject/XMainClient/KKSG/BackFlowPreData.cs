using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000650 RID: 1616
	[ProtoContract(Name = "BackFlowPreData")]
	[Serializable]
	public class BackFlowPreData : IExtensible
	{
		// Token: 0x17001FB7 RID: 8119
		// (get) Token: 0x0600648B RID: 25739 RVA: 0x000BFE9C File Offset: 0x000BE09C
		[ProtoMember(1, Name = "isOnline", DataFormat = DataFormat.Default)]
		public List<bool> isOnline
		{
			get
			{
				return this._isOnline;
			}
		}

		// Token: 0x17001FB8 RID: 8120
		// (get) Token: 0x0600648C RID: 25740 RVA: 0x000BFEB4 File Offset: 0x000BE0B4
		// (set) Token: 0x0600648D RID: 25741 RVA: 0x000BFEE0 File Offset: 0x000BE0E0
		[ProtoMember(2, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		// Token: 0x17001FB9 RID: 8121
		// (get) Token: 0x0600648E RID: 25742 RVA: 0x000BFEF0 File Offset: 0x000BE0F0
		// (set) Token: 0x0600648F RID: 25743 RVA: 0x000BFF10 File Offset: 0x000BE110
		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		// Token: 0x06006490 RID: 25744 RVA: 0x000BFF54 File Offset: 0x000BE154
		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		// Token: 0x06006491 RID: 25745 RVA: 0x000BFF6C File Offset: 0x000BE16C
		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		// Token: 0x06006492 RID: 25746 RVA: 0x000BFF78 File Offset: 0x000BE178
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001860 RID: 6240
		private readonly List<bool> _isOnline = new List<bool>();

		// Token: 0x04001861 RID: 6241
		private uint? _lastUpdateTime;

		// Token: 0x04001862 RID: 6242
		private IExtension extensionObject;
	}
}
