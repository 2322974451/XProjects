using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillReplyDataUnit")]
	[Serializable]
	public class SkillReplyDataUnit : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "PIndex", DataFormat = DataFormat.TwosComplement)]
		public uint PIndex
		{
			get
			{
				return this._PIndex ?? 0U;
			}
			set
			{
				this._PIndex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool PIndexSpecified
		{
			get
			{
				return this._PIndex != null;
			}
			set
			{
				bool flag = value == (this._PIndex == null);
				if (flag)
				{
					this._PIndex = (value ? new uint?(this.PIndex) : null);
				}
			}
		}

		private bool ShouldSerializePIndex()
		{
			return this.PIndexSpecified;
		}

		private void ResetPIndex()
		{
			this.PIndexSpecified = false;
		}

		[ProtoMember(3, Name = "TargetList", DataFormat = DataFormat.Default)]
		public List<TargetHurtInfo> TargetList
		{
			get
			{
				return this._TargetList;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "FirerID", DataFormat = DataFormat.TwosComplement)]
		public ulong FirerID
		{
			get
			{
				return this._FirerID ?? 0UL;
			}
			set
			{
				this._FirerID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool FirerIDSpecified
		{
			get
			{
				return this._FirerID != null;
			}
			set
			{
				bool flag = value == (this._FirerID == null);
				if (flag)
				{
					this._FirerID = (value ? new ulong?(this.FirerID) : null);
				}
			}
		}

		private bool ShouldSerializeFirerID()
		{
			return this.FirerIDSpecified;
		}

		private void ResetFirerID()
		{
			this.FirerIDSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "BulletID", DataFormat = DataFormat.TwosComplement)]
		public ulong BulletID
		{
			get
			{
				return this._BulletID ?? 0UL;
			}
			set
			{
				this._BulletID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BulletIDSpecified
		{
			get
			{
				return this._BulletID != null;
			}
			set
			{
				bool flag = value == (this._BulletID == null);
				if (flag)
				{
					this._BulletID = (value ? new ulong?(this.BulletID) : null);
				}
			}
		}

		private bool ShouldSerializeBulletID()
		{
			return this.BulletIDSpecified;
		}

		private void ResetBulletID()
		{
			this.BulletIDSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "BulletExtraID", DataFormat = DataFormat.TwosComplement)]
		public ulong BulletExtraID
		{
			get
			{
				return this._BulletExtraID ?? 0UL;
			}
			set
			{
				this._BulletExtraID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BulletExtraIDSpecified
		{
			get
			{
				return this._BulletExtraID != null;
			}
			set
			{
				bool flag = value == (this._BulletExtraID == null);
				if (flag)
				{
					this._BulletExtraID = (value ? new ulong?(this.BulletExtraID) : null);
				}
			}
		}

		private bool ShouldSerializeBulletExtraID()
		{
			return this.BulletExtraIDSpecified;
		}

		private void ResetBulletExtraID()
		{
			this.BulletExtraIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SkillID;

		private uint? _PIndex;

		private readonly List<TargetHurtInfo> _TargetList = new List<TargetHurtInfo>();

		private ulong? _FirerID;

		private ulong? _BulletID;

		private ulong? _BulletExtraID;

		private IExtension extensionObject;
	}
}
