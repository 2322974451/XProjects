using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F1 RID: 241
	[ProtoContract(Name = "Position")]
	[Serializable]
	public class Position : IExtensible
	{
		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06000F6B RID: 3947 RVA: 0x0001FC48 File Offset: 0x0001DE48
		// (set) Token: 0x06000F6C RID: 3948 RVA: 0x0001FC75 File Offset: 0x0001DE75
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

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06000F6D RID: 3949 RVA: 0x0001FC84 File Offset: 0x0001DE84
		// (set) Token: 0x06000F6E RID: 3950 RVA: 0x0001FCA4 File Offset: 0x0001DEA4
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

		// Token: 0x06000F6F RID: 3951 RVA: 0x0001FCE8 File Offset: 0x0001DEE8
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x0001FD00 File Offset: 0x0001DF00
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06000F71 RID: 3953 RVA: 0x0001FD0C File Offset: 0x0001DF0C
		// (set) Token: 0x06000F72 RID: 3954 RVA: 0x0001FD38 File Offset: 0x0001DF38
		[ProtoMember(2, IsRequired = false, Name = "pos_x", DataFormat = DataFormat.TwosComplement)]
		public int pos_x
		{
			get
			{
				return this._pos_x ?? 0;
			}
			set
			{
				this._pos_x = new int?(value);
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x0001FD48 File Offset: 0x0001DF48
		// (set) Token: 0x06000F74 RID: 3956 RVA: 0x0001FD68 File Offset: 0x0001DF68
		[XmlIgnore]
		[Browsable(false)]
		public bool pos_xSpecified
		{
			get
			{
				return this._pos_x != null;
			}
			set
			{
				bool flag = value == (this._pos_x == null);
				if (flag)
				{
					this._pos_x = (value ? new int?(this.pos_x) : null);
				}
			}
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0001FDAC File Offset: 0x0001DFAC
		private bool ShouldSerializepos_x()
		{
			return this.pos_xSpecified;
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0001FDC4 File Offset: 0x0001DFC4
		private void Resetpos_x()
		{
			this.pos_xSpecified = false;
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06000F77 RID: 3959 RVA: 0x0001FDD0 File Offset: 0x0001DFD0
		// (set) Token: 0x06000F78 RID: 3960 RVA: 0x0001FDFC File Offset: 0x0001DFFC
		[ProtoMember(3, IsRequired = false, Name = "pos_y", DataFormat = DataFormat.TwosComplement)]
		public int pos_y
		{
			get
			{
				return this._pos_y ?? 0;
			}
			set
			{
				this._pos_y = new int?(value);
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06000F79 RID: 3961 RVA: 0x0001FE0C File Offset: 0x0001E00C
		// (set) Token: 0x06000F7A RID: 3962 RVA: 0x0001FE2C File Offset: 0x0001E02C
		[XmlIgnore]
		[Browsable(false)]
		public bool pos_ySpecified
		{
			get
			{
				return this._pos_y != null;
			}
			set
			{
				bool flag = value == (this._pos_y == null);
				if (flag)
				{
					this._pos_y = (value ? new int?(this.pos_y) : null);
				}
			}
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x0001FE70 File Offset: 0x0001E070
		private bool ShouldSerializepos_y()
		{
			return this.pos_ySpecified;
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x0001FE88 File Offset: 0x0001E088
		private void Resetpos_y()
		{
			this.pos_ySpecified = false;
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06000F7D RID: 3965 RVA: 0x0001FE94 File Offset: 0x0001E094
		// (set) Token: 0x06000F7E RID: 3966 RVA: 0x0001FEC0 File Offset: 0x0001E0C0
		[ProtoMember(4, IsRequired = false, Name = "pos_z", DataFormat = DataFormat.TwosComplement)]
		public int pos_z
		{
			get
			{
				return this._pos_z ?? 0;
			}
			set
			{
				this._pos_z = new int?(value);
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06000F7F RID: 3967 RVA: 0x0001FED0 File Offset: 0x0001E0D0
		// (set) Token: 0x06000F80 RID: 3968 RVA: 0x0001FEF0 File Offset: 0x0001E0F0
		[XmlIgnore]
		[Browsable(false)]
		public bool pos_zSpecified
		{
			get
			{
				return this._pos_z != null;
			}
			set
			{
				bool flag = value == (this._pos_z == null);
				if (flag)
				{
					this._pos_z = (value ? new int?(this.pos_z) : null);
				}
			}
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x0001FF34 File Offset: 0x0001E134
		private bool ShouldSerializepos_z()
		{
			return this.pos_zSpecified;
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x0001FF4C File Offset: 0x0001E14C
		private void Resetpos_z()
		{
			this.pos_zSpecified = false;
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x0001FF58 File Offset: 0x0001E158
		// (set) Token: 0x06000F84 RID: 3972 RVA: 0x0001FF84 File Offset: 0x0001E184
		[ProtoMember(5, IsRequired = false, Name = "face", DataFormat = DataFormat.TwosComplement)]
		public int face
		{
			get
			{
				return this._face ?? 0;
			}
			set
			{
				this._face = new int?(value);
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x0001FF94 File Offset: 0x0001E194
		// (set) Token: 0x06000F86 RID: 3974 RVA: 0x0001FFB4 File Offset: 0x0001E1B4
		[XmlIgnore]
		[Browsable(false)]
		public bool faceSpecified
		{
			get
			{
				return this._face != null;
			}
			set
			{
				bool flag = value == (this._face == null);
				if (flag)
				{
					this._face = (value ? new int?(this.face) : null);
				}
			}
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x0001FFF8 File Offset: 0x0001E1F8
		private bool ShouldSerializeface()
		{
			return this.faceSpecified;
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x00020010 File Offset: 0x0001E210
		private void Resetface()
		{
			this.faceSpecified = false;
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06000F89 RID: 3977 RVA: 0x0002001C File Offset: 0x0001E21C
		// (set) Token: 0x06000F8A RID: 3978 RVA: 0x00020048 File Offset: 0x0001E248
		[ProtoMember(6, IsRequired = false, Name = "bTransfer", DataFormat = DataFormat.Default)]
		public bool bTransfer
		{
			get
			{
				return this._bTransfer ?? false;
			}
			set
			{
				this._bTransfer = new bool?(value);
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06000F8B RID: 3979 RVA: 0x00020058 File Offset: 0x0001E258
		// (set) Token: 0x06000F8C RID: 3980 RVA: 0x00020078 File Offset: 0x0001E278
		[XmlIgnore]
		[Browsable(false)]
		public bool bTransferSpecified
		{
			get
			{
				return this._bTransfer != null;
			}
			set
			{
				bool flag = value == (this._bTransfer == null);
				if (flag)
				{
					this._bTransfer = (value ? new bool?(this.bTransfer) : null);
				}
			}
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x000200BC File Offset: 0x0001E2BC
		private bool ShouldSerializebTransfer()
		{
			return this.bTransferSpecified;
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x000200D4 File Offset: 0x0001E2D4
		private void ResetbTransfer()
		{
			this.bTransferSpecified = false;
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x000200E0 File Offset: 0x0001E2E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003DC RID: 988
		private ulong? _uid;

		// Token: 0x040003DD RID: 989
		private int? _pos_x;

		// Token: 0x040003DE RID: 990
		private int? _pos_y;

		// Token: 0x040003DF RID: 991
		private int? _pos_z;

		// Token: 0x040003E0 RID: 992
		private int? _face;

		// Token: 0x040003E1 RID: 993
		private bool? _bTransfer;

		// Token: 0x040003E2 RID: 994
		private IExtension extensionObject;
	}
}
