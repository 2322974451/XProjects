using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000585 RID: 1413
	[ProtoContract(Name = "ComAgate")]
	[Serializable]
	public class ComAgate : IExtensible
	{
		// Token: 0x1700169B RID: 5787
		// (get) Token: 0x060049A2 RID: 18850 RVA: 0x0008BFAC File Offset: 0x0008A1AC
		// (set) Token: 0x060049A3 RID: 18851 RVA: 0x0008BFD8 File Offset: 0x0008A1D8
		[ProtoMember(1, IsRequired = false, Name = "itemId", DataFormat = DataFormat.TwosComplement)]
		public uint itemId
		{
			get
			{
				return this._itemId ?? 0U;
			}
			set
			{
				this._itemId = new uint?(value);
			}
		}

		// Token: 0x1700169C RID: 5788
		// (get) Token: 0x060049A4 RID: 18852 RVA: 0x0008BFE8 File Offset: 0x0008A1E8
		// (set) Token: 0x060049A5 RID: 18853 RVA: 0x0008C008 File Offset: 0x0008A208
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIdSpecified
		{
			get
			{
				return this._itemId != null;
			}
			set
			{
				bool flag = value == (this._itemId == null);
				if (flag)
				{
					this._itemId = (value ? new uint?(this.itemId) : null);
				}
			}
		}

		// Token: 0x060049A6 RID: 18854 RVA: 0x0008C04C File Offset: 0x0008A24C
		private bool ShouldSerializeitemId()
		{
			return this.itemIdSpecified;
		}

		// Token: 0x060049A7 RID: 18855 RVA: 0x0008C064 File Offset: 0x0008A264
		private void ResetitemId()
		{
			this.itemIdSpecified = false;
		}

		// Token: 0x1700169D RID: 5789
		// (get) Token: 0x060049A8 RID: 18856 RVA: 0x0008C070 File Offset: 0x0008A270
		// (set) Token: 0x060049A9 RID: 18857 RVA: 0x0008C09C File Offset: 0x0008A29C
		[ProtoMember(2, IsRequired = false, Name = "comNum", DataFormat = DataFormat.TwosComplement)]
		public uint comNum
		{
			get
			{
				return this._comNum ?? 0U;
			}
			set
			{
				this._comNum = new uint?(value);
			}
		}

		// Token: 0x1700169E RID: 5790
		// (get) Token: 0x060049AA RID: 18858 RVA: 0x0008C0AC File Offset: 0x0008A2AC
		// (set) Token: 0x060049AB RID: 18859 RVA: 0x0008C0CC File Offset: 0x0008A2CC
		[XmlIgnore]
		[Browsable(false)]
		public bool comNumSpecified
		{
			get
			{
				return this._comNum != null;
			}
			set
			{
				bool flag = value == (this._comNum == null);
				if (flag)
				{
					this._comNum = (value ? new uint?(this.comNum) : null);
				}
			}
		}

		// Token: 0x060049AC RID: 18860 RVA: 0x0008C110 File Offset: 0x0008A310
		private bool ShouldSerializecomNum()
		{
			return this.comNumSpecified;
		}

		// Token: 0x060049AD RID: 18861 RVA: 0x0008C128 File Offset: 0x0008A328
		private void ResetcomNum()
		{
			this.comNumSpecified = false;
		}

		// Token: 0x060049AE RID: 18862 RVA: 0x0008C134 File Offset: 0x0008A334
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001260 RID: 4704
		private uint? _itemId;

		// Token: 0x04001261 RID: 4705
		private uint? _comNum;

		// Token: 0x04001262 RID: 4706
		private IExtension extensionObject;
	}
}
