using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D3 RID: 1491
	[ProtoContract(Name = "TowerResult")]
	[Serializable]
	public class TowerResult : IExtensible
	{
		// Token: 0x17001A74 RID: 6772
		// (get) Token: 0x06005546 RID: 21830 RVA: 0x000A2480 File Offset: 0x000A0680
		// (set) Token: 0x06005547 RID: 21831 RVA: 0x000A24AC File Offset: 0x000A06AC
		[ProtoMember(1, IsRequired = false, Name = "isNewRecord", DataFormat = DataFormat.Default)]
		public bool isNewRecord
		{
			get
			{
				return this._isNewRecord ?? false;
			}
			set
			{
				this._isNewRecord = new bool?(value);
			}
		}

		// Token: 0x17001A75 RID: 6773
		// (get) Token: 0x06005548 RID: 21832 RVA: 0x000A24BC File Offset: 0x000A06BC
		// (set) Token: 0x06005549 RID: 21833 RVA: 0x000A24DC File Offset: 0x000A06DC
		[XmlIgnore]
		[Browsable(false)]
		public bool isNewRecordSpecified
		{
			get
			{
				return this._isNewRecord != null;
			}
			set
			{
				bool flag = value == (this._isNewRecord == null);
				if (flag)
				{
					this._isNewRecord = (value ? new bool?(this.isNewRecord) : null);
				}
			}
		}

		// Token: 0x0600554A RID: 21834 RVA: 0x000A2520 File Offset: 0x000A0720
		private bool ShouldSerializeisNewRecord()
		{
			return this.isNewRecordSpecified;
		}

		// Token: 0x0600554B RID: 21835 RVA: 0x000A2538 File Offset: 0x000A0738
		private void ResetisNewRecord()
		{
			this.isNewRecordSpecified = false;
		}

		// Token: 0x17001A76 RID: 6774
		// (get) Token: 0x0600554C RID: 21836 RVA: 0x000A2544 File Offset: 0x000A0744
		// (set) Token: 0x0600554D RID: 21837 RVA: 0x000A2570 File Offset: 0x000A0770
		[ProtoMember(2, IsRequired = false, Name = "towerFloor", DataFormat = DataFormat.TwosComplement)]
		public int towerFloor
		{
			get
			{
				return this._towerFloor ?? 0;
			}
			set
			{
				this._towerFloor = new int?(value);
			}
		}

		// Token: 0x17001A77 RID: 6775
		// (get) Token: 0x0600554E RID: 21838 RVA: 0x000A2580 File Offset: 0x000A0780
		// (set) Token: 0x0600554F RID: 21839 RVA: 0x000A25A0 File Offset: 0x000A07A0
		[XmlIgnore]
		[Browsable(false)]
		public bool towerFloorSpecified
		{
			get
			{
				return this._towerFloor != null;
			}
			set
			{
				bool flag = value == (this._towerFloor == null);
				if (flag)
				{
					this._towerFloor = (value ? new int?(this.towerFloor) : null);
				}
			}
		}

		// Token: 0x06005550 RID: 21840 RVA: 0x000A25E4 File Offset: 0x000A07E4
		private bool ShouldSerializetowerFloor()
		{
			return this.towerFloorSpecified;
		}

		// Token: 0x06005551 RID: 21841 RVA: 0x000A25FC File Offset: 0x000A07FC
		private void ResettowerFloor()
		{
			this.towerFloorSpecified = false;
		}

		// Token: 0x06005552 RID: 21842 RVA: 0x000A2608 File Offset: 0x000A0808
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014C9 RID: 5321
		private bool? _isNewRecord;

		// Token: 0x040014CA RID: 5322
		private int? _towerFloor;

		// Token: 0x040014CB RID: 5323
		private IExtension extensionObject;
	}
}
