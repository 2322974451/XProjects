using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018E2 RID: 6370
	public class WelfareGrowthFundItem
	{
		// Token: 0x06010992 RID: 67986 RVA: 0x00417A64 File Offset: 0x00415C64
		public void Init(Transform tf)
		{
			this.m_transform = tf;
			this.m_getBtn = (tf.FindChild("Recharge").GetComponent("XUIButton") as IXUIButton);
			this.m_contentLabel = (tf.FindChild("Content").GetComponent("XUILabel") as IXUILabel);
			this.m_valueLabel = (tf.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_messageLabel = (tf.FindChild("Message").GetComponent("XUILabel") as IXUILabel);
			this.m_hasBuySprite = (tf.FindChild("HasBuy").GetComponent("XUISprite") as IXUISprite);
			this.m_getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGetHandler));
		}

		// Token: 0x06010993 RID: 67987 RVA: 0x00417B34 File Offset: 0x00415D34
		private bool OnClickGetHandler(IXUIButton btn)
		{
			bool flag = this.m_type == 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				specificDocument.GetGrowthFundAward(this.m_type, this.m_key);
				result = true;
			}
			return result;
		}

		// Token: 0x06010994 RID: 67988 RVA: 0x00417B78 File Offset: 0x00415D78
		public void Set(int type, int key, int value)
		{
			this.m_type = type;
			this.m_key = key;
			this.m_value = value;
			this.m_valueLabel.SetText(this.m_value.ToString());
			bool flag = this.m_type == 0;
			if (flag)
			{
				this.m_contentLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_CONTENT"));
			}
			else
			{
				this.m_contentLabel.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("WELFARE_GROWTHFUND_CONTENT", this.m_type.ToString()), new object[]
				{
					this.m_key
				}));
			}
		}

		// Token: 0x06010995 RID: 67989 RVA: 0x00417C1C File Offset: 0x00415E1C
		public void Refresh()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = !specificDocument.HasBuyGrowthFund;
			if (flag)
			{
				this.m_messageLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_ERROR"));
				this.m_getBtn.SetVisible(false);
				this.m_hasBuySprite.SetVisible(false);
			}
			else
			{
				bool flag2 = this.m_type == 0;
				if (flag2)
				{
					this.m_hasBuySprite.SetVisible(true);
					this.m_getBtn.SetVisible(false);
					this.m_messageLabel.SetText(string.Empty);
				}
				else
				{
					bool flag3 = specificDocument.HasGrowthFundGet(this.m_type, this.m_key);
					if (flag3)
					{
						this.m_hasBuySprite.SetVisible(true);
						this.m_messageLabel.SetText(string.Empty);
						this.m_getBtn.SetVisible(false);
					}
					else
					{
						this.m_hasBuySprite.SetVisible(false);
						bool flag4 = this.m_type == 1;
						if (flag4)
						{
							int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
							bool flag5 = level < this.m_key;
							if (flag5)
							{
								this.m_messageLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_MESSAGE1", new object[]
								{
									this.m_key - level
								}));
								this.m_getBtn.SetVisible(false);
							}
							else
							{
								this.m_messageLabel.SetText(string.Empty);
								this.m_getBtn.SetVisible(true);
							}
						}
						else
						{
							bool flag6 = this.m_type == 2;
							if (flag6)
							{
								int loginDayCount = specificDocument.LoginDayCount;
								bool flag7 = loginDayCount < this.m_key;
								if (flag7)
								{
									this.m_messageLabel.SetText(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_MESSAGE2", new object[]
									{
										this.m_key - loginDayCount
									}));
									this.m_getBtn.SetVisible(false);
								}
								else
								{
									this.m_messageLabel.SetText(string.Empty);
									this.m_getBtn.SetVisible(true);
								}
							}
							else
							{
								this.m_messageLabel.SetText(string.Empty);
								this.m_getBtn.SetVisible(false);
							}
						}
					}
				}
			}
		}

		// Token: 0x04007883 RID: 30851
		private Transform m_transform;

		// Token: 0x04007884 RID: 30852
		private IXUIButton m_getBtn;

		// Token: 0x04007885 RID: 30853
		private IXUILabel m_contentLabel;

		// Token: 0x04007886 RID: 30854
		private IXUILabel m_valueLabel;

		// Token: 0x04007887 RID: 30855
		private IXUILabel m_messageLabel;

		// Token: 0x04007888 RID: 30856
		private IXUISprite m_hasBuySprite;

		// Token: 0x04007889 RID: 30857
		private int m_type;

		// Token: 0x0400788A RID: 30858
		private int m_key;

		// Token: 0x0400788B RID: 30859
		private int m_value;
	}
}
