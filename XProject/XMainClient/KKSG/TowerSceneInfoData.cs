using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200010A RID: 266
	[ProtoContract(Name = "TowerSceneInfoData")]
	[Serializable]
	public class TowerSceneInfoData : IExtensible
	{
		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x060010DB RID: 4315 RVA: 0x00022814 File Offset: 0x00020A14
		// (set) Token: 0x060010DC RID: 4316 RVA: 0x00022840 File Offset: 0x00020A40
		[ProtoMember(1, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x060010DD RID: 4317 RVA: 0x00022850 File Offset: 0x00020A50
		// (set) Token: 0x060010DE RID: 4318 RVA: 0x00022870 File Offset: 0x00020A70
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x000228B4 File Offset: 0x00020AB4
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x000228CC File Offset: 0x00020ACC
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x060010E1 RID: 4321 RVA: 0x000228D8 File Offset: 0x00020AD8
		// (set) Token: 0x060010E2 RID: 4322 RVA: 0x00022904 File Offset: 0x00020B04
		[ProtoMember(2, IsRequired = false, Name = "curTowerFloor", DataFormat = DataFormat.TwosComplement)]
		public int curTowerFloor
		{
			get
			{
				return this._curTowerFloor ?? 0;
			}
			set
			{
				this._curTowerFloor = new int?(value);
			}
		}

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x060010E3 RID: 4323 RVA: 0x00022914 File Offset: 0x00020B14
		// (set) Token: 0x060010E4 RID: 4324 RVA: 0x00022934 File Offset: 0x00020B34
		[XmlIgnore]
		[Browsable(false)]
		public bool curTowerFloorSpecified
		{
			get
			{
				return this._curTowerFloor != null;
			}
			set
			{
				bool flag = value == (this._curTowerFloor == null);
				if (flag)
				{
					this._curTowerFloor = (value ? new int?(this.curTowerFloor) : null);
				}
			}
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x00022978 File Offset: 0x00020B78
		private bool ShouldSerializecurTowerFloor()
		{
			return this.curTowerFloorSpecified;
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x00022990 File Offset: 0x00020B90
		private void ResetcurTowerFloor()
		{
			this.curTowerFloorSpecified = false;
		}

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x060010E7 RID: 4327 RVA: 0x0002299C File Offset: 0x00020B9C
		[ProtoMember(3, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x000229B4 File Offset: 0x00020BB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000438 RID: 1080
		private int? _leftTime;

		// Token: 0x04000439 RID: 1081
		private int? _curTowerFloor;

		// Token: 0x0400043A RID: 1082
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x0400043B RID: 1083
		private IExtension extensionObject;
	}
}
