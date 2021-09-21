using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C2 RID: 1474
	[ProtoContract(Name = "PositionCheck")]
	[Serializable]
	public class PositionCheck : IExtensible
	{
		// Token: 0x17001999 RID: 6553
		// (get) Token: 0x060052BA RID: 21178 RVA: 0x0009D5DC File Offset: 0x0009B7DC
		// (set) Token: 0x060052BB RID: 21179 RVA: 0x0009D609 File Offset: 0x0009B809
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

		// Token: 0x1700199A RID: 6554
		// (get) Token: 0x060052BC RID: 21180 RVA: 0x0009D618 File Offset: 0x0009B818
		// (set) Token: 0x060052BD RID: 21181 RVA: 0x0009D638 File Offset: 0x0009B838
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

		// Token: 0x060052BE RID: 21182 RVA: 0x0009D67C File Offset: 0x0009B87C
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060052BF RID: 21183 RVA: 0x0009D694 File Offset: 0x0009B894
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x1700199B RID: 6555
		// (get) Token: 0x060052C0 RID: 21184 RVA: 0x0009D6A0 File Offset: 0x0009B8A0
		// (set) Token: 0x060052C1 RID: 21185 RVA: 0x0009D6B8 File Offset: 0x0009B8B8
		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		// Token: 0x1700199C RID: 6556
		// (get) Token: 0x060052C2 RID: 21186 RVA: 0x0009D6C4 File Offset: 0x0009B8C4
		// (set) Token: 0x060052C3 RID: 21187 RVA: 0x0009D6F4 File Offset: 0x0009B8F4
		[ProtoMember(3, IsRequired = false, Name = "face", DataFormat = DataFormat.FixedSize)]
		public float face
		{
			get
			{
				return this._face ?? 0f;
			}
			set
			{
				this._face = new float?(value);
			}
		}

		// Token: 0x1700199D RID: 6557
		// (get) Token: 0x060052C4 RID: 21188 RVA: 0x0009D704 File Offset: 0x0009B904
		// (set) Token: 0x060052C5 RID: 21189 RVA: 0x0009D724 File Offset: 0x0009B924
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
					this._face = (value ? new float?(this.face) : null);
				}
			}
		}

		// Token: 0x060052C6 RID: 21190 RVA: 0x0009D768 File Offset: 0x0009B968
		private bool ShouldSerializeface()
		{
			return this.faceSpecified;
		}

		// Token: 0x060052C7 RID: 21191 RVA: 0x0009D780 File Offset: 0x0009B980
		private void Resetface()
		{
			this.faceSpecified = false;
		}

		// Token: 0x060052C8 RID: 21192 RVA: 0x0009D78C File Offset: 0x0009B98C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400143B RID: 5179
		private ulong? _uid;

		// Token: 0x0400143C RID: 5180
		private Vec3 _position = null;

		// Token: 0x0400143D RID: 5181
		private float? _face;

		// Token: 0x0400143E RID: 5182
		private IExtension extensionObject;
	}
}
