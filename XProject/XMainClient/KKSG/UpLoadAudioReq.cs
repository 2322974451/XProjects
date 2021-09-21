using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000150 RID: 336
	[ProtoContract(Name = "UpLoadAudioReq")]
	[Serializable]
	public class UpLoadAudioReq : IExtensible
	{
		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x06001466 RID: 5222 RVA: 0x000291E4 File Offset: 0x000273E4
		// (set) Token: 0x06001467 RID: 5223 RVA: 0x00029201 File Offset: 0x00027401
		[ProtoMember(1, IsRequired = false, Name = "audio", DataFormat = DataFormat.Default)]
		public byte[] audio
		{
			get
			{
				return this._audio ?? null;
			}
			set
			{
				this._audio = value;
			}
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06001468 RID: 5224 RVA: 0x0002920C File Offset: 0x0002740C
		// (set) Token: 0x06001469 RID: 5225 RVA: 0x00029228 File Offset: 0x00027428
		[XmlIgnore]
		[Browsable(false)]
		public bool audioSpecified
		{
			get
			{
				return this._audio != null;
			}
			set
			{
				bool flag = value == (this._audio == null);
				if (flag)
				{
					this._audio = (value ? this.audio : null);
				}
			}
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x00029258 File Offset: 0x00027458
		private bool ShouldSerializeaudio()
		{
			return this.audioSpecified;
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x00029270 File Offset: 0x00027470
		private void Resetaudio()
		{
			this.audioSpecified = false;
		}

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x0600146C RID: 5228 RVA: 0x0002927C File Offset: 0x0002747C
		// (set) Token: 0x0600146D RID: 5229 RVA: 0x00029299 File Offset: 0x00027499
		[ProtoMember(2, IsRequired = false, Name = "text", DataFormat = DataFormat.Default)]
		public byte[] text
		{
			get
			{
				return this._text ?? null;
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x0600146E RID: 5230 RVA: 0x000292A4 File Offset: 0x000274A4
		// (set) Token: 0x0600146F RID: 5231 RVA: 0x000292C0 File Offset: 0x000274C0
		[XmlIgnore]
		[Browsable(false)]
		public bool textSpecified
		{
			get
			{
				return this._text != null;
			}
			set
			{
				bool flag = value == (this._text == null);
				if (flag)
				{
					this._text = (value ? this.text : null);
				}
			}
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x000292F0 File Offset: 0x000274F0
		private bool ShouldSerializetext()
		{
			return this.textSpecified;
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x00029308 File Offset: 0x00027508
		private void Resettext()
		{
			this.textSpecified = false;
		}

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x06001472 RID: 5234 RVA: 0x00029314 File Offset: 0x00027514
		// (set) Token: 0x06001473 RID: 5235 RVA: 0x00029340 File Offset: 0x00027540
		[ProtoMember(3, IsRequired = false, Name = "srctype", DataFormat = DataFormat.TwosComplement)]
		public uint srctype
		{
			get
			{
				return this._srctype ?? 0U;
			}
			set
			{
				this._srctype = new uint?(value);
			}
		}

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x06001474 RID: 5236 RVA: 0x00029350 File Offset: 0x00027550
		// (set) Token: 0x06001475 RID: 5237 RVA: 0x00029370 File Offset: 0x00027570
		[XmlIgnore]
		[Browsable(false)]
		public bool srctypeSpecified
		{
			get
			{
				return this._srctype != null;
			}
			set
			{
				bool flag = value == (this._srctype == null);
				if (flag)
				{
					this._srctype = (value ? new uint?(this.srctype) : null);
				}
			}
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x000293B4 File Offset: 0x000275B4
		private bool ShouldSerializesrctype()
		{
			return this.srctypeSpecified;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x000293CC File Offset: 0x000275CC
		private void Resetsrctype()
		{
			this.srctypeSpecified = false;
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x06001478 RID: 5240 RVA: 0x000293D8 File Offset: 0x000275D8
		// (set) Token: 0x06001479 RID: 5241 RVA: 0x00029404 File Offset: 0x00027604
		[ProtoMember(4, IsRequired = false, Name = "savetype", DataFormat = DataFormat.TwosComplement)]
		public uint savetype
		{
			get
			{
				return this._savetype ?? 0U;
			}
			set
			{
				this._savetype = new uint?(value);
			}
		}

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x0600147A RID: 5242 RVA: 0x00029414 File Offset: 0x00027614
		// (set) Token: 0x0600147B RID: 5243 RVA: 0x00029434 File Offset: 0x00027634
		[XmlIgnore]
		[Browsable(false)]
		public bool savetypeSpecified
		{
			get
			{
				return this._savetype != null;
			}
			set
			{
				bool flag = value == (this._savetype == null);
				if (flag)
				{
					this._savetype = (value ? new uint?(this.savetype) : null);
				}
			}
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x00029478 File Offset: 0x00027678
		private bool ShouldSerializesavetype()
		{
			return this.savetypeSpecified;
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x00029490 File Offset: 0x00027690
		private void Resetsavetype()
		{
			this.savetypeSpecified = false;
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x0600147E RID: 5246 RVA: 0x0002949C File Offset: 0x0002769C
		// (set) Token: 0x0600147F RID: 5247 RVA: 0x000294C8 File Offset: 0x000276C8
		[ProtoMember(5, IsRequired = false, Name = "iscross", DataFormat = DataFormat.Default)]
		public bool iscross
		{
			get
			{
				return this._iscross ?? false;
			}
			set
			{
				this._iscross = new bool?(value);
			}
		}

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x06001480 RID: 5248 RVA: 0x000294D8 File Offset: 0x000276D8
		// (set) Token: 0x06001481 RID: 5249 RVA: 0x000294F8 File Offset: 0x000276F8
		[XmlIgnore]
		[Browsable(false)]
		public bool iscrossSpecified
		{
			get
			{
				return this._iscross != null;
			}
			set
			{
				bool flag = value == (this._iscross == null);
				if (flag)
				{
					this._iscross = (value ? new bool?(this.iscross) : null);
				}
			}
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x0002953C File Offset: 0x0002773C
		private bool ShouldSerializeiscross()
		{
			return this.iscrossSpecified;
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x00029554 File Offset: 0x00027754
		private void Resetiscross()
		{
			this.iscrossSpecified = false;
		}

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x00029560 File Offset: 0x00027760
		// (set) Token: 0x06001485 RID: 5253 RVA: 0x0002958C File Offset: 0x0002778C
		[ProtoMember(6, IsRequired = false, Name = "rpcid", DataFormat = DataFormat.TwosComplement)]
		public uint rpcid
		{
			get
			{
				return this._rpcid ?? 0U;
			}
			set
			{
				this._rpcid = new uint?(value);
			}
		}

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06001486 RID: 5254 RVA: 0x0002959C File Offset: 0x0002779C
		// (set) Token: 0x06001487 RID: 5255 RVA: 0x000295BC File Offset: 0x000277BC
		[XmlIgnore]
		[Browsable(false)]
		public bool rpcidSpecified
		{
			get
			{
				return this._rpcid != null;
			}
			set
			{
				bool flag = value == (this._rpcid == null);
				if (flag)
				{
					this._rpcid = (value ? new uint?(this.rpcid) : null);
				}
			}
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x00029600 File Offset: 0x00027800
		private bool ShouldSerializerpcid()
		{
			return this.rpcidSpecified;
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00029618 File Offset: 0x00027818
		private void Resetrpcid()
		{
			this.rpcidSpecified = false;
		}

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x0600148A RID: 5258 RVA: 0x00029624 File Offset: 0x00027824
		// (set) Token: 0x0600148B RID: 5259 RVA: 0x00029651 File Offset: 0x00027851
		[ProtoMember(7, IsRequired = false, Name = "audiouid", DataFormat = DataFormat.TwosComplement)]
		public ulong audiouid
		{
			get
			{
				return this._audiouid ?? 0UL;
			}
			set
			{
				this._audiouid = new ulong?(value);
			}
		}

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x0600148C RID: 5260 RVA: 0x00029660 File Offset: 0x00027860
		// (set) Token: 0x0600148D RID: 5261 RVA: 0x00029680 File Offset: 0x00027880
		[XmlIgnore]
		[Browsable(false)]
		public bool audiouidSpecified
		{
			get
			{
				return this._audiouid != null;
			}
			set
			{
				bool flag = value == (this._audiouid == null);
				if (flag)
				{
					this._audiouid = (value ? new ulong?(this.audiouid) : null);
				}
			}
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x000296C4 File Offset: 0x000278C4
		private bool ShouldSerializeaudiouid()
		{
			return this.audiouidSpecified;
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x000296DC File Offset: 0x000278DC
		private void Resetaudiouid()
		{
			this.audiouidSpecified = false;
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x000296E8 File Offset: 0x000278E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000517 RID: 1303
		private byte[] _audio;

		// Token: 0x04000518 RID: 1304
		private byte[] _text;

		// Token: 0x04000519 RID: 1305
		private uint? _srctype;

		// Token: 0x0400051A RID: 1306
		private uint? _savetype;

		// Token: 0x0400051B RID: 1307
		private bool? _iscross;

		// Token: 0x0400051C RID: 1308
		private uint? _rpcid;

		// Token: 0x0400051D RID: 1309
		private ulong? _audiouid;

		// Token: 0x0400051E RID: 1310
		private IExtension extensionObject;
	}
}
