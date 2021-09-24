using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XHitData : XBaseData
	{

		public XHitData()
		{
			this.Fx_Follow = true;
			this.Additional_Using_Default = true;
		}

		[SerializeField]
		[DefaultValue(0f)]
		public float Time_Present_Straight;

		[SerializeField]
		[DefaultValue(0f)]
		public float Time_Hard_Straight;

		[SerializeField]
		[DefaultValue(0f)]
		public float Offset;

		[SerializeField]
		[DefaultValue(0f)]
		public float Height;

		[SerializeField]
		public XBeHitState State = XBeHitState.Hit_Back;

		[SerializeField]
		public XBeHitState_Animation State_Animation = XBeHitState_Animation.Hit_Back_Front;

		[SerializeField]
		[DefaultValue(0f)]
		public float Random_Range;

		[SerializeField]
		public string Fx = null;

		[SerializeField]
		[DefaultValue(true)]
		public bool Fx_Follow;

		[SerializeField]
		[DefaultValue(false)]
		public bool Fx_StickToGround;

		[SerializeField]
		[DefaultValue(false)]
		public bool CurveUsing;

		[SerializeField]
		[DefaultValue(false)]
		public bool FreezePresent;

		[SerializeField]
		[DefaultValue(0f)]
		public float FreezeDuration;

		[SerializeField]
		[DefaultValue(true)]
		public bool Additional_Using_Default;

		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Time_Present_Straight;

		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Time_Hard_Straight;

		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Offset;

		[SerializeField]
		[DefaultValue(0f)]
		public float Additional_Hit_Height;
	}
}
