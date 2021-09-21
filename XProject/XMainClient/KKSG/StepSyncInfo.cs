using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000135 RID: 309
	[ProtoContract(Name = "StepSyncInfo")]
	[Serializable]
	public class StepSyncInfo : IExtensible
	{
		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x060012E4 RID: 4836 RVA: 0x00026470 File Offset: 0x00024670
		[ProtoMember(1, Name = "DataList", DataFormat = DataFormat.Default)]
		public List<StepSyncData> DataList
		{
			get
			{
				return this._DataList;
			}
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x00026488 File Offset: 0x00024688
		// (set) Token: 0x060012E6 RID: 4838 RVA: 0x000264B4 File Offset: 0x000246B4
		[ProtoMember(2, IsRequired = false, Name = "StepFrame", DataFormat = DataFormat.TwosComplement)]
		public uint StepFrame
		{
			get
			{
				return this._StepFrame ?? 0U;
			}
			set
			{
				this._StepFrame = new uint?(value);
			}
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x000264C4 File Offset: 0x000246C4
		// (set) Token: 0x060012E8 RID: 4840 RVA: 0x000264E4 File Offset: 0x000246E4
		[XmlIgnore]
		[Browsable(false)]
		public bool StepFrameSpecified
		{
			get
			{
				return this._StepFrame != null;
			}
			set
			{
				bool flag = value == (this._StepFrame == null);
				if (flag)
				{
					this._StepFrame = (value ? new uint?(this.StepFrame) : null);
				}
			}
		}

		// Token: 0x060012E9 RID: 4841 RVA: 0x00026528 File Offset: 0x00024728
		private bool ShouldSerializeStepFrame()
		{
			return this.StepFrameSpecified;
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x00026540 File Offset: 0x00024740
		private void ResetStepFrame()
		{
			this.StepFrameSpecified = false;
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x0002654C File Offset: 0x0002474C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004B7 RID: 1207
		private readonly List<StepSyncData> _DataList = new List<StepSyncData>();

		// Token: 0x040004B8 RID: 1208
		private uint? _StepFrame;

		// Token: 0x040004B9 RID: 1209
		private IExtension extensionObject;
	}
}
