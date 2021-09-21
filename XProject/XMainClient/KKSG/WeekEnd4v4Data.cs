using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200066F RID: 1647
	[ProtoContract(Name = "WeekEnd4v4Data")]
	[Serializable]
	public class WeekEnd4v4Data : IExtensible
	{
		// Token: 0x17002126 RID: 8486
		// (get) Token: 0x060068D3 RID: 26835 RVA: 0x000C862C File Offset: 0x000C682C
		// (set) Token: 0x060068D4 RID: 26836 RVA: 0x000C8658 File Offset: 0x000C6858
		[ProtoMember(1, IsRequired = false, Name = "indexWeekEnd", DataFormat = DataFormat.TwosComplement)]
		public uint indexWeekEnd
		{
			get
			{
				return this._indexWeekEnd ?? 0U;
			}
			set
			{
				this._indexWeekEnd = new uint?(value);
			}
		}

		// Token: 0x17002127 RID: 8487
		// (get) Token: 0x060068D5 RID: 26837 RVA: 0x000C8668 File Offset: 0x000C6868
		// (set) Token: 0x060068D6 RID: 26838 RVA: 0x000C8688 File Offset: 0x000C6888
		[XmlIgnore]
		[Browsable(false)]
		public bool indexWeekEndSpecified
		{
			get
			{
				return this._indexWeekEnd != null;
			}
			set
			{
				bool flag = value == (this._indexWeekEnd == null);
				if (flag)
				{
					this._indexWeekEnd = (value ? new uint?(this.indexWeekEnd) : null);
				}
			}
		}

		// Token: 0x060068D7 RID: 26839 RVA: 0x000C86CC File Offset: 0x000C68CC
		private bool ShouldSerializeindexWeekEnd()
		{
			return this.indexWeekEndSpecified;
		}

		// Token: 0x060068D8 RID: 26840 RVA: 0x000C86E4 File Offset: 0x000C68E4
		private void ResetindexWeekEnd()
		{
			this.indexWeekEndSpecified = false;
		}

		// Token: 0x17002128 RID: 8488
		// (get) Token: 0x060068D9 RID: 26841 RVA: 0x000C86F0 File Offset: 0x000C68F0
		// (set) Token: 0x060068DA RID: 26842 RVA: 0x000C871C File Offset: 0x000C691C
		[ProtoMember(2, IsRequired = false, Name = "activityID", DataFormat = DataFormat.TwosComplement)]
		public uint activityID
		{
			get
			{
				return this._activityID ?? 0U;
			}
			set
			{
				this._activityID = new uint?(value);
			}
		}

		// Token: 0x17002129 RID: 8489
		// (get) Token: 0x060068DB RID: 26843 RVA: 0x000C872C File Offset: 0x000C692C
		// (set) Token: 0x060068DC RID: 26844 RVA: 0x000C874C File Offset: 0x000C694C
		[XmlIgnore]
		[Browsable(false)]
		public bool activityIDSpecified
		{
			get
			{
				return this._activityID != null;
			}
			set
			{
				bool flag = value == (this._activityID == null);
				if (flag)
				{
					this._activityID = (value ? new uint?(this.activityID) : null);
				}
			}
		}

		// Token: 0x060068DD RID: 26845 RVA: 0x000C8790 File Offset: 0x000C6990
		private bool ShouldSerializeactivityID()
		{
			return this.activityIDSpecified;
		}

		// Token: 0x060068DE RID: 26846 RVA: 0x000C87A8 File Offset: 0x000C69A8
		private void ResetactivityID()
		{
			this.activityIDSpecified = false;
		}

		// Token: 0x1700212A RID: 8490
		// (get) Token: 0x060068DF RID: 26847 RVA: 0x000C87B4 File Offset: 0x000C69B4
		// (set) Token: 0x060068E0 RID: 26848 RVA: 0x000C87E0 File Offset: 0x000C69E0
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x1700212B RID: 8491
		// (get) Token: 0x060068E1 RID: 26849 RVA: 0x000C87F0 File Offset: 0x000C69F0
		// (set) Token: 0x060068E2 RID: 26850 RVA: 0x000C8810 File Offset: 0x000C6A10
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x060068E3 RID: 26851 RVA: 0x000C8854 File Offset: 0x000C6A54
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060068E4 RID: 26852 RVA: 0x000C886C File Offset: 0x000C6A6C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x060068E5 RID: 26853 RVA: 0x000C8878 File Offset: 0x000C6A78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001949 RID: 6473
		private uint? _indexWeekEnd;

		// Token: 0x0400194A RID: 6474
		private uint? _activityID;

		// Token: 0x0400194B RID: 6475
		private uint? _count;

		// Token: 0x0400194C RID: 6476
		private IExtension extensionObject;
	}
}
