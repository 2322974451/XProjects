using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E1 RID: 225
	[ProtoContract(Name = "BulletUnitData")]
	[Serializable]
	public class BulletUnitData : IExtensible
	{
		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000E6E RID: 3694 RVA: 0x0001DEA0 File Offset: 0x0001C0A0
		// (set) Token: 0x06000E6F RID: 3695 RVA: 0x0001DECC File Offset: 0x0001C0CC
		[ProtoMember(1, IsRequired = false, Name = "SkillId", DataFormat = DataFormat.TwosComplement)]
		public uint SkillId
		{
			get
			{
				return this._SkillId ?? 0U;
			}
			set
			{
				this._SkillId = new uint?(value);
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x0001DEDC File Offset: 0x0001C0DC
		// (set) Token: 0x06000E71 RID: 3697 RVA: 0x0001DEFC File Offset: 0x0001C0FC
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIdSpecified
		{
			get
			{
				return this._SkillId != null;
			}
			set
			{
				bool flag = value == (this._SkillId == null);
				if (flag)
				{
					this._SkillId = (value ? new uint?(this.SkillId) : null);
				}
			}
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x0001DF40 File Offset: 0x0001C140
		private bool ShouldSerializeSkillId()
		{
			return this.SkillIdSpecified;
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x0001DF58 File Offset: 0x0001C158
		private void ResetSkillId()
		{
			this.SkillIdSpecified = false;
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x0001DF64 File Offset: 0x0001C164
		// (set) Token: 0x06000E75 RID: 3701 RVA: 0x0001DF90 File Offset: 0x0001C190
		[ProtoMember(2, IsRequired = false, Name = "TriggerTime", DataFormat = DataFormat.TwosComplement)]
		public int TriggerTime
		{
			get
			{
				return this._TriggerTime ?? 0;
			}
			set
			{
				this._TriggerTime = new int?(value);
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x0001DFA0 File Offset: 0x0001C1A0
		// (set) Token: 0x06000E77 RID: 3703 RVA: 0x0001DFC0 File Offset: 0x0001C1C0
		[XmlIgnore]
		[Browsable(false)]
		public bool TriggerTimeSpecified
		{
			get
			{
				return this._TriggerTime != null;
			}
			set
			{
				bool flag = value == (this._TriggerTime == null);
				if (flag)
				{
					this._TriggerTime = (value ? new int?(this.TriggerTime) : null);
				}
			}
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x0001E004 File Offset: 0x0001C204
		private bool ShouldSerializeTriggerTime()
		{
			return this.TriggerTimeSpecified;
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x0001E01C File Offset: 0x0001C21C
		private void ResetTriggerTime()
		{
			this.TriggerTimeSpecified = false;
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x0001E028 File Offset: 0x0001C228
		// (set) Token: 0x06000E7B RID: 3707 RVA: 0x0001E054 File Offset: 0x0001C254
		[ProtoMember(3, IsRequired = false, Name = "ResultToken", DataFormat = DataFormat.TwosComplement)]
		public int ResultToken
		{
			get
			{
				return this._ResultToken ?? 0;
			}
			set
			{
				this._ResultToken = new int?(value);
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x0001E064 File Offset: 0x0001C264
		// (set) Token: 0x06000E7D RID: 3709 RVA: 0x0001E084 File Offset: 0x0001C284
		[XmlIgnore]
		[Browsable(false)]
		public bool ResultTokenSpecified
		{
			get
			{
				return this._ResultToken != null;
			}
			set
			{
				bool flag = value == (this._ResultToken == null);
				if (flag)
				{
					this._ResultToken = (value ? new int?(this.ResultToken) : null);
				}
			}
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x0001E0C8 File Offset: 0x0001C2C8
		private bool ShouldSerializeResultToken()
		{
			return this.ResultTokenSpecified;
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x0001E0E0 File Offset: 0x0001C2E0
		private void ResetResultToken()
		{
			this.ResultTokenSpecified = false;
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x0001E0EC File Offset: 0x0001C2EC
		// (set) Token: 0x06000E81 RID: 3713 RVA: 0x0001E104 File Offset: 0x0001C304
		[ProtoMember(4, IsRequired = false, Name = "Pos", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 Pos
		{
			get
			{
				return this._Pos;
			}
			set
			{
				this._Pos = value;
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x0001E110 File Offset: 0x0001C310
		// (set) Token: 0x06000E83 RID: 3715 RVA: 0x0001E140 File Offset: 0x0001C340
		[ProtoMember(5, IsRequired = false, Name = "Face", DataFormat = DataFormat.FixedSize)]
		public float Face
		{
			get
			{
				return this._Face ?? 0f;
			}
			set
			{
				this._Face = new float?(value);
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000E84 RID: 3716 RVA: 0x0001E150 File Offset: 0x0001C350
		// (set) Token: 0x06000E85 RID: 3717 RVA: 0x0001E170 File Offset: 0x0001C370
		[XmlIgnore]
		[Browsable(false)]
		public bool FaceSpecified
		{
			get
			{
				return this._Face != null;
			}
			set
			{
				bool flag = value == (this._Face == null);
				if (flag)
				{
					this._Face = (value ? new float?(this.Face) : null);
				}
			}
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x0001E1B4 File Offset: 0x0001C3B4
		private bool ShouldSerializeFace()
		{
			return this.FaceSpecified;
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x0001E1CC File Offset: 0x0001C3CC
		private void ResetFace()
		{
			this.FaceSpecified = false;
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06000E88 RID: 3720 RVA: 0x0001E1D8 File Offset: 0x0001C3D8
		// (set) Token: 0x06000E89 RID: 3721 RVA: 0x0001E204 File Offset: 0x0001C404
		[ProtoMember(6, IsRequired = false, Name = "AdditionalDegree", DataFormat = DataFormat.TwosComplement)]
		public int AdditionalDegree
		{
			get
			{
				return this._AdditionalDegree ?? 0;
			}
			set
			{
				this._AdditionalDegree = new int?(value);
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x0001E214 File Offset: 0x0001C414
		// (set) Token: 0x06000E8B RID: 3723 RVA: 0x0001E234 File Offset: 0x0001C434
		[XmlIgnore]
		[Browsable(false)]
		public bool AdditionalDegreeSpecified
		{
			get
			{
				return this._AdditionalDegree != null;
			}
			set
			{
				bool flag = value == (this._AdditionalDegree == null);
				if (flag)
				{
					this._AdditionalDegree = (value ? new int?(this.AdditionalDegree) : null);
				}
			}
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x0001E278 File Offset: 0x0001C478
		private bool ShouldSerializeAdditionalDegree()
		{
			return this.AdditionalDegreeSpecified;
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x0001E290 File Offset: 0x0001C490
		private void ResetAdditionalDegree()
		{
			this.AdditionalDegreeSpecified = false;
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x0001E29C File Offset: 0x0001C49C
		// (set) Token: 0x06000E8F RID: 3727 RVA: 0x0001E2C9 File Offset: 0x0001C4C9
		[ProtoMember(7, IsRequired = false, Name = "BulletToken", DataFormat = DataFormat.TwosComplement)]
		public ulong BulletToken
		{
			get
			{
				return this._BulletToken ?? 0UL;
			}
			set
			{
				this._BulletToken = new ulong?(value);
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x0001E2D8 File Offset: 0x0001C4D8
		// (set) Token: 0x06000E91 RID: 3729 RVA: 0x0001E2F8 File Offset: 0x0001C4F8
		[XmlIgnore]
		[Browsable(false)]
		public bool BulletTokenSpecified
		{
			get
			{
				return this._BulletToken != null;
			}
			set
			{
				bool flag = value == (this._BulletToken == null);
				if (flag)
				{
					this._BulletToken = (value ? new ulong?(this.BulletToken) : null);
				}
			}
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x0001E33C File Offset: 0x0001C53C
		private bool ShouldSerializeBulletToken()
		{
			return this.BulletTokenSpecified;
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x0001E354 File Offset: 0x0001C554
		private void ResetBulletToken()
		{
			this.BulletTokenSpecified = false;
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x0001E360 File Offset: 0x0001C560
		// (set) Token: 0x06000E95 RID: 3733 RVA: 0x0001E38D File Offset: 0x0001C58D
		[ProtoMember(8, IsRequired = false, Name = "Target", DataFormat = DataFormat.TwosComplement)]
		public ulong Target
		{
			get
			{
				return this._Target ?? 0UL;
			}
			set
			{
				this._Target = new ulong?(value);
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000E96 RID: 3734 RVA: 0x0001E39C File Offset: 0x0001C59C
		// (set) Token: 0x06000E97 RID: 3735 RVA: 0x0001E3BC File Offset: 0x0001C5BC
		[XmlIgnore]
		[Browsable(false)]
		public bool TargetSpecified
		{
			get
			{
				return this._Target != null;
			}
			set
			{
				bool flag = value == (this._Target == null);
				if (flag)
				{
					this._Target = (value ? new ulong?(this.Target) : null);
				}
			}
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x0001E400 File Offset: 0x0001C600
		private bool ShouldSerializeTarget()
		{
			return this.TargetSpecified;
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x0001E418 File Offset: 0x0001C618
		private void ResetTarget()
		{
			this.TargetSpecified = false;
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x0001E424 File Offset: 0x0001C624
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003A0 RID: 928
		private uint? _SkillId;

		// Token: 0x040003A1 RID: 929
		private int? _TriggerTime;

		// Token: 0x040003A2 RID: 930
		private int? _ResultToken;

		// Token: 0x040003A3 RID: 931
		private Vec3 _Pos = null;

		// Token: 0x040003A4 RID: 932
		private float? _Face;

		// Token: 0x040003A5 RID: 933
		private int? _AdditionalDegree;

		// Token: 0x040003A6 RID: 934
		private ulong? _BulletToken;

		// Token: 0x040003A7 RID: 935
		private ulong? _Target;

		// Token: 0x040003A8 RID: 936
		private IExtension extensionObject;
	}
}
