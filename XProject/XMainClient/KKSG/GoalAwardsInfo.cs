using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000732 RID: 1842
	[ProtoContract(Name = "GoalAwardsInfo")]
	[Serializable]
	public class GoalAwardsInfo : IExtensible
	{
		// Token: 0x1700286B RID: 10347
		// (get) Token: 0x06007F7A RID: 32634 RVA: 0x000F3C70 File Offset: 0x000F1E70
		// (set) Token: 0x06007F7B RID: 32635 RVA: 0x000F3C9C File Offset: 0x000F1E9C
		[ProtoMember(1, IsRequired = false, Name = "goalAwardsID", DataFormat = DataFormat.TwosComplement)]
		public uint goalAwardsID
		{
			get
			{
				return this._goalAwardsID ?? 0U;
			}
			set
			{
				this._goalAwardsID = new uint?(value);
			}
		}

		// Token: 0x1700286C RID: 10348
		// (get) Token: 0x06007F7C RID: 32636 RVA: 0x000F3CAC File Offset: 0x000F1EAC
		// (set) Token: 0x06007F7D RID: 32637 RVA: 0x000F3CCC File Offset: 0x000F1ECC
		[XmlIgnore]
		[Browsable(false)]
		public bool goalAwardsIDSpecified
		{
			get
			{
				return this._goalAwardsID != null;
			}
			set
			{
				bool flag = value == (this._goalAwardsID == null);
				if (flag)
				{
					this._goalAwardsID = (value ? new uint?(this.goalAwardsID) : null);
				}
			}
		}

		// Token: 0x06007F7E RID: 32638 RVA: 0x000F3D10 File Offset: 0x000F1F10
		private bool ShouldSerializegoalAwardsID()
		{
			return this.goalAwardsIDSpecified;
		}

		// Token: 0x06007F7F RID: 32639 RVA: 0x000F3D28 File Offset: 0x000F1F28
		private void ResetgoalAwardsID()
		{
			this.goalAwardsIDSpecified = false;
		}

		// Token: 0x1700286D RID: 10349
		// (get) Token: 0x06007F80 RID: 32640 RVA: 0x000F3D34 File Offset: 0x000F1F34
		// (set) Token: 0x06007F81 RID: 32641 RVA: 0x000F3D60 File Offset: 0x000F1F60
		[ProtoMember(2, IsRequired = false, Name = "doneIndex", DataFormat = DataFormat.TwosComplement)]
		public uint doneIndex
		{
			get
			{
				return this._doneIndex ?? 0U;
			}
			set
			{
				this._doneIndex = new uint?(value);
			}
		}

		// Token: 0x1700286E RID: 10350
		// (get) Token: 0x06007F82 RID: 32642 RVA: 0x000F3D70 File Offset: 0x000F1F70
		// (set) Token: 0x06007F83 RID: 32643 RVA: 0x000F3D90 File Offset: 0x000F1F90
		[XmlIgnore]
		[Browsable(false)]
		public bool doneIndexSpecified
		{
			get
			{
				return this._doneIndex != null;
			}
			set
			{
				bool flag = value == (this._doneIndex == null);
				if (flag)
				{
					this._doneIndex = (value ? new uint?(this.doneIndex) : null);
				}
			}
		}

		// Token: 0x06007F84 RID: 32644 RVA: 0x000F3DD4 File Offset: 0x000F1FD4
		private bool ShouldSerializedoneIndex()
		{
			return this.doneIndexSpecified;
		}

		// Token: 0x06007F85 RID: 32645 RVA: 0x000F3DEC File Offset: 0x000F1FEC
		private void ResetdoneIndex()
		{
			this.doneIndexSpecified = false;
		}

		// Token: 0x1700286F RID: 10351
		// (get) Token: 0x06007F86 RID: 32646 RVA: 0x000F3DF8 File Offset: 0x000F1FF8
		// (set) Token: 0x06007F87 RID: 32647 RVA: 0x000F3E24 File Offset: 0x000F2024
		[ProtoMember(3, IsRequired = false, Name = "gottenAwardsIndex", DataFormat = DataFormat.TwosComplement)]
		public uint gottenAwardsIndex
		{
			get
			{
				return this._gottenAwardsIndex ?? 0U;
			}
			set
			{
				this._gottenAwardsIndex = new uint?(value);
			}
		}

		// Token: 0x17002870 RID: 10352
		// (get) Token: 0x06007F88 RID: 32648 RVA: 0x000F3E34 File Offset: 0x000F2034
		// (set) Token: 0x06007F89 RID: 32649 RVA: 0x000F3E54 File Offset: 0x000F2054
		[XmlIgnore]
		[Browsable(false)]
		public bool gottenAwardsIndexSpecified
		{
			get
			{
				return this._gottenAwardsIndex != null;
			}
			set
			{
				bool flag = value == (this._gottenAwardsIndex == null);
				if (flag)
				{
					this._gottenAwardsIndex = (value ? new uint?(this.gottenAwardsIndex) : null);
				}
			}
		}

		// Token: 0x06007F8A RID: 32650 RVA: 0x000F3E98 File Offset: 0x000F2098
		private bool ShouldSerializegottenAwardsIndex()
		{
			return this.gottenAwardsIndexSpecified;
		}

		// Token: 0x06007F8B RID: 32651 RVA: 0x000F3EB0 File Offset: 0x000F20B0
		private void ResetgottenAwardsIndex()
		{
			this.gottenAwardsIndexSpecified = false;
		}

		// Token: 0x17002871 RID: 10353
		// (get) Token: 0x06007F8C RID: 32652 RVA: 0x000F3EBC File Offset: 0x000F20BC
		// (set) Token: 0x06007F8D RID: 32653 RVA: 0x000F3EF0 File Offset: 0x000F20F0
		[ProtoMember(4, IsRequired = false, Name = "totalvalue", DataFormat = DataFormat.TwosComplement)]
		public double totalvalue
		{
			get
			{
				return this._totalvalue ?? 0.0;
			}
			set
			{
				this._totalvalue = new double?(value);
			}
		}

		// Token: 0x17002872 RID: 10354
		// (get) Token: 0x06007F8E RID: 32654 RVA: 0x000F3F00 File Offset: 0x000F2100
		// (set) Token: 0x06007F8F RID: 32655 RVA: 0x000F3F20 File Offset: 0x000F2120
		[XmlIgnore]
		[Browsable(false)]
		public bool totalvalueSpecified
		{
			get
			{
				return this._totalvalue != null;
			}
			set
			{
				bool flag = value == (this._totalvalue == null);
				if (flag)
				{
					this._totalvalue = (value ? new double?(this.totalvalue) : null);
				}
			}
		}

		// Token: 0x06007F90 RID: 32656 RVA: 0x000F3F64 File Offset: 0x000F2164
		private bool ShouldSerializetotalvalue()
		{
			return this.totalvalueSpecified;
		}

		// Token: 0x06007F91 RID: 32657 RVA: 0x000F3F7C File Offset: 0x000F217C
		private void Resettotalvalue()
		{
			this.totalvalueSpecified = false;
		}

		// Token: 0x17002873 RID: 10355
		// (get) Token: 0x06007F92 RID: 32658 RVA: 0x000F3F88 File Offset: 0x000F2188
		[ProtoMember(5, Name = "gkidvalue", DataFormat = DataFormat.Default)]
		public List<GoalAwardsValue> gkidvalue
		{
			get
			{
				return this._gkidvalue;
			}
		}

		// Token: 0x06007F93 RID: 32659 RVA: 0x000F3FA0 File Offset: 0x000F21A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DE7 RID: 7655
		private uint? _goalAwardsID;

		// Token: 0x04001DE8 RID: 7656
		private uint? _doneIndex;

		// Token: 0x04001DE9 RID: 7657
		private uint? _gottenAwardsIndex;

		// Token: 0x04001DEA RID: 7658
		private double? _totalvalue;

		// Token: 0x04001DEB RID: 7659
		private readonly List<GoalAwardsValue> _gkidvalue = new List<GoalAwardsValue>();

		// Token: 0x04001DEC RID: 7660
		private IExtension extensionObject;
	}
}
