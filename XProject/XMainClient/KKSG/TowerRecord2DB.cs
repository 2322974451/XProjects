using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000612 RID: 1554
	[ProtoContract(Name = "TowerRecord2DB")]
	[Serializable]
	public class TowerRecord2DB : IExtensible
	{
		// Token: 0x17001D80 RID: 7552
		// (get) Token: 0x06005E0C RID: 24076 RVA: 0x000B344C File Offset: 0x000B164C
		[ProtoMember(1, Name = "records", DataFormat = DataFormat.Default)]
		public List<TowerRecord> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x17001D81 RID: 7553
		// (get) Token: 0x06005E0D RID: 24077 RVA: 0x000B3464 File Offset: 0x000B1664
		// (set) Token: 0x06005E0E RID: 24078 RVA: 0x000B3490 File Offset: 0x000B1690
		[ProtoMember(2, IsRequired = false, Name = "m_updateTime", DataFormat = DataFormat.TwosComplement)]
		public int m_updateTime
		{
			get
			{
				return this._m_updateTime ?? 0;
			}
			set
			{
				this._m_updateTime = new int?(value);
			}
		}

		// Token: 0x17001D82 RID: 7554
		// (get) Token: 0x06005E0F RID: 24079 RVA: 0x000B34A0 File Offset: 0x000B16A0
		// (set) Token: 0x06005E10 RID: 24080 RVA: 0x000B34C0 File Offset: 0x000B16C0
		[XmlIgnore]
		[Browsable(false)]
		public bool m_updateTimeSpecified
		{
			get
			{
				return this._m_updateTime != null;
			}
			set
			{
				bool flag = value == (this._m_updateTime == null);
				if (flag)
				{
					this._m_updateTime = (value ? new int?(this.m_updateTime) : null);
				}
			}
		}

		// Token: 0x06005E11 RID: 24081 RVA: 0x000B3504 File Offset: 0x000B1704
		private bool ShouldSerializem_updateTime()
		{
			return this.m_updateTimeSpecified;
		}

		// Token: 0x06005E12 RID: 24082 RVA: 0x000B351C File Offset: 0x000B171C
		private void Resetm_updateTime()
		{
			this.m_updateTimeSpecified = false;
		}

		// Token: 0x17001D83 RID: 7555
		// (get) Token: 0x06005E13 RID: 24083 RVA: 0x000B3528 File Offset: 0x000B1728
		// (set) Token: 0x06005E14 RID: 24084 RVA: 0x000B3554 File Offset: 0x000B1754
		[ProtoMember(3, IsRequired = false, Name = "useResetCount", DataFormat = DataFormat.TwosComplement)]
		public int useResetCount
		{
			get
			{
				return this._useResetCount ?? 0;
			}
			set
			{
				this._useResetCount = new int?(value);
			}
		}

		// Token: 0x17001D84 RID: 7556
		// (get) Token: 0x06005E15 RID: 24085 RVA: 0x000B3564 File Offset: 0x000B1764
		// (set) Token: 0x06005E16 RID: 24086 RVA: 0x000B3584 File Offset: 0x000B1784
		[XmlIgnore]
		[Browsable(false)]
		public bool useResetCountSpecified
		{
			get
			{
				return this._useResetCount != null;
			}
			set
			{
				bool flag = value == (this._useResetCount == null);
				if (flag)
				{
					this._useResetCount = (value ? new int?(this.useResetCount) : null);
				}
			}
		}

		// Token: 0x06005E17 RID: 24087 RVA: 0x000B35C8 File Offset: 0x000B17C8
		private bool ShouldSerializeuseResetCount()
		{
			return this.useResetCountSpecified;
		}

		// Token: 0x06005E18 RID: 24088 RVA: 0x000B35E0 File Offset: 0x000B17E0
		private void ResetuseResetCount()
		{
			this.useResetCountSpecified = false;
		}

		// Token: 0x06005E19 RID: 24089 RVA: 0x000B35EC File Offset: 0x000B17EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016D7 RID: 5847
		private readonly List<TowerRecord> _records = new List<TowerRecord>();

		// Token: 0x040016D8 RID: 5848
		private int? _m_updateTime;

		// Token: 0x040016D9 RID: 5849
		private int? _useResetCount;

		// Token: 0x040016DA RID: 5850
		private IExtension extensionObject;
	}
}
