using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000616 RID: 1558
	[ProtoContract(Name = "PvpOneRec")]
	[Serializable]
	public class PvpOneRec : IExtensible
	{
		// Token: 0x17001DAA RID: 7594
		// (get) Token: 0x06005E8A RID: 24202 RVA: 0x000B4414 File Offset: 0x000B2614
		// (set) Token: 0x06005E8B RID: 24203 RVA: 0x000B4440 File Offset: 0x000B2640
		[ProtoMember(1, IsRequired = false, Name = "wincount", DataFormat = DataFormat.TwosComplement)]
		public int wincount
		{
			get
			{
				return this._wincount ?? 0;
			}
			set
			{
				this._wincount = new int?(value);
			}
		}

		// Token: 0x17001DAB RID: 7595
		// (get) Token: 0x06005E8C RID: 24204 RVA: 0x000B4450 File Offset: 0x000B2650
		// (set) Token: 0x06005E8D RID: 24205 RVA: 0x000B4470 File Offset: 0x000B2670
		[XmlIgnore]
		[Browsable(false)]
		public bool wincountSpecified
		{
			get
			{
				return this._wincount != null;
			}
			set
			{
				bool flag = value == (this._wincount == null);
				if (flag)
				{
					this._wincount = (value ? new int?(this.wincount) : null);
				}
			}
		}

		// Token: 0x06005E8E RID: 24206 RVA: 0x000B44B4 File Offset: 0x000B26B4
		private bool ShouldSerializewincount()
		{
			return this.wincountSpecified;
		}

		// Token: 0x06005E8F RID: 24207 RVA: 0x000B44CC File Offset: 0x000B26CC
		private void Resetwincount()
		{
			this.wincountSpecified = false;
		}

		// Token: 0x17001DAC RID: 7596
		// (get) Token: 0x06005E90 RID: 24208 RVA: 0x000B44D8 File Offset: 0x000B26D8
		// (set) Token: 0x06005E91 RID: 24209 RVA: 0x000B4504 File Offset: 0x000B2704
		[ProtoMember(2, IsRequired = false, Name = "losecount", DataFormat = DataFormat.TwosComplement)]
		public int losecount
		{
			get
			{
				return this._losecount ?? 0;
			}
			set
			{
				this._losecount = new int?(value);
			}
		}

		// Token: 0x17001DAD RID: 7597
		// (get) Token: 0x06005E92 RID: 24210 RVA: 0x000B4514 File Offset: 0x000B2714
		// (set) Token: 0x06005E93 RID: 24211 RVA: 0x000B4534 File Offset: 0x000B2734
		[XmlIgnore]
		[Browsable(false)]
		public bool losecountSpecified
		{
			get
			{
				return this._losecount != null;
			}
			set
			{
				bool flag = value == (this._losecount == null);
				if (flag)
				{
					this._losecount = (value ? new int?(this.losecount) : null);
				}
			}
		}

		// Token: 0x06005E94 RID: 24212 RVA: 0x000B4578 File Offset: 0x000B2778
		private bool ShouldSerializelosecount()
		{
			return this.losecountSpecified;
		}

		// Token: 0x06005E95 RID: 24213 RVA: 0x000B4590 File Offset: 0x000B2790
		private void Resetlosecount()
		{
			this.losecountSpecified = false;
		}

		// Token: 0x17001DAE RID: 7598
		// (get) Token: 0x06005E96 RID: 24214 RVA: 0x000B459C File Offset: 0x000B279C
		// (set) Token: 0x06005E97 RID: 24215 RVA: 0x000B45C8 File Offset: 0x000B27C8
		[ProtoMember(3, IsRequired = false, Name = "drawcount", DataFormat = DataFormat.TwosComplement)]
		public int drawcount
		{
			get
			{
				return this._drawcount ?? 0;
			}
			set
			{
				this._drawcount = new int?(value);
			}
		}

		// Token: 0x17001DAF RID: 7599
		// (get) Token: 0x06005E98 RID: 24216 RVA: 0x000B45D8 File Offset: 0x000B27D8
		// (set) Token: 0x06005E99 RID: 24217 RVA: 0x000B45F8 File Offset: 0x000B27F8
		[XmlIgnore]
		[Browsable(false)]
		public bool drawcountSpecified
		{
			get
			{
				return this._drawcount != null;
			}
			set
			{
				bool flag = value == (this._drawcount == null);
				if (flag)
				{
					this._drawcount = (value ? new int?(this.drawcount) : null);
				}
			}
		}

		// Token: 0x06005E9A RID: 24218 RVA: 0x000B463C File Offset: 0x000B283C
		private bool ShouldSerializedrawcount()
		{
			return this.drawcountSpecified;
		}

		// Token: 0x06005E9B RID: 24219 RVA: 0x000B4654 File Offset: 0x000B2854
		private void Resetdrawcount()
		{
			this.drawcountSpecified = false;
		}

		// Token: 0x17001DB0 RID: 7600
		// (get) Token: 0x06005E9C RID: 24220 RVA: 0x000B4660 File Offset: 0x000B2860
		// (set) Token: 0x06005E9D RID: 24221 RVA: 0x000B468D File Offset: 0x000B288D
		[ProtoMember(4, IsRequired = false, Name = "mvpID", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpID
		{
			get
			{
				return this._mvpID ?? 0UL;
			}
			set
			{
				this._mvpID = new ulong?(value);
			}
		}

		// Token: 0x17001DB1 RID: 7601
		// (get) Token: 0x06005E9E RID: 24222 RVA: 0x000B469C File Offset: 0x000B289C
		// (set) Token: 0x06005E9F RID: 24223 RVA: 0x000B46BC File Offset: 0x000B28BC
		[XmlIgnore]
		[Browsable(false)]
		public bool mvpIDSpecified
		{
			get
			{
				return this._mvpID != null;
			}
			set
			{
				bool flag = value == (this._mvpID == null);
				if (flag)
				{
					this._mvpID = (value ? new ulong?(this.mvpID) : null);
				}
			}
		}

		// Token: 0x06005EA0 RID: 24224 RVA: 0x000B4700 File Offset: 0x000B2900
		private bool ShouldSerializemvpID()
		{
			return this.mvpIDSpecified;
		}

		// Token: 0x06005EA1 RID: 24225 RVA: 0x000B4718 File Offset: 0x000B2918
		private void ResetmvpID()
		{
			this.mvpIDSpecified = false;
		}

		// Token: 0x17001DB2 RID: 7602
		// (get) Token: 0x06005EA2 RID: 24226 RVA: 0x000B4724 File Offset: 0x000B2924
		[ProtoMember(5, Name = "myside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> myside
		{
			get
			{
				return this._myside;
			}
		}

		// Token: 0x17001DB3 RID: 7603
		// (get) Token: 0x06005EA3 RID: 24227 RVA: 0x000B473C File Offset: 0x000B293C
		[ProtoMember(6, Name = "opside", DataFormat = DataFormat.Default)]
		public List<PvpRoleBrief> opside
		{
			get
			{
				return this._opside;
			}
		}

		// Token: 0x17001DB4 RID: 7604
		// (get) Token: 0x06005EA4 RID: 24228 RVA: 0x000B4754 File Offset: 0x000B2954
		// (set) Token: 0x06005EA5 RID: 24229 RVA: 0x000B4780 File Offset: 0x000B2980
		[ProtoMember(7, IsRequired = false, Name = "military", DataFormat = DataFormat.TwosComplement)]
		public uint military
		{
			get
			{
				return this._military ?? 0U;
			}
			set
			{
				this._military = new uint?(value);
			}
		}

		// Token: 0x17001DB5 RID: 7605
		// (get) Token: 0x06005EA6 RID: 24230 RVA: 0x000B4790 File Offset: 0x000B2990
		// (set) Token: 0x06005EA7 RID: 24231 RVA: 0x000B47B0 File Offset: 0x000B29B0
		[XmlIgnore]
		[Browsable(false)]
		public bool militarySpecified
		{
			get
			{
				return this._military != null;
			}
			set
			{
				bool flag = value == (this._military == null);
				if (flag)
				{
					this._military = (value ? new uint?(this.military) : null);
				}
			}
		}

		// Token: 0x06005EA8 RID: 24232 RVA: 0x000B47F4 File Offset: 0x000B29F4
		private bool ShouldSerializemilitary()
		{
			return this.militarySpecified;
		}

		// Token: 0x06005EA9 RID: 24233 RVA: 0x000B480C File Offset: 0x000B2A0C
		private void Resetmilitary()
		{
			this.militarySpecified = false;
		}

		// Token: 0x06005EAA RID: 24234 RVA: 0x000B4818 File Offset: 0x000B2A18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016F2 RID: 5874
		private int? _wincount;

		// Token: 0x040016F3 RID: 5875
		private int? _losecount;

		// Token: 0x040016F4 RID: 5876
		private int? _drawcount;

		// Token: 0x040016F5 RID: 5877
		private ulong? _mvpID;

		// Token: 0x040016F6 RID: 5878
		private readonly List<PvpRoleBrief> _myside = new List<PvpRoleBrief>();

		// Token: 0x040016F7 RID: 5879
		private readonly List<PvpRoleBrief> _opside = new List<PvpRoleBrief>();

		// Token: 0x040016F8 RID: 5880
		private uint? _military;

		// Token: 0x040016F9 RID: 5881
		private IExtension extensionObject;
	}
}
