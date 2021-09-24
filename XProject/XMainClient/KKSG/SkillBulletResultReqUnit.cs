using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillBulletResultReqUnit")]
	[Serializable]
	public class SkillBulletResultReqUnit : IExtensible
	{

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

		private bool ShouldSerializeBulletId()
		{
			return this.BulletIdSpecified;
		}

		private void ResetBulletId()
		{
			this.BulletIdSpecified = false;
		}

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

		private bool ShouldSerializeResultForward()
		{
			return this.ResultForwardSpecified;
		}

		private void ResetResultForward()
		{
			this.ResultForwardSpecified = false;
		}

		[ProtoMember(4, Name = "TargetList", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> TargetList
		{
			get
			{
				return this._TargetList;
			}
		}

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

		private bool ShouldSerializeIsCollided()
		{
			return this.IsCollidedSpecified;
		}

		private void ResetIsCollided()
		{
			this.IsCollidedSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _BulletId;

		private Vec3 _ResultAt = null;

		private float? _ResultForward;

		private readonly List<ulong> _TargetList = new List<ulong>();

		private bool? _IsCollided;

		private IExtension extensionObject;
	}
}
