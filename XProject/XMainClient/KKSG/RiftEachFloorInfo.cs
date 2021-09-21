using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200073F RID: 1855
	[ProtoContract(Name = "RiftEachFloorInfo")]
	[Serializable]
	public class RiftEachFloorInfo : IExtensible
	{
		// Token: 0x170028D6 RID: 10454
		// (get) Token: 0x060080CD RID: 32973 RVA: 0x000F64E4 File Offset: 0x000F46E4
		// (set) Token: 0x060080CE RID: 32974 RVA: 0x000F6510 File Offset: 0x000F4710
		[ProtoMember(1, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public int floor
		{
			get
			{
				return this._floor ?? 0;
			}
			set
			{
				this._floor = new int?(value);
			}
		}

		// Token: 0x170028D7 RID: 10455
		// (get) Token: 0x060080CF RID: 32975 RVA: 0x000F6520 File Offset: 0x000F4720
		// (set) Token: 0x060080D0 RID: 32976 RVA: 0x000F6540 File Offset: 0x000F4740
		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new int?(this.floor) : null);
				}
			}
		}

		// Token: 0x060080D1 RID: 32977 RVA: 0x000F6584 File Offset: 0x000F4784
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x060080D2 RID: 32978 RVA: 0x000F659C File Offset: 0x000F479C
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x170028D8 RID: 10456
		// (get) Token: 0x060080D3 RID: 32979 RVA: 0x000F65A8 File Offset: 0x000F47A8
		// (set) Token: 0x060080D4 RID: 32980 RVA: 0x000F65D4 File Offset: 0x000F47D4
		[ProtoMember(2, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
		public RiftFloorStatus status
		{
			get
			{
				return this._status ?? RiftFloorStatus.RiftFloor_NotPass;
			}
			set
			{
				this._status = new RiftFloorStatus?(value);
			}
		}

		// Token: 0x170028D9 RID: 10457
		// (get) Token: 0x060080D5 RID: 32981 RVA: 0x000F65E4 File Offset: 0x000F47E4
		// (set) Token: 0x060080D6 RID: 32982 RVA: 0x000F6604 File Offset: 0x000F4804
		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new RiftFloorStatus?(this.status) : null);
				}
			}
		}

		// Token: 0x060080D7 RID: 32983 RVA: 0x000F6648 File Offset: 0x000F4848
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x060080D8 RID: 32984 RVA: 0x000F6660 File Offset: 0x000F4860
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x170028DA RID: 10458
		// (get) Token: 0x060080D9 RID: 32985 RVA: 0x000F666C File Offset: 0x000F486C
		// (set) Token: 0x060080DA RID: 32986 RVA: 0x000F6698 File Offset: 0x000F4898
		[ProtoMember(3, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		// Token: 0x170028DB RID: 10459
		// (get) Token: 0x060080DB RID: 32987 RVA: 0x000F66A8 File Offset: 0x000F48A8
		// (set) Token: 0x060080DC RID: 32988 RVA: 0x000F66C8 File Offset: 0x000F48C8
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x060080DD RID: 32989 RVA: 0x000F670C File Offset: 0x000F490C
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060080DE RID: 32990 RVA: 0x000F6724 File Offset: 0x000F4924
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x060080DF RID: 32991 RVA: 0x000F6730 File Offset: 0x000F4930
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E2C RID: 7724
		private int? _floor;

		// Token: 0x04001E2D RID: 7725
		private RiftFloorStatus? _status;

		// Token: 0x04001E2E RID: 7726
		private int? _sceneID;

		// Token: 0x04001E2F RID: 7727
		private IExtension extensionObject;
	}
}
