using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlatformShareAwardPara")]
	[Serializable]
	public class PlatformShareAwardPara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "share_scene_id", DataFormat = DataFormat.TwosComplement)]
		public uint share_scene_id
		{
			get
			{
				return this._share_scene_id ?? 0U;
			}
			set
			{
				this._share_scene_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool share_scene_idSpecified
		{
			get
			{
				return this._share_scene_id != null;
			}
			set
			{
				bool flag = value == (this._share_scene_id == null);
				if (flag)
				{
					this._share_scene_id = (value ? new uint?(this.share_scene_id) : null);
				}
			}
		}

		private bool ShouldSerializeshare_scene_id()
		{
			return this.share_scene_idSpecified;
		}

		private void Resetshare_scene_id()
		{
			this.share_scene_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "weekly_share_number", DataFormat = DataFormat.TwosComplement)]
		public uint weekly_share_number
		{
			get
			{
				return this._weekly_share_number ?? 0U;
			}
			set
			{
				this._weekly_share_number = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_share_numberSpecified
		{
			get
			{
				return this._weekly_share_number != null;
			}
			set
			{
				bool flag = value == (this._weekly_share_number == null);
				if (flag)
				{
					this._weekly_share_number = (value ? new uint?(this.weekly_share_number) : null);
				}
			}
		}

		private bool ShouldSerializeweekly_share_number()
		{
			return this.weekly_share_numberSpecified;
		}

		private void Resetweekly_share_number()
		{
			this.weekly_share_numberSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "weekly_award", DataFormat = DataFormat.Default)]
		public bool weekly_award
		{
			get
			{
				return this._weekly_award ?? false;
			}
			set
			{
				this._weekly_award = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_awardSpecified
		{
			get
			{
				return this._weekly_award != null;
			}
			set
			{
				bool flag = value == (this._weekly_award == null);
				if (flag)
				{
					this._weekly_award = (value ? new bool?(this.weekly_award) : null);
				}
			}
		}

		private bool ShouldSerializeweekly_award()
		{
			return this.weekly_awardSpecified;
		}

		private void Resetweekly_award()
		{
			this.weekly_awardSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "disappear_redpoint", DataFormat = DataFormat.Default)]
		public bool disappear_redpoint
		{
			get
			{
				return this._disappear_redpoint ?? false;
			}
			set
			{
				this._disappear_redpoint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool disappear_redpointSpecified
		{
			get
			{
				return this._disappear_redpoint != null;
			}
			set
			{
				bool flag = value == (this._disappear_redpoint == null);
				if (flag)
				{
					this._disappear_redpoint = (value ? new bool?(this.disappear_redpoint) : null);
				}
			}
		}

		private bool ShouldSerializedisappear_redpoint()
		{
			return this.disappear_redpointSpecified;
		}

		private void Resetdisappear_redpoint()
		{
			this.disappear_redpointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _share_scene_id;

		private uint? _weekly_share_number;

		private bool? _weekly_award;

		private bool? _disappear_redpoint;

		private IExtension extensionObject;
	}
}
