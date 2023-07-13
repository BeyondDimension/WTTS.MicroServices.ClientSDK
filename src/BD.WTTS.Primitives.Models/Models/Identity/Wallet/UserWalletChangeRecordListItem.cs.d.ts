declare module server {
	interface userWalletChangeRecordListItem {
		/** 变更类型 */
		type: any;
		/** 变更原因 */
		reason: string;
		/** 支付方向 */
		paymentDirection: any;
		/** 变更值 */
		value: number;
		/** 账号余额 */
		accountBalance: number;
		remarks: string;
		/** 变更时间 */
		creationTime: Date;
	}
}
