using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200070B RID: 1803
	[ProtoContract(Name = "CustomBattleRank")]
	[Serializable]
	public class CustomBattleRank : IExtensible
	{
		// Token: 0x170026B8 RID: 9912
		// (get) Token: 0x06007A2E RID: 31278 RVA: 0x000E98B8 File Offset: 0x000E7AB8
		// (set) Token: 0x06007A2F RID: 31279 RVA: 0x000E98E5 File Offset: 0x000E7AE5
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170026B9 RID: 9913
		// (get) Token: 0x06007A30 RID: 31280 RVA: 0x000E98F4 File Offset: 0x000E7AF4
		// (set) Token: 0x06007A31 RID: 31281 RVA: 0x000E9914 File Offset: 0x000E7B14
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

		// Token: 0x06007A32 RID: 31282 RVA: 0x000E9958 File Offset: 0x000E7B58
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007A33 RID: 31283 RVA: 0x000E9970 File Offset: 0x000E7B70
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170026BA RID: 9914
		// (get) Token: 0x06007A34 RID: 31284 RVA: 0x000E997C File Offset: 0x000E7B7C
		// (set) Token: 0x06007A35 RID: 31285 RVA: 0x000E999D File Offset: 0x000E7B9D
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170026BB RID: 9915
		// (get) Token: 0x06007A36 RID: 31286 RVA: 0x000E99A8 File Offset: 0x000E7BA8
		// (set) Token: 0x06007A37 RID: 31287 RVA: 0x000E99C4 File Offset: 0x000E7BC4
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007A38 RID: 31288 RVA: 0x000E99F4 File Offset: 0x000E7BF4
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007A39 RID: 31289 RVA: 0x000E9A0C File Offset: 0x000E7C0C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170026BC RID: 9916
		// (get) Token: 0x06007A3A RID: 31290 RVA: 0x000E9A18 File Offset: 0x000E7C18
		// (set) Token: 0x06007A3B RID: 31291 RVA: 0x000E9A44 File Offset: 0x000E7C44
		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x170026BD RID: 9917
		// (get) Token: 0x06007A3C RID: 31292 RVA: 0x000E9A54 File Offset: 0x000E7C54
		// (set) Token: 0x06007A3D RID: 31293 RVA: 0x000E9A74 File Offset: 0x000E7C74
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06007A3E RID: 31294 RVA: 0x000E9AB8 File Offset: 0x000E7CB8
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06007A3F RID: 31295 RVA: 0x000E9AD0 File Offset: 0x000E7CD0
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x170026BE RID: 9918
		// (get) Token: 0x06007A40 RID: 31296 RVA: 0x000E9ADC File Offset: 0x000E7CDC
		// (set) Token: 0x06007A41 RID: 31297 RVA: 0x000E9B08 File Offset: 0x000E7D08
		[ProtoMember(4, IsRequired = false, Name = "rewardcd", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcd
		{
			get
			{
				return this._rewardcd ?? 0U;
			}
			set
			{
				this._rewardcd = new uint?(value);
			}
		}

		// Token: 0x170026BF RID: 9919
		// (get) Token: 0x06007A42 RID: 31298 RVA: 0x000E9B18 File Offset: 0x000E7D18
		// (set) Token: 0x06007A43 RID: 31299 RVA: 0x000E9B38 File Offset: 0x000E7D38
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcdSpecified
		{
			get
			{
				return this._rewardcd != null;
			}
			set
			{
				bool flag = value == (this._rewardcd == null);
				if (flag)
				{
					this._rewardcd = (value ? new uint?(this.rewardcd) : null);
				}
			}
		}

		// Token: 0x06007A44 RID: 31300 RVA: 0x000E9B7C File Offset: 0x000E7D7C
		private bool ShouldSerializerewardcd()
		{
			return this.rewardcdSpecified;
		}

		// Token: 0x06007A45 RID: 31301 RVA: 0x000E9B94 File Offset: 0x000E7D94
		private void Resetrewardcd()
		{
			this.rewardcdSpecified = false;
		}

		// Token: 0x170026C0 RID: 9920
		// (get) Token: 0x06007A46 RID: 31302 RVA: 0x000E9BA0 File Offset: 0x000E7DA0
		// (set) Token: 0x06007A47 RID: 31303 RVA: 0x000E9BCC File Offset: 0x000E7DCC
		[ProtoMember(5, IsRequired = false, Name = "istakenreward", DataFormat = DataFormat.Default)]
		public bool istakenreward
		{
			get
			{
				return this._istakenreward ?? false;
			}
			set
			{
				this._istakenreward = new bool?(value);
			}
		}

		// Token: 0x170026C1 RID: 9921
		// (get) Token: 0x06007A48 RID: 31304 RVA: 0x000E9BDC File Offset: 0x000E7DDC
		// (set) Token: 0x06007A49 RID: 31305 RVA: 0x000E9BFC File Offset: 0x000E7DFC
		[XmlIgnore]
		[Browsable(false)]
		public bool istakenrewardSpecified
		{
			get
			{
				return this._istakenreward != null;
			}
			set
			{
				bool flag = value == (this._istakenreward == null);
				if (flag)
				{
					this._istakenreward = (value ? new bool?(this.istakenreward) : null);
				}
			}
		}

		// Token: 0x06007A4A RID: 31306 RVA: 0x000E9C40 File Offset: 0x000E7E40
		private bool ShouldSerializeistakenreward()
		{
			return this.istakenrewardSpecified;
		}

		// Token: 0x06007A4B RID: 31307 RVA: 0x000E9C58 File Offset: 0x000E7E58
		private void Resetistakenreward()
		{
			this.istakenrewardSpecified = false;
		}

		// Token: 0x170026C2 RID: 9922
		// (get) Token: 0x06007A4C RID: 31308 RVA: 0x000E9C64 File Offset: 0x000E7E64
		// (set) Token: 0x06007A4D RID: 31309 RVA: 0x000E9C90 File Offset: 0x000E7E90
		[ProtoMember(6, IsRequired = false, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public uint timestamp
		{
			get
			{
				return this._timestamp ?? 0U;
			}
			set
			{
				this._timestamp = new uint?(value);
			}
		}

		// Token: 0x170026C3 RID: 9923
		// (get) Token: 0x06007A4E RID: 31310 RVA: 0x000E9CA0 File Offset: 0x000E7EA0
		// (set) Token: 0x06007A4F RID: 31311 RVA: 0x000E9CC0 File Offset: 0x000E7EC0
		[XmlIgnore]
		[Browsable(false)]
		public bool timestampSpecified
		{
			get
			{
				return this._timestamp != null;
			}
			set
			{
				bool flag = value == (this._timestamp == null);
				if (flag)
				{
					this._timestamp = (value ? new uint?(this.timestamp) : null);
				}
			}
		}

		// Token: 0x06007A50 RID: 31312 RVA: 0x000E9D04 File Offset: 0x000E7F04
		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		// Token: 0x06007A51 RID: 31313 RVA: 0x000E9D1C File Offset: 0x000E7F1C
		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

		// Token: 0x06007A52 RID: 31314 RVA: 0x000E9D28 File Offset: 0x000E7F28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CDE RID: 7390
		private ulong? _roleid;

		// Token: 0x04001CDF RID: 7391
		private string _name;

		// Token: 0x04001CE0 RID: 7392
		private uint? _point;

		// Token: 0x04001CE1 RID: 7393
		private uint? _rewardcd;

		// Token: 0x04001CE2 RID: 7394
		private bool? _istakenreward;

		// Token: 0x04001CE3 RID: 7395
		private uint? _timestamp;

		// Token: 0x04001CE4 RID: 7396
		private IExtension extensionObject;
	}
}
