using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200064E RID: 1614
	[ProtoContract(Name = "ShadowCatData")]
	[Serializable]
	public class ShadowCatData : IExtensible
	{
		// Token: 0x17001FB0 RID: 8112
		// (get) Token: 0x06006478 RID: 25720 RVA: 0x000BFC58 File Offset: 0x000BDE58
		// (set) Token: 0x06006479 RID: 25721 RVA: 0x000BFC84 File Offset: 0x000BDE84
		[ProtoMember(1, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001FB1 RID: 8113
		// (get) Token: 0x0600647A RID: 25722 RVA: 0x000BFC94 File Offset: 0x000BDE94
		// (set) Token: 0x0600647B RID: 25723 RVA: 0x000BFCB4 File Offset: 0x000BDEB4
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

		// Token: 0x0600647C RID: 25724 RVA: 0x000BFCF8 File Offset: 0x000BDEF8
		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		// Token: 0x0600647D RID: 25725 RVA: 0x000BFD10 File Offset: 0x000BDF10
		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		// Token: 0x17001FB2 RID: 8114
		// (get) Token: 0x0600647E RID: 25726 RVA: 0x000BFD1C File Offset: 0x000BDF1C
		[ProtoMember(2, Name = "treasures", DataFormat = DataFormat.TwosComplement)]
		public List<uint> treasures
		{
			get
			{
				return this._treasures;
			}
		}

		// Token: 0x0600647F RID: 25727 RVA: 0x000BFD34 File Offset: 0x000BDF34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001859 RID: 6233
		private uint? _lastUpdateTime;

		// Token: 0x0400185A RID: 6234
		private readonly List<uint> _treasures = new List<uint>();

		// Token: 0x0400185B RID: 6235
		private IExtension extensionObject;
	}
}
