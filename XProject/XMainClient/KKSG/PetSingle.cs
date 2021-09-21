using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200057D RID: 1405
	[ProtoContract(Name = "PetSingle")]
	[Serializable]
	public class PetSingle : IExtensible
	{
		// Token: 0x17001647 RID: 5703
		// (get) Token: 0x0600489C RID: 18588 RVA: 0x00089F7C File Offset: 0x0008817C
		// (set) Token: 0x0600489D RID: 18589 RVA: 0x00089FA9 File Offset: 0x000881A9
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17001648 RID: 5704
		// (get) Token: 0x0600489E RID: 18590 RVA: 0x00089FB8 File Offset: 0x000881B8
		// (set) Token: 0x0600489F RID: 18591 RVA: 0x00089FD8 File Offset: 0x000881D8
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x060048A0 RID: 18592 RVA: 0x0008A01C File Offset: 0x0008821C
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060048A1 RID: 18593 RVA: 0x0008A034 File Offset: 0x00088234
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17001649 RID: 5705
		// (get) Token: 0x060048A2 RID: 18594 RVA: 0x0008A040 File Offset: 0x00088240
		// (set) Token: 0x060048A3 RID: 18595 RVA: 0x0008A06C File Offset: 0x0008826C
		[ProtoMember(2, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public uint petid
		{
			get
			{
				return this._petid ?? 0U;
			}
			set
			{
				this._petid = new uint?(value);
			}
		}

		// Token: 0x1700164A RID: 5706
		// (get) Token: 0x060048A4 RID: 18596 RVA: 0x0008A07C File Offset: 0x0008827C
		// (set) Token: 0x060048A5 RID: 18597 RVA: 0x0008A09C File Offset: 0x0008829C
		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new uint?(this.petid) : null);
				}
			}
		}

		// Token: 0x060048A6 RID: 18598 RVA: 0x0008A0E0 File Offset: 0x000882E0
		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		// Token: 0x060048A7 RID: 18599 RVA: 0x0008A0F8 File Offset: 0x000882F8
		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		// Token: 0x1700164B RID: 5707
		// (get) Token: 0x060048A8 RID: 18600 RVA: 0x0008A104 File Offset: 0x00088304
		// (set) Token: 0x060048A9 RID: 18601 RVA: 0x0008A130 File Offset: 0x00088330
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x1700164C RID: 5708
		// (get) Token: 0x060048AA RID: 18602 RVA: 0x0008A140 File Offset: 0x00088340
		// (set) Token: 0x060048AB RID: 18603 RVA: 0x0008A160 File Offset: 0x00088360
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x060048AC RID: 18604 RVA: 0x0008A1A4 File Offset: 0x000883A4
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060048AD RID: 18605 RVA: 0x0008A1BC File Offset: 0x000883BC
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x1700164D RID: 5709
		// (get) Token: 0x060048AE RID: 18606 RVA: 0x0008A1C8 File Offset: 0x000883C8
		// (set) Token: 0x060048AF RID: 18607 RVA: 0x0008A1F4 File Offset: 0x000883F4
		[ProtoMember(4, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		// Token: 0x1700164E RID: 5710
		// (get) Token: 0x060048B0 RID: 18608 RVA: 0x0008A204 File Offset: 0x00088404
		// (set) Token: 0x060048B1 RID: 18609 RVA: 0x0008A224 File Offset: 0x00088424
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		// Token: 0x060048B2 RID: 18610 RVA: 0x0008A268 File Offset: 0x00088468
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x060048B3 RID: 18611 RVA: 0x0008A280 File Offset: 0x00088480
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x1700164F RID: 5711
		// (get) Token: 0x060048B4 RID: 18612 RVA: 0x0008A28C File Offset: 0x0008848C
		// (set) Token: 0x060048B5 RID: 18613 RVA: 0x0008A2B8 File Offset: 0x000884B8
		[ProtoMember(5, IsRequired = false, Name = "sex", DataFormat = DataFormat.TwosComplement)]
		public uint sex
		{
			get
			{
				return this._sex ?? 0U;
			}
			set
			{
				this._sex = new uint?(value);
			}
		}

		// Token: 0x17001650 RID: 5712
		// (get) Token: 0x060048B6 RID: 18614 RVA: 0x0008A2C8 File Offset: 0x000884C8
		// (set) Token: 0x060048B7 RID: 18615 RVA: 0x0008A2E8 File Offset: 0x000884E8
		[XmlIgnore]
		[Browsable(false)]
		public bool sexSpecified
		{
			get
			{
				return this._sex != null;
			}
			set
			{
				bool flag = value == (this._sex == null);
				if (flag)
				{
					this._sex = (value ? new uint?(this.sex) : null);
				}
			}
		}

		// Token: 0x060048B8 RID: 18616 RVA: 0x0008A32C File Offset: 0x0008852C
		private bool ShouldSerializesex()
		{
			return this.sexSpecified;
		}

		// Token: 0x060048B9 RID: 18617 RVA: 0x0008A344 File Offset: 0x00088544
		private void Resetsex()
		{
			this.sexSpecified = false;
		}

		// Token: 0x17001651 RID: 5713
		// (get) Token: 0x060048BA RID: 18618 RVA: 0x0008A350 File Offset: 0x00088550
		// (set) Token: 0x060048BB RID: 18619 RVA: 0x0008A37C File Offset: 0x0008857C
		[ProtoMember(6, IsRequired = false, Name = "power", DataFormat = DataFormat.TwosComplement)]
		public uint power
		{
			get
			{
				return this._power ?? 0U;
			}
			set
			{
				this._power = new uint?(value);
			}
		}

		// Token: 0x17001652 RID: 5714
		// (get) Token: 0x060048BC RID: 18620 RVA: 0x0008A38C File Offset: 0x0008858C
		// (set) Token: 0x060048BD RID: 18621 RVA: 0x0008A3AC File Offset: 0x000885AC
		[XmlIgnore]
		[Browsable(false)]
		public bool powerSpecified
		{
			get
			{
				return this._power != null;
			}
			set
			{
				bool flag = value == (this._power == null);
				if (flag)
				{
					this._power = (value ? new uint?(this.power) : null);
				}
			}
		}

		// Token: 0x060048BE RID: 18622 RVA: 0x0008A3F0 File Offset: 0x000885F0
		private bool ShouldSerializepower()
		{
			return this.powerSpecified;
		}

		// Token: 0x060048BF RID: 18623 RVA: 0x0008A408 File Offset: 0x00088608
		private void Resetpower()
		{
			this.powerSpecified = false;
		}

		// Token: 0x17001653 RID: 5715
		// (get) Token: 0x060048C0 RID: 18624 RVA: 0x0008A414 File Offset: 0x00088614
		// (set) Token: 0x060048C1 RID: 18625 RVA: 0x0008A440 File Offset: 0x00088640
		[ProtoMember(7, IsRequired = false, Name = "mood", DataFormat = DataFormat.TwosComplement)]
		public uint mood
		{
			get
			{
				return this._mood ?? 0U;
			}
			set
			{
				this._mood = new uint?(value);
			}
		}

		// Token: 0x17001654 RID: 5716
		// (get) Token: 0x060048C2 RID: 18626 RVA: 0x0008A450 File Offset: 0x00088650
		// (set) Token: 0x060048C3 RID: 18627 RVA: 0x0008A470 File Offset: 0x00088670
		[XmlIgnore]
		[Browsable(false)]
		public bool moodSpecified
		{
			get
			{
				return this._mood != null;
			}
			set
			{
				bool flag = value == (this._mood == null);
				if (flag)
				{
					this._mood = (value ? new uint?(this.mood) : null);
				}
			}
		}

		// Token: 0x060048C4 RID: 18628 RVA: 0x0008A4B4 File Offset: 0x000886B4
		private bool ShouldSerializemood()
		{
			return this.moodSpecified;
		}

		// Token: 0x060048C5 RID: 18629 RVA: 0x0008A4CC File Offset: 0x000886CC
		private void Resetmood()
		{
			this.moodSpecified = false;
		}

		// Token: 0x17001655 RID: 5717
		// (get) Token: 0x060048C6 RID: 18630 RVA: 0x0008A4D8 File Offset: 0x000886D8
		// (set) Token: 0x060048C7 RID: 18631 RVA: 0x0008A504 File Offset: 0x00088704
		[ProtoMember(8, IsRequired = false, Name = "hungry", DataFormat = DataFormat.TwosComplement)]
		public uint hungry
		{
			get
			{
				return this._hungry ?? 0U;
			}
			set
			{
				this._hungry = new uint?(value);
			}
		}

		// Token: 0x17001656 RID: 5718
		// (get) Token: 0x060048C8 RID: 18632 RVA: 0x0008A514 File Offset: 0x00088714
		// (set) Token: 0x060048C9 RID: 18633 RVA: 0x0008A534 File Offset: 0x00088734
		[XmlIgnore]
		[Browsable(false)]
		public bool hungrySpecified
		{
			get
			{
				return this._hungry != null;
			}
			set
			{
				bool flag = value == (this._hungry == null);
				if (flag)
				{
					this._hungry = (value ? new uint?(this.hungry) : null);
				}
			}
		}

		// Token: 0x060048CA RID: 18634 RVA: 0x0008A578 File Offset: 0x00088778
		private bool ShouldSerializehungry()
		{
			return this.hungrySpecified;
		}

		// Token: 0x060048CB RID: 18635 RVA: 0x0008A590 File Offset: 0x00088790
		private void Resethungry()
		{
			this.hungrySpecified = false;
		}

		// Token: 0x17001657 RID: 5719
		// (get) Token: 0x060048CC RID: 18636 RVA: 0x0008A59C File Offset: 0x0008879C
		[ProtoMember(9, Name = "fixedskills", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fixedskills
		{
			get
			{
				return this._fixedskills;
			}
		}

		// Token: 0x17001658 RID: 5720
		// (get) Token: 0x060048CD RID: 18637 RVA: 0x0008A5B4 File Offset: 0x000887B4
		[ProtoMember(10, Name = "randskills", DataFormat = DataFormat.TwosComplement)]
		public List<uint> randskills
		{
			get
			{
				return this._randskills;
			}
		}

		// Token: 0x17001659 RID: 5721
		// (get) Token: 0x060048CE RID: 18638 RVA: 0x0008A5CC File Offset: 0x000887CC
		// (set) Token: 0x060048CF RID: 18639 RVA: 0x0008A5E4 File Offset: 0x000887E4
		[ProtoMember(11, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SPetRecord record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		// Token: 0x1700165A RID: 5722
		// (get) Token: 0x060048D0 RID: 18640 RVA: 0x0008A5F0 File Offset: 0x000887F0
		// (set) Token: 0x060048D1 RID: 18641 RVA: 0x0008A61C File Offset: 0x0008881C
		[ProtoMember(12, IsRequired = false, Name = "max_level", DataFormat = DataFormat.TwosComplement)]
		public uint max_level
		{
			get
			{
				return this._max_level ?? 0U;
			}
			set
			{
				this._max_level = new uint?(value);
			}
		}

		// Token: 0x1700165B RID: 5723
		// (get) Token: 0x060048D2 RID: 18642 RVA: 0x0008A62C File Offset: 0x0008882C
		// (set) Token: 0x060048D3 RID: 18643 RVA: 0x0008A64C File Offset: 0x0008884C
		[XmlIgnore]
		[Browsable(false)]
		public bool max_levelSpecified
		{
			get
			{
				return this._max_level != null;
			}
			set
			{
				bool flag = value == (this._max_level == null);
				if (flag)
				{
					this._max_level = (value ? new uint?(this.max_level) : null);
				}
			}
		}

		// Token: 0x060048D4 RID: 18644 RVA: 0x0008A690 File Offset: 0x00088890
		private bool ShouldSerializemax_level()
		{
			return this.max_levelSpecified;
		}

		// Token: 0x060048D5 RID: 18645 RVA: 0x0008A6A8 File Offset: 0x000888A8
		private void Resetmax_level()
		{
			this.max_levelSpecified = false;
		}

		// Token: 0x1700165C RID: 5724
		// (get) Token: 0x060048D6 RID: 18646 RVA: 0x0008A6B4 File Offset: 0x000888B4
		// (set) Token: 0x060048D7 RID: 18647 RVA: 0x0008A6E0 File Offset: 0x000888E0
		[ProtoMember(13, IsRequired = false, Name = "canpairride", DataFormat = DataFormat.Default)]
		public bool canpairride
		{
			get
			{
				return this._canpairride ?? false;
			}
			set
			{
				this._canpairride = new bool?(value);
			}
		}

		// Token: 0x1700165D RID: 5725
		// (get) Token: 0x060048D8 RID: 18648 RVA: 0x0008A6F0 File Offset: 0x000888F0
		// (set) Token: 0x060048D9 RID: 18649 RVA: 0x0008A710 File Offset: 0x00088910
		[XmlIgnore]
		[Browsable(false)]
		public bool canpairrideSpecified
		{
			get
			{
				return this._canpairride != null;
			}
			set
			{
				bool flag = value == (this._canpairride == null);
				if (flag)
				{
					this._canpairride = (value ? new bool?(this.canpairride) : null);
				}
			}
		}

		// Token: 0x060048DA RID: 18650 RVA: 0x0008A754 File Offset: 0x00088954
		private bool ShouldSerializecanpairride()
		{
			return this.canpairrideSpecified;
		}

		// Token: 0x060048DB RID: 18651 RVA: 0x0008A76C File Offset: 0x0008896C
		private void Resetcanpairride()
		{
			this.canpairrideSpecified = false;
		}

		// Token: 0x060048DC RID: 18652 RVA: 0x0008A778 File Offset: 0x00088978
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400122C RID: 4652
		private ulong? _uid;

		// Token: 0x0400122D RID: 4653
		private uint? _petid;

		// Token: 0x0400122E RID: 4654
		private uint? _level;

		// Token: 0x0400122F RID: 4655
		private uint? _exp;

		// Token: 0x04001230 RID: 4656
		private uint? _sex;

		// Token: 0x04001231 RID: 4657
		private uint? _power;

		// Token: 0x04001232 RID: 4658
		private uint? _mood;

		// Token: 0x04001233 RID: 4659
		private uint? _hungry;

		// Token: 0x04001234 RID: 4660
		private readonly List<uint> _fixedskills = new List<uint>();

		// Token: 0x04001235 RID: 4661
		private readonly List<uint> _randskills = new List<uint>();

		// Token: 0x04001236 RID: 4662
		private SPetRecord _record = null;

		// Token: 0x04001237 RID: 4663
		private uint? _max_level;

		// Token: 0x04001238 RID: 4664
		private bool? _canpairride;

		// Token: 0x04001239 RID: 4665
		private IExtension extensionObject;
	}
}
