package md5c71bd3ede1cc5b61e4a263b3f1f671c6;


public class AuthenticationScreen
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
		mono.android.Runtime.register ("TipperKit.AuthenticationScreen, TipperKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AuthenticationScreen.class, __md_methods);
	}


	public AuthenticationScreen ()
	{
		super ();
		if (getClass () == AuthenticationScreen.class)
			mono.android.TypeManager.Activate ("TipperKit.AuthenticationScreen, TipperKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
