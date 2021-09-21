using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000DD RID: 221
	[ProtoContract(Name = "SkillResultReqUnit")]
	[Serializable]
	public class SkillResultReqUnit : IExtensible
	{
		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000E1E RID: 3614 RVA: 0x0001D510 File Offset: 0x0001B710
		// (set) Token: 0x06000E1F RID: 3615 RVA: 0x0001D53C File Offset: 0x0001B73C
		[ProtoMember(1, IsRequired = false, Name = "SkillID", DataFormat = DataFormat.TwosComplement)]
		public uint SkillID
		{
			get
			{
				return this._SkillID ?? 0U;
			}
			set
			{
				this._SkillID = new uint?(value);
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000E20 RID: 3616 RVA: 0x0001D54C File Offset: 0x0001B74C
		// (set) Token: 0x06000E21 RID: 3617 RVA: 0x0001D56C File Offset: 0x0001B76C
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIDSpecified
		{
			get
			{
				return this._SkillID != null;
			}
			set
			{
				bool flag = value == (this._SkillID == null);
				if (flag)
				{
					this._SkillID = (value ? new uint?(this.SkillID) : null);
				}
			}
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x0001D5B0 File Offset: 0x0001B7B0
		private bool ShouldSerializeSkillID()
		{
			return this.SkillIDSpecified;
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x0001D5C8 File Offset: 0x0001B7C8
		private void ResetSkillID()
		{
			this.SkillIDSpecified = false;
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x0001D5D4 File Offset: 0x0001B7D4
		// (set) Token: 0x06000E25 RID: 3621 RVA: 0x0001D5EC File Offset: 0x0001B7EC
		[ProtoMember(2, IsRequired = false, Name = "Pos", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000E26 RID: 3622 RVA: 0x0001D5F8 File Offset: 0x0001B7F8
		// (set) Token: 0x06000E27 RID: 3623 RVA: 0x0001D628 File Offset: 0x0001B828
		[ProtoMember(3, IsRequired = false, Name = "Face", DataFormat = DataFormat.FixedSize)]
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

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000E28 RID: 3624 RVA: 0x0001D638 File Offset: 0x0001B838
		// (set) Token: 0x06000E29 RID: 3625 RVA: 0x0001D658 File Offset: 0x0001B858
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

		// Token: 0x06000E2A RID: 3626 RVA: 0x0001D69C File Offset: 0x0001B89C
		private bool ShouldSerializeFace()
		{
			return this.FaceSpecified;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x0001D6B4 File Offset: 0x0001B8B4
		private void ResetFace()
		{
			this.FaceSpecified = false;
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000E2C RID: 3628 RVA: 0x0001D6C0 File Offset: 0x0001B8C0
		// (set) Token: 0x06000E2D RID: 3629 RVA: 0x0001D6EC File Offset: 0x0001B8EC
		[ProtoMember(4, IsRequired = false, Name = "TriggerTime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000E2E RID: 3630 RVA: 0x0001D6FC File Offset: 0x0001B8FC
		// (set) Token: 0x06000E2F RID: 3631 RVA: 0x0001D71C File Offset: 0x0001B91C
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

		// Token: 0x06000E30 RID: 3632 RVA: 0x0001D760 File Offset: 0x0001B960
		private bool ShouldSerializeTriggerTime()
		{
			return this.TriggerTimeSpecified;
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x0001D778 File Offset: 0x0001B978
		private void ResetTriggerTime()
		{
			this.TriggerTimeSpecified = false;
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000E32 RID: 3634 RVA: 0x0001D784 File Offset: 0x0001B984
		// (set) Token: 0x06000E33 RID: 3635 RVA: 0x0001D7B0 File Offset: 0x0001B9B0
		[ProtoMember(5, IsRequired = false, Name = "ResultToken", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x0001D7C0 File Offset: 0x0001B9C0
		// (set) Token: 0x06000E35 RID: 3637 RVA: 0x0001D7E0 File Offset: 0x0001B9E0
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

		// Token: 0x06000E36 RID: 3638 RVA: 0x0001D824 File Offset: 0x0001BA24
		private bool ShouldSerializeResultToken()
		{
			return this.ResultTokenSpecified;
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x0001D83C File Offset: 0x0001BA3C
		private void ResetResultToken()
		{
			this.ResultTokenSpecified = false;
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000E38 RID: 3640 RVA: 0x0001D848 File Offset: 0x0001BA48
		// (set) Token: 0x06000E39 RID: 3641 RVA: 0x0001D860 File Offset: 0x0001BA60
		[ProtoMember(6, IsRequired = false, Name = "ResultAt", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 ResultAt
		{
			get
			{
				return this._ResultAt;
			}
			set
			{
				this._ResultAt = value;
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000E3A RID: 3642 RVA: 0x0001D86C File Offset: 0x0001BA6C
		// (set) Token: 0x06000E3B RID: 3643 RVA: 0x0001D89C File Offset: 0x0001BA9C
		[ProtoMember(7, IsRequired = false, Name = "ResultForward", DataFormat = DataFormat.FixedSize)]
		public float ResultForward
		{
			get
			{
				return this._ResultForward ?? 0f;
			}
			set
			{
				this._ResultForward = new float?(value);
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000E3C RID: 3644 RVA: 0x0001D8AC File Offset: 0x0001BAAC
		// (set) Token: 0x06000E3D RID: 3645 RVA: 0x0001D8CC File Offset: 0x0001BACC
		[XmlIgnore]
		[Browsable(false)]
		public bool ResultForwardSpecified
		{
			get
			{
				return this._ResultForward != null;
			}
			set
			{
				bool flag = value == (this._ResultForward == null);
				if (flag)
				{
					this._ResultForward = (value ? new float?(this.ResultForward) : null);
				}
			}
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x0001D910 File Offset: 0x0001BB10
		private bool ShouldSerializeResultForward()
		{
			return this.ResultForwardSpecified;
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x0001D928 File Offset: 0x0001BB28
		private void ResetResultForward()
		{
			this.ResultForwardSpecified = false;
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x0001D934 File Offset: 0x0001BB34
		[ProtoMember(8, Name = "TargetList", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> TargetList
		{
			get
			{
				return this._TargetList;
			}
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x0001D94C File Offset: 0x0001BB4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400038D RID: 909
		private uint? _SkillID;

		// Token: 0x0400038E RID: 910
		private Vec3 _Pos = null;

		// Token: 0x0400038F RID: 911
		private float? _Face;

		// Token: 0x04000390 RID: 912
		private int? _TriggerTime;

		// Token: 0x04000391 RID: 913
		private int? _ResultToken;

		// Token: 0x04000392 RID: 914
		private Vec3 _ResultAt = null;

		// Token: 0x04000393 RID: 915
		private float? _ResultForward;

		// Token: 0x04000394 RID: 916
		private readonly List<ulong> _TargetList = new List<ulong>();

		// Token: 0x04000395 RID: 917
		private IExtension extensionObject;
	}
}
