using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000159 RID: 345
	[ProtoContract(Name = "QARoomRankNtf")]
	[Serializable]
	public class QARoomRankNtf : IExtensible
	{
		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06001522 RID: 5410 RVA: 0x0002A888 File Offset: 0x00028A88
		[ProtoMember(1, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<QARoomRankData> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x06001523 RID: 5411 RVA: 0x0002A8A0 File Offset: 0x00028AA0
		// (set) Token: 0x06001524 RID: 5412 RVA: 0x0002A8CC File Offset: 0x00028ACC
		[ProtoMember(2, IsRequired = false, Name = "myscore", DataFormat = DataFormat.TwosComplement)]
		public uint myscore
		{
			get
			{
				return this._myscore ?? 0U;
			}
			set
			{
				this._myscore = new uint?(value);
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x06001525 RID: 5413 RVA: 0x0002A8DC File Offset: 0x00028ADC
		// (set) Token: 0x06001526 RID: 5414 RVA: 0x0002A8FC File Offset: 0x00028AFC
		[XmlIgnore]
		[Browsable(false)]
		public bool myscoreSpecified
		{
			get
			{
				return this._myscore != null;
			}
			set
			{
				bool flag = value == (this._myscore == null);
				if (flag)
				{
					this._myscore = (value ? new uint?(this.myscore) : null);
				}
			}
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x0002A940 File Offset: 0x00028B40
		private bool ShouldSerializemyscore()
		{
			return this.myscoreSpecified;
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x0002A958 File Offset: 0x00028B58
		private void Resetmyscore()
		{
			this.myscoreSpecified = false;
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x0002A964 File Offset: 0x00028B64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400053E RID: 1342
		private readonly List<QARoomRankData> _dataList = new List<QARoomRankData>();

		// Token: 0x0400053F RID: 1343
		private uint? _myscore;

		// Token: 0x04000540 RID: 1344
		private IExtension extensionObject;
	}
}
