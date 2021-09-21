using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000560 RID: 1376
	[ProtoContract(Name = "Vec3")]
	[Serializable]
	public class Vec3 : IExtensible
	{
		// Token: 0x17001580 RID: 5504
		// (get) Token: 0x0600466A RID: 18026 RVA: 0x00085BEC File Offset: 0x00083DEC
		// (set) Token: 0x0600466B RID: 18027 RVA: 0x00085C1C File Offset: 0x00083E1C
		[ProtoMember(1, IsRequired = false, Name = "x", DataFormat = DataFormat.FixedSize)]
		public float x
		{
			get
			{
				return this._x ?? 0f;
			}
			set
			{
				this._x = new float?(value);
			}
		}

		// Token: 0x17001581 RID: 5505
		// (get) Token: 0x0600466C RID: 18028 RVA: 0x00085C2C File Offset: 0x00083E2C
		// (set) Token: 0x0600466D RID: 18029 RVA: 0x00085C4C File Offset: 0x00083E4C
		[XmlIgnore]
		[Browsable(false)]
		public bool xSpecified
		{
			get
			{
				return this._x != null;
			}
			set
			{
				bool flag = value == (this._x == null);
				if (flag)
				{
					this._x = (value ? new float?(this.x) : null);
				}
			}
		}

		// Token: 0x0600466E RID: 18030 RVA: 0x00085C90 File Offset: 0x00083E90
		private bool ShouldSerializex()
		{
			return this.xSpecified;
		}

		// Token: 0x0600466F RID: 18031 RVA: 0x00085CA8 File Offset: 0x00083EA8
		private void Resetx()
		{
			this.xSpecified = false;
		}

		// Token: 0x17001582 RID: 5506
		// (get) Token: 0x06004670 RID: 18032 RVA: 0x00085CB4 File Offset: 0x00083EB4
		// (set) Token: 0x06004671 RID: 18033 RVA: 0x00085CE4 File Offset: 0x00083EE4
		[ProtoMember(2, IsRequired = false, Name = "y", DataFormat = DataFormat.FixedSize)]
		public float y
		{
			get
			{
				return this._y ?? 0f;
			}
			set
			{
				this._y = new float?(value);
			}
		}

		// Token: 0x17001583 RID: 5507
		// (get) Token: 0x06004672 RID: 18034 RVA: 0x00085CF4 File Offset: 0x00083EF4
		// (set) Token: 0x06004673 RID: 18035 RVA: 0x00085D14 File Offset: 0x00083F14
		[XmlIgnore]
		[Browsable(false)]
		public bool ySpecified
		{
			get
			{
				return this._y != null;
			}
			set
			{
				bool flag = value == (this._y == null);
				if (flag)
				{
					this._y = (value ? new float?(this.y) : null);
				}
			}
		}

		// Token: 0x06004674 RID: 18036 RVA: 0x00085D58 File Offset: 0x00083F58
		private bool ShouldSerializey()
		{
			return this.ySpecified;
		}

		// Token: 0x06004675 RID: 18037 RVA: 0x00085D70 File Offset: 0x00083F70
		private void Resety()
		{
			this.ySpecified = false;
		}

		// Token: 0x17001584 RID: 5508
		// (get) Token: 0x06004676 RID: 18038 RVA: 0x00085D7C File Offset: 0x00083F7C
		// (set) Token: 0x06004677 RID: 18039 RVA: 0x00085DAC File Offset: 0x00083FAC
		[ProtoMember(3, IsRequired = false, Name = "z", DataFormat = DataFormat.FixedSize)]
		public float z
		{
			get
			{
				return this._z ?? 0f;
			}
			set
			{
				this._z = new float?(value);
			}
		}

		// Token: 0x17001585 RID: 5509
		// (get) Token: 0x06004678 RID: 18040 RVA: 0x00085DBC File Offset: 0x00083FBC
		// (set) Token: 0x06004679 RID: 18041 RVA: 0x00085DDC File Offset: 0x00083FDC
		[XmlIgnore]
		[Browsable(false)]
		public bool zSpecified
		{
			get
			{
				return this._z != null;
			}
			set
			{
				bool flag = value == (this._z == null);
				if (flag)
				{
					this._z = (value ? new float?(this.z) : null);
				}
			}
		}

		// Token: 0x0600467A RID: 18042 RVA: 0x00085E20 File Offset: 0x00084020
		private bool ShouldSerializez()
		{
			return this.zSpecified;
		}

		// Token: 0x0600467B RID: 18043 RVA: 0x00085E38 File Offset: 0x00084038
		private void Resetz()
		{
			this.zSpecified = false;
		}

		// Token: 0x0600467C RID: 18044 RVA: 0x00085E44 File Offset: 0x00084044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001190 RID: 4496
		private float? _x;

		// Token: 0x04001191 RID: 4497
		private float? _y;

		// Token: 0x04001192 RID: 4498
		private float? _z;

		// Token: 0x04001193 RID: 4499
		private IExtension extensionObject;
	}
}
