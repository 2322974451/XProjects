using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200067A RID: 1658
	[ProtoContract(Name = "NpcFeelingOneNpc")]
	[Serializable]
	public class NpcFeelingOneNpc : IExtensible
	{
		// Token: 0x17002196 RID: 8598
		// (get) Token: 0x06006A25 RID: 27173 RVA: 0x000CAFA8 File Offset: 0x000C91A8
		// (set) Token: 0x06006A26 RID: 27174 RVA: 0x000CAFD4 File Offset: 0x000C91D4
		[ProtoMember(1, IsRequired = false, Name = "npcid", DataFormat = DataFormat.TwosComplement)]
		public uint npcid
		{
			get
			{
				return this._npcid ?? 0U;
			}
			set
			{
				this._npcid = new uint?(value);
			}
		}

		// Token: 0x17002197 RID: 8599
		// (get) Token: 0x06006A27 RID: 27175 RVA: 0x000CAFE4 File Offset: 0x000C91E4
		// (set) Token: 0x06006A28 RID: 27176 RVA: 0x000CB004 File Offset: 0x000C9204
		[XmlIgnore]
		[Browsable(false)]
		public bool npcidSpecified
		{
			get
			{
				return this._npcid != null;
			}
			set
			{
				bool flag = value == (this._npcid == null);
				if (flag)
				{
					this._npcid = (value ? new uint?(this.npcid) : null);
				}
			}
		}

		// Token: 0x06006A29 RID: 27177 RVA: 0x000CB048 File Offset: 0x000C9248
		private bool ShouldSerializenpcid()
		{
			return this.npcidSpecified;
		}

		// Token: 0x06006A2A RID: 27178 RVA: 0x000CB060 File Offset: 0x000C9260
		private void Resetnpcid()
		{
			this.npcidSpecified = false;
		}

		// Token: 0x17002198 RID: 8600
		// (get) Token: 0x06006A2B RID: 27179 RVA: 0x000CB06C File Offset: 0x000C926C
		// (set) Token: 0x06006A2C RID: 27180 RVA: 0x000CB098 File Offset: 0x000C9298
		[ProtoMember(2, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002199 RID: 8601
		// (get) Token: 0x06006A2D RID: 27181 RVA: 0x000CB0A8 File Offset: 0x000C92A8
		// (set) Token: 0x06006A2E RID: 27182 RVA: 0x000CB0C8 File Offset: 0x000C92C8
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

		// Token: 0x06006A2F RID: 27183 RVA: 0x000CB10C File Offset: 0x000C930C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06006A30 RID: 27184 RVA: 0x000CB124 File Offset: 0x000C9324
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x1700219A RID: 8602
		// (get) Token: 0x06006A31 RID: 27185 RVA: 0x000CB130 File Offset: 0x000C9330
		// (set) Token: 0x06006A32 RID: 27186 RVA: 0x000CB15C File Offset: 0x000C935C
		[ProtoMember(3, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700219B RID: 8603
		// (get) Token: 0x06006A33 RID: 27187 RVA: 0x000CB16C File Offset: 0x000C936C
		// (set) Token: 0x06006A34 RID: 27188 RVA: 0x000CB18C File Offset: 0x000C938C
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

		// Token: 0x06006A35 RID: 27189 RVA: 0x000CB1D0 File Offset: 0x000C93D0
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06006A36 RID: 27190 RVA: 0x000CB1E8 File Offset: 0x000C93E8
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x1700219C RID: 8604
		// (get) Token: 0x06006A37 RID: 27191 RVA: 0x000CB1F4 File Offset: 0x000C93F4
		[ProtoMember(4, Name = "likeitem", DataFormat = DataFormat.Default)]
		public List<NpcLikeItem> likeitem
		{
			get
			{
				return this._likeitem;
			}
		}

		// Token: 0x1700219D RID: 8605
		// (get) Token: 0x06006A38 RID: 27192 RVA: 0x000CB20C File Offset: 0x000C940C
		[ProtoMember(5, Name = "exchange", DataFormat = DataFormat.Default)]
		public List<ItemBrief> exchange
		{
			get
			{
				return this._exchange;
			}
		}

		// Token: 0x1700219E RID: 8606
		// (get) Token: 0x06006A39 RID: 27193 RVA: 0x000CB224 File Offset: 0x000C9424
		// (set) Token: 0x06006A3A RID: 27194 RVA: 0x000CB250 File Offset: 0x000C9450
		[ProtoMember(6, IsRequired = false, Name = "isnew", DataFormat = DataFormat.Default)]
		public bool isnew
		{
			get
			{
				return this._isnew ?? false;
			}
			set
			{
				this._isnew = new bool?(value);
			}
		}

		// Token: 0x1700219F RID: 8607
		// (get) Token: 0x06006A3B RID: 27195 RVA: 0x000CB260 File Offset: 0x000C9460
		// (set) Token: 0x06006A3C RID: 27196 RVA: 0x000CB280 File Offset: 0x000C9480
		[XmlIgnore]
		[Browsable(false)]
		public bool isnewSpecified
		{
			get
			{
				return this._isnew != null;
			}
			set
			{
				bool flag = value == (this._isnew == null);
				if (flag)
				{
					this._isnew = (value ? new bool?(this.isnew) : null);
				}
			}
		}

		// Token: 0x06006A3D RID: 27197 RVA: 0x000CB2C4 File Offset: 0x000C94C4
		private bool ShouldSerializeisnew()
		{
			return this.isnewSpecified;
		}

		// Token: 0x06006A3E RID: 27198 RVA: 0x000CB2DC File Offset: 0x000C94DC
		private void Resetisnew()
		{
			this.isnewSpecified = false;
		}

		// Token: 0x06006A3F RID: 27199 RVA: 0x000CB2E8 File Offset: 0x000C94E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001992 RID: 6546
		private uint? _npcid;

		// Token: 0x04001993 RID: 6547
		private uint? _level;

		// Token: 0x04001994 RID: 6548
		private uint? _exp;

		// Token: 0x04001995 RID: 6549
		private readonly List<NpcLikeItem> _likeitem = new List<NpcLikeItem>();

		// Token: 0x04001996 RID: 6550
		private readonly List<ItemBrief> _exchange = new List<ItemBrief>();

		// Token: 0x04001997 RID: 6551
		private bool? _isnew;

		// Token: 0x04001998 RID: 6552
		private IExtension extensionObject;
	}
}
