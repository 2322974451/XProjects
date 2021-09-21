using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E2 RID: 226
	[ProtoContract(Name = "SkillBulletResultReqUnit")]
	[Serializable]
	public class SkillBulletResultReqUnit : IExtensible
	{
		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x0001E460 File Offset: 0x0001C660
		// (set) Token: 0x06000E9D RID: 3741 RVA: 0x0001E48D File Offset: 0x0001C68D
		[ProtoMember(1, IsRequired = false, Name = "BulletId", DataFormat = DataFormat.TwosComplement)]
		public ulong BulletId
		{
			get
			{
				return this._BulletId ?? 0UL;
			}
			set
			{
				this._BulletId = new ulong?(value);
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x0001E49C File Offset: 0x0001C69C
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x0001E4BC File Offset: 0x0001C6BC
		[XmlIgnore]
		[Browsable(false)]
		public bool BulletIdSpecified
		{
			get
			{
				return this._BulletId != null;
			}
			set
			{
				bool flag = value == (this._BulletId == null);
				if (flag)
				{
					this._BulletId = (value ? new ulong?(this.BulletId) : null);
				}
			}
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x0001E500 File Offset: 0x0001C700
		private bool ShouldSerializeBulletId()
		{
			return this.BulletIdSpecified;
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x0001E518 File Offset: 0x0001C718
		private void ResetBulletId()
		{
			this.BulletIdSpecified = false;
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x0001E524 File Offset: 0x0001C724
		// (set) Token: 0x06000EA3 RID: 3747 RVA: 0x0001E53C File Offset: 0x0001C73C
		[ProtoMember(2, IsRequired = false, Name = "ResultAt", DataFormat = DataFormat.Default)]
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

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x0001E548 File Offset: 0x0001C748
		// (set) Token: 0x06000EA5 RID: 3749 RVA: 0x0001E578 File Offset: 0x0001C778
		[ProtoMember(3, IsRequired = false, Name = "ResultForward", DataFormat = DataFormat.FixedSize)]
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

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0001E588 File Offset: 0x0001C788
		// (set) Token: 0x06000EA7 RID: 3751 RVA: 0x0001E5A8 File Offset: 0x0001C7A8
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

		// Token: 0x06000EA8 RID: 3752 RVA: 0x0001E5EC File Offset: 0x0001C7EC
		private bool ShouldSerializeResultForward()
		{
			return this.ResultForwardSpecified;
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x0001E604 File Offset: 0x0001C804
		private void ResetResultForward()
		{
			this.ResultForwardSpecified = false;
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x0001E610 File Offset: 0x0001C810
		[ProtoMember(4, Name = "TargetList", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> TargetList
		{
			get
			{
				return this._TargetList;
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x0001E628 File Offset: 0x0001C828
		// (set) Token: 0x06000EAC RID: 3756 RVA: 0x0001E654 File Offset: 0x0001C854
		[ProtoMember(5, IsRequired = false, Name = "IsCollided", DataFormat = DataFormat.Default)]
		public bool IsCollided
		{
			get
			{
				return this._IsCollided ?? false;
			}
			set
			{
				this._IsCollided = new bool?(value);
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000EAD RID: 3757 RVA: 0x0001E664 File Offset: 0x0001C864
		// (set) Token: 0x06000EAE RID: 3758 RVA: 0x0001E684 File Offset: 0x0001C884
		[XmlIgnore]
		[Browsable(false)]
		public bool IsCollidedSpecified
		{
			get
			{
				return this._IsCollided != null;
			}
			set
			{
				bool flag = value == (this._IsCollided == null);
				if (flag)
				{
					this._IsCollided = (value ? new bool?(this.IsCollided) : null);
				}
			}
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x0001E6C8 File Offset: 0x0001C8C8
		private bool ShouldSerializeIsCollided()
		{
			return this.IsCollidedSpecified;
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x0001E6E0 File Offset: 0x0001C8E0
		private void ResetIsCollided()
		{
			this.IsCollidedSpecified = false;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x0001E6EC File Offset: 0x0001C8EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003A9 RID: 937
		private ulong? _BulletId;

		// Token: 0x040003AA RID: 938
		private Vec3 _ResultAt = null;

		// Token: 0x040003AB RID: 939
		private float? _ResultForward;

		// Token: 0x040003AC RID: 940
		private readonly List<ulong> _TargetList = new List<ulong>();

		// Token: 0x040003AD RID: 941
		private bool? _IsCollided;

		// Token: 0x040003AE RID: 942
		private IExtension extensionObject;
	}
}
