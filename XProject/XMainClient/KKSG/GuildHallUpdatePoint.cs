using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000547 RID: 1351
	[ProtoContract(Name = "GuildHallUpdatePoint")]
	[Serializable]
	public class GuildHallUpdatePoint : IExtensible
	{
		// Token: 0x17001516 RID: 5398
		// (get) Token: 0x06004500 RID: 17664 RVA: 0x00083308 File Offset: 0x00081508
		// (set) Token: 0x06004501 RID: 17665 RVA: 0x00083334 File Offset: 0x00081534
		[ProtoMember(1, IsRequired = false, Name = "schoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint schoolpoint
		{
			get
			{
				return this._schoolpoint ?? 0U;
			}
			set
			{
				this._schoolpoint = new uint?(value);
			}
		}

		// Token: 0x17001517 RID: 5399
		// (get) Token: 0x06004502 RID: 17666 RVA: 0x00083344 File Offset: 0x00081544
		// (set) Token: 0x06004503 RID: 17667 RVA: 0x00083364 File Offset: 0x00081564
		[XmlIgnore]
		[Browsable(false)]
		public bool schoolpointSpecified
		{
			get
			{
				return this._schoolpoint != null;
			}
			set
			{
				bool flag = value == (this._schoolpoint == null);
				if (flag)
				{
					this._schoolpoint = (value ? new uint?(this.schoolpoint) : null);
				}
			}
		}

		// Token: 0x06004504 RID: 17668 RVA: 0x000833A8 File Offset: 0x000815A8
		private bool ShouldSerializeschoolpoint()
		{
			return this.schoolpointSpecified;
		}

		// Token: 0x06004505 RID: 17669 RVA: 0x000833C0 File Offset: 0x000815C0
		private void Resetschoolpoint()
		{
			this.schoolpointSpecified = false;
		}

		// Token: 0x17001518 RID: 5400
		// (get) Token: 0x06004506 RID: 17670 RVA: 0x000833CC File Offset: 0x000815CC
		// (set) Token: 0x06004507 RID: 17671 RVA: 0x000833F8 File Offset: 0x000815F8
		[ProtoMember(2, IsRequired = false, Name = "hallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint hallpoint
		{
			get
			{
				return this._hallpoint ?? 0U;
			}
			set
			{
				this._hallpoint = new uint?(value);
			}
		}

		// Token: 0x17001519 RID: 5401
		// (get) Token: 0x06004508 RID: 17672 RVA: 0x00083408 File Offset: 0x00081608
		// (set) Token: 0x06004509 RID: 17673 RVA: 0x00083428 File Offset: 0x00081628
		[XmlIgnore]
		[Browsable(false)]
		public bool hallpointSpecified
		{
			get
			{
				return this._hallpoint != null;
			}
			set
			{
				bool flag = value == (this._hallpoint == null);
				if (flag)
				{
					this._hallpoint = (value ? new uint?(this.hallpoint) : null);
				}
			}
		}

		// Token: 0x0600450A RID: 17674 RVA: 0x0008346C File Offset: 0x0008166C
		private bool ShouldSerializehallpoint()
		{
			return this.hallpointSpecified;
		}

		// Token: 0x0600450B RID: 17675 RVA: 0x00083484 File Offset: 0x00081684
		private void Resethallpoint()
		{
			this.hallpointSpecified = false;
		}

		// Token: 0x1700151A RID: 5402
		// (get) Token: 0x0600450C RID: 17676 RVA: 0x00083490 File Offset: 0x00081690
		// (set) Token: 0x0600450D RID: 17677 RVA: 0x000834BD File Offset: 0x000816BD
		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x1700151B RID: 5403
		// (get) Token: 0x0600450E RID: 17678 RVA: 0x000834CC File Offset: 0x000816CC
		// (set) Token: 0x0600450F RID: 17679 RVA: 0x000834EC File Offset: 0x000816EC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06004510 RID: 17680 RVA: 0x00083530 File Offset: 0x00081730
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06004511 RID: 17681 RVA: 0x00083548 File Offset: 0x00081748
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700151C RID: 5404
		// (get) Token: 0x06004512 RID: 17682 RVA: 0x00083554 File Offset: 0x00081754
		// (set) Token: 0x06004513 RID: 17683 RVA: 0x00083580 File Offset: 0x00081780
		[ProtoMember(4, IsRequired = false, Name = "deltaschoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint deltaschoolpoint
		{
			get
			{
				return this._deltaschoolpoint ?? 0U;
			}
			set
			{
				this._deltaschoolpoint = new uint?(value);
			}
		}

		// Token: 0x1700151D RID: 5405
		// (get) Token: 0x06004514 RID: 17684 RVA: 0x00083590 File Offset: 0x00081790
		// (set) Token: 0x06004515 RID: 17685 RVA: 0x000835B0 File Offset: 0x000817B0
		[XmlIgnore]
		[Browsable(false)]
		public bool deltaschoolpointSpecified
		{
			get
			{
				return this._deltaschoolpoint != null;
			}
			set
			{
				bool flag = value == (this._deltaschoolpoint == null);
				if (flag)
				{
					this._deltaschoolpoint = (value ? new uint?(this.deltaschoolpoint) : null);
				}
			}
		}

		// Token: 0x06004516 RID: 17686 RVA: 0x000835F4 File Offset: 0x000817F4
		private bool ShouldSerializedeltaschoolpoint()
		{
			return this.deltaschoolpointSpecified;
		}

		// Token: 0x06004517 RID: 17687 RVA: 0x0008360C File Offset: 0x0008180C
		private void Resetdeltaschoolpoint()
		{
			this.deltaschoolpointSpecified = false;
		}

		// Token: 0x1700151E RID: 5406
		// (get) Token: 0x06004518 RID: 17688 RVA: 0x00083618 File Offset: 0x00081818
		// (set) Token: 0x06004519 RID: 17689 RVA: 0x00083644 File Offset: 0x00081844
		[ProtoMember(5, IsRequired = false, Name = "deltahallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint deltahallpoint
		{
			get
			{
				return this._deltahallpoint ?? 0U;
			}
			set
			{
				this._deltahallpoint = new uint?(value);
			}
		}

		// Token: 0x1700151F RID: 5407
		// (get) Token: 0x0600451A RID: 17690 RVA: 0x00083654 File Offset: 0x00081854
		// (set) Token: 0x0600451B RID: 17691 RVA: 0x00083674 File Offset: 0x00081874
		[XmlIgnore]
		[Browsable(false)]
		public bool deltahallpointSpecified
		{
			get
			{
				return this._deltahallpoint != null;
			}
			set
			{
				bool flag = value == (this._deltahallpoint == null);
				if (flag)
				{
					this._deltahallpoint = (value ? new uint?(this.deltahallpoint) : null);
				}
			}
		}

		// Token: 0x0600451C RID: 17692 RVA: 0x000836B8 File Offset: 0x000818B8
		private bool ShouldSerializedeltahallpoint()
		{
			return this.deltahallpointSpecified;
		}

		// Token: 0x0600451D RID: 17693 RVA: 0x000836D0 File Offset: 0x000818D0
		private void Resetdeltahallpoint()
		{
			this.deltahallpointSpecified = false;
		}

		// Token: 0x0600451E RID: 17694 RVA: 0x000836DC File Offset: 0x000818DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001140 RID: 4416
		private uint? _schoolpoint;

		// Token: 0x04001141 RID: 4417
		private uint? _hallpoint;

		// Token: 0x04001142 RID: 4418
		private ulong? _roleid;

		// Token: 0x04001143 RID: 4419
		private uint? _deltaschoolpoint;

		// Token: 0x04001144 RID: 4420
		private uint? _deltahallpoint;

		// Token: 0x04001145 RID: 4421
		private IExtension extensionObject;
	}
}
