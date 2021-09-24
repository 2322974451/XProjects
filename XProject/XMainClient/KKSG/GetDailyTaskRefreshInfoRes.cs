using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDailyTaskRefreshInfoRes")]
	[Serializable]
	public class GetDailyTaskRefreshInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "refresh_num", DataFormat = DataFormat.TwosComplement)]
		public uint refresh_num
		{
			get
			{
				return this._refresh_num ?? 0U;
			}
			set
			{
				this._refresh_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refresh_numSpecified
		{
			get
			{
				return this._refresh_num != null;
			}
			set
			{
				bool flag = value == (this._refresh_num == null);
				if (flag)
				{
					this._refresh_num = (value ? new uint?(this.refresh_num) : null);
				}
			}
		}

		private bool ShouldSerializerefresh_num()
		{
			return this.refresh_numSpecified;
		}

		private void Resetrefresh_num()
		{
			this.refresh_numSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "extra_refresh_num", DataFormat = DataFormat.TwosComplement)]
		public uint extra_refresh_num
		{
			get
			{
				return this._extra_refresh_num ?? 0U;
			}
			set
			{
				this._extra_refresh_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extra_refresh_numSpecified
		{
			get
			{
				return this._extra_refresh_num != null;
			}
			set
			{
				bool flag = value == (this._extra_refresh_num == null);
				if (flag)
				{
					this._extra_refresh_num = (value ? new uint?(this.extra_refresh_num) : null);
				}
			}
		}

		private bool ShouldSerializeextra_refresh_num()
		{
			return this.extra_refresh_numSpecified;
		}

		private void Resetextra_refresh_num()
		{
			this.extra_refresh_numSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "today_buy_num", DataFormat = DataFormat.TwosComplement)]
		public uint today_buy_num
		{
			get
			{
				return this._today_buy_num ?? 0U;
			}
			set
			{
				this._today_buy_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool today_buy_numSpecified
		{
			get
			{
				return this._today_buy_num != null;
			}
			set
			{
				bool flag = value == (this._today_buy_num == null);
				if (flag)
				{
					this._today_buy_num = (value ? new uint?(this.today_buy_num) : null);
				}
			}
		}

		private bool ShouldSerializetoday_buy_num()
		{
			return this.today_buy_numSpecified;
		}

		private void Resettoday_buy_num()
		{
			this.today_buy_numSpecified = false;
		}

		[ProtoMember(6, Name = "friendinfo", DataFormat = DataFormat.Default)]
		public List<DailyTaskRefreshRoleInfo> friendinfo
		{
			get
			{
				return this._friendinfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _luck;

		private uint? _refresh_num;

		private uint? _extra_refresh_num;

		private uint? _today_buy_num;

		private readonly List<DailyTaskRefreshRoleInfo> _friendinfo = new List<DailyTaskRefreshRoleInfo>();

		private IExtension extensionObject;
	}
}
