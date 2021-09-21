using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200064F RID: 1615
	[ProtoContract(Name = "ArgentaPreData")]
	[Serializable]
	public class ArgentaPreData : IExtensible
	{
		// Token: 0x17001FB3 RID: 8115
		// (get) Token: 0x06006481 RID: 25729 RVA: 0x000BFD74 File Offset: 0x000BDF74
		// (set) Token: 0x06006482 RID: 25730 RVA: 0x000BFDA0 File Offset: 0x000BDFA0
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

		// Token: 0x17001FB4 RID: 8116
		// (get) Token: 0x06006483 RID: 25731 RVA: 0x000BFDB0 File Offset: 0x000BDFB0
		// (set) Token: 0x06006484 RID: 25732 RVA: 0x000BFDD0 File Offset: 0x000BDFD0
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

		// Token: 0x06006485 RID: 25733 RVA: 0x000BFE14 File Offset: 0x000BE014
		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		// Token: 0x06006486 RID: 25734 RVA: 0x000BFE2C File Offset: 0x000BE02C
		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		// Token: 0x17001FB5 RID: 8117
		// (get) Token: 0x06006487 RID: 25735 RVA: 0x000BFE38 File Offset: 0x000BE038
		[ProtoMember(2, Name = "activityPoint", DataFormat = DataFormat.TwosComplement)]
		public List<uint> activityPoint
		{
			get
			{
				return this._activityPoint;
			}
		}

		// Token: 0x17001FB6 RID: 8118
		// (get) Token: 0x06006488 RID: 25736 RVA: 0x000BFE50 File Offset: 0x000BE050
		[ProtoMember(3, Name = "finishNestCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> finishNestCount
		{
			get
			{
				return this._finishNestCount;
			}
		}

		// Token: 0x06006489 RID: 25737 RVA: 0x000BFE68 File Offset: 0x000BE068
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400185C RID: 6236
		private uint? _lastUpdateTime;

		// Token: 0x0400185D RID: 6237
		private readonly List<uint> _activityPoint = new List<uint>();

		// Token: 0x0400185E RID: 6238
		private readonly List<uint> _finishNestCount = new List<uint>();

		// Token: 0x0400185F RID: 6239
		private IExtension extensionObject;
	}
}
