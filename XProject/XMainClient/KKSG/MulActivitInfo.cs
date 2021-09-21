using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200068D RID: 1677
	[ProtoContract(Name = "MulActivitInfo")]
	[Serializable]
	public class MulActivitInfo : IExtensible
	{
		// Token: 0x1700224C RID: 8780
		// (get) Token: 0x06006C5D RID: 27741 RVA: 0x000CF4F4 File Offset: 0x000CD6F4
		// (set) Token: 0x06006C5E RID: 27742 RVA: 0x000CF520 File Offset: 0x000CD720
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public int id
		{
			get
			{
				return this._id ?? 0;
			}
			set
			{
				this._id = new int?(value);
			}
		}

		// Token: 0x1700224D RID: 8781
		// (get) Token: 0x06006C5F RID: 27743 RVA: 0x000CF530 File Offset: 0x000CD730
		// (set) Token: 0x06006C60 RID: 27744 RVA: 0x000CF550 File Offset: 0x000CD750
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new int?(this.id) : null);
				}
			}
		}

		// Token: 0x06006C61 RID: 27745 RVA: 0x000CF594 File Offset: 0x000CD794
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06006C62 RID: 27746 RVA: 0x000CF5AC File Offset: 0x000CD7AC
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700224E RID: 8782
		// (get) Token: 0x06006C63 RID: 27747 RVA: 0x000CF5B8 File Offset: 0x000CD7B8
		// (set) Token: 0x06006C64 RID: 27748 RVA: 0x000CF5E4 File Offset: 0x000CD7E4
		[ProtoMember(2, IsRequired = false, Name = "openstate", DataFormat = DataFormat.TwosComplement)]
		public MulActivityTimeState openstate
		{
			get
			{
				return this._openstate ?? MulActivityTimeState.MULACTIVITY_BEfOREOPEN;
			}
			set
			{
				this._openstate = new MulActivityTimeState?(value);
			}
		}

		// Token: 0x1700224F RID: 8783
		// (get) Token: 0x06006C65 RID: 27749 RVA: 0x000CF5F4 File Offset: 0x000CD7F4
		// (set) Token: 0x06006C66 RID: 27750 RVA: 0x000CF614 File Offset: 0x000CD814
		[XmlIgnore]
		[Browsable(false)]
		public bool openstateSpecified
		{
			get
			{
				return this._openstate != null;
			}
			set
			{
				bool flag = value == (this._openstate == null);
				if (flag)
				{
					this._openstate = (value ? new MulActivityTimeState?(this.openstate) : null);
				}
			}
		}

		// Token: 0x06006C67 RID: 27751 RVA: 0x000CF658 File Offset: 0x000CD858
		private bool ShouldSerializeopenstate()
		{
			return this.openstateSpecified;
		}

		// Token: 0x06006C68 RID: 27752 RVA: 0x000CF670 File Offset: 0x000CD870
		private void Resetopenstate()
		{
			this.openstateSpecified = false;
		}

		// Token: 0x17002250 RID: 8784
		// (get) Token: 0x06006C69 RID: 27753 RVA: 0x000CF67C File Offset: 0x000CD87C
		// (set) Token: 0x06006C6A RID: 27754 RVA: 0x000CF6A8 File Offset: 0x000CD8A8
		[ProtoMember(3, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17002251 RID: 8785
		// (get) Token: 0x06006C6B RID: 27755 RVA: 0x000CF6B8 File Offset: 0x000CD8B8
		// (set) Token: 0x06006C6C RID: 27756 RVA: 0x000CF6D8 File Offset: 0x000CD8D8
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06006C6D RID: 27757 RVA: 0x000CF71C File Offset: 0x000CD91C
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06006C6E RID: 27758 RVA: 0x000CF734 File Offset: 0x000CD934
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x17002252 RID: 8786
		// (get) Token: 0x06006C6F RID: 27759 RVA: 0x000CF740 File Offset: 0x000CD940
		// (set) Token: 0x06006C70 RID: 27760 RVA: 0x000CF76C File Offset: 0x000CD96C
		[ProtoMember(4, IsRequired = false, Name = "dayjoincount", DataFormat = DataFormat.TwosComplement)]
		public int dayjoincount
		{
			get
			{
				return this._dayjoincount ?? 0;
			}
			set
			{
				this._dayjoincount = new int?(value);
			}
		}

		// Token: 0x17002253 RID: 8787
		// (get) Token: 0x06006C71 RID: 27761 RVA: 0x000CF77C File Offset: 0x000CD97C
		// (set) Token: 0x06006C72 RID: 27762 RVA: 0x000CF79C File Offset: 0x000CD99C
		[XmlIgnore]
		[Browsable(false)]
		public bool dayjoincountSpecified
		{
			get
			{
				return this._dayjoincount != null;
			}
			set
			{
				bool flag = value == (this._dayjoincount == null);
				if (flag)
				{
					this._dayjoincount = (value ? new int?(this.dayjoincount) : null);
				}
			}
		}

		// Token: 0x06006C73 RID: 27763 RVA: 0x000CF7E0 File Offset: 0x000CD9E0
		private bool ShouldSerializedayjoincount()
		{
			return this.dayjoincountSpecified;
		}

		// Token: 0x06006C74 RID: 27764 RVA: 0x000CF7F8 File Offset: 0x000CD9F8
		private void Resetdayjoincount()
		{
			this.dayjoincountSpecified = false;
		}

		// Token: 0x17002254 RID: 8788
		// (get) Token: 0x06006C75 RID: 27765 RVA: 0x000CF804 File Offset: 0x000CDA04
		// (set) Token: 0x06006C76 RID: 27766 RVA: 0x000CF830 File Offset: 0x000CDA30
		[ProtoMember(5, IsRequired = false, Name = "beginmin", DataFormat = DataFormat.TwosComplement)]
		public uint beginmin
		{
			get
			{
				return this._beginmin ?? 0U;
			}
			set
			{
				this._beginmin = new uint?(value);
			}
		}

		// Token: 0x17002255 RID: 8789
		// (get) Token: 0x06006C77 RID: 27767 RVA: 0x000CF840 File Offset: 0x000CDA40
		// (set) Token: 0x06006C78 RID: 27768 RVA: 0x000CF860 File Offset: 0x000CDA60
		[XmlIgnore]
		[Browsable(false)]
		public bool beginminSpecified
		{
			get
			{
				return this._beginmin != null;
			}
			set
			{
				bool flag = value == (this._beginmin == null);
				if (flag)
				{
					this._beginmin = (value ? new uint?(this.beginmin) : null);
				}
			}
		}

		// Token: 0x06006C79 RID: 27769 RVA: 0x000CF8A4 File Offset: 0x000CDAA4
		private bool ShouldSerializebeginmin()
		{
			return this.beginminSpecified;
		}

		// Token: 0x06006C7A RID: 27770 RVA: 0x000CF8BC File Offset: 0x000CDABC
		private void Resetbeginmin()
		{
			this.beginminSpecified = false;
		}

		// Token: 0x17002256 RID: 8790
		// (get) Token: 0x06006C7B RID: 27771 RVA: 0x000CF8C8 File Offset: 0x000CDAC8
		// (set) Token: 0x06006C7C RID: 27772 RVA: 0x000CF8F4 File Offset: 0x000CDAF4
		[ProtoMember(6, IsRequired = false, Name = "endmin", DataFormat = DataFormat.TwosComplement)]
		public uint endmin
		{
			get
			{
				return this._endmin ?? 0U;
			}
			set
			{
				this._endmin = new uint?(value);
			}
		}

		// Token: 0x17002257 RID: 8791
		// (get) Token: 0x06006C7D RID: 27773 RVA: 0x000CF904 File Offset: 0x000CDB04
		// (set) Token: 0x06006C7E RID: 27774 RVA: 0x000CF924 File Offset: 0x000CDB24
		[XmlIgnore]
		[Browsable(false)]
		public bool endminSpecified
		{
			get
			{
				return this._endmin != null;
			}
			set
			{
				bool flag = value == (this._endmin == null);
				if (flag)
				{
					this._endmin = (value ? new uint?(this.endmin) : null);
				}
			}
		}

		// Token: 0x06006C7F RID: 27775 RVA: 0x000CF968 File Offset: 0x000CDB68
		private bool ShouldSerializeendmin()
		{
			return this.endminSpecified;
		}

		// Token: 0x06006C80 RID: 27776 RVA: 0x000CF980 File Offset: 0x000CDB80
		private void Resetendmin()
		{
			this.endminSpecified = false;
		}

		// Token: 0x17002258 RID: 8792
		// (get) Token: 0x06006C81 RID: 27777 RVA: 0x000CF98C File Offset: 0x000CDB8C
		// (set) Token: 0x06006C82 RID: 27778 RVA: 0x000CF9B8 File Offset: 0x000CDBB8
		[ProtoMember(7, IsRequired = false, Name = "real_open_state", DataFormat = DataFormat.TwosComplement)]
		public ActOpenState real_open_state
		{
			get
			{
				return this._real_open_state ?? ActOpenState.ActOpenState_NotOpen;
			}
			set
			{
				this._real_open_state = new ActOpenState?(value);
			}
		}

		// Token: 0x17002259 RID: 8793
		// (get) Token: 0x06006C83 RID: 27779 RVA: 0x000CF9C8 File Offset: 0x000CDBC8
		// (set) Token: 0x06006C84 RID: 27780 RVA: 0x000CF9E8 File Offset: 0x000CDBE8
		[XmlIgnore]
		[Browsable(false)]
		public bool real_open_stateSpecified
		{
			get
			{
				return this._real_open_state != null;
			}
			set
			{
				bool flag = value == (this._real_open_state == null);
				if (flag)
				{
					this._real_open_state = (value ? new ActOpenState?(this.real_open_state) : null);
				}
			}
		}

		// Token: 0x06006C85 RID: 27781 RVA: 0x000CFA2C File Offset: 0x000CDC2C
		private bool ShouldSerializereal_open_state()
		{
			return this.real_open_stateSpecified;
		}

		// Token: 0x06006C86 RID: 27782 RVA: 0x000CFA44 File Offset: 0x000CDC44
		private void Resetreal_open_state()
		{
			this.real_open_stateSpecified = false;
		}

		// Token: 0x1700225A RID: 8794
		// (get) Token: 0x06006C87 RID: 27783 RVA: 0x000CFA50 File Offset: 0x000CDC50
		// (set) Token: 0x06006C88 RID: 27784 RVA: 0x000CFA7C File Offset: 0x000CDC7C
		[ProtoMember(8, IsRequired = false, Name = "is_playing", DataFormat = DataFormat.Default)]
		public bool is_playing
		{
			get
			{
				return this._is_playing ?? false;
			}
			set
			{
				this._is_playing = new bool?(value);
			}
		}

		// Token: 0x1700225B RID: 8795
		// (get) Token: 0x06006C89 RID: 27785 RVA: 0x000CFA8C File Offset: 0x000CDC8C
		// (set) Token: 0x06006C8A RID: 27786 RVA: 0x000CFAAC File Offset: 0x000CDCAC
		[XmlIgnore]
		[Browsable(false)]
		public bool is_playingSpecified
		{
			get
			{
				return this._is_playing != null;
			}
			set
			{
				bool flag = value == (this._is_playing == null);
				if (flag)
				{
					this._is_playing = (value ? new bool?(this.is_playing) : null);
				}
			}
		}

		// Token: 0x06006C8B RID: 27787 RVA: 0x000CFAF0 File Offset: 0x000CDCF0
		private bool ShouldSerializeis_playing()
		{
			return this.is_playingSpecified;
		}

		// Token: 0x06006C8C RID: 27788 RVA: 0x000CFB08 File Offset: 0x000CDD08
		private void Resetis_playing()
		{
			this.is_playingSpecified = false;
		}

		// Token: 0x06006C8D RID: 27789 RVA: 0x000CFB14 File Offset: 0x000CDD14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A04 RID: 6660
		private int? _id;

		// Token: 0x04001A05 RID: 6661
		private MulActivityTimeState? _openstate;

		// Token: 0x04001A06 RID: 6662
		private uint? _lefttime;

		// Token: 0x04001A07 RID: 6663
		private int? _dayjoincount;

		// Token: 0x04001A08 RID: 6664
		private uint? _beginmin;

		// Token: 0x04001A09 RID: 6665
		private uint? _endmin;

		// Token: 0x04001A0A RID: 6666
		private ActOpenState? _real_open_state;

		// Token: 0x04001A0B RID: 6667
		private bool? _is_playing;

		// Token: 0x04001A0C RID: 6668
		private IExtension extensionObject;
	}
}
