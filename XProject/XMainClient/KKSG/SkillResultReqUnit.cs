using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillResultReqUnit")]
	[Serializable]
	public class SkillResultReqUnit : IExtensible
	{

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

		private bool ShouldSerializeSkillID()
		{
			return this.SkillIDSpecified;
		}

		private void ResetSkillID()
		{
			this.SkillIDSpecified = false;
		}

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

		[ProtoMember(8, Name = "TargetList", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> TargetList
		{
			get
			{
				return this._TargetList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SkillID;

		private Vec3 _Pos = null;

		private float? _Face;

		private int? _TriggerTime;

		private int? _ResultToken;

		private Vec3 _ResultAt = null;

		private float? _ResultForward;

		private readonly List<ulong> _TargetList = new List<ulong>();

		private IExtension extensionObject;
	}
}
