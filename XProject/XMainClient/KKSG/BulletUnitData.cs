using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BulletUnitData")]
	[Serializable]
	public class BulletUnitData : IExtensible
	{

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

		private bool ShouldSerializeSkillId()
		{
			return this.SkillIdSpecified;
		}

		private void ResetSkillId()
		{
			this.SkillIdSpecified = false;
		}

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

		private bool ShouldSerializeTriggerTime()
		{
			return this.TriggerTimeSpecified;
		}

		private void ResetTriggerTime()
		{
			this.TriggerTimeSpecified = false;
		}

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

		private bool ShouldSerializeResultToken()
		{
			return this.ResultTokenSpecified;
		}

		private void ResetResultToken()
		{
			this.ResultTokenSpecified = false;
		}

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

		private bool ShouldSerializeFace()
		{
			return this.FaceSpecified;
		}

		private void ResetFace()
		{
			this.FaceSpecified = false;
		}

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

		private bool ShouldSerializeAdditionalDegree()
		{
			return this.AdditionalDegreeSpecified;
		}

		private void ResetAdditionalDegree()
		{
			this.AdditionalDegreeSpecified = false;
		}

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

		private bool ShouldSerializeBulletToken()
		{
			return this.BulletTokenSpecified;
		}

		private void ResetBulletToken()
		{
			this.BulletTokenSpecified = false;
		}

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

		private bool ShouldSerializeTarget()
		{
			return this.TargetSpecified;
		}

		private void ResetTarget()
		{
			this.TargetSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SkillId;

		private int? _TriggerTime;

		private int? _ResultToken;

		private Vec3 _Pos = null;

		private float? _Face;

		private int? _AdditionalDegree;

		private ulong? _BulletToken;

		private ulong? _Target;

		private IExtension extensionObject;
	}
}
