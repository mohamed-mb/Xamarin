package md55d545f2b25f5efc7bcda408f2fb94909;


public class TransactionHistoryActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("SMS_Test.TransactionHistoryActivity, SMS_Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TransactionHistoryActivity.class, __md_methods);
	}


	public TransactionHistoryActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TransactionHistoryActivity.class)
			mono.android.TypeManager.Activate ("SMS_Test.TransactionHistoryActivity, SMS_Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
