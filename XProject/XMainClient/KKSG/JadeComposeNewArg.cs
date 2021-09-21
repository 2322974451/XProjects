using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200054B RID: 1355
	[ProtoContract(Name = "JadeComposeNewArg")]
	[Serializable]
	public class JadeComposeNewArg : IExtensible
	{
		// Token: 0x17001527 RID: 5415
		// (get) Token: 0x0600453A RID: 17722 RVA: 0x000839DC File Offset: 0x00081BDC
		// (set) Token: 0x0600453B RID: 17723 RVA: 0x00083A08 File Offset: 0x00081C08
		[ProtoMember(1, IsRequired = false, Name = "ComposeType", DataFormat = DataFormat.TwosComplement)]
		public uint ComposeType
		{
			get
			{
				return this._ComposeType ?? 0U;
			}
			set
			{
				this._ComposeType = new uint?(value);
			}
		}

		// Token: 0x17001528 RID: 5416
		// (get) Token: 0x0600453C RID: 17724 RVA: 0x00083A18 File Offset: 0x00081C18
		// (set) Token: 0x0600453D RID: 17725 RVA: 0x00083A38 File Offset: 0x00081C38
		[XmlIgnore]
		[Browsable(false)]
		public bool ComposeTypeSpecified
		{
			get
			{
				return this._ComposeType != null;
			}
			set
			{
				bool flag = value == (this._ComposeType == null);
				if (flag)
				{
					this._ComposeType = (value ? new uint?(this.ComposeType) : null);
				}
			}
		}

		// Token: 0x0600453E RID: 17726 RVA: 0x00083A7C File Offset: 0x00081C7C
		private bool ShouldSerializeComposeType()
		{
			return this.ComposeTypeSpecified;
		}

		// Token: 0x0600453F RID: 17727 RVA: 0x00083A94 File Offset: 0x00081C94
		private void ResetComposeType()
		{
			this.ComposeTypeSpecified = false;
		}

		// Token: 0x17001529 RID: 5417
		// (get) Token: 0x06004540 RID: 17728 RVA: 0x00083AA0 File Offset: 0x00081CA0
		// (set) Token: 0x06004541 RID: 17729 RVA: 0x00083AC1 File Offset: 0x00081CC1
		[ProtoMember(2, IsRequired = false, Name = "JadeUniqueId", DataFormat = DataFormat.Default)]
		public string JadeUniqueId
		{
			get
			{
				return this._JadeUniqueId ?? "";
			}
			set
			{
				this._JadeUniqueId = value;
			}
		}

		// Token: 0x1700152A RID: 5418
		// (get) Token: 0x06004542 RID: 17730 RVA: 0x00083ACC File Offset: 0x00081CCC
		// (set) Token: 0x06004543 RID: 17731 RVA: 0x00083AE8 File Offset: 0x00081CE8
		[XmlIgnore]
		[Browsable(false)]
		public bool JadeUniqueIdSpecified
		{
			get
			{
				return this._JadeUniqueId != null;
			}
			set
			{
				bool flag = value == (this._JadeUniqueId == null);
				if (flag)
				{
					this._JadeUniqueId = (value ? this.JadeUniqueId : null);
				}
			}
		}

		// Token: 0x06004544 RID: 17732 RVA: 0x00083B18 File Offset: 0x00081D18
		private bool ShouldSerializeJadeUniqueId()
		{
			return this.JadeUniqueIdSpecified;
		}

		// Token: 0x06004545 RID: 17733 RVA: 0x00083B30 File Offset: 0x00081D30
		private void ResetJadeUniqueId()
		{
			this.JadeUniqueIdSpecified = false;
		}

		// Token: 0x1700152B RID: 5419
		// (get) Token: 0x06004546 RID: 17734 RVA: 0x00083B3C File Offset: 0x00081D3C
		// (set) Token: 0x06004547 RID: 17735 RVA: 0x00083B5D File Offset: 0x00081D5D
		[ProtoMember(3, IsRequired = false, Name = "EquipUniqueId", DataFormat = DataFormat.Default)]
		public string EquipUniqueId
		{
			get
			{
				return this._EquipUniqueId ?? "";
			}
			set
			{
				this._EquipUniqueId = value;
			}
		}

		// Token: 0x1700152C RID: 5420
		// (get) Token: 0x06004548 RID: 17736 RVA: 0x00083B68 File Offset: 0x00081D68
		// (set) Token: 0x06004549 RID: 17737 RVA: 0x00083B84 File Offset: 0x00081D84
		[XmlIgnore]
		[Browsable(false)]
		public bool EquipUniqueIdSpecified
		{
			get
			{
				return this._EquipUniqueId != null;
			}
			set
			{
				bool flag = value == (this._EquipUniqueId == null);
				if (flag)
				{
					this._EquipUniqueId = (value ? this.EquipUniqueId : null);
				}
			}
		}

		// Token: 0x0600454A RID: 17738 RVA: 0x00083BB4 File Offset: 0x00081DB4
		private bool ShouldSerializeEquipUniqueId()
		{
			return this.EquipUniqueIdSpecified;
		}

		// Token: 0x0600454B RID: 17739 RVA: 0x00083BCC File Offset: 0x00081DCC
		private void ResetEquipUniqueId()
		{
			this.EquipUniqueIdSpecified = false;
		}

		// Token: 0x1700152D RID: 5421
		// (get) Token: 0x0600454C RID: 17740 RVA: 0x00083BD8 File Offset: 0x00081DD8
		// (set) Token: 0x0600454D RID: 17741 RVA: 0x00083C04 File Offset: 0x00081E04
		[ProtoMember(4, IsRequired = false, Name = "SlotPos", DataFormat = DataFormat.TwosComplement)]
		public uint SlotPos
		{
			get
			{
				return this._SlotPos ?? 0U;
			}
			set
			{
				this._SlotPos = new uint?(value);
			}
		}

		// Token: 0x1700152E RID: 5422
		// (get) Token: 0x0600454E RID: 17742 RVA: 0x00083C14 File Offset: 0x00081E14
		// (set) Token: 0x0600454F RID: 17743 RVA: 0x00083C34 File Offset: 0x00081E34
		[XmlIgnore]
		[Browsable(false)]
		public bool SlotPosSpecified
		{
			get
			{
				return this._SlotPos != null;
			}
			set
			{
				bool flag = value == (this._SlotPos == null);
				if (flag)
				{
					this._SlotPos = (value ? new uint?(this.SlotPos) : null);
				}
			}
		}

		// Token: 0x06004550 RID: 17744 RVA: 0x00083C78 File Offset: 0x00081E78
		private bool ShouldSerializeSlotPos()
		{
			return this.SlotPosSpecified;
		}

		// Token: 0x06004551 RID: 17745 RVA: 0x00083C90 File Offset: 0x00081E90
		private void ResetSlotPos()
		{
			this.SlotPosSpecified = false;
		}

		// Token: 0x1700152F RID: 5423
		// (get) Token: 0x06004552 RID: 17746 RVA: 0x00083C9C File Offset: 0x00081E9C
		// (set) Token: 0x06004553 RID: 17747 RVA: 0x00083CC8 File Offset: 0x00081EC8
		[ProtoMember(5, IsRequired = false, Name = "AddLevel", DataFormat = DataFormat.TwosComplement)]
		public uint AddLevel
		{
			get
			{
				return this._AddLevel ?? 0U;
			}
			set
			{
				this._AddLevel = new uint?(value);
			}
		}

		// Token: 0x17001530 RID: 5424
		// (get) Token: 0x06004554 RID: 17748 RVA: 0x00083CD8 File Offset: 0x00081ED8
		// (set) Token: 0x06004555 RID: 17749 RVA: 0x00083CF8 File Offset: 0x00081EF8
		[XmlIgnore]
		[Browsable(false)]
		public bool AddLevelSpecified
		{
			get
			{
				return this._AddLevel != null;
			}
			set
			{
				bool flag = value == (this._AddLevel == null);
				if (flag)
				{
					this._AddLevel = (value ? new uint?(this.AddLevel) : null);
				}
			}
		}

		// Token: 0x06004556 RID: 17750 RVA: 0x00083D3C File Offset: 0x00081F3C
		private bool ShouldSerializeAddLevel()
		{
			return this.AddLevelSpecified;
		}

		// Token: 0x06004557 RID: 17751 RVA: 0x00083D54 File Offset: 0x00081F54
		private void ResetAddLevel()
		{
			this.AddLevelSpecified = false;
		}

		// Token: 0x06004558 RID: 17752 RVA: 0x00083D60 File Offset: 0x00081F60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400114D RID: 4429
		private uint? _ComposeType;

		// Token: 0x0400114E RID: 4430
		private string _JadeUniqueId;

		// Token: 0x0400114F RID: 4431
		private string _EquipUniqueId;

		// Token: 0x04001150 RID: 4432
		private uint? _SlotPos;

		// Token: 0x04001151 RID: 4433
		private uint? _AddLevel;

		// Token: 0x04001152 RID: 4434
		private IExtension extensionObject;
	}
}
